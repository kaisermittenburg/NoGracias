using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias.Server
{
    class Card
    {
        #region Variables
        public int value { get; set; }
        public int chipsOnCard { get; set; }
        #endregion

        /**
         * Default constructor with empty body
         */
        public Card() { }
        
        /**
         * Overlaoded constructor setting card value
         */
        public Card(int value)
        {
            this.value = value;
        }

        /**
         * Overloaded copy constructor makes a copy from parameter
         * @param copy The source Card
         */
        public Card(Card copy)
        {
            this.value = copy.value;
            this.chipsOnCard = copy.chipsOnCard;
        }
    }
}
