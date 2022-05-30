using GtRacingNews.Common.Constants;

namespace GtRacingNews.ViewModels.Delete
{
    public class DeleteFormModel
    {
        public CollectionNames CollectionNames { get; set; } = new CollectionNames();

        public Dictionary<string, string> Teams = new Dictionary<string, string>();
        public Dictionary<string, string> Drivers = new Dictionary<string, string>();
        public Dictionary<string, string> Championships = new Dictionary<string, string>();
        public Dictionary<string, string> News = new Dictionary<string, string>();
        public Dictionary<string, string> Races = new Dictionary<string, string>();
        public Dictionary<string, string> Users = new Dictionary<string, string>();
        public Dictionary<string, string> Roles = new Dictionary<string, string>();
    }
}
