using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication2
{
    public class NguoiDungModel
    {
        [DisplayName("Tên khách hàng")]
        [Required(ErrorMessage = "không thể bỏ trống")]
        public string name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "không thể bỏ trống")]
        public string email { get; set; }
        [DisplayName("Số điện thoại")]
        [Required(ErrorMessage = "không thể bỏ trống")]
        public string phone { get; set; }
        [DisplayName("Ngày sinh")]
        [Required(ErrorMessage = "không thể bỏ trống")]
        public DateTime date { get; set; }
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "không thể bỏ trống")]
        public string username { get; set; }
        [Required(ErrorMessage = "không thể bỏ trống")]
        [StringLength(50, MinimumLength = 6)]
        [DataType(DataType.Password)]
        [DisplayName("Mật khẩu")]
        public string password { get; set; }
        [Required(ErrorMessage = "không thể bỏ trống")]

        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu phải bằng nhau")]
        [DisplayName("Xác nhận mật khẩu")]
        public string confirmPassword { get; set; }
    }
}