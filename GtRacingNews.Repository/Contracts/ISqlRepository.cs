using GtRacingNews.Data.DataModels.SqlModels;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Repository.Contracts
{
    public interface ISqlRepository
    {
        void SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        Task AddRangeAsync<T>(List<T> newItems) where T : class;
        Task RemoveAsync<T>(T Item) where T : class;
      
        List<T> GettAll<T>() where T : class;

        IdentityUser FindUserByEmail(string email);
        IdentityUser FindUserById(string Id);
        IdentityRole FindRoleById(string Id);

        Profile FindByUserId(string UserId);
        T FindById<T>(string Id) where T : class;
        T FindByName<T>(string Name) where T : class;
    }
}
