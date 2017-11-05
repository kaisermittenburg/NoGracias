using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoGracias.Server
{
    class GameDriver
    {
        #region Variables
        List<Player> players;
        Deck deck;
        bool isOver;
        Player currentPlayer;
        Card cardInPlay;

        #endregion

        public GameDriver()
        {
            players = new List<Player>();
            deck = new Deck();
            isOver = false;
            currentPlayer = new Player();
            cardInPlay = new Card();
        }

        #region Functions

        public void Setup(List<string> names)
        {
            for(int i=0; i<names.Count; i++)
            {
                Player p1 = new Player(names[i]);
                players.Add(p1);
            }
            for(int i=0; i<players.Count - 1; i++)
            {
                players[i].nextPlayer = players[i];
            }
            players.Last().nextPlayer = players[0];

            //TODO: Send Player positions to each client

            currentPlayer = players[0];
            cardInPlay = deck.TopCard();
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

            if(/*player takes it*/)
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
            else if(/*player passes it*/)
            {
                cardInPlay.chipsOnCard++;
            }
        }
        #endregion
    }
}
