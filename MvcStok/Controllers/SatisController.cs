using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;//

namespace MvcStok.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MvcStokDbEntities db = new MvcStokDbEntities();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniSatisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatisYap( TBLSATISLAR p1)
        {
            db.TBLSATISLAR.Add(p1);
            db.SaveChanges();
            return View("Index");
        }
    }
}