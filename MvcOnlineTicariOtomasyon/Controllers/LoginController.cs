using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]      
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult PersonelLogin1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelLogin1(Personel p) 
        {
            var bilgiler = c.Personels.FirstOrDefault(x => x.PersonelMail == p.PersonelMail && x.PersonelSifre == p.PersonelSifre);
            if (bilgiler != null)
            { 
                FormsAuthentication.SetAuthCookie(bilgiler.PersonelMail, false);       
                Session["PersonelMail"] = bilgiler.PersonelMail.ToString();
                return RedirectToAction("Index", "CariPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a) 
        {
            var deger = c.Admins.FirstOrDefault(x => x.KullaniciAd == a.KullaniciAd && x.Sifre == a.Sifre);
            if (deger != null) 
            {
                FormsAuthentication.SetAuthCookie(deger.KullaniciAd, false);
                Session["KullaniciAd"] = deger.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}