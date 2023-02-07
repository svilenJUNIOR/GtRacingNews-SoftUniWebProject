using GtRacingNews.Common.Constants;
using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Others.Contracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;

namespace GtRacingNews.Services.Others
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
        public IEnumerable<Exception> ValidateTeam(string Name)
        {
            var errors = new List<Exception>();

            if (sqlRepository.GettAll<Team>().FirstOrDefault(x => x.Name == Name) != null)
                errors.Add(new ArgumentException(Messages.ExistingTeam));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateChampionship(string Name)
        {
            var errors = new List<Exception>();

            if (sqlRepository.GettAll<Championship>().FirstOrDefault(x => x.Name == Name) != null)
                errors.Add(new ArgumentException(Messages.ExistingChampionship));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateNews(string Heading)
        {
            var errors = new List<Exception>();

            if (sqlRepository.GettAll<News>().FirstOrDefault(x => x.Heading == Heading) != null)
                errors.Add(new ArgumentException(Messages.ExistingNews));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateRace(string Name)
        {
            var errors = new List<Exception>();

            if (sqlRepository.GettAll<Race>().FirstOrDefault(x => x.Name == Name) != null)
                errors.Add(new ArgumentException(Messages.ExistingRace));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> ValidateDriver(string Name)
        {
            var errors = new List<Exception>();

            if (sqlRepository.GettAll<Driver>().FirstOrDefault(x => x.Name == Name) != null)
                errors.Add(new ArgumentException(Messages.ExistingDriver));

            return ThrowErrors(errors);
        }
        public IEnumerable<Exception> CollectModelStateErrors(ModelStateDictionary modelState)
        {
            var errors = new List<Exception>();

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
