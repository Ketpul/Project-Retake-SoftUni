using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Core.Contracts;
using Project.Core.Models.OtherViews;
using Project.Core.Models.RestaurantViews;
using Project.Core.Services;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;
using System.Security.Claims;
using static Project.Constants.MessageConstants;
using static Project.Constants.RoleConstants;

namespace Project.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        public RestaurantController(IRestaurantService _restaurantService)
        {
            restaurantService = _restaurantService;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!User.IsInRole(Restaurateur))
            {
                return RedirectToAction("Add", "Restaurateur");
            }

            var model = new RestaurantFormViewModel();
            model.Categories = await restaurantService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(RestaurantFormViewModel model)
        {
            if (!User.IsInRole(Restaurateur))
            {
                return RedirectToAction("Add", "Restaurateur");
            }

            if (!ModelState.IsValid)
            {
                model.Categories =  await restaurantService.AllCategoriesAsync();

                return View(model);
            }

            string userId = GetUserId();

            Restaurant newHouse = await restaurantService.CreateAsync(model, userId );

            TempData[UserMessageSuccess] = "You added restaurants successfuly!";

            return RedirectToAction(nameof(Details), new { id = newHouse.Id });
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(string searchString, string category, string city, int rating)
        {
            var model = await restaurantService.AllAsync(searchString, category, city, rating);


            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var details = await restaurantService.DetailsRestaurantAsync(id);

            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await restaurantService.GetEditViewModelAsync(id);

            if (!User.IsInRole(AdminRole))
            {
                if (model.Restaurateur != GetUserId())
                {
                    return Unauthorized();
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantFormViewModel model, int id)
        {
            var restaurant = await restaurantService.GetRestaurantByIdAsync(id);


            if (restaurant == null)
            {
                return BadRequest();
            }

            if (!User.IsInRole(AdminRole))
            {
                if (restaurant.RestaurateurId != GetUserId())
                {
                    return Unauthorized();
                }
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await restaurantService.AllCategoriesAsync();

                return View(model);
            }

            model.Categories = await restaurantService.AllCategoriesAsync();
            await restaurantService.EditAsync(id, model);

            TempData[UserMessageSuccess] = "Редактиранте беше успоешно";

            return RedirectToAction(nameof(Details), new { id = id });
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {

            var restaurant = await restaurantService.GetRestaurantByIdAsync(id);

            if (!User.IsInRole(AdminRole))
            {
                if (restaurant.RestaurateurId != GetUserId())
                {
                    return Unauthorized();
                }
            }

            if (restaurant == null)
            {
                return BadRequest();
            }

            if (!User.IsInRole(AdminRole))
            {
                if (restaurant.RestaurateurId != GetUserId())
                {
                    return Unauthorized();
                }
            }

            await restaurantService.DeleteAsync(id);

            TempData[UserMessageError] = "You delete restaurants successfuly!";

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> FavoriteRestaurants(int id)
        {
            string userId = GetUserId();

            var model = await restaurantService.FavoriteRestaurantsAsync(id, userId);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavoriteRestaurants(int id)
        {
            string userId = GetUserId();

            if (await restaurantService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (await restaurantService.AddFavoriteRestaurantsExistAsync(id, userId))
            {
                return RedirectToAction(nameof(FavoriteRestaurants));
            }


            await restaurantService.AddFavoriteRestaurantsAsync(id, userId);
           

            TempData[UserMessageSuccess] = "Добавихте в любими успоешно";

            return RedirectToAction(nameof(FavoriteRestaurants));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorite(int id)
        {
            await restaurantService.RemoveFromFavoriteAsync(id, GetUserId());

            TempData[UserMessageError] = "Премахнате от любими";

            return RedirectToAction(nameof(FavoriteRestaurants));
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty; 
        }
    }


}
