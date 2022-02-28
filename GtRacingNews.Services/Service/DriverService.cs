﻿using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class DriverService : IDriverService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void AddNewDriver(string name, string cup, string imageUrl, int age)
        {
            var driver = new Driver
            {
                Name = name,
                Cup = cup,
                ImageUrl = imageUrl,
                Age = age,
            };

            context.Drivers.Add(driver);
            context.SaveChanges();
        }

        public void AddToTeam(int teamId, int driverId)
        {
            var team = context.Teams.Where(x => x.Id == teamId).FirstOrDefault();

            var driver = context.Drivers.Where(x => x.Id == driverId).FirstOrDefault();

            team.Drivers.Add(driver);

            context.SaveChanges();
        }
    }
}