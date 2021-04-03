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
        DBBILETALEntities db = new DBBILETALEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BiletGoster(int otobusId)
        {
            var biletler = from k in db.TBLBilet select k;
            var otobusIdBiletler = biletler.Where(x => x.OtobusID == otobusId).ToList();
            return View(otobusIdBiletler);
        }
    }
}