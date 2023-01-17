using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.Repository.Contracts;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class EditService : IEditService
    {
        private ISqlRepository sqlRepository;

        public EditService(ISqlRepository sqlRepository) 
            => this.sqlRepository = sqlRepository;

        public T EditObject<T>(string id) where T : class
        {
            var objectToEdit = this.sqlRepository.FindById<T>(id);
            return objectToEdit;
        }
    }
}
