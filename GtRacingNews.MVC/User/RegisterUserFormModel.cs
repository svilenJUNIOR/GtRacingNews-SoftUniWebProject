using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.User
{
    public class RegisterUserFormModel
    {
        [Required]
        public string Email { get; set; }
        
        [MinLength(6, ErrorMessage = "Password must be at least 6 symbols!")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }

        [MinLength(6, ErrorMessage = "Username must be at least 6 symbols!")]
        [MaxLength(20, ErrorMessage = "Username must be less than 20 symbols!")]
        public string Username { get; set; }
    }
}
