namespace GtRacingNews.ViewModels.Championship
{
    public class ViewDetailsViewModel
    {
        public string ChampionshipName { get; set; }
        public ICollection<Data.DataModels.Team> Teams { get; set; } = new List<Data.DataModels.Team>();
        public Dictionary<string, List<string>> Drivers { get; set; } = new Dictionary<string, List<string>>();
    }
}
