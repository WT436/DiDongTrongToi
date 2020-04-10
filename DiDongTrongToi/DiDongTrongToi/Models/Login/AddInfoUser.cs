using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiDongTrongToi.Models.Login
{
    public class AddInfoUser
    {        
        public string taikhoan { get; set; }        
        public string matkhau { get; set; }       
        public string gmail { get; set; }        
        public string ten { get; set; }     
        public int tuoi { get; set; }      
        public string diachi { get; set; }       
        public int sdt { get; set; }   
        public string anh { get; set; }
    }
}