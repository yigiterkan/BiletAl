using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletAl.Models.Entity;


namespace BiletAl.Controllers
{
    public class BiletController : Controller
    {
        // GET: Bilet
        DBBILETALEntities1 db = new DBBILETALEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BiletGoster()
        {
            var biletler = from k in db.TBLBilet select k;
            var otobusIdBiletler = biletler.ToList();
            return View(otobusIdBiletler);
        }

        public ActionResult BiletAl()
        {
            return View();
        }
     
        [HttpPost]
        public ActionResult BiletAl(int otobusID )
        {
            var otobus = db.TBLOtobüs.FirstOrDefault(o => o.OtobusID == otobusID);
            string eposta = Session["Eposta"].ToString();
            var yolcu = db.TBLKullanici.FirstOrDefault(y => y.Eposta ==eposta);
            int satilmisBiletAdeti = db.TBLBilet.Where(x => x.OtobusID == otobusID).Count();
            decimal satisFiyati = otobus.AcilisFiyati +
                otobus.AcilisFiyati*((satilmisBiletAdeti - satilmisBiletAdeti % 5) / 5) *0.1m;
            db.TBLBilet.Add(new TBLBilet { 
                KoltukNo = new Random().Next(1, 20).ToString(),
                OtobusID=otobusID,
                SatisFiyati=satisFiyati,
                YolcuID=yolcu.YolcuID
            });
            db.SaveChanges();
            return View();
        }
        [HttpGet]
        public ActionResult BiletSil()
        {          
            return View();
        }
        [HttpPost]
        public ActionResult BiletSil(int biletID)
        {
            var bilet = db.TBLBilet.FirstOrDefault(o => o.BiletID == biletID);
            db.TBLBilet.Remove(bilet);
            db.SaveChanges();
            return View();
        }
    }
}