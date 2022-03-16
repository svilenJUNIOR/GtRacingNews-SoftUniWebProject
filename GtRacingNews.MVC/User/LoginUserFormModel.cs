using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.User
{
    public class LoginUserFormModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
