using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.ViewModels.Driver;

namespace GtRacingNews.Services.Driver
{
    public interface IDriverService
    {
        public  Task AddNewDriver(string name, string cup, string imageUrl, int age, string teamName, bool isModerator, string userId);
        public void EditDriver(string Id, AddNewDriverFormModel data);
        public ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind);
        public AddNewDriverFormModel BindDriverForEdit(string Id);
        public ICollection<Driver> GetAll();
    }
}
