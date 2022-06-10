using System.ComponentModel.DataAnnotations;

namespace GtRacingNews.ViewModels.Race
{
    public class AddNewRaceFormModel
    {
        public AddNewRaceFormModel()
        {
            this.Championships = new List<Data.DataModels.SqlModels.Championship>();
        }
        [Required]
        [MaxLength(50, ErrorMessage = "The name must be less than 50 symbols!")]
        public string Name { get; set; }

        [Required]
        public string Date { get; set; }
        public string ChampionshipName { get; set; }
        public List<Data.DataModels.SqlModels.Championship> Championships { get; set; }
    }
}
