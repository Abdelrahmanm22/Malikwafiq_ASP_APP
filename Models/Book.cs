using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Malek_wafik.Models
{
    public class Book
    {
        public int Id { get; set; } //PK
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string? Discription { get; set; }
        public string? ImageName { get; set; }
        [InverseProperty("Book")]
        public ICollection<Section> Sections { get; set; } = new HashSet<Section>();
    }
}
