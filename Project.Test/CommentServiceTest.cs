﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Project.Core.Contracts;
using Project.Core.Services;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;

namespace Project.Test
{
    public class CommentServiceTest
    {
        private IRepository repository;
        private ICommentService commentService;
        private ApplicationDbContext applicationDbContext;
        private UserManager<ApplicationUser> userManager;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ProjectDB")
                .Options;


            applicationDbContext = new ApplicationDbContext(contextOptions);

            var normalizer = new UpperInvariantLookupNormalizer();
            var userStore = new UserStore<ApplicationUser>(applicationDbContext);
            userManager = new UserManager<ApplicationUser>(userStore, null, null, null, null, normalizer, null, null, null);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task AddCommentAsyncTest()
        {
            var repository = new Repository(applicationDbContext); 
            commentService = new CommentService(repository, userManager);

            var comment = new Comment()
            {
                info = "commentText",
                UserName = "user.UserName",
                RestaurantId = 1,
                Rating = 5
            };

            await commentService.AddCommentAsync("commentText", 1, 5, "df7c92db-9dec-4483-9b0c-39836de8f44a");
            await repository.SaveChangesAsync(); 

            var currentComment = await repository.AllReadOnly<Comment>().FirstAsync();

            Assert.AreEqual(comment.info, currentComment.info);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
