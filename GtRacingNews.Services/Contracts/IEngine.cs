﻿using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Contracts
{
    public  interface IEngine
    {
        Task<ICollection<string>> AddTeam(bool isModerator, string userId, AddTeamFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<string>> AddNews(bool isModerator, string userId, AddNewFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<string>> AddRace(bool isModerator, string userId, AddNewRaceFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<string>> AddDriver(bool isModerator, string userId, AddNewDriverFormModel model, string type, ModelStateDictionary modelState);
        Task<ICollection<string>> AddChampionship(bool isModerator, string userId, AddNewChampionshipFormModel model, string type, ModelStateDictionary modelState);

        ICollection<string> CollectErrors(ICollection<string> dataErrors, ICollection<string> nullErrors, ModelStateDictionary modelState);
    }
}
