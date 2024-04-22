using System.ComponentModel.DataAnnotations;
using static Project.Infrastructure.Constants.DateConstants;

namespace Project.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentInfoMaxLength)]
        public string info { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public double Rating { get; set; }
    }
}
