namespace GtRacingNews.ViewModels.Team
{
    public class ViewAllTeamsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string CarModel { get; set; }
        public string ChampionshipName { get; set; }
        public ICollection<string> Drivers { get; set; } = new List<string>();
    }
}
