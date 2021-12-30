using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestTask.Models
{
    public class ShowPairsViewModel
    {
        public Item FirstOpponent { get; set; }
        public int FirstOpponentScore { get; set; } = 0;
        public Item SecondOpponent { get; set; }
        public int SecondOpponentScore { get; set; } = 0;
    }
}