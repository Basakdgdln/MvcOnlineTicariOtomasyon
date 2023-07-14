using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index(int sayfa=1)
        {
            var deger = c.Carilers.Where(x => x.Durum == true).ToList().ToPagedList(sayfa,10);
            return View(deger);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler cari)
        {
            cari.Durum = true;
            c.Carilers.Add(cari);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

     
        public ActionResult CariGetir(int id)
        {
            var cr = c.Carilers.Find(id);
            return View("CariGetir", cr);
        }

        public ActionResult CariGuncelle(Cariler car)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            var cr = c.Carilers.Find(car.CariID);
            cr.CariAd = car.CariAd;
            cr.CariSoyad = car.CariSoyad;
            cr.CariSehir = car.CariSehir;
            cr.CariMail = car.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cr = c.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
        public ActionResult Rapor(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(degerler);
        }
    }
}