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
    
    public partial class like_Rep_danhGia
    {
        public int id { get; set; }
        public Nullable<bool> C_like { get; set; }
        public Nullable<bool> dislike { get; set; }
        public string acc { get; set; }
        public Nullable<System.DateTime> thoiGian { get; set; }
        public Nullable<int> like_DanhGia { get; set; }
    
        public virtual acc acc1 { get; set; }
        public virtual like_DanhGia like_DanhGia1 { get; set; }
    }
}