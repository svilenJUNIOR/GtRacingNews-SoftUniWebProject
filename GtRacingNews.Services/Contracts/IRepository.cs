namespace GtRacingNews.Services
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
