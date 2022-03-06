using GtRacingNews.Data.DataModels;

namespace GtRacingNews.ViewModels.News
{
    public class ReadNewsViewModel
    {
        public int NewsId { get; set; }
        public string Description { get; set; }
        public ICollection<string> Comments { get; set; }
    }
}
