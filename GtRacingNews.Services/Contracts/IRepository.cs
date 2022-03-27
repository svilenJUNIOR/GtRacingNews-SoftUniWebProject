namespace GtRacingNews.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task Remove(TEntity entity);
    }
}
