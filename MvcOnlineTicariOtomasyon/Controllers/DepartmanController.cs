using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]    // bütün alanları etkiler.
    public class DepartmanController : Controller
    {
        // GET: Departman
       readonly Context c = new Context();
 
        public ActionResult Index()
        {
            var degerler = c.Departmen.Where(x=>x.Durum==true).ToList();
            return View(degerler);
        }
       
        [Authorize(Roles ="A")]           // bu actiona ulaşabilmek için A yetkisine sahip olmak gerekir.
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            d.Durum = true;
            c.Departmen.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var dpt = c.Departmen.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();     
            ViewBag.dprt = dpt;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var pad = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.dp = pad;
            return View(degerler);
        }

        public ActionResult Rapor(int id)
        {
            var degerler= c.SatisHarekets.Where(x=>x.SatisID==id).ToList();
            return View(degerler);
        }
    }
}