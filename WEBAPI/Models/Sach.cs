//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WEBAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            this.ChiTiets = new HashSet<ChiTiet>();
        }
    
        public int ID { get; set; }
        public string TenSach { get; set; }
        public Nullable<double> Gia { get; set; }
        public Nullable<int> SoTrang { get; set; }
        public Nullable<int> ID_TheLoai { get; set; }
        public string Anhbia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTiet> ChiTiets { get; set; }
        public virtual TheLoai TheLoai { get; set; }
    }
}