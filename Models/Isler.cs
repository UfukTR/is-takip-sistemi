using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsTakipSistemi.Models
{
    [Table("Isler", Schema = "dbo")]
    public class Isler
    {
        [Key]
        [Column("isId")]
        public int IsId { get; set; }

        [Column("isBaslik")]
        public string IsBaslik { get; set; }

        [Column("isAciklama")]
        public string IsAciklama { get; set; }

        [Column("isPersonelId")]
        public int? IsPersonelId { get; set; }

        [Column("iletilenTarih")]
        public DateTime? IletilenTarih { get; set; }

        [Column("yapilanTarih")]
        public DateTime? YapilanTarih { get; set; }

        [Column("isDurumId")]
        public int? IsDurumId { get; set; }

        // Navigation properties
        [ForeignKey("IsPersonelId")]
        public virtual Personeller Personel { get; set; }

        [ForeignKey("IsDurumId")]
        public virtual Durumlar Durum { get; set; }
    }
}
