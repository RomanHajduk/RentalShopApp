using RentalShopApp.Components.DataProviders;
using RentalShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalShopApp.Services.UserCommunication
{
    
    public class ProviderCommunication: IProviderCommunication
    {
        private readonly IBooksProvider _booksProvider;
        private readonly ICDsMusicProvider _cdsMusicProvider;
        private readonly IPCGamesProvider _pcGamesProvider;
        private readonly IEmployeesProvider _employeesProvider;
        private readonly IClientsProvider _clientsProvider;
        
        public ProviderCommunication(IBooksProvider booksProvider, ICDsMusicProvider cdsMusicProvider, 
                                     IPCGamesProvider pcGamesProvider, IEmployeesProvider employeesProvider, 
                                     IClientsProvider clientsProvider)
        {
            _booksProvider = booksProvider;
            _cdsMusicProvider = cdsMusicProvider;
            _pcGamesProvider = pcGamesProvider;
            _employeesProvider = employeesProvider;
            _clientsProvider = clientsProvider;
        }

        public void FindBookBy()
        {
            Console.Clear();
            DisplayInfo("Menu Find Book by");
            Console.WriteLine("1. Author");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. Title");
            Console.Write("Choose option:");
            var choice = Console.ReadKey();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter book author:");
                    var author = Console.ReadLine();
                    if (author != null || author != "")
                    {
                        var fbooks = _booksProvider.GetBooksByAuthor(author);
                        if (!(fbooks.Count == 0))
                        {
                            foreach (var item in fbooks)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("The selected author's books do not exist in the database!!!");
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
                        if (!(fbooks.Count == 0))
                        {
                            foreach (var item in fbooks)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Books of the selected genre do not exist in the database!!!");
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
                        if (!(fbooks.Count == 0))
                        {
                            foreach (var item in fbooks)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Books with the given title do not exist in the database!!!");
                        }
                    }
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindCDMusicBy()
        {
            Console.Clear();
            DisplayInfo("Menu Find CD Music by");
            Console.WriteLine("1. BandName");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. Album Title");
            Console.Write("Choose option:");
            var choice = Console.ReadKey(); 
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter Bandname:");
                    var band = Console.ReadLine();
                    if (band != null || band != "")
                    {
                        var fcdsMusic = _cdsMusicProvider.GetCDsMusicByBandName(band);
                        if (!(fcdsMusic.Count == 0))
                        {
                            foreach (var item in fcdsMusic)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("The selected band's cds do not exist in the database!!!");
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
                        if (!(fcdsMusic.Count == 0))
                        {
                            foreach (var item in fcdsMusic)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("CDs of the given genre do not exist in the database!!!");
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
                        if (!(fcdsMusic.Count == 0))
                        {
                            foreach (var item in fcdsMusic)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("CDs with the given title do not exist in the database!!!");
                        }
                    }
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindPCGameBy()
        {
            Console.Clear();
            DisplayInfo("Menu Find PCGame by");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Genre");
            Console.WriteLine("3. PEGI");
            Console.Write("Choose option:");
            var choice = Console.ReadKey();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter the game title:");
                    var title = Console.ReadLine();
                    if (title != null || title != "")
                    {
                        var fpcGames = _pcGamesProvider.GetPCGamesByGameTitle(title);
                        if (!(fpcGames.Count == 0))
                        {
                            foreach (var item in fpcGames)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Games with the given title do not exist in the database!!!");
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
                        if (!(fpcGames.Count == 0))
                        {
                            foreach (var item in fpcGames)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Games of the selected genre do not exist in the database!!!");
                        }
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.Write("Enter the age for PEGI:");
                    var strage = Console.ReadLine();
                    int age;
                    var resParsing = int.TryParse(strage, out age);
                    if (resParsing)
                    {
                        if (age != 0)
                        {
                            var fpcGames = _pcGamesProvider.GetPCGamesByPEGI(age);
                            if (!(fpcGames.Count == 0))
                            {
                                foreach (var item in fpcGames)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                DisplayInfo("Games with the given pegi category do not exist in the database!!!");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Given value is not number");
                    }
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindEmployeeBy()
        {
            Console.Clear();
            DisplayInfo("Menu Find Employee by");
            Console.WriteLine("1. FirstName");
            Console.WriteLine("2. LastName");
            Console.WriteLine("3. Type of work");
            Console.WriteLine("4. Age");
            Console.Write("Choose option:");
            var choice = Console.ReadKey();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter the employee firstname:");
                    var firstname = Console.ReadLine();
                    if (firstname != null || firstname != "")
                    {
                        var fEmployees = _employeesProvider.GetEmployeeByFirstName(firstname);
                        if (!(fEmployees.Count == 0))
                        {
                            foreach (var item in fEmployees)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Employees with the given firstname do not exist in the database!!!");
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
                        if (!(fEmployees.Count == 0))
                        {
                            foreach (var item in fEmployees)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Employees with the given lastname do not exist in the database!!!");
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
                        if (!(fEmployees.Count == 0))
                        {
                            foreach (var item in fEmployees)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Employees performing the specified type of work do not exist in the database!!!");
                        }
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.Write("Enter the age of employee:");
                    var strage = Console.ReadLine();
                    int age;
                    var resParsing =  int.TryParse(strage, out age);
                    if (resParsing)
                    {
                        if (age != 0)
                        {
                            var fEmployees = _employeesProvider.GetEmployeeByAge(age);
                            if (!(fEmployees.Count == 0))
                            {
                                foreach (var item in fEmployees)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                DisplayInfo("Employees with the given age do not exist in the database!!!");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Given value is not number!!!");
                    }
                    break;
            }
            DisplayContinueInfo();
        }
        public void FindClientBy()
        {
            Console.Clear();
            DisplayInfo("Menu Find Client by");
            Console.WriteLine("1. FirstName");
            Console.WriteLine("2. LastName");
            Console.WriteLine("3. Premium");
            Console.WriteLine("4. Age");
            Console.Write("Choose option:");
            var choice = Console.ReadKey();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.Write("Enter the firstname client:");
                    var firstname = Console.ReadLine();
                    if (firstname != null || firstname != "")
                    {
                        var fClients = _clientsProvider.GetClientByFirstName(firstname);
                        if (!(fClients.Count == 0))
                        {
                            foreach (var item in fClients)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo(" Clients with the given firstname do not exist in the database!!!");
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
                        if (!(fClients.Count == 0))
                        {
                            foreach (var item in fClients)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            DisplayInfo("Clients with the given lastname do not exist in the database!!!");
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
                            if (!(fClients.Count == 0))
                            {
                                foreach (var item in fClients)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                DisplayInfo("Clients with the specified premium client status do not exist in the database!!!");
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
                    var parsingRes =int.TryParse(strage, out age);
                    if (parsingRes)
                    {
                        if (age != 0)
                        {
                            var fClients = _clientsProvider.GetClientByAge(age);

                            if (!(fClients.Count == 0))
                            {
                                foreach (var item in fClients)
                                {
                                    Console.WriteLine(item);
                                }
                            }
                            else
                            {
                                DisplayInfo("Clients with the given age do not exist in the database!!!");
                            }
                        }
                    }
                    else
                    { 
                        throw new Exception("Given value is not number");
                    }
                    break;
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
    }
}
