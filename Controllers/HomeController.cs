using AspNetCore3._1Student.Models;
using AspNetCore3._1Student.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.Controllers
{
    public class HomeController : Controller
    {
        public readonly IStudentRepository _studentRepository;
        private readonly SqlDbContext _context;
        /// <summary>
        /// 依赖注入，解耦
        /// </summary>
        /// <param name="studentRepository"></param>
        public HomeController(IStudentRepository studentRepository,SqlDbContext context )
        {
            _studentRepository = studentRepository;
            _context = context;
        }
        /// <summary>
        /// 用户登录界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Admin() 
        {
            return View();
        }
        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Admin(AdminCreateViewModel model) 
        {
            
            
                var admin = new Admin
                {
                    AdminID = model.AdminID,
                    Password = model.Password
                };
                var models = _studentRepository.Login(admin);
            if (models != null)
            {
                if ((models.AdminID == admin.AdminID) && (models.Password == admin.Password))
                {
                    //保存登录数据到Session中，方便在其他页面调用。
                    HttpContext.Session.SetString("AdminID", models.AdminID);
                    ViewBag.Admin = "false";
                    return RedirectToAction("index");
                }
                else
                {
                    //判断登录状态，如果验证失败就返回提示账号密码的不正确
                    ViewBag.Admin = "true";
                }
            }
            else 
            {
                ViewBag.Admin = "true";
            }
                
            //如果没有找到用户或者用户账号密码不匹配，则重新加载页面并输出提示
            return View();
        }

        public IActionResult ChangeAdmin() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangeAdmin(AdminCreateViewModel viewModel)
        {
                //保存用户输入的值
                var AdminID = viewModel.AdminID;
                var Password = viewModel.Password;
                var PasswordTwo = viewModel.PasswordTwo;
                //在数据库里寻找用户是否再存
                var model = _studentRepository.FindAdmin(viewModel.AdminID);
                if (model != null)
                {
                    if ((model.AdminID == AdminID)&&(Password == PasswordTwo))
                    {
                       //用户想要改变的值重新赋值
                        model.AdminID = viewModel.AdminID;
                        model.Password = viewModel.Password;
                       //把想要改变的值在数据库中进行修改
                        _studentRepository.UPdateAdmin(model);
                       //修改密码之后需要重新登录
                        return RedirectToAction("Admin");
                    }
                    else 
                    {
                        ViewBag.Title = "true";
                    }
                }
                else
                {
                    ViewBag.Title = "true";
                }
          
            return View(viewModel);
        }

        /// <summary>
        /// 初始界面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            //在此页面需要用到存储在Session中的用户状态。
            ViewBag.AdminID = HttpContext.Session.GetString("AdminID");
            //把数据库中的所有数据都直接在页面上按照要求直接展示出来
            return View(_studentRepository.GetAll());//传输数据到页面上进行显示
        }
        /// <summary>
        /// 搜索框
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewBag.AdminID = HttpContext.Session.GetString("AdminID");
            //查找学生，在数据库中直接检索，把所有学生的信息直接存储到变量中。
            //并且在下方用linq语句查询
            var movies = from m in _context.Students
                         select m;
            // 代表 searchString 即不为空引用,也不为空字符串
            if (!string.IsNullOrEmpty(searchString))
            {
                //linq语句查询，根据姓名查询数据，查询具有延迟性，只有当ToList语句执行的时候才会执行linq语句
                movies = movies.Where(s => s.Name.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.AdminID = HttpContext.Session.GetString("AdminID");
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreateViewModels model)
        {
            //ModelState.IsValid : 此模型状态中是否有任何模型状态值
            if (ModelState.IsValid)
            {
                //需要获取在页面上用户输入的数据，进行存储，方便直接添加进入数据库
                var student = new Student
                {
                    Name = model.Name,
                    Adress = model.Adress,
                    ClassName = model.ClassName,
                    StudentNo = model.StudentNo,
                };
                //把数据直接添加进入数据库
                _studentRepository.Add(student);
                return RedirectToAction("index");
            }
            return View();
        }

        /// <summary>
        /// 编辑学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.AdminID = HttpContext.Session.GetString("AdminID");
            //根据学生ID来进行检索学生的信息，并进行调用、
            var model = _studentRepository.GEtByID(id);
            if (model == null) return View("StudentNotFound");

            //存储查找出来的数据，并返回给页面进行数据显示。
            var viewModel = new StudentEditViewModel
            {
                ID = model.ID,
                Name = model.Name,
                ClassName = model.ClassName,
                Adress = model.Adress,
                StudentNo = model.StudentNo,
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //检索用户需要修改是哪一个学生的信息。并直接把用户输入的数据直接覆盖之前的数据。
                var model = _studentRepository.GEtByID(viewModel.ID);
                if (model == null) return View("StudentNotFound");

                model.Name = viewModel.Name;
                model.Adress = viewModel.Adress;
                model.ClassName = viewModel.ClassName;
                model.StudentNo = viewModel.StudentNo;
                //在数据库中进行修改。
                _studentRepository.Update(model);
                return RedirectToAction("index");
            }
            return View(viewModel);
        }


        // GET: Movies/Delete/5
        public IActionResult Delete(int id)
        {
            //直接根据Id来删除学生信息。
            _studentRepository.Delete(id);
            return RedirectToAction("index");
        }
    }
}
