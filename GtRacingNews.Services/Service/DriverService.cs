﻿using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class DriverService : IDriverService
    {
        private readonly GTNewsDbContext context;
        public DriverService(GTNewsDbContext context)
        {
            this.context = context;
        }
        public async Task AddNewDriver(string name, string cup, string imageUrl, int age, string teamName)
        {
            var team = context.Teams.Where(x => x.Name == teamName).FirstOrDefault();

            var driver = new Driver
            {
                Name = name,
                Cup = cup,
                ImageUrl = imageUrl,
                Age = age,
                TeamId = team.Id
            };

            context.Drivers.Add(driver);
            await context.SaveChangesAsync();
        }
    }
}
