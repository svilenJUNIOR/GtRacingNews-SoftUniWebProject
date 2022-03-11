using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.User
{
    public class RegisterUserFormModel
    {
        [Required]
        public string Email { get; set; }
        
        [MinLength(6)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [MinLength(6)]
        [MaxLength(20)]
        public string Username { get; set; }
    }
}
