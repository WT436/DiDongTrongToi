using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiDongTrongToi.Areas.Supplier.Models
{
    [Serializable]
    public class SaveNewProduct
    {
        
        public  string taiKhoan { get; set;}
        public int maAnh { get; set;}
        public int maSanPham { get; set; }
        public int machude { get; set; }
        public int maChungloai { get; set; }
    }
}