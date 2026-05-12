using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IsTakipSistemi.Models
{
    [Table("YetkiTurler", Schema = "dbo")]
    public class YetkiTurler
    {
        [Key]
        [Column("yetkiTurId")]
        public int YetkiTurId { get; set; }

        [Column("yetkiTurAd")]
        [StringLength(50)]
        public string YetkiTurAd { get; set; }

        // Navigation property
        public virtual ICollection<Personeller> Personeller { get; set; } = new List<Personeller>();
    }
}
