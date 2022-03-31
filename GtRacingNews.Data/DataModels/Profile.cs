namespace GtRacingNews.Data.DataModels
{
    public class Profile
    {
        public Profile(int age, string profileType, string userId, string Address)
        {
            this.Age = age;
            this.ProfileType = profileType;
            this.UserId = userId;
            this.Address = Address;
        }
        public int Id { get; set; }
        public int Age { get; set; }
        public string ProfileType { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
    }
}
