﻿using GtRacingNews.Common.Constants;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Service
{
    public class Validator : IValidator
    {
        private readonly IHasher hasher;
        private readonly IRepository repository;
        public Validator(IHasher hasher, IRepository repository)
        {
            this.hasher = hasher;
            this.repository = repository;
        }
        public ICollection<string> AgainstNull(params string[] args)
        {
            var errors = new List<string>();
            bool check = false;

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    check = true;

            if (check) errors.Add(Messages.NullField);

            return errors;
        }

        public IEnumerable<string> ValidateForm(ModelStateDictionary modelState)
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

        public IEnumerable<string> ValidateUserLogin(LoginUserFormModel model)
        {
            var errors = new List<string>();
            var users = repository.GettAll<IdentityUser>();

            if (!users.Any(x => x.Email == model.Email)) errors.Add(Messages.UnExistingEmail);
            if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(Messages.UnExistingPassword);

            return errors;
        }
        public IEnumerable<string> ValidateUserRegister(RegisterUserFormModel model)
        {
            var errors = new List<string>();
            var users = repository.GettAll<IdentityUser>();

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

        public IEnumerable<string> ValidateObject(string dbset, string check, ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            if (dbset == "Team")
                if (repository.FindTeamByName(check) == null) errors.Add(Messages.ExistingTeam);

            if (dbset == "Championship") 
                if (repository.FindChampionshipByName(check) == null) errors.Add(Messages.ExistingChampionship);

            if (dbset == "News") 
                if (repository.FindNewsByName(check) == null) errors.Add(Messages.ExistingNews);

            if (dbset == "Race") 
                if (repository.FindRaceByName(check) == null) errors.Add(Messages.ExistingRace);

            if (dbset == "Driver") 
                if (repository.FindDriverByName(check) == null) errors.Add(Messages.ExistingDriver);

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
    }
}
