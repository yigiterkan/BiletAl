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
        DBBILETALEntities db = new DBBILETALEntities();
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
            var kullanici = (string)Session["Mail"];
            var id = db.TBLUYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            return View(degerler);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
       
    }
}