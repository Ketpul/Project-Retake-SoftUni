using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using Project.Core.Contracts;
using Project.Core.Models.RestaurantViews;
using Project.Core.Services;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;
using Project.Infrastructure.Enums;
using System.Xml.Linq;

namespace Project.Test
{
    public class RestaurantServiceTest
    {
        
        private UserManager<ApplicationUser> userManager;
        private IRestaurantService restaurantService;
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
        public async Task ExistsAsyncTestTrue()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var exist = await restaurantService.ExistsAsync(1);

            Assert.That(exist, Is.True);
        }
        
        
        [Test]
        public async Task ExistsAsyncTestFalse()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var exist = await restaurantService.ExistsAsync(0);

            Assert.That(exist, Is.False);
        }

        [Test]
        public async Task AllAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var exist = await restaurantService.AllAsync(null, null, null, 0);

            Assert.AreEqual(3, exist.Count());
        }


        [Test]
        public async Task AllCategoriesAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var exist = await restaurantService.AllCategoriesAsync();

            Assert.AreEqual(5, exist.Count());
        }
        
        [Test]
        public async Task CreateAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var model = new RestaurantFormViewModel()
            {
                Name = "Name",
                ImageUrl1 = "ImageUrl1",
                ImageUrl2 = "ImageUrl2",
                ImageUrl3 = "ImageUrl3",
                Address = "Address",
                Description = "DescriptionDescription",
                GoogleMaps = "GoogleMaps",
                Restaurateur = "Restaurateur",
                RegionalCity = RegionalCity.Благо̀евград,
                CategoryId = 1,
            };

            var exist = await restaurantService.CreateAsync(model, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            Assert.AreEqual("Name", exist.Name);
            Assert.AreEqual("df7c92db-9dec-4483-9b0c-39836de8f44a", exist.RestaurateurId);
        }

        [Test]
        public async Task FavoriteRestaurantsAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            await restaurantService.AddFavoriteRestaurantsAsync(1, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            var exist = await restaurantService.FavoriteRestaurantsAsync(0, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            Assert.AreEqual(1, exist.Count());
        }

        [Test]
        public async Task AddFavoriteRestaurantsExistAsyncTestTrue()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            await restaurantService.AddFavoriteRestaurantsAsync(1, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            var exist = await restaurantService.AddFavoriteRestaurantsExistAsync(1, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            Assert.AreEqual(true, exist);
        }

        [Test]
        public async Task AddFavoriteRestaurantsExistAsyncTestFalse()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            await restaurantService.AddFavoriteRestaurantsAsync(1, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            var exist = await restaurantService.AddFavoriteRestaurantsExistAsync(2, "df7c92db-9dec-4483-9b0c-39836de8f44a");

            Assert.AreEqual(false, exist);
        }


        [Test]
        public async Task GetEditViewModelAsyncTestTrue()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var model = await restaurantService.GetEditViewModelAsync(1);

            Assert.AreEqual("Friends Restaurant", model.Name);

        }
        
        [Test]
        public async Task GetEditViewModelAsyncTestFalse()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var model = await restaurantService.GetEditViewModelAsync(2);

            Assert.AreNotEqual("Friends Restaurant", model.Name);

        }

        [Test]
        public async Task GetRestaurantByIdAsyncTestTrue()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var model = await restaurantService.GetRestaurantByIdAsync(1);

            Assert.AreEqual("Friends Restaurant", model.Name);

        }
        
        [Test]
        public async Task GetRestaurantByIdAsyncTestFalse()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var model = await restaurantService.GetRestaurantByIdAsync(2);

            Assert.AreNotEqual("Friends Restaurant", model.Name);

        } 
        
        [Test]
        public async Task EditAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            restaurantService = new RestaurantService(repository, userManager);

            var model = new RestaurantFormViewModel()
            {
                Name = "Name",
                ImageUrl1 = "ImageUrl1",
                ImageUrl2 = "ImageUrl2",
                ImageUrl3 = "ImageUrl3",
                Address = "Address",
                Description = "DescriptionDescription",
                GoogleMaps = "GoogleMaps",
                Restaurateur = "Restaurateur",
                RegionalCity = RegionalCity.Благо̀евград,
                CategoryId = 2,
            };

            await restaurantService.EditAsync(1, model);

            var exist = await restaurantService.GetRestaurantByIdAsync(1);

            Assert.AreEqual("Name", exist.Name);

        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
