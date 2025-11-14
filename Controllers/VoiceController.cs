using System.Threading.Tasks;
using AutoMapper;
using Malek_wafik.Helpers;
using Malek_wafik.Interfaces;
using Malek_wafik.Models;
using Malek_wafik.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Malek_wafik.Controllers
{
    [Authorize]
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
            var voices = await unitOfWork.VoiceRepository.GetAllAsync();
            var voicesVM = mapper.Map<IEnumerable<Voice>, IEnumerable<VoiceViewModel>>(voices);
            return View(voicesVM);
        }
        public async Task<IActionResult> Create() {
            ViewBag.Sections = await unitOfWork.SectionRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VoiceViewModel voiceVM)
        {
            if (ModelState.IsValid) {
                if(voiceVM.AudioFile is not null)
                {
                    voiceVM.AudioFileName = DocumentSettings.UploadFile(voiceVM.AudioFile, "Voices");
                }
                var voice = mapper.Map<VoiceViewModel,Voice>(voiceVM);
                await unitOfWork.VoiceRepository.AddAsync(voice);
                await unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Sections = await unitOfWork.SectionRepository.GetAllAsync();
            return View(voiceVM);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var voice = await unitOfWork.VoiceRepository.GetbyIDAsync(id);
            if (voice is null) { return NotFound(); }
            var voiceVM = mapper.Map<Voice, VoiceViewModel>(voice);
            ViewBag.Sections = await unitOfWork.SectionRepository.GetAllAsync();
            return View(voiceVM);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VoiceViewModel voiceVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (voiceVM.AudioFile is not null)
                    {
                        if (!string.IsNullOrEmpty(voiceVM.AudioFileName))
                            DocumentSettings.DeleteFile(voiceVM.AudioFileName, "Voices");
                        voiceVM.AudioFileName = DocumentSettings.UploadFile(voiceVM.AudioFile, "Voices");
                    }
                    var voice = mapper.Map<VoiceViewModel, Voice>(voiceVM);
                    unitOfWork.VoiceRepository.Update(voice);
                    await unitOfWork.CompleteAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(voiceVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var voice = await unitOfWork.VoiceRepository.GetbyIDAsync(id);
            if (voice is null) return NotFound();
            try
            {
                unitOfWork.VoiceRepository.Delete(voice);
                int res = await unitOfWork.CompleteAsync();
                if (res > 0)
                {
                    DocumentSettings.DeleteFile(voice.AudioFileName, "Voices");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
