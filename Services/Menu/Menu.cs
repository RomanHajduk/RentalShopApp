using RentalShopApp.Data.Entities;
using RentalShopApp.Services.UserCommunication;

namespace RentalShopApp.Services.Menu
{
    public class Menu : IMenu
    {
        private readonly IUserCommunication _userCommunication;

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
        public Menu(IUserCommunication userCommunication)
        {
            _userCommunication = userCommunication;
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
            var choose = _userCommunication.GetUserChoice();
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
                        _userCommunication.DisplayErrorMessage(ex.Message);
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
                        _userCommunication.DisplayErrorMessage(ex.Message);
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    try
                    {
                        ActionFindStuffLoop();
                    }
                    catch (Exception ex)
                    {
                        _userCommunication.DisplayErrorMessage(ex.Message);
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    try
                    {
                        _userCommunication.DisplayAllDataFromDatabase();
                    }
                    catch (Exception ex)
                    {

                        _userCommunication.DisplayErrorMessage(ex.Message);
                    }
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Environment.Exit(0);
                    break;
                default:
                    _userCommunication.DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionLoop();
                    break;
            }
        }
        public void ActionAddLoop()
        {
            DisplaySubMenuAddingStuff();
            var choose = _userCommunication.GetUserChoice();
            switch (choose.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    _userCommunication.AddStuff(new Book());
                    ActionAddLoop();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    _userCommunication.AddStuff(new CDMusic());
                    ActionAddLoop();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    _userCommunication.AddStuff(new PCGame());
                    ActionAddLoop();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    _userCommunication.AddStuff(new Employee());
                    ActionAddLoop();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    _userCommunication.AddStuff(new Client());
                    ActionAddLoop();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    _userCommunication.AddAllStuff();
                    ActionAddLoop();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    _userCommunication.DisplayInfo("Return to main menu!!! Please any key to continue!!!");
                    ActionLoop();
                    break;
                default:
                    _userCommunication.DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionAddLoop();
                    break;
            }
        }
        public void ActionRemLoop()
        {
            DisplaySubMenuRemovingStuff();
            var choose = _userCommunication.GetUserChoice();
            switch (choose.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    _userCommunication.RemStuff(new Book());
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    _userCommunication.RemStuff(new CDMusic());
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    _userCommunication.RemStuff(new PCGame());
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    _userCommunication.RemStuff(new Employee());
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    _userCommunication.RemStuff(new Client());
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    _userCommunication.RemAllStuff();
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    _userCommunication.DisplayInfo("Return to main menu!!! Please any key to continue!!!");
                    ActionLoop();
                    break;
                default:
                    _userCommunication.DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionRemLoop();
                    break;
            }
        }
        public void ActionFindStuffLoop()
        {
            DisplaySubMenuFindingStuff();
            var choose = _userCommunication.GetUserChoice();
            switch (choose.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    _userCommunication.FindBookBy();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    _userCommunication.FindCDMusicBy();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    _userCommunication.FindPCGameBy();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    _userCommunication.FindEmployeeBy();
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    _userCommunication.FindClientBy();
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    _userCommunication.DisplayInfo("Return to main menu!!! Please any key to continue!!!");
                    ActionLoop();
                    break;
                default:
                    _userCommunication.DisplayErrorMessage("Incorrect option.Please again choose correct option!! Please any key to continue...");
                    Console.ReadKey();
                    ActionRemLoop();
                    break;
            }
        }
    }
}
