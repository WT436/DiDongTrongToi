using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiDongTrongToi.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Chưa Nhập Tài Khoản")]
        public string TaiKhoan { get ; set; }

       
        public string MatKhau { get; set; }

       
        public string MatKhauMoi { get; set; }

        
        public string MatKhauLai { get; set; }

        
        public string Gmail { get; set; }
    }
}