using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Project.Core.Contracts;
using Project.Core.Services;
using Project.Infrastructure.Constants;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;

namespace Project.Test
{
    public class ReservationServiceTest
    {
        private UserManager<ApplicationUser> userManager;
        private IReservationService reservationService;
        private ApplicationDbContext applicationDbContext;


        [SetUp]
        public async Task Setup()
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
        public async Task AllUsersAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            reservationService = new ReservationService(repository, userManager);

           var listComment = await reservationService.AllUsersAsync("df7c92db-9dec-4483-9b0c-39836de8f44a");
            

            Assert.AreEqual("admin", listComment[0].UserName);
            Assert.AreEqual("Guest", listComment[1].UserName);
        }
        
        [Test]
        public async Task AllReservationAsyncTestNULL()
        {
            var repository = new Repository(applicationDbContext);
            reservationService = new ReservationService(repository, userManager);

            var reservation = await reservationService.AllReservationAsync("4bc18388-81ca-42ee-a068-f0a4a4c3fb2d");

            Assert.AreEqual(0, reservation.Count());
        }

        

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
