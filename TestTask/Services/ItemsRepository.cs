using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TestTask.Models;

namespace TestTask.Services
{
    public class ItemsRepository : IItemsRepository
    {
        private IGetPath _getFilePath;

        public ItemsRepository(IGetPath getFilePath)
        {
            _getFilePath = getFilePath;
        }

        public void StoreItems(List<Item> items)
        {
            ItemListForJSON its = new ItemListForJSON
            {
                Items = items // adjustding for JSON 
            };
            var jsonObject = JsonConvert.SerializeObject(its, Formatting.Indented); // serializing the object to save to the JSON file
            string path = _getFilePath.GetPath("Services", "StoringFile.json");
            //string filePath = @"StoringFile.json"; // simplify path
            System.IO.File.WriteAllText(path, jsonObject); // write to JSON
        }

        public List<Item> LoadItems()
        {
            string path = _getFilePath.GetPath("Services", "StoringFile.json");
            List<Item> items = new List<Item>();
            using (StreamReader r = new StreamReader(path)) // simplify path
            {
                string json = r.ReadToEnd();
                ItemListForJSON its = JsonConvert.DeserializeObject<ItemListForJSON>(json); // deserijalizacija JSON-a
                items = its.Items;
            } // getting data from JSON file
            items = items.OrderByDescending(x => x.Score).ToList(); // sorting items 
            return items;
        }
    }
}