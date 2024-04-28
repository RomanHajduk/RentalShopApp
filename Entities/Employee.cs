using Microsoft.EntityFrameworkCore;
namespace RentalShopApp.Entities
{
    [PrimaryKey(nameof(Id))]
    public class Employee: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TypeOfWork {  get; set; }
        public int Age {  get; set; }
        public override string ToString() => $"Id: {Id} FirstName: {FirstName} LastName: {LastName} TypeOfWork: {TypeOfWork} Age: {Age}";
        public Employee() 
        {
            FirstName = "unknown";
            LastName = "unknown";
            TypeOfWork = "unknown";
            Age = 0;
        }
        public Employee(string firstName, string lastName, string typeOfWork, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfWork = typeOfWork;
            Age = age;
        }
    }
}
