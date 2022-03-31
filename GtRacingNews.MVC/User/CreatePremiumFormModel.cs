namespace GtRacingNews.ViewModels.User
{
    public class CreatePremiumFormModel
    {
        public int Age { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string ProfilePicture { get; set; }
        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}
