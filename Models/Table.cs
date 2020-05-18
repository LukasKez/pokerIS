using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PokerIS.Models
{
    public class Table
    {
        public int ID { get; set; }
        public int Seats { get; set; }
        public double StartingBet { get; set; }

        [DefaultValue(0)]
        public int PlayerCount { get; set; }
    }
}
