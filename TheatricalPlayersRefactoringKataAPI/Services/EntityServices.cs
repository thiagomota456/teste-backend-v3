using Microsoft.EntityFrameworkCore;
using TheatricalPlayersRefactoringKataAPI.Data;

namespace TheatricalPlayersRefactoringKataAPI.Services
{
    public class EntityServices<T> : IEntityServices<T> where T : class
    {
        internal readonly ApplicationDbContext _context;
        public EntityServices(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
