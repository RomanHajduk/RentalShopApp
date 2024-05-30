using RentalShopApp.Data.Entities;
using RentalShopApp.Services.UserCommunication;

namespace RentalShopApp.Services.Menu
{
    public class Menu : IMenu
    {
        private readonly IProviderCommunication _providerCommunication;
        private readonly IRepositoryCommunication _repositoryCommunication;

        string[] _choicemainoption = new string[] {"Menu adding stuff to database",
                                                   "Menu deleting stuff in database",
                                                   "Menu searching stuff in database",
                                                   "Display all data from database",
                                                   "Exit the application"};
        string[] _choicesubmenuaddingoption = new string[] {"Add Book to database",
                                                            "Add CD Music to database",
                                                            "Add PC Game to database",
                                                            "Add Personnel to database",
                                                            "Add Client to database",
                                                            "Create all data for tables in database",
                                                            "Return to main menu"};
        string[] _choicesubmenuremovingoption = new string[] {"Delete Book from database",
                                                              "Delete CD Music from database",
                                                              "Delete PC Game from database",
                                                              "Delete Personnel from database",
                                                              "Delete Client from database",
                                                              "Delete all data from tables in database",
                                                              "Return to main menu"};
        string[] _choicesubmenufindingoption = new string[] {"Find Book",
                                                             "Find CDMusic",
                                                             "Find PC Game",
                                                             "Find Employee",
                                                             "Find Client",
                                                             "Return to main menu"};
        public Menu(IProviderCommunication providerCommunication, IRepositoryCommunication repositoryCommunication)
        {
            _providerCommunication = providerCommunication;
            _repositoryCommunication = repositoryCommunication;
        }

        public void DisplayMainMenu()
        {
            DisplayMenu("Main Menu Rental Books Music Games Shop", _choicemainoption);
        }
        public void DisplaySubMenuAddingStuff()
        {
            DisplayMenu("Submenu Adding Stuff For Rental Application", _choicesubmenuaddingoption);
        }
        public void DisplaySubMenuRemovingStuff()
        {
            DisplayMenu("Submenu Removing Stuff For Rental Application", _choicesubmenuremovingoption);
        }
        public void DisplaySubMenuFindingStuff()
        {
            DisplayMenu("Submenu Finding Stuff For Rental Application", _choicesubmenufindingoption);
        }
        public void DisplayMenu(string namemenu, string[] arrayoflistofchoice)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            if (namemenu.Length % 2 == 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("*");
                Console.SetCursorPosition((48 - namemenu.Length) / 2 - 1, Console.GetCursorPosition().Top);
                Console.Write(namemenu);
                Console.SetCursorPosition(49, Console.GetCursorPosition().Top);
                Console.WriteLine("*");
                for (int i = 0; i < 50; i++)
                {
                    Console.Write("*");
                }
            }
            else
            {
                for (int i = 0; i < 49; i++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                Console.Write("*");
                Console.SetCursorPosition((47 - namemenu.Length) / 2, Console.GetCursorPosition().Top);
                Console.Write(namemenu);
                Console.SetCursorPosition(49, Console.GetCursorPosition().Top);
                Console.WriteLine("*");
                for (int i = 0; i < 49; i++)
                {
                    Console.Write("*");
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-----------Menu------------");
            for (int i = 0; i < arrayoflistofchoice.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {arrayoflistofchoice[i]}");
            }

        }
        public void ActionLoop()
        {
            DisplayMainMenu();
            var choose = GetUserChoice();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choose.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    try
                    {
                        ActionAddLoop();
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex.Message);
                        DisplayContinueInfo();
                        ActionAddLoop();
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    try
                    {
                        ActionRemLoop();
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex.Message);
                        DisplayContinueInfo();
                        ActionRemLoop();
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ActionFindStuffLoop();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    _repositoryCommunication.DisplayAllDataFromDatabase();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Environment.Exit(0);
                    break;
                default:
                    DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionLoop();
                    break;
            }
        }
        public void ActionAddLoop()
        {
            DisplaySubMenuAddingStuff();
            var choose = GetUserChoice();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choose.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    try
                    {
                        _repositoryCommunication.AddStuff(new Book());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionAddLoop();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    try
                    {
                        _repositoryCommunication.AddStuff(new CDMusic());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionAddLoop();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    try
                    {
                        _repositoryCommunication.AddStuff(new PCGame());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                     ActionAddLoop();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    try
                    {
                        _repositoryCommunication.AddStuff(new Employee());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionAddLoop();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    try
                    {
                        _repositoryCommunication.AddStuff(new Client());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionAddLoop();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    _repositoryCommunication.AddAllStuff();
                    ActionAddLoop();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    DisplayInfo("Return to main menu!!! Please any key to continue!!!");
                    ActionLoop();
                    break;
                default:
                    DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionAddLoop();
                    break;
            }
        }
        public void ActionRemLoop()
        {
            DisplaySubMenuRemovingStuff();
            var choose = GetUserChoice();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choose.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    try
                    {
                        _repositoryCommunication.RemStuff(new Book());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionRemLoop();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    try
                    {
                        _repositoryCommunication.RemStuff(new CDMusic());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionRemLoop(); 
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    try
                    {
                        _repositoryCommunication.RemStuff(new PCGame());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionRemLoop();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    try
                    {
                        _repositoryCommunication.RemStuff(new Employee());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionRemLoop();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    try
                    {
                        _repositoryCommunication.RemStuff(new Employee());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    ActionRemLoop();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    _repositoryCommunication.RemAllStuff();
                    ActionRemLoop();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    DisplayInfo("Return to main menu!!! Please any key to continue!!!");
                    ActionLoop();
                    break;
                default:
                    DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionRemLoop();
                    break;
            }
        }
        public void ActionFindStuffLoop()
        {
            DisplaySubMenuFindingStuff();
            var choose = GetUserChoice();
            Console.SetCursorPosition(0, Console.GetCursorPosition().Top);
            switch (choose.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    try
                    {
                        _providerCommunication.FindBookBy();
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex.Message);
                        DisplayContinueInfo();
                    }
                    finally
                    {
                        ActionFindStuffLoop();
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    try
                    {
                        _providerCommunication.FindCDMusicBy();
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex.Message);
                        DisplayContinueInfo();
                    }
                    finally
                    {
                        ActionFindStuffLoop();
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    try
                    {
                        _providerCommunication.FindPCGameBy();
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex.Message);
                        DisplayContinueInfo();
                    }
                    finally
                    {
                        ActionFindStuffLoop();
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    try
                    {
                        _providerCommunication.FindEmployeeBy();
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex.Message);
                        DisplayContinueInfo();
                    }
                    finally
                    {
                        ActionFindStuffLoop();
                    }
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    try
                    {
                        _providerCommunication.FindClientBy();
                    }
                    catch (Exception ex)
                    {
                        DisplayErrorMessage(ex.Message);
                        DisplayContinueInfo();
                    }
                    finally
                    {
                        ActionFindStuffLoop();
                    }
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    DisplayInfo("Return to main menu!!! Please any key to continue!!!");
                    ActionLoop();
                    break;
                default:
                    DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionFindStuffLoop();
                    break;
            }
        }
        public ConsoleKeyInfo GetUserChoice()
        {
            Console.Write("Choose option:");
            var choose = Console.ReadKey();
            return choose;
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
