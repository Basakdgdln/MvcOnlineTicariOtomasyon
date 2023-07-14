using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult PersonelLİste(int sayfa = 1)
        {
            return View(c.Personels.ToList().ToPagedList(sayfa, 9));
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> departman = (from x in c.Departmen.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmanAd,
                                                 Value = x.DepartmanID.ToString()
                                             }).ToList();
            ViewBag.dprt = departman;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);         
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = yol;

            }
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departman = (from x in c.Departmen.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.DepartmanAd,
                                                  Value = x.DepartmanID.ToString()
                                              }).ToList();
            ViewBag.dprt = departman;
            var deger = c.Personels.Find(id);
            ViewBag.tel = deger.Telefon;
            return View("PersonelGetir", deger);
        }

        public ActionResult PersonelGuncelle(Personel p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.PersonelGorsel = "~/Image/" + dosyaadi + uzanti;

            }
            var prs = c.Personels.Find(p.PersonelID);
            prs.PersonelAd = p.PersonelAd;
            prs.PersonelSoyad = p.PersonelSoyad;
            prs.PersonelGorsel = p.PersonelGorsel;
            prs.DepartmanID = p.DepartmanID;
            prs.Adres = p.Adres;
            prs.Telefon = p.Telefon;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}