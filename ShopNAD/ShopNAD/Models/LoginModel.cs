using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNAD.Models
{
    public class LoginModel
    {

        [Display(Name = "Tên Đăng Nhập")]
        [Required(ErrorMessage = "Tên tài khoản không được trống")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được trống")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Độ dài mật khẩu ít nhất 6 kí tự")]
        public string Password { get; set; }

    }
}