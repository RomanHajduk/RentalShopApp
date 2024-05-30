namespace RentalShopApp.Services.Menu
{
    public interface IMenu
    {
        void DisplayMainMenu();
        void DisplaySubMenuAddingStuff();
        void DisplaySubMenuRemovingStuff();
        void DisplayMenu(string namemenu, string[] arrayoflistofchoice);
        void ActionLoop();
        ConsoleKeyInfo GetUserChoice();

    }
}
