using Library.Models;

namespace Library.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<BookViewModel>> GetAllBooksAsync();
    }
}
