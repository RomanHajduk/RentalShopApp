using Microsoft.EntityFrameworkCore;
namespace RentalShopApp.Entities
{
    [PrimaryKey(nameof(Id))]
    public class PCGame: EntityBase
    { 
        public string Title { get; set; }
        public int ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int PEGI { get; set; }

        public override string ToString() => $"Id: {Id} Game: {Title} Genre: {Genre} PEGI: {PEGI} Date Release: {ReleaseDate}";
        public PCGame()
        {
            Title = "";
            ReleaseDate = 0;
            Genre = "";
            PEGI = 0;
        }
        public PCGame(string title, int releaseDate, string genre, int pegi)
        {
            Title = title;
            ReleaseDate = releaseDate;
            Genre = genre;
            PEGI = pegi;
        }
    }
}
