using Microsoft.AspNetCore.Mvc;

namespace OnTolkien.Controllers
{
    public class SourcesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult FanSites() 
        { 
            return View();
        }
    }
}
