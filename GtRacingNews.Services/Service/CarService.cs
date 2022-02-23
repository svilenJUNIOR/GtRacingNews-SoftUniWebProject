using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class CarService : ICarService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void AddNewCar(string model, string imageUrl)
        {
            var car = new Car
            {
                ImageUrl = imageUrl,
                Model = model
            };

            context.Cars.Add(car);
            context.SaveChanges();
        }
    }
}
