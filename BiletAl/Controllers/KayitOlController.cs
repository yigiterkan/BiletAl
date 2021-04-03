using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletAl.Models.Entity;


namespace BiletAl.Controllers
{
    [AllowAnonymous]
    public class KayitOlController : Controller
    {
        // GET: KayitOl

        private DBBILETALEntities db = new DBBILETALEntities();

        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBLKullanici p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBLKullanici.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}