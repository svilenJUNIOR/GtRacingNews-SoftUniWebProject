﻿using GtRacingNews.Data.DataModels;
using GtRacingNews.Data.DBContext;
using GtRacingNews.Services.Contracts;

namespace GtRacingNews.Services.Service
{
    public class CommentService : ICommentService
    {

        private readonly GTNewsDbContext context;
        public CommentService(GTNewsDbContext context)
        {
            this.context = context;
        }
        public async Task AddNewComment(string Description, int newsId, string UserName)
        {
            var comment = new Comment
            {
                NewsId = newsId,
                Description = Description,
                UserName = UserName,
            };

            context.Comments.Add(comment);
            await context.SaveChangesAsync();
        }
    }
}