﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using NoGracias.Communication;
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

        #endregion

        /**
         * Constructor
         */
        public GameDriver(List<Player> clients)
        {

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
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_POSITION.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerInfo));
            }
        }

        /**
         * Run the Game. Runs game turn wise until the deck is empty, and sends scores to all players after the last round
         */
        public void Run()
        {
            while(!isOver)
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
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_SCORE.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerScores));
            }
            //Send exit message to clients
        }

        /**
         * Operates Game for a single turn
         * Details: Changes the state of turn specific variables based on interaction with clients. Responsible for sending turn data to clients and receiving response
         */
        public void playTurn()
        {
            //TODO: Show card number and chips to all clients
            for(int i=0; i<players.Count; i++)
            {
                string turnCard = cardInPlay.value.ToString() + "," + cardInPlay.chipsOnCard.ToString();
                Console.WriteLine("GameDriver is Sending to "+players[i].mName+": " + turnCard);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_CARD.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(turnCard));
            }

            //Send current player to all clients
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("GameDriver is Sending to "+players[i].mName+": " + currentPlayer.mName);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_PLAYER.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(currentPlayer.mName));
            }

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


            //TODO: Get currentPlayer's response
            Console.WriteLine("GameDriver before response loop");
            bool responseReceived = false;
            Console.WriteLine("GameDriver value of responseReceived: " + responseReceived.ToString());
            while (!responseReceived)
            {
                Console.WriteLine("Inside GameDriver Receive loop");
                string msg = "";
                byte[] buffer = new byte[1024];
                byte[] data;
                int receivedSize = 0;
                try
                {
                    receivedSize = currentPlayer.mSocket.Receive(buffer, SocketFlags.None);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR Receive Failed: " + e.ToString());
                }

                if (receivedSize != 0)
                {
                    
                    data = new byte[receivedSize];
                    Array.Copy(buffer, data, receivedSize);
                    msg = Encoding.ASCII.GetString(data);
                    Console.WriteLine("GameDriver received in receive loop: " + msg); //debug

                    if (msg == "ACCEPT_CARD") //player takes it
                    {
                        responseReceived = true;
                        //Send card update to all players
                        for (int i=0; i<players.Count; i++)
                        {
                            string playerCardInfo = currentPlayer.mName + "," + cardInPlay.value.ToString() + "," + cardInPlay.chipsOnCard.ToString();
                            Console.WriteLine("GameDriver is Sending to "+players[i].mName+": " + playerCardInfo);
                            players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_CARD_UPDATE.ToString()));
                            System.Threading.Thread.Sleep(250);
                            players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerCardInfo));
                            System.Threading.Thread.Sleep(500);
                        }

                        currentPlayer.cards.Add(cardInPlay.value);
                        currentPlayer.cards.Sort();
                        currentPlayer.chips += cardInPlay.chipsOnCard;
                        if (deck.isEmpty())
                        {
                            isOver = true;
                            for(int i=0; i<players.Count; i++)
                            {
                                Console.WriteLine("GameDriver is Sending to "+players[i].mName+": GAME_OVER");
                                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.GAME_OVER.ToString()));
                            }
                        }
                        else
                        {
                            cardInPlay = deck.TopCard();
                        }
                    }
                    else if (msg == "REJECT_CARD") //player passes it
                    {

                        responseReceived = true;
                        for (int i = 0; i < players.Count; i++)
                        {
                            Console.WriteLine("GameDriver is Sending to "+players[i].mName+": CARD_REJECTED");
                            players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.CARD_REJECTED.ToString()));
                            System.Threading.Thread.Sleep(250);
                            players[i].mSocket.Send(Encoding.ASCII.GetBytes(currentPlayer.mName));
                            System.Threading.Thread.Sleep(250);
                        }
                        currentPlayer.chips--;
                        cardInPlay.chipsOnCard++;
                    }
                }
            }

            currentPlayer = currentPlayer.nextPlayer;
        }

        #endregion
    }
}
