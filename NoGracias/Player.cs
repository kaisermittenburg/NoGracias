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

        public Player()
        {
            cards = new List<int>();
            chips = 11;
        }

        public Player(string PlayerName)
        {
            cards = new List<int>();
            mName = PlayerName;
            chips = 11;
        }

        /**
         *	Public player constructor that takes two arguments of type int and Socket.
         *	Details: Sets the member's socket and playernumber.
         *	@param socket the socket the player is connected on
         *	@param PlayerNumber order in which they connected to the server.
         */

        public Player(Socket socket, int PlayerNumber)
        {
            cards = new List<int>();
            this.mSocket = socket;
            mPlayerNumber = PlayerNumber;
            chips = 11;
        }

        /**
         *	Public player constructor that takes three arguments of type int, Socket, and string.
         *	Details: Sets the member's socket and playernumber.
         *	@param socket the socket the player is connected on
         *	@param PlayerNumber order in which they connected to the server.
         *	@param PlayerName is the string of name which they pass in through the main menu form
         */
        public Player(Socket socket, int PlayerNumber, string PlayerName)
        {
            cards = new List<int>();
            this.mSocket = socket;
            mPlayerNumber = PlayerNumber;
            mName = PlayerName;
            chips = 11;
        }

        #region Functions
        /**
         *	Public player constructor that takes three arguments of type int, Socket, and string.
         *	Details: Calculates the score
         */
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

    /**
     *	Public player enumeration that takes describes the current player state.
     *	Details: Sets the member's state in the game to allow game logic to take over.
     */
    public enum PlayerState
    {
        IDLE,
        WAITING_FOR_RESPONSE,
        READY,


    }
}
