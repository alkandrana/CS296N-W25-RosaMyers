using OnTolkien.Models;
namespace OnTolkien.Data;

public interface IStoryRepository
{
    public Task<List<Story>> GetAllStoriesAsync(); 
    public Task<Story?>? GetStoryByIdAsync(int id);
    public Task<int> StoreStoryAsync(Story model);

    public Task<int> UpdateStoryAsync(Story model);
}