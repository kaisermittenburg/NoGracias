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
        public Socket mSocket;
        public string mName;
        public PlayerState mState;
        public int mPlayerNumber;
        

        public Player(Socket socket, int PlayerNumber)
        {
            this.mSocket = socket;
            mPlayerNumber = PlayerNumber;
        }

    }
    public enum PlayerState
    {
        IDLE,
        WAITING_FOR_RESPONSE,
        READY,


    }
}
