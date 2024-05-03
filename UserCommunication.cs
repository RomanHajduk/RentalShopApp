namespace RentalShopApp
{
    using System.Collections.Generic;
    public class UserCommunication : IUserCommunication
    {
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
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"{message}");
            Console.WriteLine("------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
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
                Console.SetCursorPosition(((48 - namemenu.Length) / 2)-1, Console.GetCursorPosition().Top);
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
                Console.SetCursorPosition(((47 - namemenu.Length) / 2), Console.GetCursorPosition().Top);
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
            for (int i = 0; i < arrayoflistofchoice.Length;i++)
            {
                Console.WriteLine($"{i}. {arrayoflistofchoice[i]}");                 
            }
            
        }

        public ConsoleKeyInfo GetUserChoice()
        {
            Console.Write("Choose option:");
            var choice = Console.ReadKey();
            return choice;
        }


        
    }
}
