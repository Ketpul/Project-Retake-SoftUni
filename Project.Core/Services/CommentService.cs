using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Core.Contracts;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Services
{
    public class CommentService : ICommentService
    {
        private IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentService(IRepository _repository, UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
        }

        public async Task AddCommentAsync(string commentText, int restaurantId, int rating, string userId)
        {
            var restaurant = await repository.All<Restaurant>().FirstAsync(r => r.Id == restaurantId);
            var user = await userManager.Users.FirstAsync(u => u.Id == userId);

            var comment = new Comment()
            {
                info = commentText,
                UserName = user.UserName,
                RestaurantId = restaurantId,
                Rating =  rating
            };
            await repository.AddAsync(comment);

            double commentsAvg = 0;
            var comments = await repository.AllReadOnly<Comment>().Where(c => c.RestaurantId == restaurantId).ToListAsync();

            if (comments.Any())
            {
                commentsAvg = comments.Average(c => c.Rating);
                restaurant.AvgRating = (int)commentsAvg;
            }


            await repository.SaveChangesAsync();

        }
    }
}
