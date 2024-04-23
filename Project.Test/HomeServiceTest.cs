using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using Project.Core.Contracts;
using Project.Core.Services;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;

namespace Project.Test
{
    public class HomeServiceTest
    {
        private IRepository repository;
        private IHomeService homeService;
        private ApplicationDbContext applicationDbContext;
        

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ProjectDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestIndexAsync()
        {
            var repository = new Repository(applicationDbContext);
            homeService = new HomeService(repository);

            await repository.AddAsync(new Restaurant() { AvgRating = 2 });
            await repository.AddAsync(new Restaurant() { AvgRating = 4 });
            await repository.AddAsync(new Restaurant() { AvgRating = 5 });
            await repository.AddAsync(new Restaurant() { AvgRating = 3 });

            await repository.SaveChangesAsync();
            var homeList = await homeService.IndexAsync();

            Assert.That(3, Is.EqualTo(homeList.Restaurants.Count()));
            Assert.That(homeList.Restaurants.Any(h => h.AvgRating == 2), Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
