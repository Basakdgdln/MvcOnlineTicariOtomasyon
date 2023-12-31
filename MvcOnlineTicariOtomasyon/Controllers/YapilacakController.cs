﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        // GET: Yapilacak
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Carilers.Count();
            ViewBag.d1 = deger1;
            var deger2 = c.Uruns.Count();
            ViewBag.d2 = deger2;
            var deger3 = c.Kategoris.Count();
            ViewBag.d3 = deger3;
            var deger4 = (from x in c.Carilers select x.CariSehir).Distinct().Count();
            ViewBag.d4 = deger4;


            var yapilacak = c.Yapilacaks.ToList();
            return View(yapilacak);
        }
    }
}