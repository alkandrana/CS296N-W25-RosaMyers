using OnTolkien.Models;
using Microsoft.EntityFrameworkCore;
namespace OnTolkien.Data;

public class StoryRepository : IStoryRepository
{
    private AppDbContext _context;
    
    public StoryRepository(AppDbContext ctx)
    {
        _context = ctx;
    }

    public List<Story> GetAllStories()
    {
        var stories = _context.Stories.Include(story => story.Contributor).ToList();

        return stories;
    }

    public Story? GetStoryById(int id)
    {
        var story = _context.Stories 
            .Include(story => story.Contributor)
            .SingleOrDefault(story => story.StoryId == id);
        return story;
    }
   
    public int StoreStory(Story model)
    {
        model.EntryDate = DateTime.Now;
        _context.Stories.Add(model);
        return _context.SaveChanges();
    }
    
    
}