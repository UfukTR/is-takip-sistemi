using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsTakipSistemi.Models
{
    [Table("Birimler", Schema = "dbo")]
    public class Birimler
    {
        [Key]
        [Column("birimId")]
        public int BirimId { get; set; }

        [Column("birimAd")]
        [StringLength(50)]
        public string BirimAd { get; set; }

        // Navigation property
        public virtual ICollection<Personeller> Personeller { get; set; } = new List<Personeller>();
    }
}
