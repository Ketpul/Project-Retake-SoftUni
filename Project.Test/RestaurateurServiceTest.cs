using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Moq;
using Project.Core.Contracts;
using Project.Core.Models.OwnerViews;
using Project.Core.Services;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;

namespace Project.Test
{
    public class RestaurateurServiceTest
    {
        private IRepository repository;
        private IRestaurateurService restaurateurService;
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
        public async Task AddAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            restaurateurService = new RestaurateurService(repository);

            var model = new RestaurateurRequestFromViewModel()
            {
                Id = 1,
                RestaurateurId = "df7c92db-9dec-4483-9b0c-39836de8f44a",
                FirstName = "Admin",
                LastName = "Adminov",
                PhoneNumber = "0888888888",
                Information = "Iskam",
                DateTime = DateTime.Now,
            };
            

            var restaurateurList = await restaurateurService.AddAsync(model, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            Assert.AreEqual(model.RestaurateurId, restaurateurList.RestaurateurId);
            Assert.AreEqual(model.FirstName, restaurateurList.FirstName);
            Assert.AreEqual(model.LastName, restaurateurList.LastName);
            Assert.AreEqual(model.PhoneNumber, restaurateurList.PhoneNumber);
            Assert.AreEqual(model.Information, restaurateurList.Information);


        }
    }
}
