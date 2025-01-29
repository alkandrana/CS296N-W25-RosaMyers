using OnTolkien.Data;
using OnTolkien.Models;
namespace OnTolkienTests;

public class FakeStoryRepository : IStoryRepository
{
    private List<Story> _stories = new List<Story>();

    public Story? GetStoryById(int id)
    {
        Story? story = _stories.Find(r => r.StoryId == id);
        return story;
    }
    
    public int StoreStory(Story? model)
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

    public List<Story> GetAllStories()
    {
        return _stories;
    }
}