//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiletAl.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLOtobüs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLOtobüs()
        {
            this.TBLBilet = new HashSet<TBLBilet>();
        }
    
        public byte OtobusID { get; set; }
        public int KoltukSayisi { get; set; }
        public byte KalkisLokasyonID { get; set; }
        public byte VarisLokasyonID { get; set; }
        public System.DateTime SeferTarihi { get; set; }
        public decimal AcilisFiyati { get; set; }
    
        public virtual TBLLokasyon TBLLokasyon { get; set; }
        public virtual TBLLokasyon TBLLokasyon1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLBilet> TBLBilet { get; set; }
    }
}
