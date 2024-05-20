using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.DataProviders
{
    public interface IClientsProvider
    {
        List<Client> GetClientByFirstName(string firstname);
        List<Client> GetClientByLastName(string lastname);
        List<Client> GetClientByAge(int age);
        List<Client> GetClientByPremium(bool premium);
    }
}
