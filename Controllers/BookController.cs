using System.Threading.Tasks;
using AutoMapper;
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
    }
}
