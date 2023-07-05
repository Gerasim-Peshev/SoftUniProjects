using System.Security.Claims;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private LibraryDbContext context;


        public BookController(LibraryDbContext libraryDb)
        {
            context = libraryDb;
        }

        public async Task<IActionResult> All()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var books = await GetAllBooksAsync();

            return View(books);
        }

        public async Task<IActionResult> Mine()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var books = await GetMyBooks(GetUserId());

            return View(books);
        }

        public async Task<IActionResult> Add()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var categories = await context.Categories.ToListAsync();

            var model = new AddBookViewModel()
            {
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel book)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            decimal rating;

            if (book.Rating < 0 || book.Rating > 10)
            {
                ModelState.AddModelError(nameof(book.Rating),"Rating must be between 0 and 10");
                
                book.Categories = await context.Categories.ToListAsync();

                return View(book);
            }

            if (ModelState.IsValid == false)
            {
                book.Categories = await context.Categories.ToListAsync();

                return View(book);
            }

            await AddBook(book);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            await AddBookToCollection(id);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            await RemoveBookFromCollection(id);

            return RedirectToAction("Mine", "Book");
        }

        private async Task AddBook(AddBookViewModel book)
        {
            var bookToAdd = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                ImageUrl = book.Url,
                Rating = book.Rating
            };

            await context.Books.AddAsync(bookToAdd);
            await context.SaveChangesAsync();
        }

        private async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
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

        private async Task AddBookToCollection(int id)
        {
            var book = await GetBookById(id);
            var userId = GetUserId();

            if (book == null || userId == null)
            {
                return;
            }

            bool alreadyAdded = await context.IdentityUserBooks
                                             .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook()
                {
                    CollectorId = userId,
                    BookId = book.Id
                };

                await context.IdentityUserBooks.AddAsync(userBook);
                await context.SaveChangesAsync();
            }
        }

        private async Task RemoveBookFromCollection(int id)
        {
            var userId = GetUserId();

            var userBook = await context.IdentityUserBooks
                                        .Where(ub => ub.CollectorId == userId && ub.BookId == id)
                                        .FirstOrDefaultAsync();

            if (userBook != null)
            {
                context.IdentityUserBooks.Remove(userBook);
                await context.SaveChangesAsync();
            }
        }

        private async Task<IEnumerable<BookViewModel>> GetMyBooks(string id)
        {
            var books = await context.IdentityUserBooks
                                     .Where(ub => ub.CollectorId == id)
                                     .Select(b => new BookViewModel()
                                      {
                                          Id = b.Book.Id,
                                          Title = b.Book.Title,
                                          Author = b.Book.Author,
                                          ImageUrl = b.Book.ImageUrl,
                                          Rating = b.Book.Rating,
                                          Category = b.Book.Category.Name,
                                      }).ToListAsync();

            return books;
        }

        private async Task<BookViewModel> GetBookById(int id)
        {
            var book = await context.Books
                                    .Where(b => b.Id == id)
                                    .Select(b => new BookViewModel()
                                     {
                                         Id = b.Id,
                                         Title = b.Title,
                                         Author = b.Author,
                                         Rating = b.Rating,
                                         ImageUrl = b.ImageUrl,
                                         Category = b.Category.Name
                                     }).FirstOrDefaultAsync();

            return book;
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
