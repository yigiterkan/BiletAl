using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletAl.Models.Entity;
using BiletAl.ViewModels;

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

        public ActionResult BiletAl(int otobusID)
        {
            var otobus = db.TBLOtobüs.FirstOrDefault(o => o.OtobusID == otobusID);
            var satilmisKoltuklar = db.TBLBilet.Where(x => x.OtobusID == otobusID).Select(x=>x.KoltukNo).ToList();
            List<int> satilmamisKoltuklar = new List<int>();
           
            for (int i = 1; i <= otobus.KoltukSayisi; i++)
            {
                if (satilmisKoltuklar.Contains(i.ToString()) == false)
                {
                    satilmamisKoltuklar.Add(i);
                }
            }
            var model = new BiletAlViewModel()
            {
                SatilmamisKoltuklar = satilmamisKoltuklar,
                OtobusID = otobusID
            };
            return View(model);
        }
     
        [HttpPost]
        public ActionResult BiletAl(int otobusID,string yolcuAdi, string yolcuSoyadi, string koltukNo)
        {
            var otobus = db.TBLOtobüs.FirstOrDefault(o => o.OtobusID == otobusID);
            string eposta = Session["Eposta"].ToString();
            var kullanici = db.TBLKullanici.FirstOrDefault(y => y.Eposta == eposta);
            int satilmisBiletAdeti = db.TBLBilet.Where(x => x.OtobusID == otobusID).Count();
            decimal satisFiyati = otobus.AcilisFiyati +
                otobus.AcilisFiyati*((satilmisBiletAdeti - satilmisBiletAdeti % 5) / 5) *0.1m;
            
            var yolcu = new TBLYolcu {

                YolcuAdı = yolcuAdi,
                YolcuSoyadı = yolcuSoyadi,
            };

            db.TBLYolcu.Add(yolcu);

            db.TBLBilet.Add(new TBLBilet { 
                KoltukNo = koltukNo,
                OtobusID=otobusID,
                SatisFiyati=satisFiyati,
                YolcuID=yolcu.YolcuID,
                KullaniciID=kullanici.KullaniciID,
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