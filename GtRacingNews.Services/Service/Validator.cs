﻿using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.Championship;
using GtRacingNews.ViewModels.Driver;
using GtRacingNews.ViewModels.News;
using GtRacingNews.ViewModels.Race;
using GtRacingNews.ViewModels.Team;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Service
{
    public class Validator : IValidator
    {
        private readonly GTNewsDbContext context;
        private readonly IHasher hasher;
        public Validator(GTNewsDbContext context, IHasher hasher)
        {
            this.context = context;
            this.hasher = hasher;
        }

        public IEnumerable<string> ValidateUserLogin(LoginUserFormModel model)
        {
            var errors = new List<string>();
            var users = context.Users.ToList();

            if (!users.Any(x => x.Email == model.Email)) errors.Add(Messages.UnExistingEmail);
            if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(Messages.UnExistingPassword);

            return errors;
        }
        public IEnumerable<string> ValidateUserRegister(RegisterUserFormModel model)
        {
            var errors = new List<string>();
            var users = context.Users.ToList();

            if (users.Any(x => x.Email == model.Email)) errors.Add(Messages.ExistingEmail);
            if (users.Any(x => x.UserName == model.Username)) errors.Add(Messages.ExistingUsername);
            if (!model.Email.EndsWith("@email.com")) errors.Add(String.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail));

            if (model.Username.Length < Values.MinUsernameLength && model.Username.Length > Values.MaxUsernameLength)
                errors.Add(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength));

            if (model.Password.Length < Values.MinPasswordLength)
                errors.Add(string.Format(Messages.WrongPasswordFormat, Values.MinUsernameLength));

            if (model.Password != model.ConfirmPassword) errors.Add(Messages.PasswordsDontMatch);

            return errors;
        }

        public IEnumerable<string> ValidateUserFormRegister(ModelStateDictionary modelState)
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

        public IEnumerable<string> ValidateAddRace(AddNewRaceFormModel model)
        {
            var errors = new List<string>();

            if (context.Races.Any(x => x.Name == model.Name))
                errors.Add(Messages.ExistingRace);

            return errors;
        }
    }
}
