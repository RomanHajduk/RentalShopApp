using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.CSVReader.Extensions
{
    public static class BookExtensions
    {
        public static IEnumerable<Book> ToBook(this IEnumerable<string> source)
        {
            foreach (var line in source)
            { 
                var columns = line.Split(',');
                yield return new Book
                {
                    Title = columns[0],
                    Author = columns[1],
                    Genre = columns[2],
                    ReleaseDate = int.Parse(columns[3])
                };
            }
        }
    }
}
