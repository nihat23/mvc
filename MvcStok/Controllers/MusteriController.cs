using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;//kutuphane
using PagedList;
using PagedList.Mvc;




namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcStokDbEntities db = new MvcStokDbEntities();

        public ActionResult Index(int sayi=1)
        {
            //var degerler = db.TBLMUSTERILER.ToList();
            var degerler = db.TBLMUSTERILER.ToList().ToPagedList(sayi,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            db.TBLMUSTERILER.Add(p1);
            db.SaveChanges();
            return View();

        }

        public ActionResult Sil(int id)
        {
            var musteriSil = db.TBLMUSTERILER.Find(id);
            db.TBLMUSTERILER.Remove(musteriSil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var mus = db.TBLMUSTERILER.Find(id);
            return View("MusteriGetir", mus);

        }

        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteriGuncel = db.TBLMUSTERILER.Find(p1.MUSTERID);
            musteriGuncel.MUSTERAD = p1.MUSTERAD;
            musteriGuncel.MUSTERISOYAD = p1.MUSTERISOYAD;
            musteriGuncel.TELEFON = p1.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}