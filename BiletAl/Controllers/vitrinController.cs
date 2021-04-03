using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletAl.Models.Entity;


namespace BiletAl.Controllers
{
    [AllowAnonymous]
    public class vitrinController : Controller
    {
        // GET: vitrin
        DBBILETALEntities db = new DBBILETALEntities();
        //[HttpGet]
        public ActionResult Index()
        {
            //Class1 cs = new Class1();
            //cs.Deger1 = db.TBLKITAP.ToList();
            //cs.Deger2 = db.TBLHAKKIMIZDA.ToList();
            var degerler = db.TBLLokasyon.ToList();
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(TBLILETISIM t)
        //{
        //    db.TBLILETISIM.Add(t);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}