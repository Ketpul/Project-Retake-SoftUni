using Microsoft.AspNetCore.Identity;
using Project.Infrastructure.Data.Models;

namespace Project.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
        public ApplicationUser AdminUser { get; set; }
        public ApplicationUser Guest { get; set; }

        public SeedData()
        {
            SeedUsers();

        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();


            AdminUser = new ApplicationUser()
            {
                Id = "df7c92db-9dec-4483-9b0c-39836de8f44a",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                FirstName = "Admin",
                LastName = "Adminov"
            };


            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123");

            Guest = new ApplicationUser()
            {
                Id = "4bc18388-81ca-42ee-a068-f0a4a4c3fb2d",
                UserName = "Guest",
                NormalizedUserName = "GUEST",
                Email = "Guest@gmail.com",
                NormalizedEmail = "GUEST@GMAIL.COM",
                FirstName = "Guest",
                LastName = "Guestov"
            };


            Guest.PasswordHash =
            hasher.HashPassword(Guest, "guest123");
        }
    }
}
