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

        [StringLength(11, MinimumLength = 11)]
        [Required(ErrorMessage = "TC kimlik alanı boş bırakılamaz.")]
        public string hasta_tc { get; set; } = null!;

        [RegularExpression(@"^[^\d]+[a-zA-ZğüşıöçĞÜŞİÖÇ\s]*$", ErrorMessage = "Bu alanda sayı bulunmamalıdır. Sadece hastanın adı adı girilmelidir. örn: Alkim Kaya")]
        [Required(ErrorMessage = "Hasta adı ve soyadı boş bırakılamaz.")]
        [StringLength(30)]
        public string hasta_ad_soyad { get; set; } = null!;



        [Required(ErrorMessage = "Doğum tarihi boş bırakılamaz.")]
        [Display(Name = "Doğum Tarihi")]
        public string dogum_tarihi { get; set; } = null!;
    }
}
