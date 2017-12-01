﻿/**************************************************************
 * File:  TestForm.cs
 * 
 * Authors: Andrew Growney, Kaiser Mittenburg, Juzer Zarif          
 * 
 * Description: The test suite window
 *                                                            
 * ***********************************************************/
using Common;
using NoGracias.Server;
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
        
        private CardTableForm cardTable;

        private GameDriver gameDriver;
        #endregion

        public TestForm()
        {
            IP = GetLocalIPAddress();
            InitializeComponent();
            Thread serverThread = new Thread(new ThreadStart(ServerStartup));
            serverThread.Start();
            ConnectClient();
            System.Threading.Thread.Sleep(500);
            Thread testingThread = new Thread(new ThreadStart(StartTests));
            testingThread.Start();
            
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

        /// <summary>
        /// God Test function. Will run all testing methods synchronously on the same thread.
        /// Any child threads generated by the test methods must be handled appropriately by the methods themselves.
        /// </summary>
        
        private void StartTests()
        {
            
            System.Threading.Thread.Sleep(1000);
            this.TestStatus.Invoke((MethodInvoker)delegate
            {
                string statusText = "\r\nServer Client Connection Test: PASSED";
                int startLength = this.TestStatus.TextLength;
                int endLength = statusText.Length;
                this.TestStatus.AppendText(statusText);
                this.TestStatus.SelectionStart = startLength;
                this.TestStatus.SelectionLength = endLength;
                this.TestStatus.SelectionColor = Color.Green;
            });
            
            TestCardTable();
            TestGameDriver();

            this.progressLabel.Invoke((MethodInvoker)delegate
            {
                this.progressLabel.Text = "FINISHED";
            });
        }

        #region CardTableForm Tests

        /// <summary>
        /// TEST FUNCTIONS FOR THE CARD TABLE - JUZER
        /// </summary>

        private void TestCardTable()
        {
            

            Thread cardTableThread = new Thread(new ThreadStart(() =>
            {
                cardTable = new CardTableForm(playerSocket);
                cardTable.WindowState = FormWindowState.Minimized;
                
                Application.Run(cardTable);                
            }));

            cardTableThread.Start();
            
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
                        
            StatusPrint("Card Table Setup Test: ", SetupTableTest());
            StatusPrint("Update Turn Card Test: ", UpdateTurnCardTest("12", "3"));
            StatusPrint("Update Turn Player (with Main Player) Test: ", UpdateTurnPlayer("Player1"));
            StatusPrint("Update Turn Player (with Opponent) Test: ", UpdateTurnPlayer("Player2"));
            StatusPrint("Update Player Card (with Main Player) Test: ", UpdatePlayerCardTest("Player1", "12", "3"));
            StatusPrint("Update Player Card (with Opponent) Test: ", UpdatePlayerCardTest("Player2", "12", "3"));
            StatusPrint("Accept Card Test: ", AcceptCardTest());
            StatusPrint("Reject Card Test: ", RejectCardTest());
            StatusPrint("Game Over Test: ", GameOverTest());
            StatusPrint("Show Score Test: ", ScoreShowTest());
            
            this.cardTable.Invoke((MethodInvoker)delegate
            {
                this.cardTable.Close();
            });
        }

        private bool SetupTableTest()
        {
            
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_POSITION.ToString()));
            System.Threading.Thread.Sleep(100);
            clientSocket.Send(Encoding.ASCII.GetBytes("5,Player1,Player2,Player3,Player4,Player5,"));
            System.Threading.Thread.Sleep(500);

            cardTable.Sound.Stop();

            bool check = true;
            
            if (cardTable.PlayerName != "Player1" || cardTable.Chips != 11) { check = false; Console.WriteLine("Main Player: " + cardTable.PlayerName); }
            else if (cardTable.Opp1PlayerName != "Player2" || cardTable.Opp1ChipNumber != "11") { check = false; Console.WriteLine("Opponent 1: " + cardTable.Opp1PlayerName); }
            else if (cardTable.Opp2PlayerName != "Player3" || cardTable.Opp2ChipNumber != "11") { check = false; Console.WriteLine("Opponent 2: " + cardTable.Opp2PlayerName); }
            else if (cardTable.Opp3PlayerName != "Player4" || cardTable.Opp3ChipNumber != "11") { check = false; Console.WriteLine("Opponent 3: " + cardTable.Opp3PlayerName); }
            else if (cardTable.Opp4PlayerName != "Player5" || cardTable.Opp4ChipNumber != "11") { check = false; Console.WriteLine("Opponent 4: " + cardTable.Opp4PlayerName); }
            
            return check;
        }

        private bool UpdateTurnCardTest(string card, string chip)
        {
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_CARD.ToString()));
            System.Threading.Thread.Sleep(100);
            clientSocket.Send(Encoding.ASCII.GetBytes(card + "," + chip));
            System.Threading.Thread.Sleep(1000);

            bool check = true;
            if (cardTable.TurnCardValue != card) { check = false; Console.WriteLine("Card number failed: " + cardTable.TurnCardValue); }
            else if (cardTable.TurnChipNumber != chip) { check = false; Console.WriteLine("Turn Chips: " + cardTable.TurnChipNumber); }

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
                if (cardTable.TurnStatusText != "Your Turn!") check = false;
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
                if (!cardTable.PlayerCard) check = false;
                if (cardTable.Chips != 11 + Int32.Parse(chip)) check = false;
            }
            else if(name == "Player2")
            {
                if (!cardTable.Opp1Card) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp1ChipNumber != n.ToString()) check = false;
            }
            else if(name == "Player3")
            {
                if (!cardTable.Opp2Card) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp2ChipNumber != n.ToString()) check = false;
            }
            else if(name == "Player4")
            {
                if (!cardTable.Opp3Card) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp3ChipNumber != n.ToString()) check = false;
            }
            else if(name == "Player5")
            {
                if (!cardTable.Opp4Card) check = false;
                int n = 11 + Int32.Parse(chip);
                if (cardTable.Opp4ChipNumber != n.ToString()) check = false;
            }

            return check;
        }

        private bool AcceptCardTest()
        {
            bool check = true;
            this.cardTable.Accept.Invoke((MethodInvoker)delegate
            {
                cardTable.Accept.PerformClick();
            });

            
            //Console.WriteLine("Inside receive loop");
            byte[] buffer = new byte[1024];
            byte[] data;
            int size = clientSocket.Receive(buffer, SocketFlags.None);
            //Console.WriteLine("receive size: " + size.ToString());
            data = new byte[size];
            Array.Copy(buffer, data, size);
            string msg = Encoding.ASCII.GetString(data);
            Console.WriteLine("Test: Received in receive loop: " + msg); //debug

            if (msg != "ACCEPT_CARD") check = false;
                            
            return check;
        }

        private bool RejectCardTest()
        {
            bool check = true;
            this.cardTable.Reject.Invoke((MethodInvoker)delegate
            {
                cardTable.Reject.Enabled = true;
                cardTable.Reject.Visible = true;
                cardTable.Reject.PerformClick();
            });

            //Console.WriteLine("Inside receive loop");
            byte[] buffer = new byte[1024];
            byte[] data;
            int size = clientSocket.Receive(buffer, SocketFlags.None);
            //Console.WriteLine("receive size: " + size.ToString());
            data = new byte[size];
            Array.Copy(buffer, data, size);
            string msg = Encoding.ASCII.GetString(data);
            Console.WriteLine("Test: Received in receive loop: " + msg); //debug

            if (msg != "REJECT_CARD") check = false;

            return check;
            
        }

        private bool GameOverTest()
        {
            bool check = true;
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.GAME_OVER.ToString()));
            System.Threading.Thread.Sleep(200);

            this.cardTable.Invoke((MethodInvoker)delegate
            {
                if (this.cardTable.TurnStatusText != "--GAME OVER--") check = false;
            });

            return check;
        }

        private bool ScoreShowTest()
        {
            bool check = true;
            clientSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_SCORE.ToString()));
            System.Threading.Thread.Sleep(100);
            clientSocket.Send(Encoding.ASCII.GetBytes("1,2,3,4,5,"));
            System.Threading.Thread.Sleep(200);

            this.cardTable.Invoke((MethodInvoker)delegate
            {
                if (cardTable.CanFocus) check = false;
            });

            return check;
        }
        #endregion

        #region GameDriver Tests

        int numberOfPlayers = 0;
        List<Socket> clientSockets = new List<Socket>();
        List<Socket> playerSockets = new List<Socket>();
        List<Player> players = new List<Player>();

        private void TestGameDriver()
        {
            
            #region Connect all players to server
            bool allConnected = false;
            Thread connectClientsThread = new Thread(new ThreadStart(() =>
            {
                serverSocket.BeginAccept(AcceptCallback, null);
            }));

            void AcceptCallback(IAsyncResult ar)
            {
                Socket temp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSockets.Add(temp);
                clientSockets[numberOfPlayers] = serverSocket.EndAccept(ar);
                Console.WriteLine("GameDriver Test: Client" + (numberOfPlayers+1).ToString() + " connected");
                numberOfPlayers++;
                if (numberOfPlayers < 5)
                {
                    serverSocket.BeginAccept(AcceptCallback, null);
                }
                else allConnected = true;
            }

            connectClientsThread.Start();

            for(int i=0; i<5; i++)
            {
                Socket temp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                playerSockets.Add(temp);
                while(!playerSockets[i].Connected)
                {
                    playerSockets[i].Connect(IP, PORT);
                    Console.WriteLine("GameDriver Test: Player" + (i+1).ToString() + " connected");
                }
            }
            #endregion

            while (!allConnected) { }

            for (int i=0; i<numberOfPlayers; i++)
            {
                string name = "Player" + (i + 1).ToString();
                Player p1 = new Player(clientSockets[i], i, name);
                players.Add(p1);
            }

            Console.WriteLine("Player List to be passed to game driver:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine(players[i].mName);
            }
            Console.WriteLine("-----------------------------------------------------------");
            gameDriver = new GameDriver(players);

            //Thread receiveThread = new Thread(new ThreadStart(gameDriver.ReceiveLoop));
            //receiveThread.Start();

            /////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////

            StatusPrint("GameDriver Setup Send Test: ", GameDriverSetupTest());
            StatusPrint("GameDriver Play Turn Accept Test: ", GameDriverTurnAcceptTest());
            System.Threading.Thread.Sleep(500);
            StatusPrint("GameDriver Play Turn Reject Test: ", GameDriverTurnRejectTest());
            System.Threading.Thread.Sleep(500);
            StatusPrint("GameDriver Turn Player Test: ", GameDriverPlayerTest());
            
            //receiveThread.Abort();
            for (int i=0; i<numberOfPlayers; i++)
            {
                players[i].mSocket.Close();
                playerSockets[i].Close();
                clientSockets[i].Close();
            }
        }

        private bool GameDriverSetupTest()
        {
            bool check = true;

            Thread setupThread = new Thread(new ThreadStart(gameDriver.Setup));
            setupThread.Start();

            for(int i=0; i<playerSockets.Count; i++)
            {
                byte[] buffer1 = new byte[1024];
                byte[] data1;
                int size1 = playerSockets[i].Receive(buffer1, SocketFlags.None);
                data1 = new byte[size1];
                Array.Copy(buffer1, data1, size1);
                string msg1 = Encoding.ASCII.GetString(data1);
                Console.WriteLine(players[i].mName + "'s message1 received: " + msg1);
                if (msg1 != Messages.RECEIVE_PLAYER_POSITION.ToString()) check = false;
            }

            for(int i=0; i<playerSockets.Count; i++)
            {
                string positionString = CreatePlayerString(players, i);

                byte[] buffer2 = new byte[1024];
                byte[] data2;
                int size2 = playerSockets[i].Receive(buffer2, SocketFlags.None);
                data2 = new byte[size2];
                Array.Copy(buffer2, data2, size2);
                string msg2 = Encoding.ASCII.GetString(data2);
                Console.WriteLine(players[i].mName + "'s message2 received: " + msg2);

                if (msg2 != positionString) check = false;
            }

            return check;
        }

        private bool GameDriverTurnAcceptTest()
        {
            bool check = true;
            int card = 0;
            int chip = 0;

            Thread turnThread = new Thread(new ThreadStart(gameDriver.playTurn));
            turnThread.Start();

            #region Receive Turn Card
            for(int i=0; i<playerSockets.Count; i++)
            {
                byte[] buffer1 = new byte[1024];
                byte[] data1;
                int size1 = playerSockets[i].Receive(buffer1, SocketFlags.None);
                data1 = new byte[size1];
                Array.Copy(buffer1, data1, size1);
                string msg1 = Encoding.ASCII.GetString(data1);
                Console.WriteLine(players[i].mName + "'s message1 received: " + msg1);
                if (msg1 != Messages.RECEIVE_TURN_CARD.ToString()) check = false;

                byte[] buffer2 = new byte[1024];
                byte[] data2;
                int size2 = playerSockets[i].Receive(buffer2, SocketFlags.None);
                data2 = new byte[size2];
                Array.Copy(buffer2, data2, size2);
                string msg2 = Encoding.ASCII.GetString(data2);
                Console.WriteLine(players[i].mName + "'s message2 received: " + msg2);
                string[] turnCard = msg2.Split(',');
                card = int.Parse(turnCard[0]);
                chip = int.Parse(turnCard[1]);
                if (card<3 || card>35) check = false;
                if (chip != 0) check = false;
            }
            #endregion

            #region Receive Turn Player
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                Console.WriteLine("Turn Player Message received");
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
                Console.WriteLine("Turn Player Name received");
            }
            #endregion

            playerSockets[0].Send(Encoding.ASCII.GetBytes(Messages.ACCEPT_CARD.ToString()));
            Console.WriteLine("ACCEPT_CARD Sent");

            #region Receive Card Update
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer1 = new byte[1024];
                byte[] data1;
                int size1 = playerSockets[i].Receive(buffer1, SocketFlags.None);
                data1 = new byte[size1];
                Array.Copy(buffer1, data1, size1);
                string msg1 = Encoding.ASCII.GetString(data1);
                Console.WriteLine(players[i].mName + "'s message1 received: " + msg1);
                if (msg1 != Messages.RECEIVE_CARD_UPDATE.ToString()) check = false;

                byte[] buffer2 = new byte[1024];
                byte[] data2;
                int size2 = playerSockets[i].Receive(buffer2, SocketFlags.None);
                data2 = new byte[size2];
                Array.Copy(buffer2, data2, size2);
                string msg2 = Encoding.ASCII.GetString(data2);
                Console.WriteLine(players[i].mName + "'s message2 received: " + msg2);
                string[] playerCard = msg2.Split(',');
                if (playerCard[0] != "Player1") check = false;
                if (int.Parse(playerCard[1]) != card) check = false;
                if (int.Parse(playerCard[2]) != chip) check = false;
            }
            #endregion

            return check;
        }

        private bool GameDriverTurnRejectTest()
        {
            bool check = true;
            int card = 0;
            int chip = 0;

            Thread turnThread = new Thread(new ThreadStart(gameDriver.playTurn));
            Console.WriteLine("\nTURN STARTING\n");
            turnThread.Start();

            #region Receive Turn Card
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer1 = new byte[1024];
                byte[] data1;
                int size1 = playerSockets[i].Receive(buffer1, SocketFlags.None);
                data1 = new byte[size1];
                Array.Copy(buffer1, data1, size1);
                string msg1 = Encoding.ASCII.GetString(data1);
                Console.WriteLine(players[i].mName + "'s message1 received: " + msg1);
                if (msg1 != Messages.RECEIVE_TURN_CARD.ToString()) check = false;

                byte[] buffer2 = new byte[1024];
                byte[] data2;
                int size2 = playerSockets[i].Receive(buffer2, SocketFlags.None);
                data2 = new byte[size2];
                Array.Copy(buffer2, data2, size2);
                string msg2 = Encoding.ASCII.GetString(data2);
                Console.WriteLine(players[i].mName + "'s message2 received: " + msg2);
                string[] turnCard = msg2.Split(',');
                card = int.Parse(turnCard[0]);
                chip = int.Parse(turnCard[1]);
                if (card < 3 || card > 35) check = false;
                if (chip != 0) check = false;
            }
            #endregion

            //Discard Turn Player Data - we know it will be player 2 because of order of operation
            for(int i=0; i<playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }

            playerSockets[1].Send(Encoding.ASCII.GetBytes(Messages.REJECT_CARD.ToString()));

            //Discard Response
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }
            
            System.Threading.Thread.Sleep(500);
            Thread turnThread2 = new Thread(new ThreadStart(gameDriver.playTurn));
            turnThread2.Start();

            #region Receive Turn Card
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer1 = new byte[1024];
                byte[] data1;
                int size1 = playerSockets[i].Receive(buffer1, SocketFlags.None);
                data1 = new byte[size1];
                Array.Copy(buffer1, data1, size1);
                string msg1 = Encoding.ASCII.GetString(data1);
                Console.WriteLine(players[i].mName + "'s message1 received: " + msg1);
                if (msg1 != Messages.RECEIVE_TURN_CARD.ToString()) check = false;

                byte[] buffer2 = new byte[1024];
                byte[] data2;
                int size2 = playerSockets[i].Receive(buffer2, SocketFlags.None);
                data2 = new byte[size2];
                Array.Copy(buffer2, data2, size2);
                string msg2 = Encoding.ASCII.GetString(data2);
                Console.WriteLine(players[i].mName + "'s message2 received: " + msg2);
                string[] turnCard = msg2.Split(',');
                int newCard = int.Parse(turnCard[0]);
                int newChip = int.Parse(turnCard[1]);
                if (newCard != card) check = false;
                if (newChip != chip+1) check = false;
            }
            #endregion

            //Discard Turn Player Data - we know it will be player 3 because of order of operation
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }

            playerSockets[2].Send(Encoding.ASCII.GetBytes(Messages.REJECT_CARD.ToString()));

            //Discard Response
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }

            return check;
        }

        private bool GameDriverPlayerTest()
        {
            bool check = true;
            string player = "";

            Thread turnThread = new Thread(new ThreadStart(gameDriver.playTurn));
            turnThread.Start();

            //Discard Turn Card Data - not relevant to test
            for(int i=0; i<playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }

            #region Receive Turn Player

            for(int i=0; i<playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                byte[] data;
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                data = new byte[size];
                Array.Copy(buffer, data, size);
                string message = Encoding.ASCII.GetString(data);

                if (message != Messages.RECEIVE_TURN_PLAYER.ToString()) { check = false; Console.WriteLine("Incorrect Turn message"); }
            }

            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                byte[] data;
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                data = new byte[size];
                Array.Copy(buffer, data, size);
                string message = Encoding.ASCII.GetString(data);

                if (message != "Player4") { check = false; Console.WriteLine("Incorrect Turn Player"); }
                else player = message;
            }
            #endregion

            playerSockets[3].Send(Encoding.ASCII.GetBytes(Messages.ACCEPT_CARD.ToString()));

            //Discard Response
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }

            System.Threading.Thread.Sleep(500);
            Thread turnThread2 = new Thread(new ThreadStart(gameDriver.playTurn));
            turnThread2.Start();

            //Discard Turn Card Data - not relevant to test
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }

            #region Receive Turn Player

            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                byte[] data;
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                data = new byte[size];
                Array.Copy(buffer, data, size);
                string message = Encoding.ASCII.GetString(data);

                if (message != Messages.RECEIVE_TURN_PLAYER.ToString()) { check = false; Console.WriteLine("Incorrect Turn message"); }
            }

            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                byte[] data;
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                data = new byte[size];
                Array.Copy(buffer, data, size);
                string message = Encoding.ASCII.GetString(data);

                if (message == player) { check = false; Console.WriteLine("Incorrect Turn Player"); }                
            }
            #endregion

            playerSockets[4].Send(Encoding.ASCII.GetBytes(Messages.ACCEPT_CARD.ToString()));

            //Discard Response
            for (int i = 0; i < playerSockets.Count; i++)
            {
                byte[] buffer = new byte[1024];
                int size = playerSockets[i].Receive(buffer, SocketFlags.None);
                size = playerSockets[i].Receive(buffer, SocketFlags.None);
            }

            return check;
        }
        #endregion

        #region Helper Methods

        private void StatusPrint(string message, bool result)
        {
            if (result)
            {
                string statusText = "\r\n" + message + "PASSED";
                Console.WriteLine(statusText);
                this.TestStatus.Invoke((MethodInvoker)delegate
                {
                    int startLength = this.TestStatus.TextLength;
                    int endLength = statusText.Length;
                    this.TestStatus.AppendText(statusText);
                    this.TestStatus.SelectionStart = startLength;
                    this.TestStatus.SelectionLength = endLength;
                    this.TestStatus.SelectionColor = Color.Green;
                });
            }
            else
            {
                string statusText = "\r\n" + message + "FAILED";
                Console.WriteLine(statusText);
                this.TestStatus.Invoke((MethodInvoker)delegate
                {
                    int startLength = this.TestStatus.TextLength;
                    int endLength = statusText.Length;
                    this.TestStatus.AppendText(statusText);
                    this.TestStatus.SelectionStart = startLength;
                    this.TestStatus.SelectionLength = endLength;
                    this.TestStatus.SelectionColor = Color.Red;
                    this.TestStatus.DeselectAll();
                });
            }
        }

        private string CreatePlayerString(List<Player> playerList, int counter)
        {
            string playerString;

            playerString = playerList.Count.ToString() + ",";
            for(int i = counter; i<playerList.Count; i++)
            {
                playerString += playerList[i].mName + ",";
            }
            for(int i=0; i<counter; i++)
            {
                playerString += playerList[i].mName + ",";
            }

            return playerString;
        }

        /*private string ResultPrint(bool result)
        {
            if(result) return "PASSED";
            else return "FAILED";
        }*/
        #endregion

        #region Event Handlers

        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //playerSocket.Disconnect(true);
            if(clientSocket.Connected) clientSocket.Disconnect(true);
            serverSocket.Close();
        }
        
                
        #endregion
    }
}
