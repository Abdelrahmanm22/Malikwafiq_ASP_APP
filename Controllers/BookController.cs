using System.Threading.Tasks;
using AutoMapper;
using Malek_wafik.Helpers;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Malek_wafik.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BookController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var books = await unitOfWork.BookRepository.GetAllAsync();
            var booksVM = mapper.Map<IEnumerable<Book>,IEnumerable<BookViewModel>>(books);
            return View(booksVM);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BookViewModel bookVM)
        {
            if (ModelState.IsValid) {
                if(bookVM.Image is not null)
                {
                    bookVM.ImageName = DocumentSettings.UploadFile(bookVM.Image, "BookImages");
                }
                var book = mapper.Map<BookViewModel, Book>(bookVM);
                await unitOfWork.BookRepository.AddAsync(book);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookVM);
        }
    }
}
