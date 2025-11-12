using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Malek_wafik.Models;

namespace Malek_wafik.ViewModels
{
    public class VideoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Title is required"), MaxLength(200, ErrorMessage = "Max Length is 200 chars")]
        public string Title { get; set; }

        [MaxLength(10000, ErrorMessage = "Max Length is 10000 chars")]
        public string? Description { get; set; }

        [Required(ErrorMessage ="Iframe is required")]
        public string Iframe { get; set; }

        [ForeignKey("Section")]
        public int SectionId { get; set; }

        [InverseProperty("Voices")]
        public Section? Section { get; set; }
    }
}
