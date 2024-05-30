
using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.CSVReader
{
    public interface ICSVReader
    {
        List<Book> ProcessBook(string filepath);
        List<CDMusic> ProcessCDMusic(string filepath);
        List<PCGame> ProcessPCGame(string filepath);
        List<Employee> ProcessEmployee(string filepath);
        List<Client> ProcessClient(string filepath);
    }
}
