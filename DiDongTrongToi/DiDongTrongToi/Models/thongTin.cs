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
    
    public partial class thongTin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public thongTin()
        {
            this.nhacungCaps = new HashSet<nhacungCap>();
        }
    
        public int id { get; set; }
        public string avatar { get; set; }
        public string ten { get; set; }
        public int tuoi { get; set; }
        public string diachi { get; set; }
        public int sdt { get; set; }
        public Nullable<bool> daxoa { get; set; }
        public Nullable<System.DateTime> ngayCapNhat { get; set; }
        public string taikhoan { get; set; }
    
        public virtual acc acc { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<nhacungCap> nhacungCaps { get; set; }
    }
}
