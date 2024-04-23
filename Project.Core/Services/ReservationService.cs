using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Core.Contracts;
using Project.Core.Models.ReservationView;
using Project.Infrastructure.Data.Common;
using Project.Infrastructure.Data.Models;
using static Project.Infrastructure.Constants.RoleConstants;

namespace Project.Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository repository;
        private readonly UserManager<ApplicationUser> userManager;
        public ReservationService(IRepository _repository, UserManager<ApplicationUser> _userManager)
        {
            repository = _repository;
            userManager = _userManager;
        }

        public async Task AddEmployeeAsync(string userName, string restaurantName)
        {
            var user = await userManager.FindByNameAsync(userName);
            var restaurant = await repository.AllReadOnly<Restaurant>().FirstAsync(c => c.Name == restaurantName);

            user.EMPRSID = restaurant.Id;
            await userManager.AddToRoleAsync(user, Employee);

            await repository.SaveChangesAsync();

        }

        public async Task<List<ReservationInfoViewModel>> AllReservationAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var reservations = await repository.AllReadOnly<Reservation>()
                .Where(r => r.RestaurantId == user.EMPRSID)
                .Select(r => new ReservationInfoViewModel
                {
                    FirstName = r.User.FirstName,
                    LastName = r.User.LastName,
                    PhoneNumber = r.User.PhoneNumber,
                    Date = r.Date,
                    Start = r.Start,
                    End = r.End,
                })
                .ToListAsync();


            return reservations;
        }

        public async Task<List<EmployeeInfoViewModel>> AllUsersAsync(string userId)
        {

            var employeeViewInfoModels = new List<EmployeeInfoViewModel>();
            var users = await userManager.Users.ToListAsync();
            
            foreach (var user in users)
            {
                bool isEmployee = await userManager.IsInRoleAsync(user, Employee);
                bool IsRestauntior = await userManager.IsInRoleAsync(user, AdminRole);

                var restaurants = await repository.AllReadOnly<Restaurant>().Where(r => r.RestaurateurId == userId).ToListAsync();
                employeeViewInfoModels.Add(new EmployeeInfoViewModel
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsEmployee = isEmployee,
                    IsRestauntior = IsRestauntior,
                    Restaurants = restaurants

                });
            }

            return employeeViewInfoModels;
        }

        public async Task<Restaurant> RemoveFromEmployeeAsync(string userName, string userId)
        {
            var user = await userManager.FindByEmailAsync(userName);
            var restaurant = await repository.AllReadOnly<Restaurant>().FirstAsync(c => c.Id == user.EMPRSID);

            if (restaurant.RestaurateurId !=  userId)
            {
                return null;
            }

            await userManager.RemoveFromRoleAsync(user, Employee);

            user.EMPRSID = -1;

            return restaurant;
        }

        public async Task ReservationAsync(string name, string lastName, string phone, string date, string start, string end, int restaurantId, string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            user.PhoneNumber = phone;
            user.FirstName = name;
            user.LastName = lastName;

            var reservation = new Reservation()
            {
                RestaurantId = restaurantId,
                UserId = userId,
                Date = date,
                Start = start,
                End = end,

            };


            await repository.AddAsync(reservation);
            await repository.SaveChangesAsync();

            
        }

        public async Task YesAsync(string phoneNumber)
        {
            var reservation = await repository.AllReadOnly<Reservation>().FirstAsync(o => o.User.PhoneNumber == phoneNumber);

            await repository.DeleteAsync<Reservation>(reservation.Id);

            await repository.SaveChangesAsync();
        }
    }
}
