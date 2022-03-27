namespace GtRacingNews.Services
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
