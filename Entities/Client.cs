namespace RentalShopApp.Entities
{
    public class Client : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool PremiumClient {  get; set; }
        public override string ToString() => $"Id: {Id} FirstName: {FirstName} LastName: {LastName} PremiumClient: {PremiumClient} Age: {Age}";
        public Client()
        {
            FirstName = "unknown";
            LastName = "unknown";
            PremiumClient = false;
            Age = 0;
        }
        public Client(string firstName, string lastName, bool premiumClient, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            PremiumClient = premiumClient;
            Age = age;
        }
    }
}
