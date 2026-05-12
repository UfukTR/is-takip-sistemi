using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsTakipSistemi.Models
{
    [Table("Durumlar", Schema = "dbo")]
    public class Durumlar
    {
        [Key]
        [Column("durumId")]
        public int DurumId { get; set; }

        [Column("durumAd")]
        [StringLength(50)]
        public string DurumAd { get; set; }

        // Navigation property
        public virtual ICollection<Isler> Isler { get; set; } = new List<Isler>();
    }
}
