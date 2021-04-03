using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BiletAl.Models.Entity;
using BiletAl.Models.Entity;

namespace BiletAl.Controllers
{
    public class islemController : Controller
    {
        // GET: islem
        DBBILETALEntities db = new DBBILETALEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.ISLEMDURUM == true).ToList();
            return View(degerler);
            
        }
    }
}