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
    
    public partial class anhsanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public anhsanpham()
        {
            this.BaiViet_LinhKien = new HashSet<BaiViet_LinhKien>();
            this.Gioi_Thieu_product = new HashSet<Gioi_Thieu_product>();
            this.sanphams = new HashSet<sanpham>();
            this.Tra_Gop = new HashSet<Tra_Gop>();
        }
    
        public int id { get; set; }
        public string anh1 { get; set; }
        public string anh2 { get; set; }
        public string anh3 { get; set; }
        public string anh5 { get; set; }
        public string anh6 { get; set; }
        public string anh7 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet_LinhKien> BaiViet_LinhKien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gioi_Thieu_product> Gioi_Thieu_product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanpham> sanphams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tra_Gop> Tra_Gop { get; set; }
    }
}