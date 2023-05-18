using FakeItEasy;
using GtRacingNews.Controllers;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Services.Championships;
using GtRacingNews.Services.Drivers;
using GtRacingNews.Services.Newss;
using GtRacingNews.Services.Races;
using GtRacingNews.Services.Teams;
using GtRacingNews.ViewModels.Championship;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GtRacingNews.Test.Controllers
{
    public class AllControllerTest
    {
        private IChampionshipService championshipService;
        private IDriverService driverService;
        private INewsService newsService;
        private IRaceService raceService;
        private ITeamService teamService;
        public AllControllerTest()
        {
            this.championshipService = A.Fake<IChampionshipService>();
            this.driverService = A.Fake<IDriverService>();
            this.newsService = A.Fake<INewsService>();
            this.raceService = A.Fake<IRaceService>();
            this.teamService = A.Fake<ITeamService>();
        }

        [Fact]

        public async void AllChampionshipsMethodShouldReturnListOfChampionships()
        {
            var fakeChampionshipsService = A.Fake<IChampionshipService>();

            A.CallTo(() => fakeChampionshipsService.GetAll())
            .Returns(new List<ViewAllChampionshipsViewModel>
            {
                new ViewAllChampionshipsViewModel(),
                new ViewAllChampionshipsViewModel(),
                new ViewAllChampionshipsViewModel(),
            });

            var allController = new AllController(championshipService, driverService,
                newsService, raceService, teamService);

            var result = await allController.AllChampionships();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ViewAllChampionshipsViewModel>>(viewResult.ViewData.Model);

        }
    }
}
