using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Models;

namespace TestTask.Services
{
    public interface IItemsRepository
    {
        void StoreItems(List<Item> items); // saving items

        List<Item> LoadItems(); // loading items
    }
}
