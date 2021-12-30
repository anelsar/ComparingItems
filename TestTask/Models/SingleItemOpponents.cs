using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class SingleItemOpponents
    {
        public Item SingleItem { get; set; }
        public List<Item> PlayedAgainst { get; set; }

        public SingleItemOpponents()
        {
            PlayedAgainst = new List<Item>();
        }
    }
}