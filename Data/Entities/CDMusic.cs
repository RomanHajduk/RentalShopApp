using Microsoft.EntityFrameworkCore;
namespace RentalShopApp.Data.Entities
{
    [PrimaryKey(nameof(Id))]
    public class CDMusic : EntityBase
    {
        public string BandName { get; set; }
        public string AlbumTitle { get; set; }
        public string Genre { get; set; }
        public int ReleaseDate { get; set; }

        public override string ToString() => $"Id: {Id} Band: {BandName} Album: {AlbumTitle} Genre: {Genre} Release Date: {ReleaseDate}";

        public CDMusic()
        {
            BandName = "";
            AlbumTitle = "";
            Genre = "";
            ReleaseDate = 0;
        }
        public CDMusic(string band, string album, string genre, int reldate)
        {
            BandName = band;
            AlbumTitle = album;
            Genre = genre;
            ReleaseDate = reldate;
        }
    }
}
