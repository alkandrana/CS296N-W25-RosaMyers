using Microsoft.AspNetCore.Mvc;
using OnTolkien.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using OnTolkien.Data;

namespace OnTolkien.Controllers
{
    public class HomeController : Controller
    {

        private IStoryRepository _repo;

        public HomeController(IStoryRepository r)
        {
            _repo = r;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Stories()
        {
             var stories = _repo.GetAllStories();
             return View(stories);
        }

        public IActionResult Filter(string name, string date)   // note to self: name attribute on the 
        {                                                       // form has to match the parameter passed 
            var stories = _repo.GetAllStories(); // into the action method
            stories = stories.Where(s => name == null || s.Contributor.UserName.Contains(name))
                .Where(s => date == null || s.EntryDate.ToShortDateString() 
                    == DateTime.Parse(date).ToShortDateString())
                .ToList();
            return View("Stories", stories);
        }

        public IActionResult Story() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Story(Story model)
        {
            model.EntryDate = DateTime.Now;
            if (_repo.StoreStory(model) > 0)
            {
                return RedirectToAction("Stories", new { storyId = model.StoryId });
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the story.";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
