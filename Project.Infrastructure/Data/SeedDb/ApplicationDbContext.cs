using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Data.Models;

namespace Project.Infrastructure.Data.SeedDb
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool _seedDb;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> 
            options, bool seed = true) : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            _seedDb = seed;
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.Restaurant)
                .WithMany()
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Reservation>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FavoriteRestaurants>()
                .HasKey(ep => new { ep.RestaurantId, ep.UserId });

            modelBuilder.Entity<FavoriteRestaurants>()
                .HasOne(e => e.Restaurant)
                .WithMany()
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<FavoriteRestaurants>()
                .HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RestaurateurRequest>()
                .HasKey(ep => new { ep.RestaurateurId });

            modelBuilder.Entity<RestaurateurRequest>()
                .HasOne(e => e.Restaurateur)
                .WithMany()
                .HasForeignKey(e => e.RestaurateurId)
                .OnDelete(DeleteBehavior.NoAction);

            

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RestaurantConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<FavoriteRestaurants> FavoritesRestaurants { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurateurRequest> RestaurateursRequests { get; set; }

    }
}
