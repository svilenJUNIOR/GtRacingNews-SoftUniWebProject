using GtRacingNews.Data.DBContext;

namespace GtRacingNews.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
