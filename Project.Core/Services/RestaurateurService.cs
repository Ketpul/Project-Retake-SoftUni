using Project.Core.Contracts;
using Project.Core.Models.OwnerViews;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;

namespace Project.Core.Services
{
    public class RestaurateurService : IRestaurateurService
    {
        private readonly IRepository repository;

        public RestaurateurService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<RestaurateurRequest> AddAsync(RestaurateurRequestFromViewModel model, string userId)
        {
            var restaurateur = new RestaurateurRequest()
            {
                RestaurateurId = userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Information = model.Information,
                DateTime =  DateTime.Now,
            };

            await repository.AddAsync(restaurateur);
            await repository.SaveChangesAsync();

            return restaurateur;
        }
    }
}
