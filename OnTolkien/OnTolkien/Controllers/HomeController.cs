using Microsoft.AspNetCore.Mvc;
using OnTolkien.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnTolkien.Data;

namespace OnTolkien.Controllers
{
    public class HomeController : Controller
    {
        private IStoryRepository _repo;
        private UserManager<AppUser>? _userManager;

        public HomeController(IStoryRepository r, UserManager<AppUser>? userMngr)
        {
            _repo = r;
            _userManager = userMngr;
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
        [Authorize]
        public IActionResult Story() 
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public IActionResult Story(Story model)
        {
            if (model.Contributor == null)  // otherwise, unit tests will fail
            {
                model.Contributor = _userManager?.GetUserAsync(User).Result;
            }
            model.EntryDate = DateTime.Now;
            if (model.Contributor == null)
            {
                ViewBag.ErrorMessage = "There was a problem saving your story. Did you make sure you are logged in?";
                return View();
            }
            else if (_repo.StoreStory(model) > 0)
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
