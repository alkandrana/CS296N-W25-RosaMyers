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

        public async Task<IActionResult> Stories()
        {
             var stories = await _repo.GetAllStoriesAsync();
             return View(stories);
        }

        public async Task<IActionResult> Filter(string name, string date)   // note to self: name attribute on the 
        {                                                       // form has to match the parameter passed 
            var stories = await _repo.GetAllStoriesAsync(); // into the action method
            stories = stories.Where(s => name == null || s.Contributor.UserName.Contains(name))
                .Where(s => date == null || s.EntryDate.ToShortDateString() 
                    == DateTime.Parse(date).ToShortDateString())
                .ToList<Story>();
            return View("Stories", stories);
        }
        [Authorize]
        public IActionResult Story() 
        {
            return View();
        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Story(Story model)
        {
            if (model.Contributor == null)  // otherwise, unit tests will fail
            {
                model.Contributor =  _userManager?.GetUserAsync(User).Result;
            }
            model.EntryDate = DateTime.Now;
            if (await _repo.StoreStoryAsync(model) > 0)
            {
                return RedirectToAction("Stories", new { storyId = model.StoryId });
            }
            else
            {
                ViewBag.ErrorMessage = "There was an error saving the story.";
                return View();
            }
        }

        public IActionResult Comment()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
