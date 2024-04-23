using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Areas.Admin.Models;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;
using Project.Core.Models.ReservationView;
using System.Security.Claims;
using static Project.Constants.RoleConstants;
using static Project.Constants.MessageConstants;
using Project.Core.Contracts;
using Project.Core.Services;


namespace Project.Controllers
{
    public class ReservationController : BaseController
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService _reservationService)
        {
            reservationService = _reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(string username, string restaurantName)
        {
            if (restaurantName == null)
            {
                return BadRequest();
            }
            if (username == null)
            {
                return BadRequest();
            }
            
            await reservationService.AddEmployeeAsync(username, restaurantName);

            TempData[UserMessageSuccess] = "Добави работника";
            return RedirectToAction("AllUsers", "Reservation");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromEmployee(string username)
        {
            if (username == null)
            {
                return BadRequest();
            }

            var restaurant = await reservationService.RemoveFromEmployeeAsync(username, GetUserId());

            if (restaurant == null)
            {
                TempData[UserMessageError] = "Не може да го премахнеш";
                return RedirectToAction("AllUsers", "Reservation");
            }

            TempData[UserMessageSuccess] = "Премахна работника";

            return RedirectToAction("AllUsers", "Reservation");
        }


        //public async Task<IActionResult> Confirm(string id)
        //{

        //    var restaurateur = await users.FindByIdAsync(id);
        //    var restaurateurRequests = await data.RestaurateursRequests.FirstAsync(o => o.RestaurateurId == id);

        //    if (restaurateur != null)
        //    {
        //        await users.AddToRoleAsync(restaurateur, Constants.RoleConstants.Restaurateur);


        //        restaurateur.FirstName = restaurateurRequests.FirstName;
        //        restaurateur.LastName = restaurateurRequests.LastName;
        //        restaurateur.PhoneNumber = restaurateurRequests.PhoneNumber;

        //        data.RestaurateursRequests.Remove(restaurateurRequests);
        //        await data.SaveChangesAsync();
        //    }

        //    TempData[UserMessageSuccess] = "Confirm!";

        //    return RedirectToAction(nameof(AllReservation));
        //}

        public async Task<IActionResult> AllUsers()
        {
            if (!User.IsInRole(Restaurateur) && !User.IsInRole(AdminRole))
            {
                return Unauthorized();
            }

            var employeeViewInfoModels = await reservationService.AllUsersAsync(GetUserId());

            return View(employeeViewInfoModels);
        }

        [HttpPost]
        public async Task<IActionResult> Reservation(string name, string surname, string phone, string date, string start, string end, int restaurantId)
        {
            await reservationService.ReservationAsync(name, surname, phone, date, start, end, restaurantId, GetUserId());
            
            TempData[UserMessageSuccess] = "Направихте резервация успоешно";

            return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
        }

        [HttpGet]
        public async Task<IActionResult> AllReservation()
        {
            if (!User.IsInRole(Employee))
            {
                return Unauthorized();
            }

            var reservations = await reservationService.AllReservationAsync(GetUserId());

            return View(reservations);

        }

        [HttpPost]
        public async Task<IActionResult> Yes(string phonenumber)
        {

            await reservationService.YesAsync(phonenumber);

            return RedirectToAction(nameof(AllReservation));
        }
        

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
