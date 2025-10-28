using AutoMapper;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;

namespace Malek_wafik.MappingProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, BookViewModel>().ReverseMap();
        }
    }
}
