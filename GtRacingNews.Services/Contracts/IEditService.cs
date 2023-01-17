using GtRacingNews.Data.DataModels.SqlModels;

namespace GtRacingNews.Services.Contracts
{
    public interface IEditService
    {
        T EditObject<T>(string id) where T : class;
    }
}
