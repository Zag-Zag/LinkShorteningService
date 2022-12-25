using Microsoft.AspNetCore.Mvc;

namespace LinkShorteningService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
