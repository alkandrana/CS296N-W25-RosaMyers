using OnTolkien.Data;
using OnTolkien.Models;
namespace OnTolkienTests;

public class FakeStoryRepository : IStoryRepository
{
    private List<Story> _stories = new List<Story>();
    private List<Topic> _topics = new List<Topic>();

    public async Task<List<Topic>> GetAllTopicsAsync()
    {
        return _topics;
    }

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

    public Task<int> UpdateStoryAsync(Story model)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteStoryAsync(Story story)
    {
        throw new NotImplementedException();
    }

    public int DeleteStory(Story story)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Story>> GetAllStoriesAsync()
    {
        return _stories;
    }
}