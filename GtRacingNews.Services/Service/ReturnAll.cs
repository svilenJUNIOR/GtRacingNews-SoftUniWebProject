﻿using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;
using GtRacingNews.ViewModels.News;

namespace GtRacingNews.Services.Service
{
    public class ReturnAll : IReturnAll
    {
        private readonly IRepository repository;

        public ReturnAll(IRepository repository) => this.repository = repository;

        public IEnumerable<object> All(string Entity)
        {

            if (Entity == "Teams")  return repository.GettAll<Team>();

            if (Entity == "Races") return repository.GettAll<Race>();
             
            if (Entity == "News") return repository.GettAll<News>();

            if (Entity == "Drivers") return repository.GettAll<Driver>();

            if (Entity == "Championships") return repository.GettAll<Championship>();

            return null;
        }

        public ReadNewsViewModel NewsDeatils(int newsId)
        {
            var context = new GTNewsDbContext();

            var news = context.News.Where(x => x.Id == newsId)
                .Select(n => new ReadNewsViewModel
                {
                    NewsId = n.Id,
                    Description = n.Description,
                    Comments = context.Comments.Where(x => x.NewsId == n.Id).ToList()
                }).FirstOrDefault();

            return news;
        }
    }
}
