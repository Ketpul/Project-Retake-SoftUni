using Project.Core.Models.ReservationView;
using Project.Infrastructure.Data.Models;

namespace Project.Core.Contracts
{
    public interface IReservationService
    {
        Task AddEmployeeAsync(string userName, string restaurantName);
        Task<Restaurant> RemoveFromEmployeeAsync(string userName, string userId);

        Task<List<EmployeeInfoViewModel>> AllUsersAsync(string userId);

        Task ReservationAsync(string name, string lastName, string phone, string date, string start, string end, int restaurantId, string userId);

        Task<List<ReservationInfoViewModel>> AllReservationAsync(string userId);

        Task YesAsync(string phoneNumber);
    }
}
