using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace NoGracias.Server
{
    class GameDriver
    {
        #region Variables
        List<Socket> playerSocket;
        List<string> playerName;
        List<Player> players;
        Deck deck;
        bool isOver;
        Player currentPlayer;
        Card cardInPlay;

        #endregion

        public GameDriver(List<Socket> clientSocket, List<string> players)
        {

            this.players = new List<Player>();
            deck = new Deck();
            isOver = false;
            currentPlayer = this.players[0];
            cardInPlay = deck.TopCard();
        }

        #region Functions

        public void Setup(List<string> names, List<Socket> sockets)
        {
            for(int i=0; i<names.Count; i++)
            {
                Player p1 = new Player(sockets[i], i, names[i]);
                players.Add(p1);
            }
            for(int i=0; i<players.Count - 1; i++)
            {
                players[i].nextPlayer = players[i];
            }
            players.Last().nextPlayer = players[0];

            //TODO: Send Player positions to each client
           

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
            //Send exit message to clients
        }

        public void playTurn()
        {
            //TODO: Show card number and chips to all clients
                    //Send play options to currentPlayer
            
            //TODO: Get currentPlayer's response and store it

            if(true) //player takes it
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
