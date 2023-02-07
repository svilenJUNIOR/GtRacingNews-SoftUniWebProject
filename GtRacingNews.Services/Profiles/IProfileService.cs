using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Profile;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Profiles
{
    public interface IProfileService
    {
        public Task AddNewProfile(CreatePremiumFormModel model, string userId);
        public void EditProfileInfo(string Id, CreatePremiumFormModel data);
        public MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile);
    }
}
