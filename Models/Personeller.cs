using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsTakipSistemi.Models
{
    [Table("Personeller", Schema = "dbo")]
    public class Personeller
    {
        [Key]
        [Column("personelId")]
        public int PersonelId { get; set; }

        [Column("personelAdSoyad")]
        [StringLength(50)]
        public string PersonelAdSoyad { get; set; }

        [Column("personelKullaniciAd")]
        [StringLength(50)]
        public string PersonelKullaniciAd { get; set; }

        [Column("personelParola")]
        [StringLength(50)]
        public string PersonelParola { get; set; }

        [Column("personelBirimId")]
        public int? PersonelBirimId { get; set; }

        [Column("personelYetkiTurId")]
        public int? PersonelYetkiTurId { get; set; }

        // Navigation properties
        [ForeignKey("PersonelBirimId")]
        public virtual Birimler Birim { get; set; }

        [ForeignKey("PersonelYetkiTurId")]
        public virtual YetkiTurler YetkiTur { get; set; }

        public virtual ICollection<Isler> Isler { get; set; } = new List<Isler>();
    }
}
