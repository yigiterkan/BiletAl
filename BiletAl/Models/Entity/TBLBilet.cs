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
    
    public partial class TBLBilet
    {
        public int BiletID { get; set; }
        public int YolcuID { get; set; }
        public decimal SatisFiyati { get; set; }
        public string KoltukNo { get; set; }
        public int OtobusID { get; set; }
    
        public virtual TBLKullanici TBLKullanici { get; set; }
        public virtual TBLOtobüs TBLOtobüs { get; set; }
    }
}
