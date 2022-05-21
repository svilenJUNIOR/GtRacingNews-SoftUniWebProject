using GtRacingNews.Repository.Contracts;

namespace GtRacingNews.Repositorys.Repositories
{
    public class BaseRepository : IRepository
    {
        public virtual List<string> GetAllNames(string name)
        {
            throw new NotImplementedException();
        }
    }
}
