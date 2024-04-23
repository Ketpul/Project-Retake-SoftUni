using Microsoft.AspNetCore.Identity;
using Project.Infrastructure.Data.Models;
using Project.Infrastructure.Enums;

namespace Project.Infrastructure.Data.SeedDb
{
    public class SeedData
    {
        public ApplicationUser AdminUser { get; set; }
        public ApplicationUser Guest { get; set; }

        public Category Fastfood { get; set; }
        public Category Fishy { get; set; }
        public Category Kaffee { get; set; }
        public Category Bar { get; set; }
        public Category Others { get; set; }

        public Restaurant FirstRestaurant { get; set; }
        public Restaurant SecondRestaurant { get; set; }
        public Restaurant ThirdRestaurant { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedCategories();
            SeedRestaurant();
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

        private void SeedCategories()
        {
            Fastfood = new Category()
            {
                Id = 1,
                Name = "Бързо хранене"
            };

            Fishy = new Category()
            {
                Id = 2,
                Name = "Рибен"
            };

            Kaffee = new Category()
            {
                Id = 3,
                Name = "Кафе"
            };

            Bar = new Category()
            {
                Id = 4,
                Name = "Бар"
            };
            
            Others = new Category()
            {
                Id = 5,
                Name = "Други"
            };
        }

        private void SeedRestaurant()
        {
            FirstRestaurant = new Restaurant()
            {
                Id = 1,
                Name = "Friends Restaurant",
                Address = "Кюстендил Център, бул. „България“ 28, 2503 Кюстендил",
                Description = "ПОВЕЧЕ ЗА НАС\r\n\r\nРесторант Приятели работи в центъра на областния град Кюстендил.\r\nЗад името Friends стои екип от ентусиасти, които година след година реализираха и надграждаха проекта на своите мечти.\r\nВсичко започна през 2012 г.\r\n\r\nКазвам се Станислав Георгиев и съм собственик и главен готвач на ресторант Friends.\r\n",
                ImageUrl1 = "https://lh3.googleusercontent.com/p/AF1QipM2zoyHecvZnoBOMs7hrypki4o9wge9_vdev1a-=s680-w680-h510",
                ImageUrl2 = "https://lh3.googleusercontent.com/p/AF1QipM_nG-VVbAPbj9kg8IuWxoF_rS-aLIypvrKRiQV=s680-w680-h510",
                ImageUrl3 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS55kTuymY_1Xwndx-VRxFdHU4pQ9gkz9eYRINNCdeREA&s",
                CategoryId = Others.Id,
                RestaurateurId = "df7c92db-9dec-4483-9b0c-39836de8f44a",
                GoogleMaps = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d23616.55298788181!2d22.68615055!3d42.277047800000005!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9cf5e3236eeb%3A0x9a4ffe6baa68477a!2z0J_RgNC40Y_RgtC10LvQuCAo0KTRgNC10L3QtNGBKQ!5e0!3m2!1sbg!2sbg!4v1713217046402!5m2!1sbg!2sbg",
                AvgRating= 0,
                RegionalCity = RegionalCity.Кюстендѝл

            };

            SecondRestaurant = new Restaurant()
            {
                Id = 2,
                Name = "Тихият кът",
                Address = "Кюстендил Център, бул. „България“ 28, 2503 Кюстендил",
                Description = "ХРАНА ЗА ВКЪЩИ. ВХОД. ХОТЕЛ. ВХОД. ХРАНА ЗА ВКЪЩИ. ВХОД. ХОТЕЛ. ВХОД. ХРАНА ЗА ВКЪЩИ. ВХОД. seperator-21. ХОТЕЛ.",
                ImageUrl1 = "https://lh5.googleusercontent.com/p/AF1QipPBob7pnM7wo1zv1XHGQu31IZFdgAxSIho8Zwab=w408-h271-k-no",
                ImageUrl2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS9AcvE24PY9wfYJ7Wcu7B5Sfz-s1XqmLaoHf8YGcRN2g&s",
                ImageUrl3 = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/264186573.jpg?k=d0329018a1f3f0ce46ad6eb784f91854739a39fb7021f40a585a2c8a3bafba33&o=&hp=1",
                CategoryId = Fastfood.Id,
                RestaurateurId = "df7c92db-9dec-4483-9b0c-39836de8f44a",
                GoogleMaps = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3941.284954862589!2d22.702939286824954!3d42.26512612570832!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9c99be2ebca1%3A0xd59065bfc6a2a121!2z0KLQuNGF0LjRj9GCINC60YrRgg!5e0!3m2!1sbg!2sbg!4v1713218733870!5m2!1sbg!2sbg",
                AvgRating= 0,
                RegionalCity = RegionalCity.Кюстендѝл
            };

            ThirdRestaurant = new Restaurant()
            {
                Id = 3,
                Name = "Пицария Роял",
                Address = "Кюстендил Център, ул. „Власина“ 2, 2500 Кюстендил",
                Description = " Предлага места на открито · Има камина · Предлага отлични коктейли",
                ImageUrl1 = "https://roterm.biz/images/obekti/royal-1.jpg",
                ImageUrl2 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2qGZwFhxwCnAA8ErQG3exX7PVnCGVZq-U6qVo0rMeBA&s",
                ImageUrl3 = "https://cdn.oink.bg/gallery/15315/045b7f2e-c039-4f44-9576-0d61c54b5b19_large.webp",
                CategoryId = Others.Id,
                RestaurateurId = "df7c92db-9dec-4483-9b0c-39836de8f44a",
                GoogleMaps = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2951.9002932955864!2d22.671783916236077!3d42.28065170000001!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x14aa9cfc7e03709d%3A0xa6b37a649c56b81b!2z0J_QuNGG0LDRgNC40Y8g0KDQvtGP0Ls!5e0!3m2!1sbg!2sbg!4v1713623330862!5m2!1sbg!2sbg",
                AvgRating= 0,
                RegionalCity = RegionalCity.Кюстендѝл
            };
        }
    }
}
