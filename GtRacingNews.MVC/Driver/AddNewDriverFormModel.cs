namespace GtRacingNews.ViewModels.Driver
{
    public class AddNewDriverFormModel
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Cup { get; set; }

        public string ImageUrl { get; set; }
        public string TeamName { get; set; }
        public ICollection<Data.DataModels.Team> Teams { get; set; } = new List<Data.DataModels.Team>();
    }
}
