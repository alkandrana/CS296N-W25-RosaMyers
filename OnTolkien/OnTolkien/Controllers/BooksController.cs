using Microsoft.AspNetCore.Mvc;

namespace OnTolkien.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
