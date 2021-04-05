using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BiletAl.Models.Entity;


namespace BiletAl.Controllers
{
    [Authorize]
    public class PanelimController : Controller
    {

        // GET: Panelim
        DBBILETALEntities1 db = new DBBILETALEntities1();
        [HttpGet]
      
        public ActionResult Index()
        {
            var uyemail = (string)Session["Eposta"];
            var degerler = db.TBLKullanici.FirstOrDefault(z => z.Eposta == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBLKullanici p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLKullanici.FirstOrDefault(x=>x.Eposta==kullanici);
            uye.Parola = p.Parola;
            uye.Eposta = p.Eposta;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Eposta"];
            var id = db.TBLKullanici.Where(x => x.Eposta == kullanici.ToString()).Select(z => z.KullaniciID).FirstOrDefault();
            var degerler = db.TBLKullanici.Where(x => x.KullaniciID == id).ToList();
            return View(degerler);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
       
    }
}