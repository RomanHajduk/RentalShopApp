namespace RentalShopApp
{
    public interface IUserCommunication
    { 
        void DisplayInfo(string message);
        void DisplayMenu(string namemenu, string[] arrayoflistofchoice);
        void DisplayErrorMessage(string message);
        ConsoleKeyInfo GetUserChoice();

        
       
    }
}
