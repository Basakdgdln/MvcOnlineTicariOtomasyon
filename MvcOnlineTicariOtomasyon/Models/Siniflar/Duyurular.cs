using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Duyurular
    {
        [Key]
        public int DuyuruID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string Yayınlayan { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(500)]
        public string İçerik { get; set; }

        public DateTime Tarih { get; set; }
    }
}