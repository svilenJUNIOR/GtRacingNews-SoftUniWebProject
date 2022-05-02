namespace GtRacingNews.Areas.Admin.ViewModels
{
    public class DeleteViewModel
    {
        public string TeamCollection = "Team";
        public string DriverCollection = "Driver";
        public string ChampionshipCollection = "Championship";
        public string NewsCollection = "News";
        public string RaceCollection = "Race";
        public string UserCollection = "User";
        public string RoleCollection = "Role";

        public Dictionary<string, int> Teams  = new Dictionary<string, int>();
        public Dictionary<string, int> Drivers  = new Dictionary<string, int>();
        public Dictionary<string, int> Championships  = new Dictionary<string, int>();
        public Dictionary<string, int> News  = new Dictionary<string, int>();
        public Dictionary<string, int> Races  = new Dictionary<string, int>();
        public Dictionary<string, string> Users  = new Dictionary<string, string>();
        public Dictionary<string, string> Roles  = new Dictionary<string, string>();
    }
}
