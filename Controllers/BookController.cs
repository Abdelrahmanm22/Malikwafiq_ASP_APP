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
        public async Task<IActionResult> Edit(int id)
        {
            var book = await unitOfWork.BookRepository.GetbyIDAsync(id);
            if(book is null)
            {
                return NotFound();
            }
            var bookVM = mapper.Map<Book, BookViewModel>(book);
            return View(bookVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(BookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(bookVM.Image is not null)
                    {
                        if (!string.IsNullOrEmpty(bookVM.ImageName))
                            DocumentSettings.DeleteFile(bookVM.ImageName, "BookImages");
                        bookVM.ImageName = DocumentSettings.UploadFile(bookVM.Image, "BookImages");
                    }
                    var book = mapper.Map<BookViewModel, Book>(bookVM);
                    unitOfWork.BookRepository.Update(book);
                    await unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(bookVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var book = await unitOfWork.BookRepository.GetbyIDAsync(id);
            if(book is null)
            {
                return NotFound();
            }
            try
            {
                unitOfWork.BookRepository.Delete(book);
                int res = await unitOfWork.CompleteAsync();
                if (res > 0)
                {
                    DocumentSettings.DeleteFile(book.ImageName, "BookImages");
                }
            }catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
