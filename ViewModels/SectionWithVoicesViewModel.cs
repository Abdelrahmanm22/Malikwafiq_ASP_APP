namespace Malek_wafik.ViewModels;

public class SectionWithVoicesViewModel
{
    public int SectionId { get; set; }
    public string SectionTitle { get; set; }
    public string BookName { get; set; }
    public IEnumerable<VoiceViewModel> Voices { get; set; } = Enumerable.Empty<VoiceViewModel>();
}