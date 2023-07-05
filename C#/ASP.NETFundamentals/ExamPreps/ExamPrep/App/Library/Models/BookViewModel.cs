using Library.Data;
using System.ComponentModel.DataAnnotations;
using Library.Data.Models;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; init; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Rating { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string Category { get; set; } = null!;
    }
}
