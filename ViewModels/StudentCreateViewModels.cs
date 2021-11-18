using AspNetCore3._1Student.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.ViewModels
{
    public class StudentCreateViewModels
    {
        [Display(Name = "姓名"),MaxLength(4,ErrorMessage = "名字长度不能超过四个字")]
        [Required(ErrorMessage = "请输入名字！")]
        public string Name { get; set; }
        [Display(Name = "班级")]
        [Required(ErrorMessage = "选择班级")]
        public ClassNameEnum? ClassName { get; set; }
        [Display(Name = "地址")]
        [Required(ErrorMessage = "请输入地址")]
        public string Adress { get; set; }
        [Display(Name = "学号"),MaxLength(6, ErrorMessage = "学号长度不能超过6位数"),MinLength(6, ErrorMessage = "学号长度不能少于6位数")]
        [Required(ErrorMessage = "请输入人六位数学号")]
        public string StudentNo { get; set; }


    }
}
