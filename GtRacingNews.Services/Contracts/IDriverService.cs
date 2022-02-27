﻿namespace GtRacingNews.Services.Contracts
{
    public interface IDriverService
    {
        void AddNewDriver(string name, string cup, string imageUrl, int age);
        void AddToTeam(int teamId, int driverId);
    }
}
