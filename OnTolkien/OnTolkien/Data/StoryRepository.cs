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

    public async Task<List<Story>> GetAllStoriesAsync()
    {
        var stories = _context.Stories.Include(story => story.Contributor)
            .Include(story => story.Comments)
            .ThenInclude(c => c.Commenter).ToListAsync();

        return await stories;
    }

    public async Task<Story?>? GetStoryByIdAsync(int id)
    {
        var story = await _context.Stories 
            .Include(story => story.Contributor)
            .Include(story => story.Comments)
            .ThenInclude(c => c.Commenter)
            .SingleOrDefaultAsync(story => story.StoryId == id);
        return story;
    }
   
    public async Task<int> StoreStoryAsync(Story model)
    {
        model.EntryDate = DateTime.Now;
        await _context.Stories.AddAsync(model);
        return await _context.SaveChangesAsync();
    }
    
    
}