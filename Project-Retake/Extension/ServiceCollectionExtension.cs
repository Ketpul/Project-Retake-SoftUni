using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Core.Contracts;
using Project.Core.Services;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Data.SeedDb;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRestaurantService, RestaurantService>();
            services.AddScoped<IRestaurateurService, RestaurateurService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IHomeServuce, HomeServuce>();
            

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection sevices, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            sevices.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            sevices.AddScoped<IRepository, Repository>();

            sevices.AddDatabaseDeveloperPageExceptionFilter();

            return sevices;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection sevices, IConfiguration config)
        {
            sevices
                .AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return sevices;
        }


    }
}
