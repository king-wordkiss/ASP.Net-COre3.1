using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.Models
{
    public static class ModelBuilderExtensions
    {
        public static void InsertSeedData(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    ID = 2,
                    Name = "张三",
                    ClassName = ClassNameEnum.FirstGrage,
                    Adress = "南昌市",
                   StudentNo = "200101"
                },
                 new Student
                 {
                     ID = 3,
                     Name = "李四",
                     ClassName = ClassNameEnum.FirstGrage,
                     Adress = "解放路",
                     StudentNo="200102"
                 },
                 new Student
                 {
                     ID = 4,
                     Name = "王五",
                     ClassName = ClassNameEnum.FirstGrage,
                     Adress = "中山路",
                     StudentNo = "200103"
                 }
                );
        }
    }
}
