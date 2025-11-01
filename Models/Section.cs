using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Malek_wafik.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [InverseProperty("Sections")]
        public Book Book { get; set; }
    }
}
