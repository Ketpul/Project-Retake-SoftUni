using Project.Core.Models.OtherViews;
using Project.Core.Models.RestaurantViews;
using Project.Infrastructure.Data.Models;

namespace Project.Core.Contracts
{
    public interface IRestaurantService
    {
        Task<List<RestaurantInfoViewModel>> AllAsync(string searchString, string category, string city, int rating);

        Task<RestaurantDetailsViewModel> DetailsRestaurantAsync(int id);

        Task<IEnumerable<CategoryViewModel>> AllCategoriesAsync();

        Task<Restaurant> CreateAsync(RestaurantFormViewModel model, string userId);

        Task EditAsync(int restauranteId, RestaurantFormViewModel model);

        Task DeleteAsync(int restaurantId);

        Task<List<RestaurantInfoViewModel>> FavoriteRestaurantsAsync(int id, string userId);

        Task AddFavoriteRestaurantsAsync(int id, string userId);

        Task<bool> ExistsAsync(int id);

        Task<bool> AddFavoriteRestaurantsExistAsync(int id, string userId);

        Task RemoveFromFavoriteAsync(int id, string userId);

        Task<RestaurantFormViewModel> GetEditViewModelAsync(int id);

        Task<Restaurant> GetRestaurantByIdAsync(int id);
    }
}
