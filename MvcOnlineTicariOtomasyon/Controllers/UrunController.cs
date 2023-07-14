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
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p, int sayfa = 1)
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p) | y.Marka.Contains(p) | y.Kategori.KategoriAd.Contains(p));
            }
            return View(urunler.ToList().ToPagedList(sayfa, 10));
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();

            ViewBag.urun = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            if (u.Stok == 0)
            {
                u.Durum = false;
            }
            else
            {
                u.Durum = true;
            }
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var deger = c.Uruns.Find(id);
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.urun = deger1;
            return View("UrunGetir", deger);
        }

        public ActionResult UrunGuncelle(Urun p)
        {
            var urun = c.Uruns.Find(p.UrunID);
            urun.UrunAd = p.UrunAd;
            urun.Marka = p.Marka;
            urun.Stok = p.Stok;
            urun.AlisFiyat = p.AlisFiyat;
            urun.SatisFiyat = p.SatisFiyat;
            urun.KategoriID = p.KategoriID;
            urun.UrunGorsel = p.UrunGorsel;
            urun.Durum = p.Durum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Urunlistesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personel = (from x in c.Personels.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                 Value = x.PersonelID.ToString()
                                             }).ToList();
            List<SelectListItem> cari = (from x in c.Carilers.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CariAd + " " + x.CariSoyad,
                                             Value = x.CariID.ToString()
                                         }).ToList();
            ViewBag.dgr = personel;
            ViewBag.d1 = cari;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunAd;
            ViewBag.dgr2 = deger1.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket p)
        {
            p.UrunID = 1;
            p.Tarih = DateTime.Parse(DateTime.Now.ToLongDateString());
            c.SatisHarekets.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
    }
}
