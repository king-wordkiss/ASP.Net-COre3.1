using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.Models
{
    public static class ModelBuiilderAdmin
    {

        public static void AdminSeedData(this ModelBuilder modelBuiilder) 
        {
            modelBuiilder.Entity<Admin>().HasData(
                new Admin
                {
                    AdminID = "admin",
                    Password = "123456"
                }
                );
                
        }

    }
}
