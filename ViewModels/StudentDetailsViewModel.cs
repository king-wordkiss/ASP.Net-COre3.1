using AspNetCore3._1Student.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.ViewModels
{
    public class StudentDetailsViewModel
    {
        public Student Student { get; set; }

        public string PageTitle { get; set; }
    }
}
