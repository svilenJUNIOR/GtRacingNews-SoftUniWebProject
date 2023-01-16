
namespace GtRacingNews.ViewModels.Team
{
    public class ViewTeamsAndChampsViewModel
    {
        public List<Data.DataModels.SqlModels.Championship> Championships { get; set; } = new List<Data.DataModels.SqlModels.Championship>();
        public List<ViewAllTeamsViewModel> Teams { get; set; } = new List<ViewAllTeamsViewModel>();

    }
}
