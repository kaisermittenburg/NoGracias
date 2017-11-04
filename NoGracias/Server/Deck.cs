using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias.Server
{
    class Deck
    {
        #region Variables
        List<Card> deck = new List<Card>;

        #endregion

        public Deck()
        {
            for(int i=3; i<36; i++)
            {
                deck.Add(new Card(i));
            }
            Shuffle();
            Shuffle();
            Shuffle();
            deck.RemoveRange(0, 9);
        }

        #region Functions
        public void Shuffle()
        {
            int length = deck.Count;
            Random randomPlace = new Random();

            while(length > 1)
            {
                int swapPlace = randomPlace.Next(0, length);
                int temp = deck[swapPlace].value;
                deck[swapPlace].value = deck[length].value;
                deck[length].value = temp;

                length--;
            }
        }

        public Card TopCard()
        {
            Card top = new Card(deck[0]);
            deck.RemoveAt(0);
            return top;
        }

        public bool isEmpty()
        {
            if(deck.Count() == 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
