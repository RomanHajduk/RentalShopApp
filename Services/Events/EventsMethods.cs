using RentalShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalShopApp.Services.Events
{
    public class EventsMethods : IEventsMethods
    {
        public void ItemAdded<T>(object? sender, T e)
        {
            DateTime dateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{e.GetType().Name} added from {sender.GetType().Name}");
            Console.ForegroundColor = ConsoleColor.White;
            using (var writer = File.AppendText("logs.txt"))
            {
                if (e.GetType().Name == "Book") 
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemAdded {e.GetType().Name} [{e.GetType().GetProperty("Title").GetValue(e)}]");
                }
                if (e.GetType().Name == "CDMusic")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemAdded {e.GetType().Name} [{e.GetType().GetProperty("BandName").GetValue(e)}]");
                }
                if (e.GetType().Name == "PCGame")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemAdded  {e.GetType().Name} [{e.GetType().GetProperty("Title").GetValue(e)}]");
                }
                if (e.GetType().Name == "Employee")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemAdded {e.GetType().Name} [{e.GetType().GetProperty("FirstName").GetValue(e)} {e.GetType().GetProperty("LastName").GetValue(e)}]");
                }
                if (e.GetType().Name == "Client")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemAdded {e.GetType().Name} [{e.GetType().GetProperty("FirstName").GetValue(e)} {e.GetType().GetProperty("LastName").GetValue(e)}]");
                }

            }
        }

        public void ItemDeleted<T>(object? sender, T e)
        {
            DateTime dateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{e.GetType().Name} deleted from {sender.GetType().Name}");
            Console.ForegroundColor = ConsoleColor.White;
            using (var writer = File.AppendText("logs.txt"))
            {
                if (e.GetType().Name == "Book")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemDeleted {e.GetType().Name} [{e.GetType().GetProperty("Title").GetValue(e)}]");
                }
                if (e.GetType().Name == "CDMusic")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemDeleted {e.GetType().Name} [{e.GetType().GetProperty("BandName").GetValue(e)}]");
                }
                if (e.GetType().Name == "PCGame")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemDeleted  {e.GetType().Name} [{e.GetType().GetProperty("Title").GetValue(e)}]");
                }
                if (e.GetType().Name == "Employee")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemDeleted {e.GetType().Name} [{e.GetType().GetProperty("FirstName").GetValue(e)} {e.GetType().GetProperty("LastName").GetValue(e)}]");
                }
                if (e.GetType().Name == "Client")
                {
                    writer.WriteLine($"[{DateTime.Now}] ItemDeleted {e.GetType().Name} [{e.GetType().GetProperty("FirstName").GetValue(e)} {e.GetType().GetProperty("LastName").GetValue(e)}]");
                }
            }
        }

    }
}
