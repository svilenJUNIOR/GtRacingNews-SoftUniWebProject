namespace GtRacingNews.Data.DataModels
{
    public class Profile
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string ProfileType { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public ICollection<Championship> MyChampionships { get; set; } = new List<Championship>();
        public ICollection<Driver> MyDrivers { get; set; } = new List<Driver>();
        public ICollection<News> MyNews { get; set; } = new List<News>();
        public ICollection<Race> MyRaces { get; set; } = new List<Race>();
        public ICollection<Team> MyTeams { get; set; } = new List<Team>();
    }
}
