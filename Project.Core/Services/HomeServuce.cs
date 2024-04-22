using Microsoft.EntityFrameworkCore;
using Project.Core.Contracts;
using Project.Core.Models.OtherViews;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Services
{
    public class HomeServuce : IHomeServuce
    {
        private readonly IRepository repository;

        public HomeServuce(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HomeIndexViewModel> IndexAsync()
        {
            var restaurants = await repository.AllReadOnly<Restaurant>().OrderByDescending(r => r.AvgRating).Take(3).ToListAsync();

            var model = new HomeIndexViewModel()
            {
                Restaurants = restaurants
            };

            return model;
        }
    }
}
