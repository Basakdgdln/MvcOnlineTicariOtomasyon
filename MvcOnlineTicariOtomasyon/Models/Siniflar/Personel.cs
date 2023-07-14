using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }

        [Display(Name = "PERSONEL ADI")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Display(Name = "PERSONEL SOYADI")]
        [Column(TypeName = "char")]
        [StringLength(11)]
        public string PersonelSoyad { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Adres { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string Telefon { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string PersonelMail { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(20)]
        public string PersonelSifre { get; set; }

        public ICollection<SatisHareket> SatisHarekets { get; set; }
        public ICollection<KargoDetayies> KargoDetayys { get; set; }
     
        public int DepartmanID { get; set; }
        public virtual Departman Departman { get; set; }
    }
}