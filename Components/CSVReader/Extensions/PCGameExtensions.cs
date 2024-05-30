using RentalShopApp.Data.Entities;


namespace RentalShopApp.Components.CSVReader.Extensions
{
    public static class PCGameExtensions
    {
        public static IEnumerable<PCGame> ToPCGame(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');
                yield return new PCGame
                {
                    Title = columns[0],
                    Genre = columns[1],
                    PEGI = int.Parse(columns[2]),
                    ReleaseDate = int.Parse(columns[3])
                };
            }
        }
    }
}
