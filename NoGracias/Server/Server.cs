using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias.Server
{
    class GameServer
    {
        private static readonly Socket Server_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private static readonly List<Socket> Client_Sockets = new List<Socket>();
        private const int BUFFER_SIZE = 2048;
        private const int PORT = 11203;
        private static readonly byte[] Buffer = new byte[BUFFER_SIZE];

        public GameServer()
        {
            //Setup
            ServerSetup();
            //Shutdown
            ServerShutdown();
        }

        #region AbleOpus Adapted Code
        //The following code in this region has been adapted from a repo called NetworkingSamples by GitHub user AbleOpus
        //User: https://github.com/AbleOpus
        //Repo: https://github.com/AbleOpus/NetworkingSamples
        //We have not directly copy and pasted ANY of this user's code, however, this is a very common and generic 
        //way of using sockets in C#, so our code is very similar, in many places, nearly word for word to AbleOpus's code, 
        //and quite similar to many other examples of socket usage on the internet.
        //This is the primary resource we used to learn about socket usage in C#. 

        private void ServerSetup()
        {
            //TODO set title of server form to "Server" or whatever
            //TODO write to server form console that the server is setting up

            Console.WriteLine("Setting up server...");
            //Bind socket
            Server_Socket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            //Tell socket to listen
            Server_Socket.Listen(0);
            //Get async connection request
            Server_Socket.BeginAccept(Accept, null);
            Console.WriteLine("Server setup complete");
            Console.WriteLine("Server IP Address: " + GetLocalIPAddress() + "\nPort Number: " + PORT);

            //TODO set form elements (ip address, port, currently connected, etc)
        }

        private void ServerShutdown()
        {

        }

        private void Accept(IAsyncResult AR)
        {
            Socket temp;

            try
            {
                temp = Server_Socket.EndAccept(AR);
            }
            catch (ObjectDisposedException)
            {
                return; //TODO determine what to do here
            }

            Client_Sockets.Add(temp);
            temp.BeginReceive(Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, temp);
            //TODO write to server form "console" that player has connected 
            Console.WriteLine("Player Connected"); //FOR NOW
            Server_Socket.BeginAccept(Accept, null);
        }

        private void Recieve(IAsyncResult AR)
        {
            Socket temp = (Socket)AR.AsyncState;
            int recieved;

            try
            {
                recieved = temp.EndReceive(AR);
            }
            catch (SocketException)
            {
                //TODO print to form "Client Disconnected"
                Console.WriteLine("Player Disconnected");//FOR NOW
                temp.Close();
                Client_Sockets.Remove(temp);
                return;
            }

            //Handle recieved message
            byte[] Recieved_Buffer = new byte[recieved];
            Array.Copy(Buffer, Recieved_Buffer, recieved);
            string message = Encoding.ASCII.GetString(Recieved_Buffer);

            //TODO write to server form "console" 
            Console.WriteLine(message); //FOR NOW

            if (message.ToLower() == "exit")
            {
                temp.Shutdown(SocketShutdown.Both);
                temp.Close();
                Client_Sockets.Remove(temp);

                //TODO write to server form "console" that a player disconnected
                //TODO handle player disconnect in game driver.
            }
            //TODO send message to communication helper, which will help the game driver progress.
        }

        #endregion


        /*Method: GetLocalIPAddress() 
         *Source: https://stackoverflow.com/questions/6803073/get-local-ip-address 
          Was top selected answer submitted by user: Mrchief
         *Accessed: 10/26/2017
         */
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
