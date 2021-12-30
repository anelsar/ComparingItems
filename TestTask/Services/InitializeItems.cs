using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.Services
{
    public class InitializeItems
    {
        public List<Item> ListOfItems { get; set; }
        public InitializeItems()
        {
            ListOfItems = new List<Item>();
        }

        public List<Item> ItemInit()
        {
            ListOfItems.Add(new Item
            {
                Name = "Item1",
                Position = 1,
                Score = 0
            }) ;
            ListOfItems.Add(new Item
            {
                Name = "Item2",
                Position = 2,
                Score = 0
            });
            ListOfItems.Add(new Item
            {
                Name = "Item3",
                Position = 3,
                Score = 0
            });
            ListOfItems.Add(new Item
            {
                Name = "Item4",
                Position = 4,
                Score = 0
            });
            ListOfItems.Add(new Item
            {
                Name = "Item5",
                Position = 5,
                Score = 0
            });
            ListOfItems.Add(new Item
            {
                Name = "Item6",
                Position = 6,
                Score = 0
            });

            return ListOfItems;
        }
    }
}