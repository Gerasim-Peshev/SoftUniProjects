using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Identity;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Event.NameMaxLength, MinimumLength = DataConstants.Event.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Event.DescriptionMaxLength,
                      MinimumLength = DataConstants.Event.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required] 
        public string OrganiserId { get; set; } = null!;

        [Required] 
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        public DateTime End { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        [Required] 
        public Type Type { get; set; } = null!;

        public IEnumerable<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
    }
}
