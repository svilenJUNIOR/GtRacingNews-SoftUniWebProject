using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Services.Service;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Team;
using Microsoft.AspNetCore.Mvc;

namespace GtRacingNews.Controllers
{
    public class ChampionshipController : Controller
    {
        private readonly IValidator validator = new Validator();
        private readonly IChampionshipService championshipService = new ChampionshipService();
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public async Task<IActionResult> Add() => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewChampionshipFormModel model)
        {
            if (string.IsNullOrEmpty(model.Name)) return Redirect("Add");

            var errors = validator.ValidateAddNewChampionship(model);

            if (errors.Count() == 0)
            {
                championshipService.AddNewChampionship(model.Name, model.LogoUrl);
                return Redirect("/");
            }

            return View("./Error", errors);
        }

        public async Task<IActionResult> All()
        {
            var championships = context.Championships
                .Select(x => new ViewAllChampionshipsViewModel
                {
                    ChampionshipId = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                });

            return View(championships);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var championship = context.Championships.Where(x => x.Id == Id).FirstOrDefault();
            var teams = context.Teams.Where(x => x.ChampionshipId == championship.Id).ToList();
            var drivers = new Dictionary<string, List<string>>();

            foreach (var team in teams)
            {
                var driversToAdd = context.Drivers.Where(x => x.TeamId == team.Id).Select(x => x.Name).ToList();
                drivers.Add(team.Name, driversToAdd);
            }

            ViewDetailsViewModel viewModel = new ViewDetailsViewModel();

            viewModel.ChampionshipName = championship.Name;
            viewModel.Drivers = drivers;
            viewModel.Teams = teams;

            return View(viewModel);
        }
    }
}
