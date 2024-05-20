using RentalShopApp.Services.Menu;

namespace RentalShopApp
{
    public class App : IApp
    {
        
        private readonly IMenu _menu;
        public App (IMenu menu)
        {
            _menu = menu;
        }


        public void Run()
        {
            _menu.ActionLoop();
           
            //var book = new Book();
            //var propBook = _userCommunication.AddStuff(book);
            //try
            //{
            //    foreach (var property in book.GetType().GetProperties())
            //    {
            //        foreach (var item in propBook)
            //        {
            //            if (property.Name == item.Key && property.PropertyType.Name == "String")
            //                property.SetValue(book, item.Value);
            //            if (property.Name == item.Key && property.PropertyType.Name == "Int32")
            //                property.SetValue(book, Convert.ToInt32(item.Value));
            //            if (property.Name == item.Key && property.PropertyType.Name == "Boolean")
            //                property.SetValue(book, Convert.ToBoolean(item.Value));
            //        }

            //    }

            // Console.WriteLine(book.ToString());
            // //   _booksRepository.Add(book);
            // //   _booksRepository.Save();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }
    }
}
