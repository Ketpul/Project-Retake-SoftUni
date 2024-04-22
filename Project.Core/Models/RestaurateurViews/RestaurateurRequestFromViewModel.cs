using System.ComponentModel.DataAnnotations;
using static Project.Infrastructure.Constants.DateConstants;

namespace Project.Core.Models.OwnerViews
{
    public class RestaurateurRequestFromViewModel
    {
        public int Id { get; set; }
        public string RestaurateurId { get; set; } = string.Empty;

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
        [StringLength(UserInformationMaxLength, MinimumLength = UserInformationMinLength)]
        public string Information { get; set; } = string.Empty;

        [Required]
        public DateTime DateTime { get; set; }
    }
}
