using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.DataProviders
{
    public interface IEmployeesProvider
    {
        List<Employee> GetEmployeeByFirstName(string firstname);
        List<Employee> GetEmployeeByLastName(string lastname);
        List<Employee> GetEmployeeByAge(int age);
        List<Employee> GetEmployeeByWorkType(string typeofwork);
    }
}
