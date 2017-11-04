using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias.Server
{
    class Player
    {
        #region Variables
        public string name { get; set; }
        public List<int> cards { get; set; } //always ordered in descending order
        public int chips { get; set; }
        public Player nextPlayer { get; set; }
        #endregion

        public Player() { }

        public Player(string name)
        {
            this.name = name;
            cards = new List<int>;
            chips = 0;
        }

        #region Functions

        public int Score()
        {
            int n = cards.Count;
            int sum = 0;

            if (n != 0)
            {
                int last = cards.Last();

                sum += cards.Last();
                n--;

                while (n > 1)
                {
                    int current = cards.ElementAt(n - 1);
                    if (current - 1 != last)
                    {
                        sum += current;
                    }

                    last = current;
                    n--;
                }
            }

            return (sum - chips);
        }
        #endregion
    }
}
