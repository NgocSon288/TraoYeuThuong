using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string FullName { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public int Age { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        public string Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DataType(DataType.Password)]
        [StringLength(255, MinimumLength = 6,  ErrorMessage = "{0} ít  nhất {1} ký tự")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [Required(ErrorMessage = "{0} không được bỏ trống")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "{0} không trùng khớp")]
        public string PasswordConfirm { get; set; }
    }
}
