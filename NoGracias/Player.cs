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
        

        public Player(Socket socket)
        {
            this.mSocket = socket;
            
        }

    }
    public enum PlayerState
    {
        IDLE,
        WAITING_FOR_RESPONSE,
        READY,


    }
}
