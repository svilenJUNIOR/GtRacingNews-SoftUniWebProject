﻿using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Service
{
    public class Guard : IGuard
    {
        private readonly ISqlRepository sqlRepository;
        public Guard(ISqlRepository sqlRepository) => this.sqlRepository = sqlRepository;

        public IEnumerable<Exception> AgainstNull(params string[] args)
        {
            var errors = new List<Exception>();
            bool check = false;

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    check = true;

            if (check) errors.Add(new ArgumentNullException(Messages.NullField));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateObject(string dbset, string check, ModelStateDictionary modelState)
        {
            var errors = new List<Exception>();

            if (dbset == "Team")
                if (sqlRepository.FindByName<Team>(check) != null) errors.Add(new ArgumentException(Messages.ExistingTeam));

            if (dbset == "Championship")
                if (sqlRepository.FindByName<Championship>(check) != null) errors.Add(new ArgumentException(Messages.ExistingChampionship));

            if (dbset == "News")
                if (sqlRepository.FindByName<News>(check) != null) errors.Add(new ArgumentException(Messages.ExistingNews));

            if (dbset == "Race")
                if (sqlRepository.FindByName<Race>(check) != null) errors.Add(new ArgumentException(Messages.ExistingRace));

            if (dbset == "Driver")
                if (sqlRepository.FindByName<Driver>(check) != null) errors.Add(new ArgumentException(Messages.ExistingDriver));

            var modelStateErrors = CheckModelState(modelState);

            if (modelStateErrors.Count() > 0) errors.AddRange(modelStateErrors);

            return ThrowErrors(errors);
        }
        
        public IEnumerable<Exception> CheckModelState(ModelStateDictionary modelState)
        {
            var errors = new List<Exception>();

            if (!modelState.IsValid)
                foreach (var values in modelState.Values)
                    foreach (var modelError in values.Errors)
                        errors.Add(new ArgumentException(modelError.ErrorMessage));

            return errors;
        }
        public IEnumerable<Exception> ThrowErrors(ICollection<Exception> errors)
        {
            if (errors.Count == 0) return new List<Exception>();
            throw new AggregateException(errors);
        }
    }
}