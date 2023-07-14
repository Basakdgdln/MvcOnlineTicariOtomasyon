using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }


        public ActionResult SatisGetir(int id)
        {
            var degerler = c.SatisHarekets.Find(id);
            List<SelectListItem> urun = (from x in c.Uruns.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.UrunAd,
                                             Value = x.UrunID.ToString()
                                         }).ToList();
            List<SelectListItem> cari = (from x in c.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            ViewBag.urun = urun;
            ViewBag.cari = cari;
            ViewBag.personel = personel;
            ViewBag.tarih = degerler.Tarih.ToShortDateString() + " " + degerler.Tarih.ToShortTimeString();
            ViewBag.adet = degerler.Adet;
            ViewBag.fiyat = degerler.Fiyat;
            ViewBag.toplamtutar = (degerler.Adet) * (degerler.Fiyat);
            return View("SatisGetir", degerler);
        }

        public ActionResult SatisGuncelle(SatisHareket s)
        {
            var satis = c.SatisHarekets.Find(s.SatisID);
            satis.UrunID = s.UrunID;
            satis.CariID = s.CariID;
            satis.PersonelID = s.PersonelID;
            satis.Adet = s.Adet;
            satis.Fiyat = s.Fiyat;
            satis.ToplamTutar = s.ToplamTutar;
            satis.Tarih = s.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

          }
}