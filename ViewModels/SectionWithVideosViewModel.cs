namespace Malek_wafik.ViewModels
{
    public class SectionWithVideosViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<VideoViewModel> Videos { get; set; } = new();
    }
}
