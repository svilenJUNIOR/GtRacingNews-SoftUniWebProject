namespace GtRacingNews.Areas.Admin.ViewModels
{
    public class RoleToUserViewModel
    {
        public ICollection<string> Roles { get; set; } = new List<string>();
        public ICollection<string> Users { get; set; } = new List<string>();
        public string Role { get; set; }
        public string User { get; set; }
    }
}
