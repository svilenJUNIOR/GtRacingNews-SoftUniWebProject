using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
