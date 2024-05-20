using RentalShopApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentalShopApp.Services.Events
{
    public interface IEventsMethods
    {
        void ItemAdded<T>(object? sender, T e);
        void ItemDeleted<T>(object? sender, T e);
    }
}
