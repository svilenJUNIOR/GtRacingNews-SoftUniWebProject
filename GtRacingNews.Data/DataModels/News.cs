using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Heading { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Description { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
