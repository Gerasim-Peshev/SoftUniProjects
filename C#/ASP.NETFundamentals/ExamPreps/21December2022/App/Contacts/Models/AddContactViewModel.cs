using Contacts.Data.Models;
using Contacts.Data;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class AddContactViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Contact.FirstNameMaxLength,
                      MinimumLength = DataConstants.Contact.FirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Contact.LastNameMaxLength,
                      MinimumLength = DataConstants.Contact.LastNameMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Contact.EmailMaxLength,
                      MinimumLength = DataConstants.Contact.EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Contact.PhoneNumberMaxLength,
                      MinimumLength = DataConstants.Contact.PhoneNumberMinLength)]
        [RegularExpression(@"(0||\+359)( ||-)?([0-9]{3})( ||-)?([0-9]{2})( ||-)?([0-9]{2})( ||-)?([0-9]{2})")]
        public string PhoneNumber { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"www.(\w||\d||\-)*.bg")]
        public string Website { get; set; } = null!;
    }
}
