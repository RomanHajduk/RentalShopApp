using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.DataProviders
{
    public interface ICDsMusicProvider
    {
        List<CDMusic> GetCDsMusicByGenre(string genre);
        List<CDMusic> GetCDsMusicByBandName(string author);
        List<CDMusic> GetCDsMusicByAlbumTitle(string title);
    }
}
