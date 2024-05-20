
using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.CSVReader
{
    public interface ICSVReader
    {
        List<Book> ProcessBook(string filepath);
    }
}
