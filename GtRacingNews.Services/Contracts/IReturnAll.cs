﻿using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Team;

namespace GtRacingNews.Services.Contracts
{
    public interface IReturnAll
    {
        ViewTeamsAndChampsViewModel AllTeams();
        public IEnumerable<object> All(string Entity);

        ReadNewsViewModel NewsDetails(string Id);
    }
}
