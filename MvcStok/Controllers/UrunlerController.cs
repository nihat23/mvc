using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MvcStok.Models.Entity;//kutuphanemız
using PagedList;
using PagedList.Mvc;


namespace MvcStok.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MvcStokDbEntities db = new MvcStokDbEntities();

        public ActionResult Index(int sayfa=1)
        {
            // var degerler = db.TBLURUNLER.ToList();
            var degerler = db.TBLURUNLER.ToList().ToPagedList(sayfa,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            var ktgr = db.TBLKATEGORILER.Where(m => m.KATEGORID == p1.TBLKATEGORILER.KATEGORID).FirstOrDefault();
            p1.TBLKATEGORILER = ktgr;

            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
            // return View(); 
        }

        public ActionResult Sil(int id)
        {
            var urunsil = db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urunsil);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLER.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urunGuncel = db.TBLURUNLER.Find(p1.ID);
            urunGuncel.URUNAD = p1.URUNAD;
            //urunGuncel.URUNKATEGORI = p1.URUNKATEGORI;
            var ktgr = db.TBLKATEGORILER.Where(m => m.KATEGORID == p1.TBLKATEGORILER.KATEGORID).FirstOrDefault();
            urunGuncel.URUNKATEGORI = ktgr.KATEGORID;

            urunGuncel.STOK = p1.STOK;
            urunGuncel.MARKA = p1.MARKA;
            urunGuncel.FIYAT = p1.FIYAT;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}