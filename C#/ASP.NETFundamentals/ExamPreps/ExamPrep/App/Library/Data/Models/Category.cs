using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(DataConstants.Category.NameMaxLenght, MinimumLength = DataConstants.Category.NameMaxLenght)]
        public string Name { get; set; } = null!;
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
    }
}
