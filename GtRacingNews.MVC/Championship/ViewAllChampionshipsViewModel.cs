namespace GtRacingNews.ViewModels.Championship
{
    public class ViewAllChampionshipsViewModel
    {
        public string ChampionshipId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public ICollection<string> Teams { get; set; } = new List<string>();
    }
}
