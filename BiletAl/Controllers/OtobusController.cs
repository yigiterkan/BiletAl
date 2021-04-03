using BiletAl.Models.Entity;
using BiletAl.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiletAl.Controllers
{
    public class OtobusController : Controller
    {
        // GET: Otobus
        DBBILETALEntities1 db = new DBBILETALEntities1();
        public ActionResult Index()
        {
            var otobusler= from Otobus in db.TBLOtobüs
                           join VarisLokasyonu in db.TBLLokasyon on Otobus.VarisLokasyonID equals VarisLokasyonu.LokasyonID
                           join KalkisLokasyonu in db.TBLLokasyon on Otobus.KalkisLokasyonID equals KalkisLokasyonu.LokasyonID
                           select new OtobusViewModel()
                           { 
                               OtobusID=Otobus.OtobusID,
                               KoltukSayisi=Otobus.KoltukSayisi,
                               AcilisFiyati=Otobus.AcilisFiyati,
                               KalkisLokasyon=KalkisLokasyonu.LokasyonAdı,
                               VarisLokasyon=VarisLokasyonu.LokasyonAdı,
                               SeferTarihi=Otobus.SeferTarihi
                           };
            return View(otobusler.ToList());
        }
    }
}