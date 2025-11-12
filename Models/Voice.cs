using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Malek_wafik.Models
{
    public class Voice
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, MaxLength(200)]
        public string AudioFileName { get; set; }
        [ForeignKey("Section")]
        public int SectionId { get; set; }

        [InverseProperty("Voices")]
        public Section Section { get; set; }
    }
}
