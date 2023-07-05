using System.Globalization;
using System.Text;
using BookShop.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookShop;

using Data;
using Initializer;

public class StartUp
{
    public static void Main()
    {
        using var db = new BookShopContext();

        Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));

        DbInitializer.ResetDatabase(db);
    }

    //P02
    public static string GetBooksByAgeRestriction(BookShopContext context, string command)
    {
        var sb = new StringBuilder();

        var books = context.Books
                           .AsNoTracking()
                           .ToList()
                           .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                           .OrderBy(b => b.Title)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title}");
        }

        return sb.ToString().TrimEnd();
    }

    //P03
    public static string GetGoldenBooks(BookShopContext context)
    {
        var sb = new StringBuilder();

        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                           .OrderBy(b => b.BookId)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title}");
        }

        return sb.ToString().TrimEnd();
    }

    //P04
    public static string GetBooksByPrice(BookShopContext context)
    {
        var sb = new StringBuilder();

        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.Price > 40)
                           .Select(b => new
                            {
                                b.Title,
                                b.Price
                            })
                           .OrderByDescending(b => b.Price)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //P05
    public static string GetBooksNotReleasedIn(BookShopContext context, int year)
    {
        var sb = new StringBuilder();

        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.ReleaseDate.Value.Year != year)
                           .Select(b => new
                            {
                                b.BookId,
                                b.Title
                            })
                           .OrderBy(b => b.BookId)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title}");
        }

        return sb.ToString().TrimEnd();
    }

    //P06
    public static string GetBooksByCategory(BookShopContext context, string input)
    {
        var sb = new StringBuilder();

        var categories = input.ToLower().Split(' ').ToList();

        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.BookCategories.Any(b => categories.Contains(b.Category.Name.ToLower())))
                           .Select(b => new
                            {
                                b.Title
                            })
                           .OrderBy(b => b.Title)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title}");
        }

        return sb.ToString().TrimEnd();

    }

    //P07
    public static string GetBooksReleasedBefore(BookShopContext context, string date)
    {
        var sb = new StringBuilder();

        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.ReleaseDate.Value < DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture))
                           .Select(b => new
                            {
                                b.Title,
                                EditionType = b.EditionType.ToString(),
                                b.Price,
                                ReleaseDate = b.ReleaseDate.Value
                            })
                           .OrderByDescending(b => b.ReleaseDate)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //P08
    public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
    {
        var sb = new StringBuilder();

        var authors = context.Authors
                             .Where(a => a.FirstName.EndsWith(input))
                             .Select(a => new
                              {
                                  FullName = a.FirstName + " " + a.LastName
                              })
                             .OrderBy(a => a.FullName)
                              .ToList();

        foreach (var author in authors)
        {
            sb.AppendLine($"{author.FullName}");
        }

        return sb.ToString().TrimEnd();
    }

    //P09
    public static string GetBookTitlesContaining(BookShopContext context, string input)
    {
        var sb = new StringBuilder();

        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                           .Select(b => new
                            {
                                b.Title
                            })
                           .OrderBy(b => b.Title)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title}");
        }

        return sb.ToString().TrimEnd();
    }

    //P10
    public static string GetBooksByAuthor(BookShopContext context, string input)
    {
        var sb = new StringBuilder();

        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                           .Select(b => new
                            {
                                b.BookId,
                                b.Title,
                                AuthorFullName = b.Author.FirstName + " " + b.Author.LastName
                            })
                           .OrderBy(b => b.BookId)
                           .ToList();

        foreach (var book in books)
        {
            sb.AppendLine($"{book.Title} ({book.AuthorFullName})");
        }

        return sb.ToString().TrimEnd();
    }

    //P11
    public static int CountBooks(BookShopContext context, int lengthCheck)
    {
        var books = context.Books
                           .AsNoTracking()
                           .Where(b => b.Title.Length > lengthCheck)
                           .Count();

        return books;
    }

    //P12
    public static string CountCopiesByAuthor(BookShopContext context)
    {
        var sb = new StringBuilder();

        var authors = context.Authors
                             .AsNoTracking()
                             .Select(a => new
                              {
                                  FullName = a.FirstName + " " + a.LastName,
                                  Copies = a.Books.Sum(b => b.Copies)
                              })
                             .OrderByDescending(a => a.Copies)
                             .ToList();

        foreach (var author in authors)
        {
            sb.AppendLine($"{author.FullName} - {author.Copies}");
        }

        return sb.ToString().TrimEnd();
    }

    //P13
    public static string GetTotalProfitByCategory(BookShopContext context)
    {
        var sb = new StringBuilder();

        var categories = context.Categories
                           .AsNoTracking()
                           .Select(c => new
                            {
                                c.Name,
                                TotalProfit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price)
                            })
                                .OrderByDescending(c => c.TotalProfit)
                                .ThenBy(c => c.Name)
                                 .ToList();

        foreach (var category in categories)
        {
            sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //P14
    public static string GetMostRecentBooks(BookShopContext context)
    {
        var sb = new StringBuilder();

        var categories = context.Categories
                                .AsNoTracking()
                                .Select(c => new
                                 {
                                     c.Name,
                                     Books = c.CategoryBooks.OrderByDescending(b => b.Book.ReleaseDate.Value).Take(3)
                                 })
                                .OrderBy(c => c.Name)
                                .ToList();

        foreach (var category in categories)
        {
            sb.AppendLine($"--{category.Name}");
            foreach (var bookCategory in category.Books)
            {
                var book = context.Books
                                  .AsNoTracking()
                                  .Where(b => b.BookId == bookCategory.BookId)
                                  .Single();
                sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //P15
    public static void IncreasePrices(BookShopContext context)
    {
        var books = context.Books
                           .Where(b => b.ReleaseDate.Value.Year < 2010)
                           .ToList();

        books.ForEach(b => b.Price += 5);
        context.SaveChanges();
    }

    //P16
    public static int RemoveBooks(BookShopContext context)
    {
        var books = context.Books
                           .Where(b => b.Copies < 4200)
                           .ToList();

        context.RemoveRange(books);
        context.SaveChanges();

        return books.Count;
    }
}



