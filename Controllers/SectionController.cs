using System.Threading.Tasks;
using AutoMapper;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Malek_wafik.Controllers
{
    public class SectionController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public SectionController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var sections = await unitOfWork.SectionRepository.GetAllAsync();
            var sectionsVM = mapper.Map<IEnumerable<Section>, IEnumerable<SectionViewModel>>(sections);
            return View(sectionsVM);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Books = await unitOfWork.BookRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SectionViewModel sectionVM)
        {
            if (ModelState.IsValid)
            {
                var section = mapper.Map<SectionViewModel,Section>(sectionVM);
                await unitOfWork.SectionRepository.AddAsync(section);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectionVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var section = await unitOfWork.SectionRepository.GetbyIDAsync(id);
            if(section is null)
            {
                return NotFound();
            }
            var sectionVM = mapper.Map<Section, SectionViewModel>(section);
            ViewBag.Books = await unitOfWork.BookRepository.GetAllAsync();
            return View(sectionVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SectionViewModel sectionVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var section = mapper.Map<SectionViewModel, Section>(sectionVM);
                    unitOfWork.SectionRepository.Update(section);
                    await unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(sectionVM);
        }
        public async Task<IActionResult> Delete(int id) {
            var section = await unitOfWork.SectionRepository.GetbyIDAsync(id);
            if (section is null) {
                return NotFound();
            }
            try
            {
                unitOfWork.SectionRepository.Delete(section);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex) {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
