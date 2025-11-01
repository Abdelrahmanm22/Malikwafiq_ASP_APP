using AutoMapper;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;

namespace Malek_wafik.MappingProfiles
{
    public class SectionProfile : Profile
    {
        public SectionProfile()
        {
            CreateMap<Section, SectionViewModel>().ReverseMap();
        }
    }
}
