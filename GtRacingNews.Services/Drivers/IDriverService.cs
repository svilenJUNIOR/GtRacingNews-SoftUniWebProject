using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Driver;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Drivers
{
    public interface IDriverService
    {
        Task AddNewDriver(AddNewDriverFormModel model, ModelStateDictionary modelState, bool isModerator, string userId);
        void EditDriver(string Id, AddNewDriverFormModel data);
        ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind);
        AddNewDriverFormModel BindDriverForEdit(string Id);
        ICollection<ViewAllDriversViewModel> GetAll();
    }
}
