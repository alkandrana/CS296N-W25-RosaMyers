using OnTolkien.Data;
using OnTolkien.Models;
namespace OnTolkienTests;

public class FakeStoryRepository : IStoryRepository
{
    private List<Story> _stories = new List<Story>();

    public async Task<Story?>? GetStoryByIdAsync(int id)
    {
        Story? story = _stories.Find(r => r.StoryId == id);
        return story;
    }
    
    public async Task<int> StoreStoryAsync(Story? model)
    {
        int status = 0;
        if (model != null && model.Contributor != null)
        {
            model.StoryId = _stories.Count + 1;
            _stories.Add(model);
            status = 1;    
        }
        return status;
    }

    public async Task<List<Story>> GetAllStoriesAsync()
    {
        return _stories;
    }
}