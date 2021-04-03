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

    public class AdminLoginController : Controller
    {
        DBBILETALEntities db = new DBBILETALEntities();
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBLAdmin p)
        {
            var bilgiler = db.TBLAdmin.FirstOrDefault(x => x.Admin == p.Admin && x.Sifre == p.Sifre);
           
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Admin, false);
                Session["Admin"] = bilgiler.Admin.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return View();
            }
        }
    }
}