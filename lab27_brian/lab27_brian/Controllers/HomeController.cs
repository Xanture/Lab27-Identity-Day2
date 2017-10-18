using Microsoft.AspNetCore.Mvc;

namespace lab27_brian.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
