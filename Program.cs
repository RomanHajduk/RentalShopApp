using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using RentalShopApp;
using RentalShopApp.Data;
using RentalShopApp.Components.DataProviders;
using RentalShopApp.Data.Entities;
using RentalShopApp.Data.Repositories;
using RentalShopApp.Services.Menu;
using RentalShopApp.Services.UserCommunication;
using RentalShopApp.Components.CSVReader;
using RentalShopApp.Services.Events;

var services = new ServiceCollection();
services.AddSingleton<IApp,App>();
services.AddSingleton<IRepository<Book>, DbRepository<Book>>();
services.AddSingleton<IRepository<CDMusic>, DbRepository<CDMusic>>();
services.AddSingleton<IRepository<PCGame>, DbRepository<PCGame>>();
services.AddSingleton<IRepository<Employee>, DbRepository<Employee>>();
services.AddSingleton<IRepository<Client>, DbRepository<Client>>();
services.AddSingleton<IProviderCommunication, ProviderCommunication>();
services.AddSingleton<IRepositoryCommunication, RepositoryCommunication>();
services.AddSingleton<IBooksProvider, BooksProviders>();
services.AddSingleton<ICDsMusicProvider, CDsMusicProvider>();
services.AddSingleton<IPCGamesProvider, PCGamesProvider>();
services.AddSingleton<IEmployeesProvider, EmployeesProvider>();
services.AddSingleton<IClientsProvider, ClientsProvider>();
services.AddSingleton<ICSVReader,CSVReader>();
services.AddSingleton<IEventsMethods, EventsMethods>();
services.AddSingleton<IMenu, Menu>();
services.AddDbContext<RentalShopAppDbContext>(options => options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=RentalShopStorage;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"));
services.AddScoped<DbContext, RentalShopAppDbContext>();
var serviceProvider = services.BuildServiceProvider();
var app = serviceProvider.GetService<IApp>();
app.Run();
//var nameclass = typeof(Book).Name;
//Console.WriteLine($"klasa Name: {nameclass}");
//var proper = typeof(Book).GetProperties();
//foreach (var item in proper)
//{
//    Console.WriteLine("właściwość: " + item.Name + " " + item.PropertyType.Name);
//}



//sqlBooksRepository._itemAdded += BookAdded;
//sqlBooksRepository._itemAdded += AddingBookLog;
//sqlBooksRepository._itemRemoved += BookRemoved;
//sqlBooksRepository._itemRemoved += RemovingBookLog;

//sqlCDsMusicRepository._itemAdded += CDMusicAdded;
//sqlCDsMusicRepository._itemAdded += AddingCDMusicLog;
//sqlCDsMusicRepository._itemRemoved += CDMusicRemoved;
//sqlCDsMusicRepository._itemRemoved += RemovingCDMusicLog;

//sqlPCGamesRepository._itemAdded += PCGameAdded;
//sqlPCGamesRepository._itemAdded += AddingPCGameLog;
//sqlPCGamesRepository._itemRemoved += PCGameRemoved;
//sqlPCGamesRepository._itemRemoved += RemovingPCGameLog;

//sqlPersonnelRepository._itemAdded += EmployeeAdded;
//sqlPersonnelRepository._itemAdded += AddingEmployeeLog;
//sqlPersonnelRepository._itemRemoved += EmployeeRemoved;
//sqlPersonnelRepository._itemRemoved += RemovingEmployeeLog;

//sqlClientsRepository._itemAdded += ClientAdded;
//sqlClientsRepository._itemAdded += AddingClientLog;
//sqlClientsRepository._itemRemoved += ClientRemoved;
//sqlClientsRepository._itemRemoved += RemovingClientLog;
//static void BookAdded(object? sender, Book item)
//{
//    Console.WriteLine($"Book added => {item.Title} from {sender?.GetType().Name}");
//}
//static void BookRemoved(object? sender, Book item)
//{
//    Console.WriteLine($"Book removed => {item.Title} from {sender?.GetType().Name}");
//}
//static void AddingBookLog(object? sender, Book item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "BookAdded " + "[" + item.Title + "]\n");
//    }
//}
//static void RemovingBookLog(object? sender, Book item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "BookRemoved " + "[" + item.Title + "]\n");
//    }
//}

//static void CDMusicAdded(object? sender, CDMusic item)
//{
//    Console.WriteLine($"CD Music added => {item.BandName} from {sender?.GetType().Name}");
//}
//static void CDMusicRemoved(object? sender, CDMusic item)
//{
//    Console.WriteLine($"CD Music removed => {item.BandName} from {sender?.GetType().Name}");
//}
//static void AddingCDMusicLog(object? sender, CDMusic item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "CDMusicAdded " + "[" + item.BandName + "]\n");
//    }
//}
//static void RemovingCDMusicLog(object? sender, CDMusic item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "CDMusicRemoved " + "[" + item.BandName + "]\n");
//    }
//}

//static void PCGameAdded(object? sender, PCGame item)
//{
//    Console.WriteLine($"CD Music added => {item.Title} from {sender?.GetType().Name}");
//}
//static void PCGameRemoved(object? sender, PCGame item)
//{
//    Console.WriteLine($"PC Game removed => {item.Title} from {sender?.GetType().Name}");
//}
//static void AddingPCGameLog(object? sender, PCGame item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "PCGameAdded " + "[" + item.Title + "]\n");
//    }
//}
//static void RemovingPCGameLog(object? sender, PCGame item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "PCGameRemoved " + "[" + item.Title + "]\n");
//    }
//}

//static void EmployeeAdded(object? sender, Employee item)
//{
//    Console.WriteLine($"Employee added => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
//}
//static void EmployeeRemoved(object? sender, Employee item)
//{
//    Console.WriteLine($"Employee removed => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
//}
//static void AddingEmployeeLog(object? sender, Employee item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "EmployeeAdded " + "[" + item.FirstName + " " + item.LastName + "]\n");
//    }
//}
//static void RemovingEmployeeLog(object? sender, Employee item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "EmployeeRemoved " + "[" + item.FirstName + " " + item.LastName + "]\n");
//    }
//}

//static void ClientAdded(object? sender, Client item)
//{
//    Console.WriteLine($"Client added => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
//}
//static void ClientRemoved(object? sender, Client item)
//{
//    Console.WriteLine($"Client removed => {item.FirstName} {item.LastName} from {sender?.GetType().Name}");
//}
//static void AddingClientLog(object? sender, Client item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "ClientAdded " + "[" + item.FirstName + " " + item.LastName + "]\n");
//    }
//}
//static void RemovingClientLog(object? sender, Client item)
//{
//    DateTime dateTime = DateTime.Now;
//    string fileName = "log.txt";
//    using (var writer = File.AppendText(fileName))
//    {
//        writer.Write(dateTime + " " + "ClientRemoved " + "[" + item.FirstName + " " + item.LastName + "]\n");
//    }
//}

//static void DisplayAllItems(IReadRepository<IEntity> repository)
//{
//    var items = repository.GetAll();
//    foreach (var item in items)
//    {
//        Console.WriteLine(item);
//    }
//}
//void CreateDataForAllRepositories()
//{

//    Console.Clear();
//    sqlBooksRepository.Add(new Book { Title = "Krew elfów", Author = "Andrzej Sapkowski", Genre = "Fantasy", ReleaseDate = 1994 });
//    sqlBooksRepository.Add(new Book { Title = "Potop", Author = "Henryk Sienkiewicz", Genre = "Powieść historyczna", ReleaseDate = 1886 });
//    sqlBooksRepository.Add(new Book { Title = "Igła", Author = "Ken Follett", Genre = "Powieść wojenna", ReleaseDate = 1978 });
//    sqlBooksRepository.Add(new Book { Title = "Akademia pana Kleksa", Author = "Jan Brzechwa", Genre = "Literatura dziecięca", ReleaseDate = 1946 });
//    sqlBooksRepository.Add(new Book { Title = "Zakazana archeologia ", Author = "Michael Cremo", Genre = "Paranauka", ReleaseDate = 1998 });
//    sqlBooksRepository.Save();
//    Console.WriteLine("Added Book To Repository");
//    sqlBooksRepository.Add(new Book { Title = "Kajko i Kokosz: Szkoła latania", Author = "Janusz Christa", Genre = "Fantasy", ReleaseDate = 1981 });
//    sqlBooksRepository.Add(new Book { Title = "Tytus, Romek i A’Tomek – Księga XIX. Tytus aktorem", Author = "Henryk Jerzy Chmielewski", Genre = "Fantasy", ReleaseDate = 1992 });
//    sqlBooksRepository.Add(new Book { Title = "Batman vs Predator", Author = "Dave Gibbons", Genre = "Sensacja/Fantasy", ReleaseDate = 1993 });
//    sqlBooksRepository.Add(new Book { Title = "Jonka, Jonek i Kleks. Złoto Alaski", Author = "Szarlota Pawel", Genre = "Adventure Fantasy", ReleaseDate = 1986 });
//    sqlBooksRepository.Add(new Book { Title = "Superman Doomsday", Author = "Dan Jurgens", Genre = "SF", ReleaseDate = 1996 });
//    sqlBooksRepository.Save();
//    Console.WriteLine("Added ComicBook To Repository");
//    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Moonspell", AlbumTitle = "Night Eternal", Genre = "Black Gothic Romantic Metal", ReleaseDate = 2008 });
//    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Therion", AlbumTitle = "Theli", Genre = "Symphonic Metal", ReleaseDate = 1996 });
//    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Bon Jovi", AlbumTitle = "Keep The Faith", Genre = "Rock", ReleaseDate = 1992 });
//    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Modern Talking", AlbumTitle = "Let’s Talk About Love", Genre = "Dance Pop", ReleaseDate = 1985 });
//    sqlCDsMusicRepository.Add(new CDMusic { BandName = "Enigma", AlbumTitle = "The Screen Behind The Mirror", Genre = "Pop", ReleaseDate = 1999 });
//    sqlCDsMusicRepository.Save();
//    Console.WriteLine("Added CompactDiscMusic To Repository");
//    sqlPCGamesRepository.Add(new PCGame { Title = "Wiedźmin 3: Dziki Gon", PEGI = 19, Genre = "Fantasy Action", ReleaseDate = 2015 });
//    sqlPCGamesRepository.Add(new PCGame { Title = "Crash Bandicoot N Sane Trilogy", PEGI = 0, Genre = "Arcade", ReleaseDate = 2017 });
//    sqlPCGamesRepository.Add(new PCGame { Title = "Mortal Kombat 11", PEGI = 18, Genre = "Fight", ReleaseDate = 2019 });
//    sqlPCGamesRepository.Add(new PCGame { Title = "Total Annihilation", PEGI = 12, Genre = "RTS", ReleaseDate = 1997 });
//    sqlPCGamesRepository.Add(new PCGame { Title = "Risen", PEGI = 16, Genre = "RPG", ReleaseDate = 2009 });
//    sqlPCGamesRepository.Save();
//    Console.WriteLine("Added DVDGame To Repository");
//    sqlPersonnelRepository.Add(new Employee { FirstName = "Paweł", LastName = "Likus", TypeOfWork = "Manager", Age = 33 });
//    sqlPersonnelRepository.Add(new Employee { FirstName = "Dominika", LastName = "Chmiel", TypeOfWork = "Customer Service", Age = 25 });
//    sqlPersonnelRepository.Add(new Employee { FirstName = "Anna", LastName = "Ziółko", TypeOfWork = "Customer Service", Age = 22 });
//    sqlPersonnelRepository.Save();
//    Console.WriteLine("Added Personnel To Repository");
//    sqlClientsRepository.Add(new Client { FirstName = "Anna", LastName = "Niepocieszona", PremiumClient = true, Age = 30 });
//    sqlClientsRepository.Add(new Client { FirstName = "Antoni", LastName = "Saper", PremiumClient = false, Age = 40 });
//    sqlClientsRepository.Add(new Client { FirstName = "Radosław", LastName = "Michalik", PremiumClient = true, Age = 28 });
//    sqlClientsRepository.Save();
//    Console.WriteLine("Added Clients To Repository");
//}









