using Microsoft.AspNetCore.Mvc;
using Project.Core.Contracts;
using Project.Core.Models.OwnerViews;
using Project.Infrastructure.Data.SeedDb;
using System.Security.Claims;

namespace Project.Controllers
{
    public class RestaurateurController : BaseController
    {
        
        private readonly IRestaurateurService restauranteurService;
        public RestaurateurController(ApplicationDbContext _data, IRestaurateurService _restauranteurService)
        {
            
            restauranteurService = _restauranteurService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new RestaurateurRequestFromViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RestaurateurRequestFromViewModel model)
        {
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
