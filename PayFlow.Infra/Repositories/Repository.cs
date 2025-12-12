using PayFlow.Domain.Interfaces;
using PayFlow.Infra.Data;

namespace PayFlow.Infra.Repositories
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public T? Add<T>(T obj) where T : class
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public async Task<T?> AddAsync<T>(T obj) where T : class
        {
            await _context.Set<T>().AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
