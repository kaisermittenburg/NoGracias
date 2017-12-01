/**************************************************************
 * File:  GameDriver.cs
 * 
 * Authors: Andrew Growney, Kaiser Mittenburg, Juzer Zarif          
 * 
 * Description: Logic to run the game 
 *                                                            
 * ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using Common;
using System.Threading;

namespace NoGracias.Server
{
    class GameDriver
    {
        #region Variables
        private List<Player> players;
        Deck deck;
        bool isOver;
        Player currentPlayer;
        Card cardInPlay;
        int PulseReturns;
        bool responseReceived;
        bool StopPulse;

        #endregion

        /**
         * Constructor
         */
        public GameDriver(List<Player> clients)
        {
            StopPulse = true;
            responseReceived = false;
            PulseReturns = 0;
            players = clients;
            deck = new Deck();
            isOver = false;
            currentPlayer = this.players[0];
            cardInPlay = deck.TopCard();
            
        }

        #region Functions

        /**
         * Sets up Game variables and sockets for starting the game. Initializes variables to their starting values 
         */
        public void Setup()
        {
            /*for(int i=0; i<names.Count; i++)
            {
                Player p1 = new Player(sockets[i], i, names[i]);
                players.Add(p1);
            }*/
            for(int i=0; i<players.Count - 1; i++)
            {
                players[i].nextPlayer = players[i+1];
            }
            players.Last().nextPlayer = players[0];

            //Send Player positions to each client
            for(int i=0; i<players.Count; i++)
            {
                string playerInfo = players.Count.ToString() + ",";
                Player current = players[i];
                for(int j=0; j<players.Count; j++)
                {
                    playerInfo += current.mName + ",";
                    current = current.nextPlayer;
                }

                Console.WriteLine("GameDriver is Sending to "+players[i].mName+": " + playerInfo);
                try
                {
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_POSITION.ToString()));
                    System.Threading.Thread.Sleep(250);
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerInfo));
                }
                catch(Exception)
                {
                    DisconnectPlayers();
                }
            }
        }

        /**
         * Run the Game. Runs game turn wise until the deck is empty, and sends scores to all players after the last round
         */
        public void Run()
        {
            //KHM
            //var thread = new Thread(CheckForDisconnects);
            //thread.TrySetApartmentState(ApartmentState.STA);
            //thread.Start();

            var thread2 = new Thread(ReceiveLoop);
            thread2.TrySetApartmentState(ApartmentState.STA);
            thread2.Start();

            while (!isOver)
            {
                   playTurn();
            }

            List<int> scores = new List<int>();
            foreach(Player p1 in players)
            {
                scores.Add(p1.Score());
            }

            //Send scores to clients
            for (int i = 0; i < players.Count; i++)
            {
                string playerScores = "";
                Player current = players[i];
                for (int j = 0; j < players.Count; j++)
                {
                    playerScores += current.Score().ToString() + ",";
                    current = current.nextPlayer;
                }

                Console.WriteLine("GameDriver is Sending to "+players[i].mName+": " + playerScores);
                try
                {
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_SCORE.ToString()));
                    System.Threading.Thread.Sleep(250);
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerScores));
                }
                catch(Exception)
                {
                    DisconnectPlayers();
                }
            }
            //Send exit message to clients
        }

        private void CheckForDisconnects()
        {
            System.Threading.Thread.Sleep(5000);
            while (true)
            {
                if (!StopPulse)
                {
                    foreach (Player p in players.ToList())
                    {
                        try
                        {
                            if (!StopPulse)
                            {
                                p.mSocket.Send(Encoding.ASCII.GetBytes(Messages.SERVER_PULSE.ToString()));
                                Console.WriteLine("Sent Pulse");
                                //System.Threading.Thread.Sleep(500);
                            }
                        }
                        catch (SocketException)
                        {
                            DisconnectPlayers();
                        }
                    }
                    System.Threading.Thread.Sleep(10000);
                }
            }
        }

        /**
         * Operates Game for a single turn
         * Details: Changes the state of turn specific variables based on interaction with clients. Responsible for sending turn data to clients and receiving response
         */
        public void playTurn()
        {
            responseReceived = false;
            //TODO: Show card number and chips to all clients
            StopPulse = true;
            System.Threading.Thread.Sleep(200);
            for(int i=0; i<players.Count; i++)
            {
                string turnCard = cardInPlay.value.ToString() + "," + cardInPlay.chipsOnCard.ToString();
                Console.WriteLine("GameDriver is Sending to "+players[i].mName+": " + turnCard);
                try
                {
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_CARD.ToString()));
                    System.Threading.Thread.Sleep(300);
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(turnCard));
                    System.Threading.Thread.Sleep(300);
                }
                catch(Exception)
                {
                    DisconnectPlayers();
                }
            }

            //Send current player to all clients
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("GameDriver is Sending to "+players[i].mName+": " + currentPlayer.mName);
                try
                {
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_PLAYER.ToString()));
                    System.Threading.Thread.Sleep(300);
                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(currentPlayer.mName));
                    System.Threading.Thread.Sleep(300);
                }
                catch(Exception)
                {
                    DisconnectPlayers();
                }
            }
            
            StopPulse = false;
            //Send play options to currentPlayer
            /*Console.WriteLine("GameDriver is Sending to " + currentPlayer.mName);
            currentPlayer.mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_OPTIONS.ToString()));
            System.Threading.Thread.Sleep(250);
            if(currentPlayer.chips != 0)
            {
                Console.WriteLine("GameDriver is Sending: Both");
                currentPlayer.mSocket.Send(Encoding.ASCII.GetBytes("Both"));
            }
            else
            {
                Console.WriteLine("GameDriver is Sending: Accept");
                currentPlayer.mSocket.Send(Encoding.ASCII.GetBytes("Accept"));
            }*/

            do
            {

            } while (!responseReceived);
            //System.Threading.Thread.Sleep(250);
            currentPlayer = currentPlayer.nextPlayer;
        }
        public void ReceiveLoop()
        {
            //TODO: Get currentPlayer's response
            Console.WriteLine("GameDriver before response loop");
            
            Console.WriteLine("GameDriver value of responseReceived: " + responseReceived.ToString());
            //Player p = currentPlayer;
            while (true)
            {
                Console.WriteLine("Inside GameDriver Receive loop");
                string msg = "";
                byte[] buffer = new byte[1024];
                byte[] data;
                int receivedSize = 0;
                try
                {
                    try
                    {
                        receivedSize = currentPlayer.mSocket.Receive(buffer, SocketFlags.None);
                    }
                    catch(Exception)
                    {
                        DisconnectPlayers();
                    }
                    if (receivedSize != 0)
                    {

                        data = new byte[receivedSize];
                        Array.Copy(buffer, data, receivedSize);
                        msg = Encoding.ASCII.GetString(data);
                        Console.WriteLine("GameDriver received in receive loop: " + msg); //debug

                        if (msg.Contains("ACCEPT_CARD")) //player takes it
                        {
                            StopPulse = true;

                            //Send card update to all players
                            for (int i = 0; i < players.Count; i++)
                            {
                                string playerCardInfo = currentPlayer.mName + "," + cardInPlay.value.ToString() + "," + cardInPlay.chipsOnCard.ToString();
                                Console.WriteLine("GameDriver is Sending to " + players[i].mName + ": " + playerCardInfo);
                                try
                                {
                                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_CARD_UPDATE.ToString()));
                                    System.Threading.Thread.Sleep(350);
                                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerCardInfo));
                                    System.Threading.Thread.Sleep(300);
                                }
                                catch(Exception)
                                {
                                    DisconnectPlayers();
                                }

                            }
                            System.Threading.Thread.Sleep(500);
                            currentPlayer.cards.Add(cardInPlay.value);
                            currentPlayer.cards.Sort();
                            currentPlayer.chips += cardInPlay.chipsOnCard;
                            if (deck.isEmpty())
                            {
                                isOver = true;
                                for (int i = 0; i < players.Count; i++)
                                {
                                    try
                                    {
                                        Console.WriteLine("GameDriver is Sending to " + players[i].mName + ": GAME_OVER");
                                        players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.GAME_OVER.ToString()));
                                    }
                                    catch(Exception)
                                    {
                                        DisconnectPlayers();
                                    }
                                }
                            }
                            else
                            {
                                cardInPlay = deck.TopCard();
                            }
                            responseReceived = true;
                        }
                        else if (msg.Contains("REJECT_CARD")) //player passes it
                        {
                            StopPulse = true;
                            for (int i = 0; i < players.Count; i++)
                            {
                                Console.WriteLine("GameDriver is Sending to " + players[i].mName + ": CARD_REJECTED");
                                try
                                {
                                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.CARD_REJECTED.ToString()));
                                    System.Threading.Thread.Sleep(250);
                                    players[i].mSocket.Send(Encoding.ASCII.GetBytes(currentPlayer.mName));
                                    System.Threading.Thread.Sleep(300);
                                }
                                catch(Exception)
                                {
                                    DisconnectPlayers();
                                }

                            }
                            currentPlayer.chips--;
                            cardInPlay.chipsOnCard++;
                            responseReceived = true;

                        }
                        else if (msg.Contains(Messages.SERVER_PULSE.ToString()))
                        {
                            PulseReturns++;
                            System.Threading.Thread.Sleep(300);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR Receive Failed: " + e.ToString());
                }

                //p = p.nextPlayer;
            }

        }
        private void DisconnectPlayers()
        {
            isOver = true;
            StopPulse = true;
            foreach (Player i in players.ToList())
            {
                try
                {
                    i.mSocket.Send(Encoding.ASCII.GetBytes(Messages.CARD_TABLE_ERROR.ToString()));
                }
                catch (Exception)
                {

                }
            }
        }

        #endregion
    }
}
