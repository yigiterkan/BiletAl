using BiletAl.Models.Entity;
using BiletAl.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BiletAl.Controllers
{
    public class OtobusController : Controller
    {
        // GET: Otobus
        DBBILETALEntities1 db = new DBBILETALEntities1();
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(int varisLokasyonId, int kalkisLokasyonId, DateTime seferTarihi)
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
                               VarisLokasyonID=VarisLokasyonu.LokasyonID,
                               KalkisLokasyonID=KalkisLokasyonu.LokasyonID,
                               SeferTarihi=Otobus.SeferTarihi
                           };
            var filtrelenmisOtobusler = otobusler.Where(x => x.KalkisLokasyonID == kalkisLokasyonId &&
                                                             x.VarisLokasyonID == varisLokasyonId &&
                                                            DbFunctions.TruncateTime(x.SeferTarihi) == seferTarihi.Date).ToList();
            return View(filtrelenmisOtobusler);
        } 
    }
}