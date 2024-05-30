using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.CSVReader.Extensions
{
    public static class ClientExtensions
    {
        public static IEnumerable<Client> ToClient(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');
                yield return new Client
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    PremiumClient = bool.Parse(columns[2]),
                    Age = int.Parse(columns[3])
                };
            }
        }
    }
}
