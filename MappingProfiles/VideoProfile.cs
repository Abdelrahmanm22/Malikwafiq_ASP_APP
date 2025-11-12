using AutoMapper;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;

namespace Malek_wafik.MappingProfiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile()
        {
            CreateMap<Video, VideoViewModel>().ReverseMap();
        }
    }
}
