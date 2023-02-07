using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Driver;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Drivers
{
    public interface IDriverService
    {
        public  Task AddNewDriver(AddNewDriverFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
        public void EditDriver(string Id, AddNewDriverFormModel data);
        public ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind);
        public AddNewDriverFormModel BindDriverForEdit(string Id);
        public ICollection<ViewAllDriversViewModel> GetAll();
    }
}
