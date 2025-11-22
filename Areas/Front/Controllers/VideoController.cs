using System.Threading.Tasks;
using AutoMapper;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Malek_wafik.Repositories;
using Malek_wafik.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Malek_wafik.Areas.Front.Controllers
{
    [Area("Front")]
    public class VideoController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VideoController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var books = await unitOfWork.BookRepository.GetAllAsync();
            var booksVM = mapper.Map<IEnumerable<Book>, IEnumerable<BookViewModel>>(books);
            return View(booksVM);
        }
        public async Task<IActionResult> Sections(int bookId)
        {
            var book = await unitOfWork.BookRepository.GetbyIDAsync(bookId);
            var sections = await unitOfWork.SectionRepository.GetSectionsByBookIdAsync(bookId);
            if (!sections.Any())
            {
                return NotFound();
            }
            var viewModel = new BookWithSectionsViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Discription = book.Discription,
                ImageName = book.ImageName,
                Sections = sections.Select(s => new SectionWithVideosViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    Videos = s.Videos.Select(v => new VideoViewModel
                    {
                        Id = v.Id,
                        Title = v.Title,
                    }).ToList()
                }).ToList(),
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Watch(int videoId)
        {
            var video = await unitOfWork.VideoRepository.GetbyIDAsync(videoId);
            if (video is null)return NotFound();
            var videoVM = mapper.Map<VideoViewModel>(video);
            return View(videoVM);
        }

    }
}
