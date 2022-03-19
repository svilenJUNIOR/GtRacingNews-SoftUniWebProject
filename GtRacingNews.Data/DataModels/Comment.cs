using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public int? NewsId { get; set; }
        public string UserName { get; set; }
    }
}
