using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.User
{
    public class CreatePremiumFormModel
    {
        [Required]
        public int Age { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string ProfilePicture { get; set; }
        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}
