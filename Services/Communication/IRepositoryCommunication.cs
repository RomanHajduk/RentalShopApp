using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalShopApp.Services.UserCommunication
{
    public interface IRepositoryCommunication
    {
        void AddStuff<T>(T nameclass);
        void RemStuff<T>(T nameclass);
        void AddAllStuff();
        void RemAllStuff();
        void DisplayAllDataFromDatabase();
    }
}
