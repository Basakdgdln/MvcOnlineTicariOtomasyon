using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        readonly Context c = new Context();


        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["PersonelMail"];
            var degerler = c.Mesajlars.Where(x => x.Alici == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Personels.Where(x => x.PersonelMail == mail).Select(y => y.PersonelID).FirstOrDefault();
            ViewBag.mid = mailid;
            var toplamsatis = c.SatisHarekets.Where(x => x.PersonelID == mailid).Count();
            ViewBag.toplamsatis = toplamsatis;
            var toplamtutar = c.SatisHarekets.Where(x => x.PersonelID == mailid).Sum(y => y.ToplamTutar);
            ViewBag.toplamtutar = toplamtutar;
            var toplamurun = c.SatisHarekets.Where(x => x.PersonelID == mailid).Sum(y => y.Adet).ToString();
            ViewBag.toplamurun = toplamurun;
            var adsoyad = c.Personels.Where(x => x.PersonelMail == mail).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.adsoyad = adsoyad;
            var departman = c.Personels.Where(x => x.PersonelID == mailid).Select(x => x.Departman.DepartmanAd).FirstOrDefault();
            ViewBag.departman = departman;
            var telefon = c.Personels.Where(x => x.PersonelID == mailid).Select(x => x.Telefon).FirstOrDefault();
            ViewBag.telefon = telefon;
            var adres = c.Personels.Where(x => x.PersonelID == mailid).Select(x => x.Adres).FirstOrDefault();
            ViewBag.adres = adres;
            var görsel = c.Personels.Where(x => x.PersonelID == mailid).Select(x => x.PersonelGorsel).FirstOrDefault();
            ViewBag.görsel = görsel;
            var sifre = c.Personels.Where(x => x.PersonelID == mailid).Select(x => x.PersonelSifre).FirstOrDefault();
            ViewBag.sifre = sifre;
            return View(degerler);
        }

        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["PersonelMail"];
            var id = c.Personels.Where(x => x.PersonelMail == mail).Select(y => y.PersonelID).FirstOrDefault();
            var degerler = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            return View(degerler);
        }

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["PersonelMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(x => x.Tarih).ToList();
            return View(mesajlar);
        }

        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["PersonelMail"];
            var mesajlar = c.Mesajlars.Where(x => x.Gönderen == mail && x.Durum == true).OrderByDescending(x => x.Tarih).ToList();
            return View(mesajlar);
        }

        public PartialViewResult MesajMenu()
        {
            var mail = (string)Session["PersonelMail"];
            var gelensayisi = c.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.d1 = gelensayisi;
            var gidensayisi = c.Mesajlars.Where(x => x.Gönderen == mail && x.Durum == true).Count();
            ViewBag.d2 = gidensayisi;
            var mesaj = c.Mesajlars.Where(x => x.Gönderen == mail && x.Durum == false).ToList();
            ViewBag.d3 = mesaj.Count();
            return PartialView();
        }

        public ActionResult MesajSil(int id)
        {
            var deger = c.Mesajlars.Where(x => x.MesajID == id).FirstOrDefault();
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }

        public ActionResult CopKutusu()
        {
            var mail = (string)Session["PersonelMail"];
            var mesaj = c.Mesajlars.Where(x => x.Gönderen == mail && x.Durum == false).ToList();
            return View(mesaj);
        }
        public ActionResult MesajıTası(int id)
        {
            var deger = c.Mesajlars.Where(x => x.Durum == false).FirstOrDefault();
            deger.Durum = true;
            c.SaveChanges();
            return RedirectToAction("GidenMesajlar");
        }

        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var degerler = c.Mesajlars.Where(x => x.MesajID == id).ToList();
            var mail = (string)Session["PersonelMail"];
            return View(degerler);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["PersonelMail"];
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar msj)
        {
            var mail = (string)Session["PersonelMail"];
            msj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            msj.Gönderen = mail;
            msj.Durum = true;
            c.Mesajlars.Add(msj);
            c.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            string mail = (string)Session["PersonelMail"];
            var kisi = c.Personels.Where(x => x.PersonelMail == mail).Select(x => x.PersonelID).FirstOrDefault();
            var k = from x in c.KargoDetayies where x.PersonelID==kisi select x;
            if (!string.IsNullOrEmpty(p))
            {
                k = k.Where(x => x.TakipKodu.Contains(p));
            }
            return View(k.ToList());
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult Partial1()
        {
            var mail = (string)Session["PersonelMail"];
            var id = c.Personels.Where(x => x.PersonelMail == mail).Select(y => y.PersonelID).FirstOrDefault();
            var personelbul = c.Personels.Find(id);
            return PartialView("Partial1", personelbul);
        }
        public PartialViewResult Partial2()
        {
            var veriler = c.Duyurulars.ToList();
            return PartialView(veriler);
        }
        public ActionResult PersonelBilgiGuncelle(Personel p)
        {
            var personel = c.Personels.Find(p.PersonelID);
            personel.PersonelAd = p.PersonelAd;
            personel.PersonelSoyad = p.PersonelSoyad;
            personel.PersonelMail = p.PersonelMail;
            personel.PersonelSifre = p.PersonelSifre;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu == id).ToList();
            return View(degerler);
        }
    }
}