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
        DBBILETALEntities1 db = new DBBILETALEntities1();
        //[HttpGet]
        public ActionResult Index()
        {
           ;
            var degerler = db.TBLLokasyon.ToList();
            return View();
        }
       

    }
}