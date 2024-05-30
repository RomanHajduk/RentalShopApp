namespace RentalShopApp.Components.CSVReader
{
    using RentalShopApp.Data.Entities;
    using Components.CSVReader.Extensions;

    public class CSVReader : ICSVReader
    {
        public List<Book> ProcessBook(string filepath)
        {
            if (!File.Exists(filepath)) 
            { 
                return new List<Book>();
            }
            else
            {
                try
                {
                    var _books = File.ReadAllLines(filepath).ToBook();
                    return _books.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public List<CDMusic> ProcessCDMusic(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<CDMusic>();
            }
            else
            {
                try
                {
                    var _cdsmusic = File.ReadAllLines(filepath).ToCDMusic();
                    return _cdsmusic.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public List<PCGame> ProcessPCGame(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<PCGame>();
            }
            else
            {
                try
                {
                    var _pcgames = File.ReadAllLines(filepath).ToPCGame();
                    return _pcgames.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public List<Employee> ProcessEmployee(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<Employee>();
            }
            else
            {
                try
                {
                    var _employees = File.ReadAllLines(filepath).ToEmployee();
                    return _employees.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public List<Client> ProcessClient(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return new List<Client>();
            }
            else
            {
                try
                {
                    var _clients = File.ReadAllLines(filepath).ToClient();
                    return _clients.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
