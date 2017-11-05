using System;
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

        public GameDriver(List<Player> clients)
        {

            players = clients;
            deck = new Deck();
            isOver = false;
            currentPlayer = this.players[0];
            cardInPlay = deck.TopCard();
        }

        #region Functions

        public void Setup()
        {
            /*for(int i=0; i<names.Count; i++)
            {
                Player p1 = new Player(sockets[i], i, names[i]);
                players.Add(p1);
            }*/
            for(int i=0; i<players.Count - 1; i++)
            {
                players[i].nextPlayer = players[i];
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

                Console.WriteLine("GameDriver is Sending: " + playerInfo);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_POSITION.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerInfo));
            }
        }

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

                Console.WriteLine("GameDriver is Sending: " + playerScores);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_PLAYER_SCORE.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(playerScores));
            }
            //Send exit message to clients
        }

        public void playTurn()
        {
            //TODO: Show card number and chips to all clients
            for(int i=0; i<players.Count; i++)
            {
                string turnCard = cardInPlay.value.ToString() + "," + cardInPlay.chipsOnCard.ToString();
                Console.WriteLine("GameDriver is Sending: " + turnCard);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_CARD.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(turnCard));
            }

            //Send current player to all clients
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("GameDriver is Sending: " + currentPlayer.mName);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_PLAYER.ToString()));
                System.Threading.Thread.Sleep(250);
                players[i].mSocket.Send(Encoding.ASCII.GetBytes(currentPlayer.mName));
            }

            //Send play options to currentPlayer
            Console.WriteLine("GameDriver is Sending to " + currentPlayer.mName);
            currentPlayer.mSocket.Send(Encoding.ASCII.GetBytes(Messages.RECEIVE_TURN_OPTIONS.ToString()));
            System.Threading.Thread.Sleep(250);
            if(currentPlayer.chips != 0)
            {
                Console.WriteLine("GameDriver is Sending: Both");
                currentPlayer.mSocket.Send(Encoding.ASCII.GetBytes("Both"));
            }
            else
            {
            }


            //TODO: Get currentPlayer's response and store it

            if (true) //player takes it
            {
                currentPlayer.cards.Add(cardInPlay.value);
                currentPlayer.chips += cardInPlay.chipsOnCard;
                if (deck.isEmpty())
                {
                    isOver = true;
                }
                else
                {
                    cardInPlay = deck.TopCard();
                }
            }
            else if(true) /*player passes it*/
            {
                cardInPlay.chipsOnCard++;
            }
        }
        #endregion
    }
}
