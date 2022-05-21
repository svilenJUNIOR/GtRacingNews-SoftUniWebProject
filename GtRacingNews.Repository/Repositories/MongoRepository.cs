using GtRacingNews.Repositorys.Repositories;

namespace GtRacingNews.Repository.Repositories
{
    public class MongoRepository : BaseRepository
    {
        public override List<string> GetAllNames(string name)
        {
            return new List<string>();
        }
    }
}
