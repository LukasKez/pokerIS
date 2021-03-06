﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerIS.Models
{
    public class Game
    {
        public double playerWallet { get; set; }
        public double cpuWallet { get; set; }
        public string[] playerHand { get; set; }
        public string[] cpuHand { get; set; }
        public string[] flop { get; set; }
        public int result { get; set; }
        public string playerResult { get; set; }
        public string cpuResult { get; set; }
        public Table table { get; set; }
    }
}
