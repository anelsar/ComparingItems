using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class Item
    {
        public int Position { get; set; }
        public string Name { get; set; }
        [Required]
        public int Score { get; set; }
    }
}