using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3._1Student.ViewModels
{
    public class AdminCreateViewModel
    {
        [Display(Name = "账号")]
        [Required(ErrorMessage = "请输入账号")]
        public string AdminID { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string Password { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "请输入密码")]
        public string PasswordTwo { get; set; }      
    }
}
