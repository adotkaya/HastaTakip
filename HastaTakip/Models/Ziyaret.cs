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

        [Required(ErrorMessage = "Hasta ID boş bırakılamaz.")]
        public int hasta_id { get; set; }

        [Required(ErrorMessage = "Ziyaret tarihi boş bırakılamaz.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime ziyaret_tarihi { get; set; }


        [RegularExpression(@"^[^\d]+[a-zA-ZğüşıöçĞÜŞİÖÇ\s]*$", ErrorMessage = "Bu alanda sayı bulunmamalıdır. Sadece hastanın adı adı girilmelidir. örn: Alkim Kaya")]
        [Required(ErrorMessage = "Doktor adı boş bırakılamaz.")]
        [StringLength(30)]
        public string doktor_adi { get; set; } = null!;

        [Required(ErrorMessage = "Hastanın şikayeti boş bırakılamaz.")]
        public string sikayet { get; set; }

        [Required(ErrorMessage = "Uygulanan tedavi boş bırakılamaz.")]
        public string tedavi_sekli { get; set; }

    }
}
