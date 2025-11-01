using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Malek_wafik.Models;

namespace Malek_wafik.ViewModels
{
    public class SectionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is required")]
        [MaxLength(100,ErrorMessage = "Max Length is 100 chars")]
        public string Title { get; set; }
        public int BookId { get; set; }
        [InverseProperty("Sections")]
        public Book? Book { get; set; }

    }
}
