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
    
    public partial class Danh_Muc_Theo_Chung_loai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Danh_Muc_Theo_Chung_loai()
        {
            this.sanphams = new HashSet<sanpham>();
        }
    
        public int id { get; set; }
        public string ten_chung_Loai { get; set; }
        public Nullable<int> Danh_Muc_Theo_Chu_De { get; set; }
        public bool da_xoa { get; set; }
    
        public virtual Danh_Muc_Theo_Chu_De Danh_Muc_Theo_Chu_De1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanpham> sanphams { get; set; }
    }
}
