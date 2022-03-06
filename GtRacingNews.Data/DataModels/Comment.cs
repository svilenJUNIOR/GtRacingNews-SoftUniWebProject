using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public int NewsId { get; set; }
    }
}
