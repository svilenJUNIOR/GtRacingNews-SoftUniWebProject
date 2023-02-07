using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Others.Contracts;
using GtRacingNews.ViewModels.Driver;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Drivers
{
    public class DriverService : IDriverService
    {
        private ISqlRepository sqlRepository;
        private IGuard guard;

        public DriverService(ISqlRepository sqlRepository, IGuard guard)
        {
            this.sqlRepository = sqlRepository;
            this.guard = guard;
        }

        public async Task AddNewDriver(AddNewDriverFormModel model, ModelStateDictionary modelState,bool isModerator, string userId)
        {
            ICollection<Exception> Errors = this.guard.CheckModelState(modelState);

            if (Errors.Any()) this.guard.ThrowErrors(Errors);

            var doesExist = this.sqlRepository.GettAll<Driver>().Any(x => x.Name == model.Name);
            if (doesExist)
            {
                Errors.Clear();
                Errors.Add(new ArgumentException(Messages.ExistingDriver));
                this.guard.ThrowErrors(Errors);
            }

            var teamId = this.sqlRepository.GettAll<Team>().FirstOrDefault(x => x.Name == model.TeamName).Id;
            var driver = new Driver(model.Name, model.Age, model.Cup, model.ImageUrl, teamId);

            if (isModerator) driver.UserId = userId;

            await sqlRepository.AddAsync<Driver>((Driver)driver);
        }
       
        public void EditDriver(string Id, AddNewDriverFormModel data)
        {
            var driver = this.sqlRepository.FindById<Driver>(Id);

            driver.ImageUrl = data.ImageUrl;
            driver.Name = data.Name;
            driver.Age = data.Age;
            driver.Cup = data.Cup;

            this.sqlRepository.SaveChangesAsync();
        }
       
        public ICollection<ViewAllDriversViewModel> DriverBind(ICollection<Driver> driversToBind)
        {
            var bindedDrivers = driversToBind.Select(x => new ViewAllDriversViewModel
            {
                Age = x.Age,
                Cup = x.Cup,
                DriverId = x.Id,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
            }).ToList();

            return bindedDrivers;
        }
       
        public AddNewDriverFormModel BindDriverForEdit(string Id)
        {
            var driver = this.sqlRepository.FindById<Driver>(Id);

            var driverToEdit = new AddNewDriverFormModel()
            {
                Age = driver.Age,
                Cup = driver.Cup,
                ImageUrl = driver.ImageUrl,
                Name = driver.Name,
                TeamName = this.sqlRepository.GettAll<Team>().
                FirstOrDefault(x => x.Id == driver.TeamId).Name,
                Teams = this.sqlRepository.GettAll<Team>()
            };

            return driverToEdit;
        }

        public ICollection<ViewAllDriversViewModel> GetAll()
            => DriverBind(sqlRepository.GettAll<Driver>());
    }
}
