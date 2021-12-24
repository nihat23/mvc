using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

using PagedList;//
using PagedList.Mvc;



namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcStokDbEntities db = new MvcStokDbEntities();

        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 5);//onemli
            return View(degerler);
        }

        [HttpGet]//herhangı bırsey yapmazsa bunu çalıştır
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]//pos yaparsan bunu çalışstır
        public ActionResult YeniKategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }

            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();

            return View();
        }

        public ActionResult Sil( int id)
        {
            var kategoriSil = db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategoriSil);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir", ktgr);

        }

        public ActionResult Guncelle(TBLKATEGORILER p1)
        {
            var ktgr = db.TBLKATEGORILER.Find(p1.KATEGORID);
            ktgr.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return View("Index");

        }

    }
}