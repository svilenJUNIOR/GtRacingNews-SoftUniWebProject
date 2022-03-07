using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.User
{
    public class RegisterUserFormModel
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Username { get; set; }
    }
}
