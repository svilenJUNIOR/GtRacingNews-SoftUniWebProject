﻿using GtRacingNews.Common.Constants;
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
            IEnumerable<Exception> NullErrors = this.guard.AgainstNull(model.Name, model.TeamName, model.ImageUrl, model.Age.ToString(), model.Cup);
            IEnumerable<Exception> ModelStateErrorsErrors = this.guard.CheckModelState(modelState);

            ICollection<Exception> Errors = this.guard.CollectErrors(NullErrors, ModelStateErrorsErrors);

            var doesExist = this.sqlRepository.GettAll<Driver>().Any(x => x.Name == model.Name);
            var teamId = this.sqlRepository.GettAll<Team>().FirstOrDefault(x => x.Name == model.TeamName).Id;

            if (doesExist) Errors.Add(new ArgumentException(Messages.ExistingDriver));

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
