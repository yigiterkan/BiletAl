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
        public byte SeferID { get; set; }
        public Nullable<int> YolcuID { get; set; }
        public Nullable<decimal> SatisFiyati { get; set; }
        public string KoltukNo { get; set; }
        public Nullable<byte> OtobusID { get; set; }
    
        public virtual TBLKullanici TBLKullanici { get; set; }
        public virtual TBLOtobüs TBLOtobüs { get; set; }
    }
}