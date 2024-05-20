using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.DataProviders
{
    public interface IPCGamesProvider
    {
        List<PCGame> GetPCGamesByGenre(string genre);
        List<PCGame> GetPCGamesByPEGI(int age);
        List<PCGame> GetPCGamesByGameTitle(string title);
    }
}
