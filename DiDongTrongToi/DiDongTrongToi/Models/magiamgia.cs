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
    
    public partial class magiamgia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public magiamgia()
        {
            this.Bao_Hanh = new HashSet<Bao_Hanh>();
            this.Dat_Hang = new HashSet<Dat_Hang>();
            this.hang_cho = new HashSet<hang_cho>();
        }
    
        public string id { get; set; }
        public int phan_Tram { get; set; }
        public bool chung { get; set; }
        public bool rieng { get; set; }
        public Nullable<int> Ma_san_Pham { get; set; }
        public System.DateTime ngay_Tao { get; set; }
        public System.DateTime ngay_Het_Han { get; set; }
        public bool da_Xoa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bao_Hanh> Bao_Hanh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dat_Hang> Dat_Hang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hang_cho> hang_cho { get; set; }
        public virtual sanpham sanpham { get; set; }
    }
}
