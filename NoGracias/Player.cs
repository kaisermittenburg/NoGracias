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

        public Player(Socket socket)
        {
            mSocket = socket;
        }
    }
}
