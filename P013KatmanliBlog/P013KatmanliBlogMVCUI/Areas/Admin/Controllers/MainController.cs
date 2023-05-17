using Microsoft.AspNetCore.Mvc;

namespace P013KatmanliBlogMVCUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
