using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore3._1Student.Models
{
    public class SqlStudentRepository : IStudentRepository
    {
        private readonly SqlDbContext _sqlDbCOntent;
        private readonly SqlAdminContext _sqlAdmin;
        /// <summary>
        /// 进行绑定数据源
        /// </summary>
        /// <param name="sqlDbContext"></param>
        /// <param name="sqlAdminContext"></param>
        public SqlStudentRepository(SqlDbContext sqlDbContext, SqlAdminContext sqlAdminContext)
        {
            _sqlDbCOntent = sqlDbContext;
            _sqlAdmin = sqlAdminContext;
        }
        /// <summary>
        /// 再所对应的数据库中添加数据
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student Add(Student student)
        {
            _sqlDbCOntent.Students.Add(student);
            _sqlDbCOntent.SaveChanges();
            return student;
        }
        /// <summary>
        /// 在学生信息表中进行更具ID来进行查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student Delete(int id)
        {
            var student = _sqlDbCOntent.Students.Find(id); //查找学生是否存在
            if (student != null)
            {
                _sqlDbCOntent.Students.Remove(student);
                _sqlDbCOntent.SaveChanges();
            }
            return student;
        }

        public Admin FindAdmin(string name) => _sqlAdmin.Admins.Find(name);
        

        public IEnumerable<Student> GetAll() => _sqlDbCOntent.Students;

        /// <summary>
        /// 根据id寻找学生
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GEtByID(int id) => _sqlDbCOntent.Students.Find(id);

        public Admin Login(Admin admin)
        {
            return _sqlAdmin.Admins.Find(admin.AdminID);
        }


        public Student Update(Student updatedStudent)
        {
            var student = _sqlDbCOntent.Students.Attach(updatedStudent);
            student.State = EntityState.Modified;
            _sqlDbCOntent.SaveChanges();
            return updatedStudent;
        }

        public Admin UPdateAdmin(Admin updateAdmin)
        {
            var admin = _sqlAdmin.Admins.Attach(updateAdmin);
            admin.State = EntityState.Modified;
            _sqlAdmin.SaveChanges();
            return updateAdmin;
        }
    }
}
