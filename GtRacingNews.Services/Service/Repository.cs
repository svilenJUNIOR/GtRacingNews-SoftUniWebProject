using GtRacingNews.Data.DBContext;

namespace GtRacingNews.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
