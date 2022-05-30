using GtRacingNews.Data.DataModels.SqlModels;

namespace GtRacingNews.ViewModels.News
{
    public class ReadNewsViewModel
    {
        public string NewsId { get; set; }
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
