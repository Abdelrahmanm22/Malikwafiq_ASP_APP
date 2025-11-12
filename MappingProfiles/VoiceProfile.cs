using AutoMapper;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;

namespace Malek_wafik.MappingProfiles
{
    public class VoiceProfile : Profile
    {
        public VoiceProfile()
        {
            CreateMap<Voice,VoiceViewModel>().ReverseMap();
        }
    }
}
