using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Class2
    {
        public IEnumerable<SelectListItem> kategoriler { get; set; }
        public IEnumerable<SelectListItem> ürünler { get; set; }

    }
}