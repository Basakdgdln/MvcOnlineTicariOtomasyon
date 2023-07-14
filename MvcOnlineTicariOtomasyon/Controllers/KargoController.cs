using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        readonly Context c = new Context();
        public ActionResult Index(string p)
        {
            var k = from x in c.KargoDetayies select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(x => x.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakter.Length + 1);
            k2 = rnd.Next(0, karakter.Length + 1);
            k3 = rnd.Next(0, karakter.Length + 1);

            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1.ToString() + karakter[k1] + s2.ToString() + karakter[k2] + s3.ToString() + karakter[k3];
            ViewBag.takipkod = kod;

            List<SelectListItem> personel = (from x in c.Personels
                                            select new SelectListItem
                                            {
                                                Text= x.PersonelAd + " "+ x.PersonelSoyad,
                                                Value= x.PersonelID.ToString()
                                            }).ToList();
            List<SelectListItem> musteri = (from x in c.Carilers
                                            select new SelectListItem 
                                            { 
                                                Text= x.CariAd+ " "+ x.CariSoyad,
                                                Value=x.CariID.ToString()
                                            }).ToList();
            ViewBag.personel = personel;
            ViewBag.musteri = musteri;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetayies d)
        {
            Random rnd = new Random();
            string[] karakter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z" };
            int k1, k2, k3;
            k1 = rnd.Next(0, karakter.Length + 1);
            k2 = rnd.Next(0, karakter.Length + 1);
            k3 = rnd.Next(0, karakter.Length + 1);

            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1.ToString() + karakter[k1] + s2.ToString() + karakter[k2] + s3.ToString() + karakter[k3];
          
            DateTime tarih = DateTime.Now;
            d.Tarih = tarih;
            d.TakipKodu = kod;
            c.KargoDetayies.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakipDetay(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }

    }
}