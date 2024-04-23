using Microsoft.AspNetCore.Mvc;
using Project.Core.Contracts;
using Project.Core.Models.OwnerViews;
using Project.Core.Services;
using Project.Infrastructure.Data.SeedDb;
using System.Security.Claims;
using static Project.Infrastructure.Constants.RoleConstants;

namespace Project.Controllers
{
    public class RestaurateurController : BaseController
    {
        
        private readonly IRestaurateurService restauranteurService;

        public RestaurateurController(IRestaurateurService _restauranteurService)
        {
            restauranteurService = _restauranteurService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!User.IsInRole(Restaurateur) && !User.IsInRole(AdminRole))
            {
                return Unauthorized();
            }

            var model = new RestaurateurRequestFromViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RestaurateurRequestFromViewModel model)
        {
            if (!User.IsInRole(Restaurateur) && !User.IsInRole(AdminRole))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = GetUserId();


            var restaurateur = await restauranteurService.AddAsync(model, userId);


            return RedirectToAction("Index", "Home");

        }



        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
