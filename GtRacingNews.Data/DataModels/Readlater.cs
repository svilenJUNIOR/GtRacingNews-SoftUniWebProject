namespace GtRacingNews.Data.DataModels
{
    public class Readlater
    {
        public int UserId { get; set; }
        public ICollection<News> ReadLater { get; set; }
    }
}
