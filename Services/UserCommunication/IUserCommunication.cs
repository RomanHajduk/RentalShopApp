namespace RentalShopApp.Services.UserCommunication
{
    public interface IUserCommunication
    {
        void DisplayInfo(string message);
        void DisplayErrorMessage(string message);
        ConsoleKeyInfo GetUserChoice();
        void AddStuff<T>(T nameclass);
        void RemStuff<T>(T nameclass);
        void AddAllStuff();
        void RemAllStuff();
        void DisplayAllDataFromDatabase();
        public void FindBookBy();
        public void FindCDMusicBy();
        public void FindPCGameBy();
        public void FindEmployeeBy();
        public void FindClientBy();
    }
}
