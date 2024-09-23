namespace TheatricalPlayersRefactoringKataAPI.Services
{
    public interface IEntityServices<T> where T : class
    {
        Task<bool> ExistsAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
    }
}
