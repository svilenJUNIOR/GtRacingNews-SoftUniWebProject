﻿using GtRacingNews.Data.DataModels;
using GtRacingNews.ViewModels.Profile;
using Microsoft.AspNetCore.Identity;

namespace GtRacingNews.Services.Contracts
{
    public interface IProfileService
    {
        MyProfileViewModel ProfileBind(IdentityUser user, Profile profile);
    }
}
