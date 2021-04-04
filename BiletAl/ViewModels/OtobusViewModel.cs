using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BiletAl.ViewModels
{
    public class OtobusViewModel
    {
        public int OtobusID { get; set; }
        public int KoltukSayisi { get; set; }
        public int KalkisLokasyonID { get; set; }
        public int VarisLokasyonID { get; set; }
        public string KalkisLokasyon { get; set; }
        public string VarisLokasyon { get; set; }
        public DateTime SeferTarihi { get; set; }
        public decimal AcilisFiyati { get; set; }
        
    }
}