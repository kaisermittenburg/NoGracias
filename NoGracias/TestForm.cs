using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoGracias
{
    public partial class TestForm : Form
    {
        #region Variables

        private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private Socket playerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private string IP;
        private int PORT = 223;
        //private byte[] buffer;
        private Image[] imgArray = new Image[35];

        private CardTableForm cardTable;
        #endregion

        public TestForm()
        {
            IP = GetLocalIPAddress();
            InitializeComponent();
            Thread serverThread = new Thread(new ThreadStart(ServerStartup));
            serverThread.Start();
            ConnectClient();
            TestCardTable();
        }

        #region Networking Setup

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

        private void ServerStartup()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse(IP), PORT));
            serverSocket.Listen(0);
            Console.WriteLine("Test: Server started");

            serverSocket.BeginAccept((IAsyncResult ar) =>
            {
                clientSocket = serverSocket.EndAccept(ar);
                Console.WriteLine("Test: Client connected");
            }, null);
        }
                
        private void ConnectClient()
        {
            while(!playerSocket.Connected)
            {
                playerSocket.Connect(IP, PORT);
                Console.WriteLine("Test: Player Connected");
            }
        }
        #endregion

        #region Functions

        /// <summary>
        /// TEST FUNCTIONS FOR THE CARD TABLE - JUZER
        /// </summary>

        private void TestCardTable()
        {
            cardTable = new CardTableForm(playerSocket);
            cardTable.Show();
            System.Threading.Thread.Sleep(100);
            /////////////////////////////////////////////////////////////////////////////////////
            /// Getting rid of the MEESAGE_TO_CRASH_RECEIVE_LOOP
            /////////////////////////////////////////////////////////////////////////////////////

            byte[] buffer = new byte[1024];
            int size = clientSocket.Receive(buffer, SocketFlags.None);
            
            byte[] data = new byte[size];
            Array.Copy(buffer, data, size);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Test: Message from server: " + message);

            ////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////

            StatusPrint("Card Table Setup Test: " + ResultPrint(SetupTableTest()));
        }

        private bool SetupTableTest()
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_POSITION.ToString()));
            System.Threading.Thread.Sleep(100);
            clientSocket.Send(Encoding.ASCII.GetBytes("Player1,Player2,Player3,Player4,Player5,"));
            System.Threading.Thread.Sleep(1000);

            bool check = true;
            if (cardTable.PlayerName != "Player1" || cardTable.Chips != 11) check = false;
            else if (cardTable.Opp1PlayerName != "Player2" || cardTable.Opp1ChipNumber != "11") check = false;
            else if (cardTable.Opp2PlayerName != "Player3" || cardTable.Opp2ChipNumber != "11") check = false;
            else if (cardTable.Opp3PlayerName != "Player4" || cardTable.Opp3ChipNumber != "11") check = false;
            else if (cardTable.Opp4PlayerName != "Player5" || cardTable.Opp4ChipNumber != "11") check = false;

            return check;
        }

        private bool UpdateTurnCardTest(string card, string chip)
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_CARD.ToString()));
            System.Threading.Thread.Sleep(100);
            clientSocket.Send(Encoding.ASCII.GetBytes(card + "," + chip));
            System.Threading.Thread.Sleep(1000);

            bool check = true;
            if (cardTable.TurnCard != imgArray[Int32.Parse(card)-1]) check = false;
            else if (cardTable.TurnChipNumber != chip) check = false;

            return check;
        }

        private bool UpdateTurnPlayer(string name)
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_PLAYER.ToString()));
            System.Threading.Thread.Sleep(100);
            clientSocket.Send(Encoding.ASCII.GetBytes(name));
            System.Threading.Thread.Sleep(1000);

            bool check = true;
            if (name == "Player1")
            {
                if (cardTable.TurnStatusText != "Player1's Turn!") check = false;
            }
            else
            {
                if (cardTable.TurnStatusText != name + "'s Turn!") check = false;
            }

            return check;
        }

        private bool UpdatePlayerCardTest(string name, string card, string chip)
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_CARD_UPDATE.ToString()));
            System.Threading.Thread.Sleep(100);
            clientSocket.Send(Encoding.ASCII.GetBytes(name + "," + card + "," + chip));
            System.Threading.Thread.Sleep(1000);

            bool check = true;
            if(name == "Player1")
            {
                if (cardTable.PlayerCard != imgArray[Int32.Parse(card) - 1]) check = false;
                if (cardTable.Chips != 11 + Int32.Parse(chip)) check = false;
            }
            else if(name == "Player2")
            {
                if (cardTable.Opp1Card != imgArray[Int32.Parse(card) - 1]) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp1ChipNumber != n.ToString()) check = false;
            }
            else if(name == "Player3")
            {
                if (cardTable.Opp2Card != imgArray[Int32.Parse(card) - 1]) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp2ChipNumber != n.ToString()) check = false;
            }
            else if(name == "Player4")
            {
                if (cardTable.Opp3Card != imgArray[Int32.Parse(card) - 1]) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp3ChipNumber != n.ToString()) check = false;
            }
            else if(name == "Player5")
            {
                if (cardTable.Opp4Card != imgArray[Int32.Parse(card) - 1]) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp4ChipNumber != n.ToString()) check = false;
            }

            return check;
        }

        private bool AcceptCardTest()
        {
            bool check = true;
            cardTable.Accept.PerformClick();

            bool responseReceived = false;
            while (!responseReceived)
            {
                byte[] buffer = new byte[1024];
                byte[] data;
                int size = playerSocket.Receive(buffer, SocketFlags.None);
                if(size != 0)
                {
                    responseReceived = true;
                    data = new byte[size];
                    Array.Copy(buffer, data, size);
                    string msg = Encoding.ASCII.GetString(data);
                    Console.WriteLine("Test: Received in receive loop: " + msg); //debug

                    if (msg != "ACCEPT_CARD") check = false;
                }
            }

            return check;
        }

        private bool RejectCardTest()
        {
            bool check = true;
            cardTable.Reject.PerformClick();

            bool responseReceived = false;
            while (!responseReceived)
            {
                byte[] buffer = new byte[1024];
                byte[] data;
                int size = playerSocket.Receive(buffer, SocketFlags.None);
                if (size != 0)
                {
                    responseReceived = true;
                    data = new byte[size];
                    Array.Copy(buffer, data, size);
                    string msg = Encoding.ASCII.GetString(data);
                    Console.WriteLine("Test: Received in receive loop: " + msg); //debug

                    if (msg != "REJECT_CARD") check = false;
                }
            }

            return check;
        }
        #endregion

        #region Helper Methods

        private void InitializeImgArray()
        {
            imgArray[0] = NoGracias.Properties.Resources.img1;
            imgArray[1] = NoGracias.Properties.Resources.img2;
            imgArray[2] = NoGracias.Properties.Resources.img3;
            imgArray[3] = NoGracias.Properties.Resources.img4;
            imgArray[4] = NoGracias.Properties.Resources.img5;
            imgArray[5] = NoGracias.Properties.Resources.img6;
            imgArray[6] = NoGracias.Properties.Resources.img7;
            imgArray[7] = NoGracias.Properties.Resources.img8;
            imgArray[8] = NoGracias.Properties.Resources.img9;
            imgArray[9] = NoGracias.Properties.Resources.img10;
            imgArray[10] = NoGracias.Properties.Resources.img11;
            imgArray[11] = NoGracias.Properties.Resources.img12;
            imgArray[12] = NoGracias.Properties.Resources.img13;
            imgArray[13] = NoGracias.Properties.Resources.img14;
            imgArray[14] = NoGracias.Properties.Resources.img15;
            imgArray[15] = NoGracias.Properties.Resources.img16;
            imgArray[16] = NoGracias.Properties.Resources.img17;
            imgArray[17] = NoGracias.Properties.Resources.img18;
            imgArray[18] = NoGracias.Properties.Resources.img19;
            imgArray[19] = NoGracias.Properties.Resources.img20;
            imgArray[20] = NoGracias.Properties.Resources.img21;
            imgArray[21] = NoGracias.Properties.Resources.img22;
            imgArray[22] = NoGracias.Properties.Resources.img23;
            imgArray[23] = NoGracias.Properties.Resources.img24;
            imgArray[24] = NoGracias.Properties.Resources.img25;
            imgArray[25] = NoGracias.Properties.Resources.img26;
            imgArray[26] = NoGracias.Properties.Resources.img27;
            imgArray[27] = NoGracias.Properties.Resources.img28;
            imgArray[28] = NoGracias.Properties.Resources.img29;
            imgArray[29] = NoGracias.Properties.Resources.img30;
            imgArray[30] = NoGracias.Properties.Resources.img31;
            imgArray[31] = NoGracias.Properties.Resources.img32;
            imgArray[32] = NoGracias.Properties.Resources.img33;
            imgArray[33] = NoGracias.Properties.Resources.img34;
            imgArray[34] = NoGracias.Properties.Resources.img35;
        }

        private void StatusPrint(string message)
        {
            Console.WriteLine(message);
            this.Invoke((MethodInvoker)delegate
            {
                this.TestStatus.Text = message + "\n";
            });
        }

        private string ResultPrint(bool result)
        {
            if(result)
            {
                return "PASSED";
            }
            else
            {
                return "FAILED";
            }
        }
        #endregion
    }
}
