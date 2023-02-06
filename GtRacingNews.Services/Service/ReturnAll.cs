﻿using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Service
{
    public class ReturnAll : IReturnAll
    {
        private readonly ISqlRepository sqlRepository;
        private readonly IBindService bindService;
        public ReturnAll(ISqlRepository sqlRepository, IBindService bindService)
        {
            this.sqlRepository = sqlRepository;
            this.bindService = bindService;
        }

        public ViewTeamsAndChampsViewModel AllTeams()
            => this.bindService.TeamsAndChampsBind(sqlRepository.GettAll<Team>());

        public IEnumerable<object> All(string Entity)
        {
            if (Entity == "Races") return this.bindService.RaceBind(sqlRepository.GettAll<Race>());


            return null;
        }

        
    }
}
