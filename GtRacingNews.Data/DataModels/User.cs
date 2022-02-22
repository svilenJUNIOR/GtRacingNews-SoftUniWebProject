using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.Data.DataModels
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Username { get; set; }
        public ICollection<News> ReadLater { get; set; } = new List<News>();
        // list of news - read later
        public ICollection<Championship> ReadAbout { get; set; } = new List<Championship>();
        // list of selected championships the user wants to read about
    }
}
