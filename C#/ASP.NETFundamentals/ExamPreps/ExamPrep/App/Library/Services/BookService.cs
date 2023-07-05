using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private LibraryDbContext context;

        public BookService(LibraryDbContext data)
        {
            context = data;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
        {
            var books = await context.Books
                                                      .Select(b => new BookViewModel()
                                                       {
                                                           Id = b.Id,
                                                           Title = b.Title,
                                                           Author = b.Author,
                                                           Rating = b.Rating,
                                                           ImageUrl = b.ImageUrl,
                                                           Category = b.Category.Name
                                                       })
                                                      .ToListAsync();

            return books;
        }


    }
}
