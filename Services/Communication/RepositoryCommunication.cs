using RentalShopApp.Components.CSVReader;
using RentalShopApp.Data.Entities;
using RentalShopApp.Data.Repositories;
using RentalShopApp.Data.Repositories.Extensions;
using RentalShopApp.Services.Events;
using System.Text.RegularExpressions;


namespace RentalShopApp.Services.UserCommunication
{
    public class RepositoryCommunication: IRepositoryCommunication
    {
        private readonly IRepository<Book> _booksRepository;
        private readonly IRepository<CDMusic> _cdsMusicRepository;
        private readonly IRepository<PCGame> _pcGamesRepository;
        private readonly IRepository<Employee> _employeesRepository;
        private readonly IRepository<Client> _clientsRepository;
        private readonly IEventsMethods _eventsMethods;
        private readonly ICSVReader _CSVReader;
        public RepositoryCommunication(IRepository<Book> booksRepository, IRepository<CDMusic> cdsMusicRepository,
                   IRepository<PCGame> pcGamesRepository, IRepository<Employee> employeeRepository,
                    IRepository<Client> clientsRepository,IEventsMethods eventsMethods,ICSVReader cSVReader)
        {
            _booksRepository = booksRepository;
            _cdsMusicRepository = cdsMusicRepository;
            _pcGamesRepository = pcGamesRepository;
            _employeesRepository = employeeRepository;
            _clientsRepository = clientsRepository;
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
            int emptystring = 0;
            for (int i = 0; i < propertiesObject.Count; i++)
            {
                
                if (propertiesObject.ElementAt(i).Value == "")
                {
                    emptystring++;    
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
                    }
                    if (emptystring == propertiesObject.Count)
                    {
                        throw new Exception("All values is empty!");
                    }
                }
               
                switch (propertiesObject.ElementAt(i).Key)
                {
                    case "TypeOfWork":
                        if (!propertiesObject.ElementAt(i).Value.All(c => char.IsLetter(c) || c == ' '))
                        {
                            throw new Exception($"This string {propertiesObject.ElementAt(i).Key} can only contain letters and whitespaces!");
                        }
                        break;
                    case "FirstName":
                        if (!propertiesObject.ElementAt(i).Value.All(c => char.IsLetter(c)))
                        {
                            throw new Exception($"This string {propertiesObject.ElementAt(i).Key} can only contain letters!");
                        }
                        break;
                    case "LastName":
                        if (!propertiesObject.ElementAt(i).Value.All(c => char.IsLetter(c) || c == '-'))
                        {
                            throw new Exception($"This string {propertiesObject.ElementAt(i).Key} can only contain letters and dash sign!");
                        }
                        break;
                    case "Genre":
                    case "Author":    
                        if (!propertiesObject.ElementAt(i).Value.All(c => char.IsLetter(c) || c == ' ' || c == '-'))
                        {
                            throw new Exception($"This string {propertiesObject.ElementAt(i).Key} can only contain letters, whitespaces and dash sign!");
                        }
                        break;
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
            foreach (var property in obj.GetType().GetProperties())
            {

                    if (property.PropertyType.Name == "String" &&
                        (obj.GetType().GetProperty(property.Name).GetValue(obj) == ""))
                    {
                    throw new Exception("This value can be empty:" + property.Name);
                    }
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
                    if(_booksRepository.GetAll().ToList().Count == 0)
                    {
                        throw new Exception("Database is empty!");
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
                    if (_cdsMusicRepository.GetAll().ToList().Count == 0)
                    {
                        throw new Exception("Database is empty!");
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
                    if (_pcGamesRepository.GetAll().ToList().Count == 0)
                    {
                        throw new Exception("Database is empty");
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
                    if (_employeesRepository.GetAll().ToList().Count == 0)
                    {
                        throw new Exception("Database is empty");
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
                    if (_clientsRepository.GetAll().ToList().Count == 0)
                    {
                        throw new Exception("Database is empty");
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
            try
            {
                var listBooksFromFile = _CSVReader.ProcessBook(@"D:\Projekty Visual Studio\RentalShopApp\RentalShopApp\Resources\Files\katalog książek.csv");
                if (listBooksFromFile.Count == 0)
                {
                    DisplayErrorMessage("Cannot add books to database because list of books is empty or file katalog książek.csv not exists!!!");
                }
                else
                {
                    _booksRepository.AddBatch(listBooksFromFile.ToArray());
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"{ex.Message}");
            }
            
            try
            {
                var listCDsMusicFromFile = _CSVReader.ProcessCDMusic(@"D:\Projekty Visual Studio\RentalShopApp\RentalShopApp\Resources\Files\katalog płyt.csv");
                if (listCDsMusicFromFile.Count == 0)
                {
                    DisplayErrorMessage("Cannot add CDs to database because list of CDs is empty or file katalog płyt.csv not exists!!!");
                }
                else
                {
                    _cdsMusicRepository.AddBatch(listCDsMusicFromFile.ToArray());
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"{ex.Message}");
            }
            try
            {
                var listPCGamesFromFile = _CSVReader.ProcessPCGame(@"D:\Projekty Visual Studio\RentalShopApp\RentalShopApp\Resources\Files\katalog gier.csv");
                if (listPCGamesFromFile.Count == 0)
                {
                    DisplayErrorMessage("Cannot add PC games to database because list of PC games is empty or file katalog gier.csv not exists!!!");
                }
                else
                {
                    _pcGamesRepository.AddBatch(listPCGamesFromFile.ToArray());
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"{ex.Message}");
            }

            try
            {
                var listEmployeesFromFile = _CSVReader.ProcessEmployee(@"D:\Projekty Visual Studio\RentalShopApp\RentalShopApp\Resources\Files\lista pracowników.csv");
                if (listEmployeesFromFile.Count == 0)
                {
                    DisplayErrorMessage("Cannot add employees to database because list of employees is empty or file lista pracowników.csv not exists!!!");
                }
                else
                {
                    _employeesRepository.AddBatch(listEmployeesFromFile.ToArray());
                }
            }
            catch (Exception ex)
            {
                DisplayErrorMessage($"{ex.Message}");
            }
                
            
            
           try
            {
                var listClientsFromFile = _CSVReader.ProcessClient(@"D:\Projekty Visual Studio\RentalShopApp\RentalShopApp\Resources\Files\lista klientów.csv");
                if (listClientsFromFile.Count == 0)
                {
                    DisplayErrorMessage("Cannot add clients to database because list of clients is empty or file lista klientów.csv not exists!!!");
                }
                else
                {
                    _clientsRepository.AddBatch(listClientsFromFile.ToArray());
                }
            }
            catch(Exception ex) 
            { 
                DisplayErrorMessage($"{ex.Message}");
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
                    _booksRepository.Save();
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
                    _cdsMusicRepository.Save();
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
                    _pcGamesRepository.Save();
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
                    _employeesRepository.Save();
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
                    _clientsRepository.Save();
                }
            }
            else
            {
                DisplayInfo("List of clients in database not exists.");
            }
            DisplayContinueInfo();
        }

        public void DisplayAllDataFromDatabase()
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
            DisplayContinueInfo();
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
        public void DisplayContinueInfo()
        {
            Console.WriteLine("Please any key to continue..");
            Console.ReadKey();
        }
        public void DisplayErrorMessage(string message)
        {
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
