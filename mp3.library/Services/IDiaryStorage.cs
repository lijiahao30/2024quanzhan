using mp3.library.Models;

namespace mp3.library.Services;

public interface IDiaryStorage
{
    Task InitializeAsync();
    
    Task InsertAsync(Diary diary);
    
    Task<IList<Diary>> ListAsync();
    
    Task<IList<Diary>> QueryAsync(string keyword);
    
    Task UpdateAsync(Diary diary);
    
    Task DeleteAsync(int id);
    
    Task<Diary?> GetByIdAsync(int id);
}