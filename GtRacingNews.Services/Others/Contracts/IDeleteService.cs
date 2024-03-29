﻿using GtRacingNews.ViewModels.Delete;

namespace GtRacingNews.Services.Others.Contracts
{
    public interface IDeleteService
    {
        Task Delete<T>(string id) where T : class;
        Task DeleteUser(string id);
        Task DeleteRole(string id);
        DeleteFormModel GetItemsForDeletion();
    }
}
