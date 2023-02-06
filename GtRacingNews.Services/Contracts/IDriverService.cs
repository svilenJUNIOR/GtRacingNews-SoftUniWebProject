using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Repositories;
using GtRacingNews.ViewModels.Driver;

namespace GtRacingNews.Services.Contracts
{
    public interface IDriverService
    {
        //add
        public async Task AddNewDriver(string name, string cup, string imageUrl, int age, string teamName, bool isModerator, string userId)
        {
            var teamId = sqlRepository.GettAll<Team>().FirstOrDefault(x => x.Name == teamName).Id;
            var driver = new Driver(name, age, cup, imageUrl, teamId);

            if (isModerator) driver.UserId = userId;

            await sqlRepository.AddAsync<Driver>((Driver)driver);
        }
        //edit
        public void EditDriver(string Id, AddNewDriverFormModel data)
        {
            var driver = this.sqlRepository.FindById<Driver>(Id);

            driver.ImageUrl = data.ImageUrl;
            driver.Name = data.Name;
            driver.Age = data.Age;
            driver.Cup = data.Cup;

            this.sqlRepository.SaveChangesAsync();
        }
        //bind
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
        //get
         this.bindService.DriverBind(sqlRepository.GettAll<Driver>());
    }
}
