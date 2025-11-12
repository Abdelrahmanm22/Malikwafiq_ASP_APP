using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Malek_wafik.Models
{
    public class Video
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [MaxLength(10000)]
        public string? Iframe { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }

        [InverseProperty("Videos")]
        public Section Section { get; set; }
    }
}
