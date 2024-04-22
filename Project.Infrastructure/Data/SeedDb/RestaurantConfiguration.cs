using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Infrastructure.Data.Models;

namespace Project.Infrastructure.Data.SeedDb
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            var data = new SeedData();


            builder.HasData(new Restaurant[] { data.ThirdHouse, data.FirstHouse, data.SecondHouse });
        }
    }
}
