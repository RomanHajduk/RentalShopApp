using RentalShopApp.Data.Entities;
using RentalShopApp.Data.Repositories;

namespace RentalShopApp.Components.DataProviders
{
    public class CDsMusicProvider : ICDsMusicProvider
    {
        private readonly IRepository<CDMusic> _cdsMusicRepository;
        public CDsMusicProvider(IRepository<CDMusic> cdsMusicRepository)
        {
            _cdsMusicRepository = cdsMusicRepository;
        }
        public List<CDMusic> GetCDsMusicByAlbumTitle(string title)
        {
            var filteredcdsMusic = _cdsMusicRepository.GetAll().Where(cdmusic => cdmusic.AlbumTitle.ToLower() == title.ToLower());
            return filteredcdsMusic.ToList();
        }

        public List<CDMusic> GetCDsMusicByBandName(string bandname)
        {
            var filteredcdsMusic = _cdsMusicRepository.GetAll().Where(cdmusic => cdmusic.BandName.ToLower() == bandname.ToLower());
            return filteredcdsMusic.ToList();
        }

        public List<CDMusic> GetCDsMusicByGenre(string genre)
        {
            var filteredcdsMusic = _cdsMusicRepository.GetAll().Where(cdmusic => cdmusic.Genre.ToLower() == genre.ToLower());
            return filteredcdsMusic.ToList();
        }
    }
}
