using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email hoặc tài khoản")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Nhớ tài khoản")]
        public bool IsRemember { get; set; }
    }
}
