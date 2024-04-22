using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Contracts
{
    public interface ICommentService
    {
        Task AddCommentAsync(string commentText, int restaurantId, int rating, string userId);
    }
}
