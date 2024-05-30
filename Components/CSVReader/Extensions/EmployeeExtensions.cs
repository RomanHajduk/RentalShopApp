using RentalShopApp.Data.Entities;

namespace RentalShopApp.Components.CSVReader.Extensions
{
    public static class EmployeeExtensions
    {
        public static IEnumerable<Employee> ToEmployee(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var columns = line.Split(',');
                yield return new Employee
                {
                    FirstName = columns[0],
                    LastName = columns[1],
                    TypeOfWork = columns[2],
                    Age = int.Parse(columns[3])
                };
            }
        }
    }
}
