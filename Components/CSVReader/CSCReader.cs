namespace RentalShopApp.Components.CSVReader
{
    using RentalShopApp.Data.Entities;
    using Components.CSVReader.Extensions;

    public class CSCReader : ICSVReader
    {
        public List<Book> ProcessBook(string filepath)
        {
            if (!File.Exists(filepath)) 
            { 
                return new List<Book>();
            }
            else
            {
                try
                {
                    var books = File.ReadAllLines(filepath).ToBook();
                    return books.ToList();
                }
                catch (Exception)
                {

                    throw new Exception("błąd wew");
                }
                
            }
        }
    }
}
