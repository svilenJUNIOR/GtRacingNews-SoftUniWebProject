using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class Race
    {
        public Race(string Name, string Date)
        {
            this.Name = Name;
            this.Date = Date;
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Date { get; set; }
        public string? UserId { get; set; }

    }
}
