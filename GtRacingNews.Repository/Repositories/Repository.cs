using GTNewsSecondVersion.Repository.Contracts;

namespace GTNewsSecondVersion.Repository.Repositories
{
    public class Repository : IRepository
    {
        public virtual List<string> GetAllNames(string name)
        {
            throw new NotImplementedException();
        }
    }
}
