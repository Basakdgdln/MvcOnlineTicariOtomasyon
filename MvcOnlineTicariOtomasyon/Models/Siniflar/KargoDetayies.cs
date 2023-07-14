using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoDetayies
    {
        [Key]
        public int KargoDetayID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }

        public int PersonelID { get; set; }
        public virtual Personel Personel { get; set; }
     
        public int CariID { get; set; }
        public virtual Cariler Cariler { get; set; }
        public DateTime Tarih { get; set; }

    }
}