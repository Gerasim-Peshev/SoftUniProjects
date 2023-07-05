using Library.Data.Models;
using Library.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(DataConstants.Book.TitleMaxLength, MinimumLength = DataConstants.Book.TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Book.AuthorMaxLength, MinimumLength = DataConstants.Book.AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [StringLength(DataConstants.Book.DescriptionMaxLength, MinimumLength = DataConstants.Book.DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        [Range(DataConstants.Book.RatingMinValue, DataConstants.Book.RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public IEnumerable<Category>? Categories { get; set; }
    }
}
