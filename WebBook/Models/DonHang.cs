//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebBook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            this.ChiTiets = new HashSet<ChiTiet>();
        }
    
        public int MaDonHang { get; set; }
        public Nullable<int> ID_NguoiMua { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDT { get; set; }
        public Nullable<System.DateTime> NgayDat { get; set; }
        public Nullable<bool> TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet> ChiTiets { get; set; }
        public virtual NguoiDung NguoiDung1 { get; set; }
    }
}
