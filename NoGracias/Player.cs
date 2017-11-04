using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias
{
    class Player
    {
        #region Variables
        public Socket mSocket;
        public string mName { get; set; }
        public PlayerState mState;
        public int mPlayerNumber;
        public List<int> cards { get; set; } //always ordered in descending order
        public int chips { get; set; }
        public Player nextPlayer { get; set; }

        #endregion

        public Player(Socket socket, int PlayerNumber)
        {
            this.mSocket = socket;
            mPlayerNumber = PlayerNumber;
        }

        public Player(Socket socket, int PlayerNumber, string PlayerName)
        {
            this.mSocket = socket;
            mPlayerNumber = PlayerNumber;
            mName = PlayerName;
            chips = 11;
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
    public enum PlayerState
    {
        IDLE,
        WAITING_FOR_RESPONSE,
        READY,


    }
}
