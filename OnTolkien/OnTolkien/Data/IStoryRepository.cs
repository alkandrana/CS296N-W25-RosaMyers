using OnTolkien.Models;
namespace OnTolkien.Data;

public interface IStoryRepository
{
    public List<Story> GetAllStories(); 
    public Story? GetStoryById(int id);
    public int StoreStory(Story model);
}