using RentalShopApp.Data.Entities;
using RentalShopApp.Data.Repositories;

namespace RentalShopApp.Components.DataProviders
{

    public class BooksProviders : IBooksProvider
    {
        private readonly IRepository<Book> _booksRepository;
        public BooksProviders(IRepository<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            var filteredBooks = _booksRepository.GetAll().Where(book => book.Author == author);
            return filteredBooks.ToList();
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            var filteredBooks = _booksRepository.GetAll().Where(book => book.Genre == genre);
            return filteredBooks.ToList();
        }

        public List<Book> GetBooksByTitle(string title)
        {
            var filteredBooks = _booksRepository.GetAll().Where(book => book.Title == title);
            return filteredBooks.ToList();
        }
    }
}
