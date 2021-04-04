using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletAl.Models.Entity;
using System.Web.Security;

namespace BiletAl.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        // GET: Login
        DBBILETALEntities1 db = new DBBILETALEntities1();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBLKullanici p)
        {
            var bilgiler = db.TBLKullanici.FirstOrDefault(x => x.Eposta == p.Eposta && x.Parola == p.Parola);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Eposta, false);
                Session["Eposta"] = bilgiler.Eposta.ToString();
                return RedirectToAction("Index", "Otobus");
            }
            else
            {
                return View();
            }
            
        }
    }
}