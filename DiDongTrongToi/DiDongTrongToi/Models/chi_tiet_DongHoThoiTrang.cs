//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiDongTrongToi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class chi_tiet_DongHoThoiTrang
    {
        public int id { get; set; }
        public string loaimay { get; set; }
        public Nullable<int> duongKinhmat { get; set; }
        public string chatLieuMatKinh { get; set; }
        public string chatLieuKhungVien { get; set; }
        public string chongxuoc { get; set; }
        public Nullable<int> dodayMat { get; set; }
        public string chatLieuDay { get; set; }
        public string tienIch { get; set; }
        public Nullable<int> doRongDay { get; set; }
        public string NguonNangLuong { get; set; }
        public string ThoiGianSuDungPin { get; set; }
        public string DoiTuongSuDung { get; set; }
        public string ThuongHieu { get; set; }
        public string noiSanXuat { get; set; }
        public string ThoiDiemRaMat { get; set; }
        public Nullable<int> sanpham { get; set; }
    
        public virtual sanpham sanpham1 { get; set; }
    }
}
