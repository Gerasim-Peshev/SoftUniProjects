using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class Book
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
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(DataConstants.Book.RatingMinValue, DataConstants.Book.RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required] 
        public Category Category { get; set; } = null!;


        public IEnumerable<IdentityUserBook> UsersBooks { get; set; } = new List<IdentityUserBook>();
    }
}
