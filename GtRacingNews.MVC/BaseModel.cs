namespace GtRacingNews.ViewModels
{
    public class BaseModel
    {
        public string returnChildType()
        {
            return this.GetType().Name;
        }
    }
}
