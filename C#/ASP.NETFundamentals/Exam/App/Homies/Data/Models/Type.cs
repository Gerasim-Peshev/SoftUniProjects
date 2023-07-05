using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Type.NameMaxLength, MinimumLength = DataConstants.Type.NameMinLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
