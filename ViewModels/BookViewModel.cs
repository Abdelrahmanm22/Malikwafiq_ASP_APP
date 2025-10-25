using System.ComponentModel.DataAnnotations;

namespace Malek_wafik.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; } //PK
        [Required(ErrorMessage ="Name is required")]
        [MaxLength(50,ErrorMessage ="Max Length is 50 chars")]
        [MinLength(5,ErrorMessage ="Min Length is 5 chars")]
        public string Name { get; set; }
        [MaxLength(500,ErrorMessage ="Max Length is 500 chars")]
        public string? Discription { get; set; }
        public string ImageName { get; set; }
    }
}
