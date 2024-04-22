using System.ComponentModel.DataAnnotations;
using static Project.Infrastructure.Constants.DateConstants;

namespace Project.Core.Models.ReservationView
{
    public class ReservationInfoViewModel
    {
        [Required]
        [StringLength(UserFirstNameMaxLength, MinimumLength = UserFirstNameMinLength)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(UserLastNameMaxLength, MinimumLength = UserLastNameMinLength)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Date { get; set; } = string.Empty;

        [Required]
        public string Start { get; set; } = string.Empty;

        [Required]
        public string End { get; set; } = string.Empty;
    }
}
