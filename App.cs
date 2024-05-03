using RentalShopApp.Repositories;
using RentalShopApp.Entities;

namespace RentalShopApp
{
    public class App : IApp
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<CDMusic> _cdsMusicRepository;
        public App(IRepository<Book> bookRepository, IRepository<CDMusic> cdsMusicRepository)
        {
            _booksRepository = bookRepository;
            _cdsMusicRepository = cdsMusicRepository;
        }


        public void Run()
        {

            Console.WriteLine("A jednak działa");
            //var books = new[]
            //{
            //    new Book { Title = "Krew elfów", Author = "Andrzej Sapkowski", Genre = "Fantasy", ReleaseDate = 1994 },
            //    new Book { Title = "Potop", Author = "Henryk Sienkiewicz", Genre = "Powieść historyczna", ReleaseDate = 1886 },
            //    new Book { Title = "Igła", Author = "Ken Follett", Genre = "Powieść wojenna", ReleaseDate = 1978 },
            //    new Book { Title = "Akademia pana Kleksa", Author = "Jan Brzechwa", Genre = "Literatura dziecięca", ReleaseDate = 1946 },
            //    new Book { Title = "Zakazana archeologia ", Author = "Michael Cremo", Genre = "Paranauka", ReleaseDate = 1998 }
            //};
            _cdsMusicRepository.Add(
                new CDMusic { BandName = "Tristania", AlbumTitle = "Beyond The Veil", Genre = "Gothic Metal", ReleaseDate = 1999 });
            //foreach (var book in books) 
            //{ 
            //    _booksRepository.Add(book);
            //}
            _cdsMusicRepository.Save();
        }
    
    }
}
