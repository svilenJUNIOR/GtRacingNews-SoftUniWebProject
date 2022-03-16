namespace GtRacingNews.Data.DataModels
{
    public class NewsReadLater
    {
        public int NewsId { get; set; }
        public News News { get; set; }
        public int ReadLaterId { get; set; }
        public Readlater Readlater { get; set; }
    }
}
