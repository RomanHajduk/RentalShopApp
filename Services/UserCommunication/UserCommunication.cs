namespace RentalShopApp.Services.UserCommunication
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.Resources;
    using RentalShopApp.Components.CSVReader;
    using RentalShopApp.Components.DataProviders;
    using RentalShopApp.Data.Entities;
    using RentalShopApp.Data.Repositories;
    using RentalShopApp.Services.Events;

    public class UserCommunication : IUserCommunication
    {

        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<CDMusic> _cdsMusicRepository;
        private readonly IRepository<PCGame> _pcGamesRepository;
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<Client> _clientsRepository;
        private readonly IBooksProvider _booksProvider;
        private readonly ICDsMusicProvider _cdsMusicProvider;
        private readonly IPCGamesProvider _pcGamesProvider;
        private readonly IEmployeesProvider _employeesProvider;
        private readonly IClientsProvider _clientsProvider;
        private readonly ICSVReader _CSVReader;
        private readonly IEventsMethods _eventsMethods;
        public UserCommunication(IRepository<Book> booksRepository, IRepository<CDMusic> cdsMusicRepository,
                   IRepository<PCGame> pcGamesRepository, IRepository<Employee> employeeRepository,
                    IRepository<Client> clientsRepository, IBooksProvider booksProvider, ICDsMusicProvider cdsMusicProvider,
                    IPCGamesProvider pcGamesProvider, IEmployeesProvider employeesProvider, IClientsProvider clientProvider,ICSVReader cSVReader,
                    IEventsMethods eventsMethods)
        {
            _booksRepository = booksRepository;
            _cdsMusicRepository = cdsMusicRepository;
            _pcGamesRepository = pcGamesRepository;
            _employeesRepository = employeeRepository;
            _clientsRepository = clientsRepository;
            _booksProvider = booksProvider;
            _cdsMusicProvider = cdsMusicProvider;
            _pcGamesProvider = pcGamesProvider;
            _employeesProvider = employeesProvider;
            _clientsProvider = clientProvider;
            _CSVReader = cSVReader;
            _eventsMethods = eventsMethods;
            _booksRepository.ItemAdded += _eventsMethods.ItemAdded;
            _cdsMusicRepository.ItemAdded += _eventsMethods.ItemAdded;
            _pcGamesRepository.ItemAdded += _eventsMethods.ItemAdded;
            _employeesRepository.ItemAdded += _eventsMethods.ItemAdded;
            _clientsRepository.ItemAdded += _eventsMethods.ItemAdded;
            _booksRepository.ItemDeleted += _eventsMethods.ItemDeleted;
            _cdsMusicRepository.ItemDeleted += _eventsMethods.ItemDeleted;
            _pcGamesRepository.ItemDeleted += _eventsMethods.ItemDeleted;
            _employeesRepository.ItemDeleted += _eventsMethods.ItemDeleted;
            _clientsRepository.ItemDeleted += _eventsMethods.ItemDeleted;
        }

        public void AddStuff<T>(T nameclass)
        {
            
            var obj = nameclass;
            Console.Clear();
            Console.WriteLine($"Adding {typeof(T).Name}");
            Dictionary<string, string> propertiesObject = new Dictionary<string, string>();
            foreach (var property in typeof(T).GetProperties())
            {
                if (property.Name != "Id")
                {
                    Console.Write($"Enter {property.Name}:");
                    string valueProperty = Console.ReadLine();
                    propertiesObject.Add(property.Name, valueProperty);
                }
            }
            for (int i = 0; i < propertiesObject.Count; i++)
            {
                if (propertiesObject.ElementAt(i).Value == "")
                {
                    switch (propertiesObject.ElementAt(i).Key)
                    {
                        case "PEGI":
                        case "Age":
                        case "ReleaseDate":
                            var key = propertiesObject.ElementAt(i).Key;
                            propertiesObject.Remove(propertiesObject.ElementAt(i).Key);
                            propertiesObject.Add(key, "0");
                            break;
                        case "PremiumClient":
                            key = propertiesObject.ElementAt(i).Key;
                            propertiesObject.Remove(propertiesObject.ElementAt(i).Key);
                            propertiesObject.Add(key, "false");
                            break;
                        default:
                            key = propertiesObject.ElementAt(i).Key;
                            propertiesObject.Remove(propertiesObject.ElementAt(i).Key);
                            propertiesObject.Add(key, "unknown");
                            break;
                    }
                }
                switch (propertiesObject.ElementAt(i).Key)
                {
                    case "PEGI":
                    case "Age":
                    case "ReleaseDate":
                        if (!int.TryParse(propertiesObject.ElementAt(i).Value, out var value))
                        {
                            throw new Exception($"Cannot convert this value to {propertiesObject.ElementAt(i).Key}");
                        }
                        break;
                    case "PremiumClient":
                        if (!bool.TryParse(propertiesObject.ElementAt(i).Value, out var boolvalue))
                        {
                            throw new Exception($"Cannot convert this value to {propertiesObject.ElementAt(i).Key}");
                        }
                        break;
                }
            }
            foreach (var property in obj.GetType().GetProperties())
            {
                foreach (var item in propertiesObject)
                {
                    if (property.Name == item.Key && property.PropertyType.Name == "String")
                        property.SetValue(obj, item.Value);
                    if (property.Name == item.Key && property.PropertyType.Name == "Int32")
                        property.SetValue(obj, Convert.ToInt32(item.Value));
                    if (property.Name == item.Key && property.PropertyType.Name == "Boolean")
                        property.SetValue(obj, Convert.ToBoolean(item.Value));
                }
            }
            foreach (var item in obj.GetType().GetProperties())
            {
                Console.WriteLine($"{item.Name} {item.PropertyType.Name} {item.GetValue(obj)} ");
            }
            switch (obj.GetType().Name)
            {
                case "Book":
                    Book book = obj as Book;
                    _booksRepository.Add(book);
                    _booksRepository.Save();
                    break;
                case "CDMusic":
                    CDMusic cDMusic = obj as CDMusic;
                    _cdsMusicRepository.Add(cDMusic);
                    _cdsMusicRepository.Save();
                    break;
                case "PCGame":
                    PCGame PCGame = obj as PCGame;
                    _pcGamesRepository.Add(PCGame);
                    _pcGamesRepository.Save();
                    break;
                case "Employee":
                    Employee Employee = obj as Employee;
                    _employeesRepository.Add(Employee);
                    _employeesRepository.Save();
                    break;
                case "Client":
                    Client Client = obj as Client;
                    _clientsRepository.Add(Client);
                    _clientsRepository.Save();
                    break;
                default:
                    break;
            }
            DisplayContinueInfo();
        }
        public void RemStuff<T>(T nameclass)
        {
            switch (typeof(T).Name)
            {
                case "Book":
                    DisplayInfo("List of books in the database");
                    foreach (var item in _booksRepository.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    Console.Write("Enter ID Book to remove:");
                    var idbook = Console.ReadLine();
                    int ID;
                    if (idbook == "")
                    {
                        throw new Exception("This value is not correct ID");
                    }
                    else
                    {
                        if (!int.TryParse(idbook, out ID))
                        {
                            throw new Exception("This value is not correct ID");
                        }
                    }
                    var exists = false;
                    foreach (Book item in _booksRepository.GetAll())
                    {
                        if (item.Id == ID)
                        {
                            _booksRepository.Remove(item);
                            _booksRepository.Save();
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        throw new Exception("Given ID Book not exists in repository!");
                    }
                    break;
                case "CDMusic":
                    DisplayInfo("List of music cds in the database:");
                    foreach (var item in _cdsMusicRepository.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    Console.Write("Enter ID CD Music to remove:");
                    var idcdmusic = Console.ReadLine();
                    if (idcdmusic == "")
                    {
                        throw new Exception("This value is not correct ID");
                    }
                    else
                    {
                        if (!int.TryParse(idcdmusic, out ID))
                        {
                            throw new Exception("This value is not correct ID");
                        }
                    }
                    exists = false;
                    foreach (CDMusic item in _cdsMusicRepository.GetAll())
                    {
                        if (item.Id == ID)
                        {
                            _cdsMusicRepository.Remove(item);
                            _cdsMusicRepository.Save();
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        throw new Exception("Given ID CD Music not exists in repository!");
                    }
                    break;
                case "PCGame":
                    DisplayInfo("Pc games list in database");
                    foreach (var item in _pcGamesRepository.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    Console.Write("Enter ID PC Game to remove:");
                    var idpcgame = Console.ReadLine();
                    if (idpcgame == "")
                    {
                        throw new Exception("This value is not correct ID");
                    }
                    else
                    {
                        if (!int.TryParse(idpcgame, out ID))
                        {
                            throw new Exception("This value is not correct ID");
                        }
                    }
                    exists = false;
                    foreach (PCGame item in _pcGamesRepository.GetAll())
                    {
                        if (item.Id == ID)
                        {
                            _pcGamesRepository.Remove(item);
                            _pcGamesRepository.Save();
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        throw new Exception("Given ID PC Game not exists in repository!");
                    }
                    break;
                case "Employee":
                    DisplayInfo("List of personnel in the database");
                    foreach (var item in _employeesRepository.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    Console.Write("Enter ID Employee to remove:");
                    var idemployee = Console.ReadLine();
                    if (idemployee == "")
                    {
                        throw new Exception("This value is not correct ID");
                    }
                    else
                    {
                        if (!int.TryParse(idemployee, out ID))
                        {
                            throw new Exception("This value is not correct ID");
                        }
                    }
                    exists = false;
                    foreach (Employee item in _employeesRepository.GetAll())
                    {
                        if (item.Id == ID)
                        {
                            _employeesRepository.Remove(item);
                            _employeesRepository.Save();
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        throw new Exception("Given ID Employee not exists in repository!");
                    }
                    break;
                case "Client":
                    DisplayInfo("List of clients in database");
                    foreach (var item in _clientsRepository.GetAll())
                    {
                        Console.WriteLine(item);
                    }
                    Console.Write("Enter ID Client to remove:");
                    var idclient = Console.ReadLine();
                    if (idclient == "")
                    {
                        throw new Exception("This value is not correct ID");
                    }
                    else
                    {
                        if (!int.TryParse(idclient, out ID))
                        {
                            throw new Exception("This value is not correct ID");
                        }
                    }
                    exists = false;
                    foreach (Client item in _clientsRepository.GetAll())
                    {
                        if (item.Id == ID)
                        {
                            _clientsRepository.Remove(item);
                            _clientsRepository.Save();
                            exists = true;
                            break;
                        }
                    }
                    if (!exists)
                    {
                        throw new Exception("Given ID Client not exists in repository!");
                    }
                    break;
                default:
                    break;
            }
            DisplayContinueInfo();
        }
        public void AddAllStuff()
        {
            var listBooksFromFile = _CSVReader.ProcessBook(@"D:\Projekty Visual Studio\RentalShopApp\RentalShopApp\Resources\Files\katalog książek.csv");
            if (listBooksFromFile.Count == 0)
            {
                DisplayErrorMessage("List of books is empty");
            }
            else 
            {
                foreach (var item in listBooksFromFile)
                {
                    _booksRepository.Add(item);
                }
                _booksRepository.Save();
            }
            DisplayContinueInfo();
        }
        public void RemAllStuff()
        {
            if (_booksRepository.GetAll().Count() != 0)
            {
                foreach (Book item in _booksRepository.GetAll())
                {
                    _booksRepository.Remove(item);
                }
            }
            else
            {
                DisplayInfo("List of books in database not exists.");
            }
            if (_cdsMusicRepository.GetAll().Count() != 0)
            {
                foreach (CDMusic item in _cdsMusicRepository.GetAll())
                {
                    _cdsMusicRepository.Remove(item);
                }
            }
            else
            {
                DisplayInfo("List of cds music in database not exists.");
            }
            if (_pcGamesRepository.GetAll().Count() != 0)
            {
                foreach (PCGame item in _pcGamesRepository.GetAll())
                {
                    _pcGamesRepository.Remove(item);
                }
            }
            else
            {
                DisplayInfo("List of pc games in database not exists.");
            }
            if (_employeesRepository.GetAll().Count() != 0)
            {
                foreach (Employee item in _employeesRepository.GetAll())
                {
                    _employeesRepository.Remove(item);
                }
            }
            else
            {
                DisplayInfo("List of employees in database not exists.");
            }
            if (_clientsRepository.GetAll().Count() != 0)
            {
                foreach (Client item in _clientsRepository.GetAll())
                {
                    _clientsRepository.Remove(item);
                }
            }
            else
            {
                DisplayInfo("List of clients in database not exists.");
            }
            DisplayContinueInfo();
        }
        public void FindBookBy()
        {
            DisplayInfo("Menu Find Book by");
            Console.WriteLine("1. Author");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. Title");
            var choice = GetUserChoice();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter book author:");
                    var author = Console.ReadLine();
                    if (author != null || author != "")
                    {
                        var fbooks = _booksProvider.GetBooksByAuthor(author);

                        foreach (var item in fbooks)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Write("Enter the genre:");
                    var genre = Console.ReadLine();
                    if (genre != null || genre != "")
                    {
                        var fbooks = _booksProvider.GetBooksByGenre(genre);

                        foreach (var item in fbooks)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Write("Enter the title:");
                    var title = Console.ReadLine();
                    if (title != null || title != "")
                    {
                        var fbooks = _booksProvider.GetBooksByGenre(title);

                        foreach (var item in fbooks)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                default:
                    FindBookBy();
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindCDMusicBy()
        {
            DisplayInfo("Menu Find CD Music by");
            Console.WriteLine("1. BandName");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. Album Title");
            var choice = GetUserChoice();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter Bandname:");
                    var band = Console.ReadLine();
                    if (band != null || band != "")
                    {
                        var fcdsMusic = _cdsMusicProvider.GetCDsMusicByBandName(band);

                        foreach (var item in fcdsMusic)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Write("Enter the genre:");
                    var genre = Console.ReadLine();
                    if (genre != null || genre != "")
                    {
                        var fcdsMusic = _cdsMusicProvider.GetCDsMusicByGenre(genre);

                        foreach (var item in fcdsMusic)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Write("Enter the album title:");
                    var title = Console.ReadLine();
                    if (title != null || title != "")
                    {
                        var fcdsMusic = _cdsMusicProvider.GetCDsMusicByAlbumTitle(title);

                        foreach (var item in fcdsMusic)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                default:
                    FindCDMusicBy();
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindPCGameBy()
        {
            DisplayInfo("Menu Find PCGame by");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. PEGI");
            var choice = GetUserChoice();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter the game title:");
                    var title = Console.ReadLine();
                    if (title != null || title != "")
                    {
                        var fpcGames = _pcGamesProvider.GetPCGamesByGameTitle(title);

                        foreach (var item in fpcGames)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Write("Enter the genre:");
                    var genre = Console.ReadLine();
                    if (genre != null || genre != "")
                    {
                        var fpcGames = _pcGamesProvider.GetPCGamesByGenre(genre);

                        foreach (var item in fpcGames)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Write("Enter the age for PEGI:");
                    var strage = Console.ReadLine();
                    int age;
                    int.TryParse(strage, out age);
                    if (age != 0)
                    {
                        var fpcGames = _pcGamesProvider.GetPCGamesByPEGI(age);

                        foreach (var item in fpcGames)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                default:
                    FindPCGameBy();
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindEmployeeBy()
        {
            DisplayInfo("Menu Find Employee by");
            Console.WriteLine("1. FirstName");
            Console.WriteLine("2. LastName");
            Console.WriteLine("3. Type of work");
            Console.WriteLine("4. Age");
            var choice = GetUserChoice();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter the firstname employee:");
                    var firstname = Console.ReadLine();
                    if (firstname != null || firstname != "")
                    {
                        var fEmployees = _employeesProvider.GetEmployeeByFirstName(firstname);

                        foreach (var item in fEmployees)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Write("Enter the lastname employee:");
                    var lastname = Console.ReadLine();
                    if (lastname != null || lastname != "")
                    {
                        var fEmployees = _employeesProvider.GetEmployeeByLastName(lastname);

                        foreach (var item in fEmployees)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Write("Enter the type of work:");
                    var typeofwork = Console.ReadLine();
                    if (typeofwork != null || typeofwork != "")
                    {
                        var fEmployees = _employeesProvider.GetEmployeeByWorkType(typeofwork);

                        foreach (var item in fEmployees)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.Write("Enter the age of employee:");
                    var strage = Console.ReadLine();
                    int age;
                    int.TryParse(strage, out age);
                    if (age != 0)
                    {
                        var fEmployees = _employeesProvider.GetEmployeeByAge(age);

                        foreach (var item in fEmployees)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                default:
                    FindEmployeeBy();
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindClientBy()
        {
            DisplayInfo("Menu Find Client by");
            Console.WriteLine("1. FirstName");
            Console.WriteLine("2. LastName");
            Console.WriteLine("3. Premium");
            Console.WriteLine("4. Age");
            var choice = GetUserChoice();
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter the firstname client:");
                    var firstname = Console.ReadLine();
                    if (firstname != null || firstname != "")
                    {
                        var fClients = _clientsProvider.GetClientByFirstName(firstname);

                        foreach (var item in fClients)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.Write("Enter the lastname client:");
                    var lastname = Console.ReadLine();
                    if (lastname != null || lastname != "")
                    {
                        var fClients = _clientsProvider.GetClientByLastName(lastname);

                        foreach (var item in fClients)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Write("Enter the PremiumClient((Y)es or (No)):");
                    var premium = Console.ReadLine();
                    if (premium != null || premium != "")
                    {
                        if (premium.ToLower() == "y" || premium.ToLower() == "n")
                        {
                            var fClients = _clientsProvider.GetClientByPremium(premium.ToLower() == "y" ? true : false);
                            foreach (var item in fClients)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            throw new Exception("Given value is not correct");
                        }
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.Write("Enter the age of client:");
                    var strage = Console.ReadLine();
                    int age;
                    int.TryParse(strage, out age);
                    if (age != 0)
                    {
                        var fClients = _clientsProvider.GetClientByAge(age);

                        foreach (var item in fClients)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                default:
                    FindClientBy();
                    break;
            }
            DisplayContinueInfo();
        }
        private void DisplayContinueInfo()
        {
            Console.WriteLine("Please any key to continue..");
            Console.ReadKey();
        }
        public void DisplayDataFromBooksRepository()
        {
            DisplayInfo("List of books from database:");
            if (_booksRepository.GetAll().ToList().Count > 0)
            {
                foreach (var item in _booksRepository.GetAll())
                {
                    Console.WriteLine(item);
                }
                DisplayInfo("");
            }       
            else
            {
                DisplayErrorMessage("List of books is empty!");
            }
            Console.WriteLine();
        }
        public void DisplayDataFromCdsMusicRepository()
        {
            DisplayInfo("List of cds music from database:");
            if (_cdsMusicRepository.GetAll().ToList().Count > 0)
            {
                foreach (var item in _cdsMusicRepository.GetAll())
                {
                    Console.WriteLine(item);
                }
                DisplayInfo("");
            }
            else
            {
                DisplayErrorMessage("List of cds music is empty!");
            }
            Console.WriteLine();
        }
        public void DisplayDataFromPCGamesRepository()
        {
            DisplayInfo("List of pc games from database:");
            if (_pcGamesRepository.GetAll().ToList().Count > 0)
            {
                foreach (var item in _pcGamesRepository.GetAll())
                {
                    Console.WriteLine(item);
                }
                DisplayInfo("");
            }
            else
            {
                DisplayErrorMessage("List of pc games is empty!");
            }
            Console.WriteLine();
        }
        public void DisplayDataFromEmployeesRepository()
        {
            DisplayInfo("List of personnel from database:");
            if (_employeesRepository.GetAll().ToList().Count > 0)
            {
                foreach (var item in _employeesRepository.GetAll())
                {
                    Console.WriteLine(item);
                }
                DisplayInfo("");
            }
            else
            {
                DisplayErrorMessage("List of personnel is empty!");
            }
            Console.WriteLine();
        }
        public void DisplayDataFromClientRepository()
        {
            DisplayInfo("List of clients from database:");
            if (_clientsRepository.GetAll().ToList().Count > 0)
            {
                foreach (var item in _clientsRepository.GetAll())
                {
                    Console.WriteLine(item);
                }
                DisplayInfo("");
            }
            else
            {
                DisplayErrorMessage("List of clients is empty!");
            }
            Console.WriteLine();
        }
        public void DisplayAllDataFromDatabase()
        {
            DisplayDataFromBooksRepository();
            DisplayDataFromCdsMusicRepository();
            DisplayDataFromPCGamesRepository();
            DisplayDataFromEmployeesRepository();
            DisplayDataFromClientRepository();
            DisplayContinueInfo();
        }
        public void DisplayErrorMessage(string message)
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void DisplayInfo(string message)
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.ForegroundColor = ConsoleColor.Green;
            if (message == "")
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("------------------------------------------");
            }
            else
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"{message}");
                Console.WriteLine("------------------------------------------");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }


        public ConsoleKeyInfo GetUserChoice()
        {
            Console.Write("Choose option:");
            return Console.ReadKey();
        }




    }
}
