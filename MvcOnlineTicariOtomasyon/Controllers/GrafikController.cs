using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            var grafikciz = new Chart(width: 600, height: 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler",
             xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" }, yValues: new[] { 85, 66, 98 }).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = c.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 800, height: 800);
            grafik.AddTitle("Stoklar")
                .AddLegend("Değerler")
                .AddSeries(chartType: "pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }
        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);       //JSON--> javascript object notation(javascript nesne gösterimi)
        }
        public List<Sinif1> UrunListesi()
        {
            List<Sinif1> snf = new List<Sinif1>();
            snf.Add(new Sinif1()
            {
                UrunAd = "Bilgisayar",
                StokSayisi = 120
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Beyaz Eşya",
                StokSayisi = 150
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Mobilya",
                StokSayisi = 70
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Küçük Ev Aletleri",
                StokSayisi = 180
            });
            snf.Add(new Sinif1()
            {
                UrunAd = "Mobil Cihazlar",
                StokSayisi = 90
            });
            return snf;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);      
        }
        public List<Sinif2> UrunListesi2() 
        {
            List<Sinif2> snf = new List<Sinif2>();
            //using (var c= new Context())
            //{
                snf = c.Uruns.Select(x => new Sinif2
                {
                    Urun=x.UrunAd,
                    Stok=x.Stok
                    
                }).ToList();
            //}
            return snf;
        }
        public ActionResult Index6()
        {
            return View();
        }
        public ActionResult Index7()
        {
            return View();
        }

    }
}