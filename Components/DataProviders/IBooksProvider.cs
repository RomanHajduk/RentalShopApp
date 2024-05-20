using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.DataProviders
{
    public interface IBooksProvider
    {
        List<Book> GetBooksByGenre(string genre);
        List<Book> GetBooksByAuthor(string author);
        List<Book> GetBooksByTitle(string title);
    }
}
