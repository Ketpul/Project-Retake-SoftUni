
using Project.Infrastructure.Data.Models;

namespace Project.Core.Models.OtherViews
{
    public class HomeIndexViewModel
    {
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
