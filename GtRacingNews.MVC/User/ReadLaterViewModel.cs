namespace GtRacingNews.ViewModels.User
{
    public class ReadLaterViewModel
    {
        public ICollection<Data.DataModels.News> News { get; set; } = new List<Data.DataModels.News>();
    }
}
