using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaTakip.Models
{
    public class Ziyaret
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ziyaret_id { get; set; }

        [ForeignKey("Hasta")]
        public int hasta_id { get; set; }

        public DateTime ziyaret_tarihi { get; set; }

        public string doktor_adi { get; set; } = null!;

        public string sikayet { get; set; }

        public string tedavi_sekli { get; set; }

    }
}
