using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.Models
{
    public class SqlAdminContext : DbContext
    {
        /// <summary>
        /// 将应用程序地配置传递给DbContext
        /// </summary>
        /// <param name="options"></param>
        public SqlAdminContext(DbContextOptions<SqlAdminContext> options) : base(options) { }

        /// <summary>
        /// 对要使用到的每个实体都添加DbSet<TEntity>属性
        /// 通过DbSet属性来进行增删改查操作
        /// 对DbSet采用Linq查询的时候，EFCore自动将其转化为SQL语句
        /// </summary>
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AdminSeedData();
        }
    }
}
