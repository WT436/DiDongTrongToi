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
    
    public partial class Danh_Gia_Trang
    {
        public int id { get; set; }
        public int so_Sao { get; set; }
        public bool Theo_doi { get; set; }
        public Nullable<int> nha_Cung_Cap { get; set; }
        public string acc { get; set; }
        public Nullable<bool> da_Xoa { get; set; }
    
        public virtual acc acc1 { get; set; }
        public virtual nhacungCap nhacungCap { get; set; }
    }
}