using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Malek_wafik.Models;
using Malek_wafik.Validations;
namespace Malek_wafik.ViewModels
{
    public class VoiceViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is Required"), MaxLength(200,ErrorMessage = "Max Length is 200 chars")]
        public string Title { get; set; }
        [MaxLength(200,ErrorMessage = "Max Length is 200 chars")]
        public string? AudioFileName { get; set; }
        [Required(ErrorMessage = "Audio File is Required")]
        [AllowedAudioExtensions]
        public IFormFile AudioFile { get; set; }
        [ForeignKey("Section")]
        public int SectionId { get; set; }

        [InverseProperty("Voices")]
        public Section? Section { get; set; }
    }
}
