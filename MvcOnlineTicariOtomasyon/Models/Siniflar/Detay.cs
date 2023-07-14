using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DETAYID { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        [StringLength(30)]
        public string URUNAD { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(2000)]
        public string URUNBİLGİ { get; set; }
    }
}