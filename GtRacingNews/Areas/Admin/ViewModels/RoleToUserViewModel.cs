namespace GtRacingNews.Areas.Admin.ViewModels
{
    public class RoleToUserViewModel
    {
        public ICollection<string> Users { get; set; } = new List<string>();
        public string User { get; set; }
    }
}
