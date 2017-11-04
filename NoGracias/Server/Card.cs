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

        public Card() { }
        
        public Card(int value)
        {
            this.value = value;
        }

        public Card(Card copy)
        {
            this.value = copy.value;
            this.chipsOnCard = copy.chipsOnCard;
        }
    }
}
