using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopNAD.Areas.Admin.Models
{
    public class UserManageModel
    {
        public long ID { get; set; }
        [DisplayName("Tên tài khoản")]
        public string UserName { get; set; }
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [DisplayName("Họ và tên")]
        public string FullName { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }

        public DateTime? CreateDate { get; set; }

        public string CeateBy { get; set; }

        public DateTime? ModifielDate { get; set; }

        public string ModifieldBy { get; set; }
        [DisplayName("Trạng thái")]
        public bool? Status { get; set; }
    }
}