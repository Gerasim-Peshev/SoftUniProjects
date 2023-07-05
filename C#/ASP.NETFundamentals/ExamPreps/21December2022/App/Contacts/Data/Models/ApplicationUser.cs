using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Contacts.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(DataConstants.ApplicationUser.UserNameMaxLength,
                      MinimumLength = DataConstants.ApplicationUser.UserNameMinLength)] 
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ApplicationUser.EmailMaxLength,
                      MinimumLength = DataConstants.ApplicationUser.EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.ApplicationUser.PasswordMaxLength,
                      MinimumLength = DataConstants.ApplicationUser.PasswordMinLength)]
        public string Password { get; set; } = null!;

        public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } =
            new List<ApplicationUserContact>();
    }
}
