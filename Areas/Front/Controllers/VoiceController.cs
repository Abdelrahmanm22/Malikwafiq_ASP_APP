using System.Threading.Tasks;
using AutoMapper;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Malek_wafik.Areas.Front.Controllers
{
    [Area("Front")]
    public class VoiceController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VoiceController(IUnitOfWork unitOfWork,IMapper mapper)
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
            var sections = await unitOfWork.SectionRepository.GetSectionsWithVoiceCountByBookIdAsync(bookId);
            var viewModel = new BookWithSectionsVoiceViewModel
            {
                BookId = book.Id,
                BookName = book.Name,
                Sections = sections.Select(s => new SectionVoiceViewModel
                {
                    Id = s.Id,
                    Title = s.Title,
                    VoiceCount = s.Voices.Count
                }).ToList()
            };
            return View(viewModel);
        }
        public async Task<IActionResult> Listen(int sectionId)
        {
            var section = await unitOfWork.SectionRepository
                .GetSectionWithVoicesAsync(sectionId);
            if (section is null)
            {
                return NotFound();
            }
            var model = new SectionWithVoicesViewModel
            {
                SectionId = section.Id,
                SectionTitle = section.Title,
                BookName = section.Book.Name,
                Voices = mapper.Map<IEnumerable<VoiceViewModel>>(section.Voices)
            };
            return View(model);
        }
    }
}
