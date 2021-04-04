using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletAl.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace BiletAl.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBBILETALEntities1 db = new DBBILETALEntities1();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLKullanici.ToList();          
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLKullanici p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLKullanici.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLKullanici.Find(id);
            db.TBLKullanici.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLKullanici.Find(id);
            return View("UyeGetir", uye);
        }
        public ActionResult UyeGuncelle(TBLKullanici p)
        {
            var uye = db.TBLKullanici.Find(p.YolcuID);
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad; 
            uye.Eposta = p.Eposta;
            uye.Parola = p.Parola;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}