﻿using GtRacingNews.Data.DataModels;
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
                    Id = x.Id,
                    Name = x.Name,
                    LogoUrl = x.LogoUrl,
                });

            return View(championships);
        }

        public void Temp()
        {
            var championship = context.Championships.Where(x => x.Id == 2).FirstOrDefault();
            var teams = championship.Teams.ToList();
            var drivers = new List<string>();

            foreach (var team in teams)
            {
                drivers.Add(team.Drivers.Select(x => x.Name).FirstOrDefault());
            }
        }
    }
}
