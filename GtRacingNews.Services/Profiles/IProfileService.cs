using GtRacingNews.Data.DataModels.SqlModels;
using GtRacingNews.ViewModels.Profile;
using GtRacingNews.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GtRacingNews.Services.Profiles
{
    public interface IProfileService
    {
        Task AddNewProfile(CreatePremiumFormModel model, ModelStateDictionary modelState, string userId);
        void EditProfileInfo(string Id, CreatePremiumFormModel data);
        MyProfileViewModel ProfileBind(IdentityUser currentUser, Profile userProfile);
        CreatePremiumFormModel AddRolesToModel(List<IdentityRole> data);
    }
}
