using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.Models
{
    public interface IStudentRepository
    {
        /// <summary>
        /// 根据ID来寻找学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GEtByID(int id);
        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Add(Student student);
        /// <summary>
        /// 返回所有学生信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAll();
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="updateStudent"></param>
        /// <returns></returns>
        Student Update(Student updateStudent);
        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student Delete(int id);
        /// <summary>
        /// 管理员账号进行查询，是否存在这个用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        Admin Login(Admin admin);
        /// <summary>
        /// 修改管理员账号的密码
        /// </summary>
        /// <param name="updateAdmin"></param>
        /// <returns></returns>
        Admin UPdateAdmin(Admin updateAdmin);
        /// <summary>
        /// 寻找是否存在这个账号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Admin FindAdmin(string name);

    }
}
