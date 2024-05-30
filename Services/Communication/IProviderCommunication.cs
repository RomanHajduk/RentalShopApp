using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalShopApp.Services.UserCommunication
{
    public interface IProviderCommunication
    {
        void FindBookBy();
        void FindCDMusicBy();
        void FindPCGameBy();
        void FindEmployeeBy();
        void FindClientBy();
        void DisplayInfo(string message);
        void DisplayContinueInfo();
    }
}
