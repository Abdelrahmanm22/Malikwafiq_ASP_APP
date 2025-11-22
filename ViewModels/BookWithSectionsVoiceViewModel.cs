namespace Malek_wafik.ViewModels
{
    public class BookWithSectionsVoiceViewModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public List<SectionVoiceViewModel> Sections { get; set; } = new();
    }
}
