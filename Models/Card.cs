using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerIS.Models
{
    public class Card
    {
        public enum Values
        {
            Two = 2, Three, Four, Five, Six, Seven, Eight,
            Nine, Ten, Jack, Queen, King, Ace
        }
        public enum Suits
        {
            Hearts,
            Spades,
            Diamonds,
            Clubs
        }
        public int ID { get; set; }
        public Values Value { get; set; }

        public Suits Suit { get; set; }
    }
}
