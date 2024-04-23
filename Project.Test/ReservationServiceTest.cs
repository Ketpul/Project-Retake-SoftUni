using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Moq;
using Project.Core.Contracts;
using Project.Core.Services;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Test
{
    public class ReservationServiceTest
    {
        private UserManager<ApplicationUser> userManager;
        private IReservationService reservationService;
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
        public async Task AddEmployeeAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            reservationService = new ReservationService(repository, userManager);
            
            await reservationService.AddEmployeeAsync("Guest", "Friends Restaurant");
            //var reservation = await reservationService.AllReservationAsync("4bc18388-81ca-42ee-a068-f0a4a4c3fb2d");

            Assert.AreEqual(1, 1);
        }

        [Test]
        public async Task AllReservationAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            reservationService = new ReservationService(repository, userManager);



            await reservationService.AddEmployeeAsync("admin", "Friends Restaurant");
            var reservation = await reservationService.AllReservationAsync("df7c92db-9dec-4483-9b0c-39836de8f44a");

            Assert.AreEqual(1, reservation.Count());
        }

        [Test]
        public async Task ReservationAsyncTest()
        {
            var repository = new Repository(applicationDbContext);
            reservationService = new ReservationService(repository, userManager);


            await reservationService.AddEmployeeAsync("Guest", "Friends Restaurant");
            await reservationService.ReservationAsync("Guest", "Guestov", "0895757578", "22/2024", "00:00", "00:00", 1, "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d");
            var reservation = await reservationService.AllReservationAsync("4bc18388-81ca-42ee-a068-f0a4a4c3fb2d");

            Assert.AreEqual(1, reservation.Count());
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
