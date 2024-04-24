using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Core.Contracts;
using Project.Core.Models.OtherViews;
using Project.Core.Models.RestaurantViews;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Project.Core.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public RestaurantService(IRepository _repository, UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
        }

        public async Task<List<RestaurantInfoViewModel>> AllAsync(string searchString, string category, string city, int rating)
        {
            var restaurantsQuery = repository.AllReadOnly<Restaurant>();

            if (!string.IsNullOrEmpty(searchString))
            {
                restaurantsQuery = restaurantsQuery.Where(r => r.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(category))
            {
                restaurantsQuery = restaurantsQuery.Where(r => r.Category.Name == category);
            }

            if (rating != 0)
            {
                restaurantsQuery = restaurantsQuery.Where(r => r.AvgRating == rating);
            }

            var restaurants = await restaurantsQuery.Select(r => new RestaurantInfoViewModel()
            {
                Id = r.Id,
                Name = r.Name,
                ImageUrl1 = r.ImageUrl1,
                ImageUrl2 = r.ImageUrl2,
                ImageUrl3 = r.ImageUrl3,
                Description = r.Description,
                Address = r.Address,
                RestaurateurId = r.RestaurateurId,
                Category = r.Category.Name,
                City = r.RegionalCity.ToString(),
                Rating = r.AvgRating,
            }).ToListAsync();

            if (!string.IsNullOrEmpty(city))
            {
                restaurants = restaurants.Where(r => r.City == city).ToList();
            }

            return restaurants;
        }

        public async Task<RestaurantDetailsViewModel> DetailsRestaurantAsync(int id)
        {
            var restaurant = await repository.AllReadOnly<Restaurant>().FirstAsync(r => r.Id == id);
            var restaurantuer = await userManager.Users.FirstAsync(u => u.Id == restaurant.RestaurateurId);
            var categery = await repository.AllReadOnly<Category>().FirstAsync(c => c.Id == restaurant.CategoryId);
            var comments = await repository.AllReadOnly<Comment>().Where(c => c.RestaurantId == restaurant.Id).ToListAsync();


            return await repository.AllReadOnly<Restaurant>()
                .Where(r => r.Id == restaurant.Id)
                .Select(r => new RestaurantDetailsViewModel()
                {
                    Id=restaurant.Id,
                    Name = restaurant.Name,
                    ImageUrl = { restaurant.ImageUrl1, restaurant.ImageUrl2, restaurant.ImageUrl3 },
                    Address = restaurant.Address,
                    Description = restaurant.Description,
                    RestaurateurId = restaurant.RestaurateurId,
                    Category = categery.Name,
                    FullName = $"{restaurantuer.FirstName} {restaurantuer.LastName}",
                    Email = restaurantuer.Email,
                    PhoneNumber = restaurantuer.PhoneNumber,
                    Comments = comments,
                    GoogleMaps = restaurant.GoogleMaps,
                    UserName = restaurantuer.UserName,
                    City = restaurant.RegionalCity.ToString(),
                }).FirstAsync();

            
        }

        public async Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<Restaurant> CreateAsync(RestaurantFormViewModel model, string userId)
        {
            var restaurant = new Restaurant()
            {
                Name = model.Name,
                ImageUrl1 = model.ImageUrl1,
                ImageUrl2 = model.ImageUrl2,
                ImageUrl3 = model.ImageUrl3,
                Description = model.Description,
                CategoryId = model.CategoryId,
                RestaurateurId = userId,
                Address = model.Address,
                GoogleMaps = model.GoogleMaps,
                RegionalCity = model.RegionalCity,
            };

            await repository.AddAsync(restaurant);
            await repository.SaveChangesAsync();

            return restaurant;
        }

        public async Task EditAsync(int restauranteId, RestaurantFormViewModel model)
        {
            var restaurant = await repository.GetByIdAsync<Restaurant>(restauranteId);

            if (restaurant != null)
            {
                restaurant.Name = model.Name;
                restaurant.ImageUrl1 = model.ImageUrl1;
                restaurant.ImageUrl2 = model.ImageUrl2;
                restaurant.ImageUrl3 = model.ImageUrl3;
                restaurant.Address = model.Address;
                restaurant.Description = model.Description;
                restaurant.GoogleMaps = model.GoogleMaps;
                restaurant.CategoryId = model.CategoryId;
                restaurant.RegionalCity = model.RegionalCity;

                await repository.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int restaurantId)
        {
            await repository.DeleteAsync<Restaurant>(restaurantId);
            await repository.SaveChangesAsync();
        }

        public async Task<List<RestaurantInfoViewModel>> FavoriteRestaurantsAsync(int id, string userId)
        {
            var restaurants = await repository.AllReadOnly<FavoriteRestaurants>()
                .Where(f => f.UserId == userId)
                .Select(r => new RestaurantInfoViewModel()
                {
                    Id = r.Restaurant.Id,
                    Name = r.Restaurant.Name,
                    ImageUrl1 = r.Restaurant.ImageUrl1,
                    ImageUrl2 = r.Restaurant.ImageUrl2,
                    ImageUrl3 = r.Restaurant.ImageUrl3,
                    Description = r.Restaurant.Description,
                    Address = r.Restaurant.Address,
                    RestaurateurId = r.Restaurant.RestaurateurId,
                    Category = r.Restaurant.Category.Name
                })
                .ToListAsync();

            return restaurants;
        }

        public async Task AddFavoriteRestaurantsAsync(int id, string userId)
        {
            var restaurant = new FavoriteRestaurants
            {
                UserId = userId,
                RestaurantId = id
            };

            await repository.AddAsync(restaurant);
            await repository.SaveChangesAsync();

        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await repository.AllReadOnly<Restaurant>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<bool> AddFavoriteRestaurantsExistAsync(int id, string userId)
        {
            return await repository.AllReadOnly<FavoriteRestaurants>()
                .AnyAsync(h => h.RestaurantId == id && h.UserId == userId);
        }

        public async Task RemoveFromFavoriteAsync(int id, string userId)
        {
            var favorite = await repository.AllReadOnly<FavoriteRestaurants>().FirstAsync(f => f.RestaurantId == id && f.UserId == userId);

            await repository.RemoveFavoriteRestaurantAsync(favorite);
            await repository.SaveChangesAsync();
        }

        public async Task<RestaurantFormViewModel> GetEditViewModelAsync(int id)
        {
            var restaurant = await repository.AllReadOnly<Restaurant>().FirstAsync(r => r.Id == id);


            var model = new RestaurantFormViewModel()
            {
                Name = restaurant.Name,
                ImageUrl1 = restaurant.ImageUrl1,
                ImageUrl2 = restaurant.ImageUrl2,
                ImageUrl3 = restaurant.ImageUrl3,
                Address = restaurant.Address,
                Description = restaurant.Description,
                GoogleMaps = restaurant.GoogleMaps,
                Restaurateur = restaurant.RestaurateurId,
                RegionalCity = restaurant.RegionalCity,

            };

            model.Categories = await AllCategoriesAsync();


            return model;
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
           return await repository.AllReadOnly<Restaurant>().FirstAsync(r => r.Id == id);
        }
        public async Task<Restaurant> GetRestaurantByNameAsync(string name)
        {
           return await repository.AllReadOnly<Restaurant>().FirstAsync(r => r.Name == name);
        }
    }
}
