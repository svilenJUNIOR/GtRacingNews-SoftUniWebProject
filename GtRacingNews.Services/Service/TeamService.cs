﻿using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class TeamService : ITeamService
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public void AddNewTeam(string name, string carModel, string logoUrl)
        {
            var team = new Team
            {
                Name = name,
                CarModel = carModel,
                LogoUrl = logoUrl
            };

            context.Teams.Add(team);
            context.SaveChangesAsync();
        }

        public void AddTeamToChampionship(int teamId, string championshipName)
        {
            var team = context.Teams.Where(x => x.Id == teamId).FirstOrDefault();
            var championship = context.Championships.Where(x => x.Name == championshipName).FirstOrDefault();

            championship.Teams.Add(team);

            context.SaveChangesAsync();
        }
    }
}
