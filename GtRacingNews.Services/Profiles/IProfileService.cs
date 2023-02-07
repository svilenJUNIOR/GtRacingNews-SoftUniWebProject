using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Profile;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Profiles
{
    public interface IProfileService
    {
        public Task AddNewProfile(CreatePremiumFormModel model, ModelStateDictionary modelState, string userId);
        public void EditProfileInfo(string Id, CreatePremiumFormModel data);
        public MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile);
    }
}
