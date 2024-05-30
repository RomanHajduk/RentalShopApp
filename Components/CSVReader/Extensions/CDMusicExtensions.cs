using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.CSVReader.Extensions
{
    public static class CDMusicExtensions
    {
        public static IEnumerable<CDMusic> ToCDMusic(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');
                yield return new CDMusic
                {
                    BandName = columns[0],
                    AlbumTitle= columns[1],
                    Genre = columns[2],
                    ReleaseDate = int.Parse(columns[3])
                };
            }
        }
    }
}
