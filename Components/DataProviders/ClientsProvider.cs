using RentalShopApp.Data.Entities;
using RentalShopApp.Data.Repositories;

namespace RentalShopApp.Components.DataProviders
{
    public class ClientsProvider : IClientsProvider
    {
        private readonly IRepository<Client> _clientsRepository;
        public ClientsProvider(IRepository<Client> clientsRepository)
        {
            _clientsRepository = clientsRepository;
        }

        public List<Client> GetClientByAge(int age)
        {
            var filteredEmployees = _clientsRepository.GetAll().Where(client => client.Age == age);
            return filteredEmployees.ToList();
        }

        public List<Client> GetClientByFirstName(string firstname)
        {
            var filteredClients = _clientsRepository.GetAll().Where(client => client.FirstName == firstname);
            return filteredClients.ToList();
        }

        public List<Client> GetClientByLastName(string lastname)
        {
            var filteredClients = _clientsRepository.GetAll().Where(client => client.LastName == lastname);
            return filteredClients.ToList();
        }

        public List<Client> GetClientByPremium(bool premium)
        {
            var filteredClients = _clientsRepository.GetAll().Where(client => client.PremiumClient == premium);
            return filteredClients.ToList();
        }
    }
}
