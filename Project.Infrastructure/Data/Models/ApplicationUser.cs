using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Project.Infrastructure.Constants.DateConstants;

namespace Project.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(UserNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(UserNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;

        public int EMPRSID { get; set; } 


    }
}