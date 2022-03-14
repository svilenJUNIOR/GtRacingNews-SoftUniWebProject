using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.Common.Constants;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Race;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Service
{
    public class Validator : IValidator
    {
        private readonly GTNewsDbContext context = new GTNewsDbContext();
        public IEnumerable<string> ValidateUserRegister(ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            if (!modelState.IsValid)
            {
                foreach (var values in modelState.Values)
                {
                    foreach (var modelError in values.Errors)
                    {
                        errors.Add(modelError.ErrorMessage);
                    }
                }
            }
            return errors;
        }

        public IEnumerable<string> ValidateAddNews(AddNewFormModel model)
        {
            var errors = new List<string>();

            if (context.News.Any(x => x.Heading == model.Heading))
                errors.Add(Messages.ExistingNews);

            return errors;
        }

        public IEnumerable<string> ValidateAddNewTeam(AddTeamFormModel model)
        {
            var errors = new List<string>();

            if (context.Teams.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingTeam);

            return errors;
        }

        public IEnumerable<string> ValidateAddNewChampionship(AddNewChampionshipFormModel model)
        {
            var errors = new List<string>();

            if (context.Championships.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingChampionship);

            return errors;
        }

        public IEnumerable<string> ValidateAddNewDriver(AddNewDriverFormModel model)
        {
            var errors = new List<string>();

            if (context.Drivers.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingDriver);

            return errors;
        }

        public IEnumerable<string> ValidateAddDriverToTeam(int teamId)
        {
            var errors = new List<string>();

            var team = context.Teams.Where(x => x.Id == teamId).FirstOrDefault();

            if (team.Drivers.Count() >= 3) errors.Add(Messages.DriverListFull);

            return errors;
        }

        public IEnumerable<string> ValidateAddRace(AddNewRaceFormModel model)
        {
            var errors = new List<string>();

            if (context.Races.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingRace);

            return errors;
        }
    }
}
