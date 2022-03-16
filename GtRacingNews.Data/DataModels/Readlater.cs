namespace GtRacingNews.Data.DataModels
{
    public class Readlater
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int NewsId { get; set; }
        public ICollection<News> ReadLater { get; set; } = new List<News>();
    }
}
