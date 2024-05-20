using RentalShopApp.Data.Entities;
using RentalShopApp.Data.Repositories;

namespace RentalShopApp.Components.DataProviders
{
    public class PCGamesProvider : IPCGamesProvider
    {
        private readonly IRepository<PCGame> _pcGamesRepository;
        public PCGamesProvider(IRepository<PCGame> pcGamesRepository)
        {
            _pcGamesRepository = pcGamesRepository;
        }
        public List<PCGame> GetPCGamesByGameTitle(string title)
        {
            var filteredPCGames = _pcGamesRepository.GetAll().Where(pcgame => pcgame.Title == title);
            return filteredPCGames.ToList();
        }

        public List<PCGame> GetPCGamesByGenre(string genre)
        {
            var filteredPCGames = _pcGamesRepository.GetAll().Where(pcgame => pcgame.Genre == genre);
            return filteredPCGames.ToList();
        }
        public List<PCGame> GetPCGamesByPEGI(int age)
        {
            var filteredPCGames = _pcGamesRepository.GetAll().Where(pcgame => pcgame.PEGI >= age);
            return filteredPCGames.ToList();
        }
    }

}
