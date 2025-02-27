using Microsoft.AspNetCore.Mvc;
using OnTolkien.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnTolkien.Data;
using OnTolkien.Models.ViewModels;

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
             AppUser currentUser = await _userManager.GetUserAsync(User);
             ViewBag.CurrentUser = currentUser;
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
        public async Task<IActionResult> Story() 
        {
            ViewBag.Topics = await _repo.GetAllTopicsAsync();
            return View();
        }
        
        [HttpPost]
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

        public async Task<IActionResult> DeleteStoryPost(int storyId)
        {
            Story story = await _repo.GetStoryByIdAsync(storyId);
            AppUser currentUser = await _userManager?.GetUserAsync(User);
            if (currentUser == story.Contributor) // check that user deleting the story is the author of the story
            {
                if (await _repo.DeleteStoryAsync(story) > 0)
                {
                    TempData["Success"] = "Story successfully deleted.";
                    return RedirectToAction("Stories");
                }
                else
                {
                    TempData["ErrorMessage"] = "There was an error deleting the story. Please try again.";
                    return RedirectToAction("Stories");
                }
            }
            else
            {
                TempData["ErrorMessage"] = "There was an error deleting the story. Make sure that you have the proper authorization.";
                return RedirectToAction("Stories");
            }
        }
        
        [Authorize]
        public IActionResult Comment(int storyId)
        {
            CommentVM model = new CommentVM{ StoryId = storyId };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(CommentVM model)
        {
            Comment comment = new Comment {CommentText = model.CommentText};
            comment.Commenter = _userManager.GetUserAsync(User).Result;
            comment.CommentDate = DateTime.Now;
            
            Story story = await _repo.GetStoryByIdAsync(model.StoryId);
            story.Comments.Add(comment);
            await _repo.UpdateStoryAsync(story);
            
            return RedirectToAction("Filter", new { storyId = model.StoryId, contributor = story.Contributor });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
