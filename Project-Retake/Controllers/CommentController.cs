using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Core.Contracts;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;
using System.Security.Claims;

namespace Project.Controllers
{
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentController( ICommentService _commentService)
        {
            commentService = _commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(string commentText, int restaurantId, int rating)
        {
            if (commentText == null)
            {
                return BadRequest();
            }

            await commentService.AddCommentAsync(commentText, restaurantId, rating, GetUserId());

            return RedirectToAction("Details", "Restaurant", new { id = restaurantId });
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
