using Homies.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models
{
    public class EditViewModel
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
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        public string Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd H:mm}")]
        public string End { get; set; }

        [Required]
        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
