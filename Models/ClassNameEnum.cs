using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.Models
{
    public enum ClassNameEnum
    {
       [Display(Name = "一年级")]
       FirstGrage,

       [Display(Name = "二年级")]
       SecondGrade,

       [Display(Name = "三年级")]
       ThirdGrade,
    }
}
