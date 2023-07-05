using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using Homies.Data;
using Microsoft.AspNetCore.Identity;

namespace Homies.Models
{
    public class AddViewModel
    {
        [Required]
        [StringLength(DataConstants.Event.NameMaxLength, MinimumLength = DataConstants.Event.NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Event.DescriptionMaxLength,
                      MinimumLength = DataConstants.Event.DescriptionMinLength)]
        public string Description { get; set; } = null!;

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

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
