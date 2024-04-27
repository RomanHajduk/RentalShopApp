using Microsoft.EntityFrameworkCore;
using RentalShopApp;
using Microsoft.Extensions.DependencyInjection;




var sqlBooksRepository = new SQLRepository<Book>(new RentalShopAppDbContext());
var sqlCDsMusicRepository = new SQLRepository<CDMusic>(new RentalShopAppDbContext());
var sqlPersonnelRepository = new SQLRepository<Employee>(new RentalShopAppDbContext());
var sqlClientsRepository = new SQLRepository<Client>(new RentalShopAppDbContext());
var sqlPCGamesRepository = new SQLRepository<PCGame>(new RentalShopAppDbContext());

sqlBooksRepository._itemAdded += BookAdded;
sqlBooksRepository._itemAdded += AddingBookLog;
sqlBooksRepository._itemRemoved += BookRemoved;
sqlBooksRepository._itemRemoved += RemovingBookLog;

sqlCDsMusicRepository._itemAdded += CDMusicAdded;
sqlCDsMusicRepository._itemAdded += AddingCDMusicLog;
sqlCDsMusicRepository._itemRemoved += CDMusicRemoved;
sqlCDsMusicRepository._itemRemoved += RemovingCDMusicLog;

sqlPCGamesRepository._itemAdded += PCGameAdded;
sqlPCGamesRepository._itemAdded += AddingPCGameLog;
sqlPCGamesRepository._itemRemoved += PCGameRemoved;
sqlPCGamesRepository._itemRemoved += RemovingPCGameLog;

sqlPersonnelRepository._itemAdded += EmployeeAdded;
sqlPersonnelRepository._itemAdded += AddingEmployeeLog;
sqlPersonnelRepository._itemRemoved += EmployeeRemoved;
sqlPersonnelRepository._itemRemoved += RemovingEmployeeLog;

sqlClientsRepository._itemAdded += ClientAdded;
sqlClientsRepository._itemAdded += AddingClientLog;
sqlClientsRepository._itemRemoved += ClientRemoved;
sqlClientsRepository._itemRemoved += RemovingClientLog;
static void BookAdded(object? sender, Book item)
{
    Console.WriteLine($"Book added => {item.Title} from {sender?.GetType().Name}");
}
static void BookRemoved(object? sender, Book item)
{
    Console.WriteLine($"Book removed => {item.Title} from {sender?.GetType().Name}");
}
static void AddingBookLog(object? sender, Book item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "BookAdded " + "[" + item.Title + "]\n");
    }
}
static void RemovingBookLog(object? sender, Book item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "BookRemoved " + "[" + item.Title + "]\n");
    }
}

static void CDMusicAdded(object? sender, CDMusic item)
{
    Console.WriteLine($"CD Music added => {item.BandName} from {sender?.GetType().Name}");
}
static void CDMusicRemoved(object? sender, CDMusic item)
{
    Console.WriteLine($"CD Music removed => {item.BandName} from {sender?.GetType().Name}");
}
static void AddingCDMusicLog(object? sender, CDMusic item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "CDMusicAdded " + "[" + item.BandName + "]\n");
    }
}
static void RemovingCDMusicLog(object? sender, CDMusic item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "CDMusicRemoved " + "[" + item.BandName + "]\n");
    }
}

static void PCGameAdded(object? sender, PCGame item)
{
    Console.WriteLine($"CD Music added => {item.Title} from {sender?.GetType().Name}");
}
static void PCGameRemoved(object? sender, PCGame item)
{
    Console.WriteLine($"PC Game removed => {item.Title} from {sender?.GetType().Name}");
}
static void AddingPCGameLog(object? sender, PCGame item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "PCGameAdded " + "[" + item.Title + "]\n");
    }
}
static void RemovingPCGameLog(object? sender, PCGame item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "PCGameRemoved " + "[" + item.Title + "]\n");
    }
}

static void EmployeeAdded(object? sender, Employee item)
{
    Console.WriteLine($"Employee added => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
}
static void EmployeeRemoved(object? sender, Employee item)
{
    Console.WriteLine($"Employee removed => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
}
static void AddingEmployeeLog(object? sender, Employee item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "EmployeeAdded " + "[" + item.FirstName + " " + item.LastName + "]\n");
    }
}
static void RemovingEmployeeLog(object? sender, Employee item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "EmployeeRemoved " + "[" + item.FirstName + " " + item.LastName + "]\n");
    }
}

static void ClientAdded(object? sender, Client item)
{
    Console.WriteLine($"Client added => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
}
static void ClientRemoved(object? sender, Client item)
{
    Console.WriteLine($"Client removed => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
}
static void AddingClientLog(object? sender, Client item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "ClientAdded " + "[" + item.FirstName + " " + item.LastName + "]\n");
    }
}
static void RemovingClientLog(object? sender, Client item)
{
    DateTime dateTime = DateTime.Now;
    string fileName = "log.txt";
    using (var writer = File.AppendText(fileName))
    {
        writer.Write(dateTime + " " + "ClientRemoved " + "[" + item.FirstName + " " + item.LastName + "]\n");
    }
}
static void AddBooks(IRepository<Book> sqlBooksRepository)
{
    var books = new[]
    {
        new Book { Title = "Kajko i Kokosz: Szkoła latania", Author = "Janusz Christa", Genre = "Fantasy", ReleaseDate = 1981 },
        new Book { Title = "Potop", Author = "Henryk Sienkiewicz", Genre = "Powieść historyczna", ReleaseDate = 1886 },
        new Book { Title = "Igła", Author = "Ken Follett", Genre = "Powieść wojenna", ReleaseDate = 1978 },
        new Book { Title = "Tytus, Romek i A’Tomek – Księga XIX. Tytus aktorem", Author = "Henryk Jerzy Chmielewski", Genre = "Fantasy", ReleaseDate = 1992 },
        new Book { Title = "Batman vs Predator", Author = "Dave Gibbons", Genre = "Sensacja/Fantasy", ReleaseDate = 1993 }
    };
    sqlBooksRepository.AddBatch(books);
}
static void DisplayAllItems(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
void CreateDataForAllRepositories()
{

    Console.Clear();
    sqlBooksRepository.Add(new Book { Title = "Krew elfów", Author = "Andrzej Sapkowski", Genre = "Fantasy", ReleaseDate = 1994 });
    sqlBooksRepository.Add(new Book { Title = "Potop", Author = "Henryk Sienkiewicz", Genre = "Powieść historyczna", ReleaseDate = 1886 });
    sqlBooksRepository.Add(new Book { Title = "Igła", Author = "Ken Follett", Genre = "Powieść wojenna", ReleaseDate = 1978 });
    sqlBooksRepository.Add(new Book { Title = "Akademia pana Kleksa", Author = "Jan Brzechwa", Genre = "Literatura dziecięca", ReleaseDate = 1946 });
    sqlBooksRepository.Add(new Book { Title = "Zakazana archeologia ", Author = "Michael Cremo", Genre = "Paranauka", ReleaseDate = 1998 });
    sqlBooksRepository.Save();
    Console.WriteLine("Added Book To Repository");
    sqlBooksRepository.Add(new Book { Title = "Kajko i Kokosz: Szkoła latania", Author = "Janusz Christa", Genre = "Fantasy", ReleaseDate = 1981 });
    sqlBooksRepository.Add(new Book { Title = "Tytus, Romek i A’Tomek – Księga XIX. Tytus aktorem", Author = "Henryk Jerzy Chmielewski", Genre = "Fantasy", ReleaseDate = 1992 });
    sqlBooksRepository.Add(new Book { Title = "Batman vs Predator", Author = "Dave Gibbons", Genre = "Sensacja/Fantasy", ReleaseDate = 1993 });
    sqlBooksRepository.Add(new Book { Title = "Jonka, Jonek i Kleks. Złoto Alaski", Author = "Szarlota Pawel", Genre = "Adventure Fantasy", ReleaseDate = 1986 });
    sqlBooksRepository.Add(new Book { Title = "Superman Doomsday", Author = "Dan Jurgens", Genre = "SF", ReleaseDate = 1996 });
    sqlBooksRepository.Save();
    Console.WriteLine("Added ComicBook To Repository");
    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Moonspell", AlbumTitle = "Night Eternal", Genre = "Black Gothic Romantic Metal", ReleaseDate = 2008 });
    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Therion", AlbumTitle = "Theli", Genre = "Symphonic Metal", ReleaseDate = 1996 });
    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Bon Jovi", AlbumTitle = "Keep The Faith", Genre = "Rock", ReleaseDate = 1992 });
    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Modern Talking", AlbumTitle = "Let’s Talk About Love", Genre = "Dance Pop", ReleaseDate = 1985 });
    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Enigma", AlbumTitle = "The Screen Behind The Mirror", Genre = "Pop", ReleaseDate = 1999 });
    sqlCDsMusicRepository.Save();
    Console.WriteLine("Added CompactDiscMusic To Repository");
    sqlPCGamesRepository.Add(new PCGame { Title = "Wiedźmin 3: Dziki Gon", PEGI = 19, Genre = "Fantasy Action", ReleaseDate = 2015 });
    sqlPCGamesRepository.Add(new PCGame { Title = "Crash Bandicoot N Sane Trilogy", PEGI = 0, Genre = "Arcade", ReleaseDate = 2017 });
    sqlPCGamesRepository.Add(new PCGame { Title = "Mortal Kombat 11", PEGI = 18, Genre = "Fight", ReleaseDate = 2019 });
    sqlPCGamesRepository.Add(new PCGame { Title = "Total Annihilation", PEGI = 12, Genre = "RTS", ReleaseDate = 1997 });
    sqlPCGamesRepository.Add(new PCGame { Title = "Risen", PEGI = 16, Genre = "RPG", ReleaseDate = 2009 });
    sqlPCGamesRepository.Save();
    Console.WriteLine("Added DVDGame To Repository");
    sqlPersonnelRepository.Add(new Employee { FirstName = "Paweł", LastName = "Likus", TypeOfWork = "Manager", Age = 33 });
    sqlPersonnelRepository.Add(new Employee { FirstName = "Dominika", LastName = "Chmiel", TypeOfWork = "Customer Service", Age = 25 });
    sqlPersonnelRepository.Add(new Employee { FirstName = "Anna", LastName = "Ziółko", TypeOfWork = "Customer Service", Age = 22 });
    sqlPersonnelRepository.Save();
    Console.WriteLine("Added Personnel To Repository");
    sqlClientsRepository.Add(new Client { FirstName = "Anna", LastName = "Niepocieszona", PremiumClient = true, Age = 30 });
    sqlClientsRepository.Add(new Client { FirstName = "Antoni", LastName = "Saper", PremiumClient = false, Age = 40 });
    sqlClientsRepository.Add(new Client { FirstName = "Radosław", LastName = "Michalik", PremiumClient = true, Age = 28 });
    sqlClientsRepository.Save();
    Console.WriteLine("Added Clients To Repository");
}

bool RemoveAllDataFromSQLBooksRepository()
{
    var done = false;
    if (sqlBooksRepository.GetAll().Count() != 0)
    {
        foreach (Book item in sqlBooksRepository.GetAll())
        {
            sqlBooksRepository.Remove(item);
        }
        done = true;
    }
    else
    {
        throw new Exception("SQLBooksRepository not exists.");
    }
    return done;
}
bool RemoveAllDataFromSQLCDsMusicRepository()
{
    var done = false;
    if (sqlCDsMusicRepository.GetAll().Count() != 0)
    {
        foreach (CDMusic item in sqlCDsMusicRepository.GetAll())
        {
            sqlCDsMusicRepository.Remove(item);
        }
        done = true;
    }
    else
    {
        throw new Exception("SQLCDsMusicRepository not exists.");
    }
    return done;
}
bool RemoveAllDataFromSQLPCGamesRepository()
{
    var done = false;
    if (sqlPCGamesRepository.GetAll().Count() != 0)
    {
        foreach (PCGame item in sqlPCGamesRepository.GetAll())
        {
            sqlPCGamesRepository.Remove(item);
        }
        done = true;
    }
    else
    {
        throw new Exception("SQLPCGamesRepository not exists.");
    }
    return done;
}
bool RemoveAllDataFromSQLPersonnelRepository()
{
    var done = false;
    if (sqlPersonnelRepository.GetAll().Count() != 0)
    {
        foreach (Employee item in sqlPersonnelRepository.GetAll())
        {
            sqlPersonnelRepository.Remove(item);
        }
        done = true;
    }
    else
    {
        throw new Exception("SQLPersonnelRepository not exists.");
    }
    return done;
}
bool RemoveAllDataFromSQLClientsRepository()
{
    var done = false;
    if (sqlClientsRepository.GetAll().Count() != 0)
    {
        foreach (Client item in sqlClientsRepository.GetAll())
        {
            sqlClientsRepository.Remove(item);
        }
        done = true;
    }
    else
    {
        throw new Exception("SQLClientsRepository not exists.");
    }
    return done;
}
void RemoveAllDataFromRepositories()
{
    try
    {
        Console.WriteLine(RemoveAllDataFromSQLBooksRepository() ? "All Data from SQLBooksRepository was removed!" : "SQLBooksRepository is empty!");
    }
    catch (Exception ex)
    {
        ShowMessage(ex.Message);
    }
    try
    {
        Console.WriteLine(RemoveAllDataFromSQLCDsMusicRepository() ? "All Data from SQLCDsMusicRepository was removed!" : "SQLCDsMusicRepository is empty!");
    }
    catch (Exception ex)
    {
        ShowMessage(ex.Message);
    }
    try
    {
        Console.WriteLine(RemoveAllDataFromSQLPCGamesRepository() ? "All Data from SQLPCGamesRepository was removed!" : "SQLPCGamesRepository is empty!");
    }
    catch (Exception ex)
    {
        ShowMessage(ex.Message);
    }
    try
    {
        Console.WriteLine(RemoveAllDataFromSQLPersonnelRepository() ? "All Data from SQLPersonnelRepository was removed!" : "SQLPersonnelRepository is empty!");
    }
    catch (Exception ex)
    {
        ShowMessage(ex.Message);
    }
    try
    {
        Console.WriteLine(RemoveAllDataFromSQLClientsRepository() ? "All Data from SQLClientsRepository was removed!" : "SQLClientsRepository is empty!");
    }
    catch (Exception ex)
    {
        ShowMessage(ex.Message);
    }
}
ConsoleKeyInfo DisplayAddingSubmenu()

{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("*************************************************\n" +
                      "*   Adding Stuff For Rental Books Music Games   *\n" +
                      "*************************************************");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("--------SubMenu----------\n" +
                  "1. Add Book\n" +
                  "2. Add CD Music\n" +
                  "3. Add PC Game\n" +
                  "4. Add Personnel\n" +
                  "5. Add Client\n" +
                  "6. Create objects for all repositories(automatic)\n" +
                  "7. Return to main menu\n" +
                  "Choose option:");
    return Console.ReadKey();
}
ConsoleKeyInfo DisplayDeletingSubmenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("*************************************************\n" +
                      "*   Adding Stuff For Rental Books Music Games   *\n" +
                      "*************************************************");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("--------SubMenu----------\n" +
                  "1. Delete Book\n" +
                  "2. Delete CD Music\n" +
                  "3. Delete PC Game\n" +
                  "4. Delete Personnel\n" +
                  "5. Delete Client\n" +
                  "6. Delete all objects from all repositories(automatic)\n" +
                  "7. Return to main menu\n" +
                  "Choose option:");
    return Console.ReadKey();
}
ConsoleKeyInfo DisplayMainMenu()
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("*************************************************\n" +
                      "*   Adding Stuff For Rental Books Music Games   *\n" +
                      "*************************************************");
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("-----------Menu----------\n" +
                  "1. Menu Adding Stuff\n" +
                  "2. Menu Deleting Stuff\n" +
                  "3. Display all repositories\n" +
                  "4. Exit the application\n" +
                  "Choose option:");
    return Console.ReadKey();
}

bool AddBook()
{
    Console.Clear();
    Console.WriteLine("Adding Book");
    Console.Write("Enter Title: ");
    var title = Console.ReadLine();
    Console.Write("Enter Author: ");
    var author = Console.ReadLine();
    Console.Write("Enter Genre: ");
    var genre = Console.ReadLine();
    Console.Write("Enter Release Date(Year): ");
    var date = Console.ReadLine();
    if (title != null && author != null && genre != null && date != null)
    {
        if (title == "")
        {
            title = "unknown";
        }
        if (author == "")
        {
            author = "unknown";
        }
        if (genre == "")
        {
            genre = "unknown";
        }
        if (date == "")
        {
            date = "0";
        }

        sqlBooksRepository.Add(new Book { Title = title, Author = author, Genre = genre, ReleaseDate = int.Parse(date) });
        sqlBooksRepository.Save();
        return true;
    }
    else
    {
        return false;
    }
}
bool AddCDMusic()
{
    Console.Clear();
    Console.WriteLine("Adding CD Music");
    Console.Write("Enter Band: ");
    var band = Console.ReadLine();
    Console.Write("Enter Album :");
    var album = Console.ReadLine();
    Console.Write("Enter Genre: ");
    var genre = Console.ReadLine();
    Console.Write("Enter Release Date: ");
    var date = Console.ReadLine();
    if (band != null && album != null && genre != null && date != null)
    {
        if (band == "")
        {
            band = "unknown";
        }
        if (album == "")
        {
            album = "unknown";
        }
        if (genre == "")
        {
            genre = "unknown";
        }
        if (date == "")
        {
            date = "0";
        }
        sqlCDsMusicRepository.Add(new CDMusic { BandName = band, AlbumTitle = album, Genre = genre, ReleaseDate = int.Parse(date) });
        sqlCDsMusicRepository.Save();
        return true;
    }
    else
    {
        return false;
    }
}
bool AddPCGame()
{
    Console.Clear();
    Console.WriteLine("Adding DVD Game");
    Console.Write("Enter Title: ");
    var title = Console.ReadLine();
    Console.Write("Enter PEGI classification: ");
    var pegiclass = Console.ReadLine();
    Console.Write("Enter Genre: ");
    var genre = Console.ReadLine();
    Console.Write("Enter Release Date: ");
    var date = Console.ReadLine();
    if (title != null && pegiclass != null && genre != null && date != null)
    {
        if (title == "")
        {
            title = "unknown";
        }
        if (pegiclass == "")
        {
            pegiclass = "unknown";
        }
        if (genre == "")
        {
            genre = "unknown";
        }
        if (date == "")
        {
            date = "0";
        }

        sqlPCGamesRepository.Add(new PCGame { Title = title, PEGI = int.Parse(pegiclass), Genre = genre, ReleaseDate = int.Parse(date) });
        sqlPCGamesRepository.Save();
        return true;
    }
    else
    {
        return false;
    }
}
bool AddPersonnel()
{
    Console.Clear();
    Console.WriteLine("Adding Employee");
    Console.Write("Enter FirstName: ");
    var firstname = Console.ReadLine();
    Console.Write("Enter LastName: ");
    var lastname = Console.ReadLine();
    Console.Write("Enter Type Of Work: ");
    var typeofwork = Console.ReadLine();
    Console.Write("Enter Age: ");
    var age = Console.ReadLine();
    if (firstname != null && lastname != null && typeofwork != null && age != null)
    {
        if (firstname == "")
        {
            firstname = "unknown";
        }
        if (lastname == "")
        {
            lastname = "unknown";
        }
        if (typeofwork == "")
        {
            typeofwork = "unknown";
        }
        if (age == "")
        {
            age = "0";
        }

        sqlPersonnelRepository.Add(new Employee { FirstName = firstname, LastName = lastname, TypeOfWork = typeofwork, Age = int.Parse(age) });
        sqlPersonnelRepository.Save();
        return true;
    }
    else
    {
        return false;
    }
}
bool AddClient()
{
    Console.Clear();
    Console.WriteLine("Adding Employee");
    Console.Write("Enter FirstName: ");
    var firstname = Console.ReadLine();
    Console.Write("Enter LastName: ");
    var lastname = Console.ReadLine();
    Console.Write("Is PremiumClient( true or false): ");
    var premiumclient = Console.ReadLine();
    Console.Write("Enter Age: ");
    var age = Console.ReadLine();
    if (firstname != null && lastname != null && premiumclient != null && age != null)
    {
        if (firstname == "")
        {
            firstname = "unknown";
        }
        if (lastname == "")
        {
            lastname = "unknown";
        }
        if (premiumclient == "")
        {
            premiumclient = "false";
        }
        if (age == "")
        {
            age = "0";
        }

        sqlClientsRepository.Add(new Client { FirstName = firstname, LastName = lastname, PremiumClient = bool.Parse(premiumclient), Age = int.Parse(age) });
        sqlClientsRepository.Save();
        return true;
    }
    else
    {
        return false;
    }
}

void RemoveBook()
{
    Console.Write("Enter ID Book to remove:");
    var idbook = Console.ReadLine();
    var ID = int.Parse(idbook);
    var exists = false;
    foreach (Book item in sqlBooksRepository.GetAll())
    {
        if (item.Id == ID)
        {
            sqlBooksRepository.Remove(item);
            sqlBooksRepository.Save();
            exists = true;
            break;
        }
    }
    if (!exists)
    {
        throw new Exception("Given ID Book not exists in repository!");
    }
}
void RemoveCDMusic()
{
    Console.Write("Enter ID CD Music to remove:");
    var idcdmusic = Console.ReadLine();
    var ID = int.Parse(idcdmusic);
    var exists = false;
    foreach (CDMusic item in sqlCDsMusicRepository.GetAll())
    {
        if (item.Id == ID)
        {
            sqlCDsMusicRepository.Remove(item);
            sqlCDsMusicRepository.Save();
            exists = true;
            break;
        }
    }
    if (!exists)
    {
        throw new Exception("Given ID CD Music not exists in repository!");
    }
}
void RemovePCGame()
{
    Console.Write("Enter ID PC Game to remove:");
    var idpcgame = Console.ReadLine();
    var ID = int.Parse(idpcgame);
    var exists = false;
    foreach (PCGame item in sqlPCGamesRepository.GetAll())
    {
        if (item.Id == ID)
        {
            sqlPCGamesRepository.Remove(item);
            sqlPCGamesRepository.Save();
            exists = true;
            break;
        }
    }
    if (!exists)
    {
        throw new Exception("Given ID PC Game not exists in repository!");
    }
}
void RemovePersonnel()
{
    Console.Write("Enter ID Employee to remove:");
    var idemployee = Console.ReadLine();
    var ID = int.Parse(idemployee);
    var exists = false;
    foreach (Employee item in sqlPersonnelRepository.GetAll())
    {
        if (item.Id == ID)
        {
            sqlPersonnelRepository.Remove(item);
            sqlPersonnelRepository.Save();
            exists = true;
            break;
        }
    }
    if (!exists)
    {
        throw new Exception("Given ID Employee not exists in repository!");
    }
}
void RemoveClient()
{
    Console.Write("Enter ID Client to remove:");
    var idclient = Console.ReadLine();
    var ID = int.Parse(idclient);
    var exists = false;
    foreach (Client item in sqlClientsRepository.GetAll())
    {
        if (item.Id == ID)
        {
            sqlClientsRepository.Remove(item);
            sqlClientsRepository.Save();
            exists = true;
            break;
        }
    }
    if (!exists)
    {
        throw new Exception("Given ID Client not exists in repository!");
    }
}
void DisplayInfo(string message)
{
    Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("------------------------------------------");
    Console.WriteLine($"{message}");
    Console.WriteLine("------------------------------------------");
    Console.ForegroundColor = ConsoleColor.White;
}
void DisplayReturnToMenu()
{
    Console.WriteLine("Press any key to return to menu..");
    Console.ReadKey();
}
void ShowMessage(string message)
{
    Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ForegroundColor = ConsoleColor.White;
}

while (true)
{
    var choose = DisplayMainMenu();
    switch (choose.Key)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            var ret = false;
            do
            {
                var choose2 = DisplayAddingSubmenu();
                switch (choose2.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        try
                        {
                            AddBook();
                        }
                        catch (Exception)
                        {
                            ShowMessage("Incorrect Data! The object was not created.");
                        }
                        DisplayReturnToMenu();
                        Console.Clear();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        try
                        {
                            AddCDMusic();
                        }
                        catch (Exception)
                        {
                            ShowMessage("Incorrect Data! The object was not created.");
                        }
                        DisplayReturnToMenu();
                        Console.Clear();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        try
                        {
                            AddPCGame();
                        }
                        catch (Exception)
                        {
                            ShowMessage("Incorrect Data! The object was not created.");
                        }
                        DisplayReturnToMenu();
                        Console.Clear();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        try
                        {
                            AddPersonnel();
                        }
                        catch (Exception)
                        {
                            ShowMessage("Incorrect Data! The object was not created.");
                        }
                        DisplayReturnToMenu();
                        Console.Clear();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        try
                        {
                            AddClient();
                        }
                        catch (Exception)
                        {
                            ShowMessage("Incorrect Data! The object was not created.");
                        }
                        DisplayReturnToMenu();
                        Console.Clear();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        CreateDataForAllRepositories();
                        DisplayReturnToMenu();
                        Console.Clear();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        ret = true;
                        DisplayInfo("Powrót do głównego menu!!!");
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                    default:
                        ShowMessage("Incorrect option.Please again choose correct option!!");
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                }
            } while (ret == false);
            break;
        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            ret = false;
            do
            {
                var choose3 = DisplayDeletingSubmenu();
                switch (choose3.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        try
                        {
                            Console.Clear();
                            DisplayInfo("All data from sqlBooksRepository");
                            DisplayAllItems(sqlBooksRepository);
                            RemoveBook();
                            await Task.Delay(2000);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            ShowMessage("Try again enter correct ID");
                            DisplayReturnToMenu();
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        try
                        {
                            Console.Clear();
                            DisplayInfo("All data from sqlCDsMusicRepository");
                            DisplayAllItems(sqlCDsMusicRepository);
                            RemoveCDMusic();
                            await Task.Delay(2000);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            ShowMessage("Try again enter correct ID");
                            DisplayReturnToMenu();
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        try
                        {
                            Console.Clear();
                            DisplayInfo("All data from sqlPCGamesRepository");
                            DisplayAllItems(sqlPCGamesRepository);
                            RemovePCGame();
                            await Task.Delay(2000);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            ShowMessage("Try again enter correct ID");
                            DisplayReturnToMenu();
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        try
                        {
                            Console.Clear();
                            DisplayInfo("All data from sqlPersonnelRepository");
                            DisplayAllItems(sqlPersonnelRepository);
                            RemovePersonnel();
                            await Task.Delay(2000);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            ShowMessage("Try again enter correct ID");
                            DisplayReturnToMenu();
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        try
                        {
                            Console.Clear();
                            DisplayInfo("All data from sqlClientRepository");
                            DisplayAllItems(sqlClientsRepository);
                            RemoveClient();
                            await Task.Delay(2000);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            ShowMessage("Try again enter correct ID");
                            DisplayReturnToMenu();
                            Console.Clear();
                        }
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        RemoveAllDataFromRepositories();
                        DisplayReturnToMenu();
                        Console.Clear();
                        break;
                    case ConsoleKey.D7:
                    case ConsoleKey.NumPad7:
                        ret = true;
                        DisplayInfo("Powrót do głównego menu!!!");
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                    default:
                        ShowMessage("Incorrect option.Please again choose correct option!!");
                        await Task.Delay(2000);
                        Console.Clear();
                        break;
                }
            } while (ret == false);
            break;
        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            Console.Clear();
            DisplayInfo("Items from the repository of books and comics:");
            DisplayAllItems(sqlBooksRepository);
            DisplayInfo("Items from the music CDs repository:");
            DisplayAllItems(sqlCDsMusicRepository);
            DisplayInfo("Items from PC games repository:");
            DisplayAllItems(sqlPCGamesRepository);
            DisplayInfo("Items from employee repository:");
            DisplayAllItems(sqlPersonnelRepository);
            DisplayInfo("Items from clients repository:");
            DisplayAllItems(sqlClientsRepository);
            DisplayReturnToMenu();
            Console.Clear();
            break;
        case ConsoleKey.D4:
        case ConsoleKey.NumPad4:
            Environment.Exit(0);
            break;
        default:
            ShowMessage("Incorrect option.Please again choose correct option!!");
            await Task.Delay(2000);
            Console.Clear();
            break;
    }
}


