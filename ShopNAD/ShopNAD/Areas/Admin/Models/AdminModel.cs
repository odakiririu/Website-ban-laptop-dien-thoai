using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNAD.Areas.Admin.Models
{
    public class AdminModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Chưa nhập tên tài khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Chưa nhập mật khẩu")]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}