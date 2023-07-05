using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaTakip.Models
{
    public class Hasta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hasta_id { get; set; }

        public string hasta_tc { get; set; }

        public string hasta_ad_soyad { get; set; } = null!;

        public string dogum_tarihi { get; set; }

    }
}
