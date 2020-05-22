using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokerIS.Models
{
    public class DeckOfCards : Card
    {
        public int ID { get; set; }
        const int NumberOfCards = 52; //Total number of cards in the deck
        private Card[] Deck; //Array of all the cards

        public DeckOfCards()
        {
            Deck = new Card[NumberOfCards];
        }

        public Card[] GetDeck { get { return Deck; } } //Get current deck

        //Create deck of 52 cards, 13 per suit, 4 suits
        public void SetupDeck()
        {
            int i = 0;
            foreach (Suits s in Enum.GetValues(typeof(Suits)))
            {
                foreach (Values v in Enum.GetValues(typeof(Values)))
                {
                    Deck[i] = new Card { Suit = s, Value = v };
                    i++;
                }
            }
            ShuffleCards();
        }
        // Shuffle the deck
        public void ShuffleCards()
        {
            Random rand = new Random();
            Card temp;
            //Run the shuffle 1000 times
            for (int shuffle = 0; shuffle < 1000; shuffle++)
            {
                for (int i = 0; i < NumberOfCards; i++)
                {
                    //Switch the cards
                    int SecondCardIndex = rand.Next(13);
                    temp = Deck[i];
                    Deck[i] = Deck[SecondCardIndex];
                    Deck[SecondCardIndex] = temp;
                }
            }
        }
    }
}
