namespace RentalShopApp.Entities
{
    public class Book: EntityBase
    {
        
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int ReleaseDate { get; set; }
        public override string ToString() => $"Id: {Id} Author: {Author} Title: {Title} Genre: {Genre} Release Date: {ReleaseDate}";

        public Book()
        {
            Title = "unknown";
            Author = "unknown";
            Genre = "unknown";
            ReleaseDate = 0;
        }
        public Book(string title, string author, string genre, int releaseDate)
        {
            Title = title;
            Author = author;
            Genre = genre;
            ReleaseDate = releaseDate;
        }
    }
}
