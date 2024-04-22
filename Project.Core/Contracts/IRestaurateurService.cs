using Project.Core.Models.OwnerViews;
using Project.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Contracts
{
    public interface IRestaurateurService
    {
        Task<RestaurateurRequest> AddAsync(RestaurateurRequestFromViewModel model, string userId);
    }
}
