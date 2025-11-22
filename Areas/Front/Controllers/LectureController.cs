using Microsoft.AspNetCore.Mvc;

namespace Malek_wafik.Areas.Front.Controllers
{
    [Area("Front")]
    public class LectureController : Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
