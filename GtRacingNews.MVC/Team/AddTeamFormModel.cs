namespace GtRacingNews.ViewModels.Team
{
    public class AddTeamFormModel
    {
        public string Name { get; set; }
        public string CarModel { get; set; }
        public string LogoUrl { get; set; }
        public string ChampionshipName { get; set; }
        public ICollection<Data.DataModels.Championship> Championships { get; set; }
    }
}
