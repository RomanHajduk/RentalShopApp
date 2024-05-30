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
            var filteredBooks = _booksRepository.GetAll().Where(book => book.Author.ToLower() == author.ToLower());
            return filteredBooks.ToList();
        }

        public List<Book> GetBooksByGenre(string genre)
        {
            var filteredBooks = _booksRepository.GetAll().Where(book => book.Genre.ToLower() == genre.ToLower());
            return filteredBooks.ToList();
        }

        public List<Book> GetBooksByTitle(string title)
        {
            var filteredBooks = _booksRepository.GetAll().Where(book => book.Title.ToLower() == title.ToLower());
            return filteredBooks.ToList();
        }
    }
}
