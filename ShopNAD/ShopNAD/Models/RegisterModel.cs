using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNAD.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { get; set; }

        [Display(Name="Tên Đăng Nhập")]
        [Required(ErrorMessage ="Tên tài khoản không được trống")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được trống")]
        [StringLength(100,MinimumLength =6,ErrorMessage ="Độ dài mật khẩu ít nhất 6 kí tự")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password",ErrorMessage ="Không trùng mật khẩu")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Họ tên không được trống")]
        [Display(Name = "Họ và tên")]     
        public string FullName { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Địa chỉ không được trống")]
        public string Address { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được trống")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string CaptchaCode { get; set; }

    }
}