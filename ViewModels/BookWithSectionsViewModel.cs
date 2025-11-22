namespace Malek_wafik.ViewModels
{
    public class BookWithSectionsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Discription { get; set; }
        public string? ImageName { get; set; }
        public List<SectionWithVideosViewModel> Sections { get; set; } = new();
    }
}
