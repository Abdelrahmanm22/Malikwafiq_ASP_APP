using System.Threading.Tasks;
using AutoMapper;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Malek_wafik.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class VideoController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public VideoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var videos = await unitOfWork.VideoRepository.GetAllAsync();
            var videosVM = mapper.Map<IEnumerable<Video>, IEnumerable<VideoViewModel>>(videos);
            return View(videosVM);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Sections = await unitOfWork.SectionRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VideoViewModel videoVM)
        {
            if (ModelState.IsValid)
            {
                var video = mapper.Map<VideoViewModel, Video>(videoVM);
                await unitOfWork.VideoRepository.AddAsync(video);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Sections = await unitOfWork.SectionRepository.GetAllAsync();
            return View(videoVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var video = await unitOfWork.VideoRepository.GetbyIDAsync(id);
            if (video is null) return NotFound();

            var videoVM = mapper.Map<Video, VideoViewModel>(video);
            ViewBag.Sections = await unitOfWork.SectionRepository.GetAllAsync();
            return View(videoVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VideoViewModel videoVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var video = mapper.Map<VideoViewModel, Video>(videoVM);
                    unitOfWork.VideoRepository.Update(video);
                    await unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            ViewBag.Sections = await unitOfWork.SectionRepository.GetAllAsync();
            return View(videoVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var video = await unitOfWork.VideoRepository.GetbyIDAsync(id);
            if (video is null) return NotFound();

            try
            {
                unitOfWork.VideoRepository.Delete(video);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
