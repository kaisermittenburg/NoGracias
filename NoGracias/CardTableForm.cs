/**************************************************************
 * File:  CardTableForm.cs
 * 
 * Authors: Andrew Growney, Kaiser Mittenburg, Juzer Zarif          
 * 
 * Description: The Card Table window
 *                                                            
 * ***********************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace NoGracias
{
    public partial class CardTableForm : Form
    {
        #region Variables
        private List<Player> opponents = new List<Player>();
        private Player mainPlayer = new Player();
        int currentCard = 0;
        int currentChips = 0;
        int cardsInDeck = 24;
        bool isGameOver = false;
        Image[] imgArray = new Image[35];
        System.Media.SoundPlayer soundDriver;
        bool isSoundPlaying = true;
        
        #endregion
        public CardTableForm(Socket aClientSocket)
        {
            InitializeComponent();
            mClientSocket = aClientSocket;
            //mClientSocket.Send(Encoding.ASCII.GetBytes("MESSAGE_TO_CRASH_RECEIVE_LOOP"));
            InitializeImgArray();
            ListenToServer();
        }

        #region Event Handlers
        private void CardTableForm_Load(object sender, EventArgs e)
        {
            soundDriver = new System.Media.SoundPlayer(NoGracias.Properties.Resources.bensound_jazzyfrenchy);
            soundDriver.Load();
            soundDriver.PlayLooping();
            isSoundPlaying = true;
        }
        		
        private void AcceptCardButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(mainPlayer.mName + "'s Card Table is Sending: ACCEPT_CARD");
            this.Invoke((MethodInvoker)delegate
            {
                this.AcceptCardButton.Visible = false;
                this.NoGraciasButton.Visible = false;
                mClientSocket.Send(Encoding.ASCII.GetBytes(Messages.ACCEPT_CARD.ToString()));
            });
        }

        private void NoGraciasButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(mainPlayer.mName + "'s Card Table is Sending: REJECT_CARD");
            this.Invoke((MethodInvoker)delegate
            {
                this.AcceptCardButton.Visible = false;
                this.NoGraciasButton.Visible = false;
                mClientSocket.Send(Encoding.ASCII.GetBytes(Messages.REJECT_CARD.ToString()));
            });
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(isSoundPlaying)
            {
                this.button1.BackgroundImage = NoGracias.Properties.Resources.speaker_mute;
                soundDriver.Stop();
                isSoundPlaying = false;
            }
            else
            {
                this.button1.BackgroundImage = NoGracias.Properties.Resources.speaker;
                soundDriver.PlayLooping();
                isSoundPlaying = true;
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void CardTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        #endregion

        #region Functions

        private void ListenToServer()
        {
            Thread listener = null;

            try
            {
                ThreadStart startMethod = new ThreadStart(StartReceive);
                listener = new Thread(startMethod);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR Failed to create thread: " + e);
                return;
            }

            try
            {
                listener.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR Failed to start thread: " + e);
                return;
            }
        }

        private void StartReceive()
        {
            mClientSocket.Send(Encoding.ASCII.GetBytes("MESSAGE_TO_CRASH_RECEIVE_LOOP")); 
            while (!isGameOver)
            {
                ReceiveFromServer();
            }
        }

        private void ReceiveFromServer()
        {
            byte[] buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);

            if (received == 0) return;

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server in main receive...  " + message); //debugging

            if(message == Messages.RECEIVE_PLAYER_POSITION.ToString())
            {
                SetupTable();
            }
            else if(message == Messages.RECEIVE_TURN_CARD.ToString())
            {
                UpdateCardInPlay();
            }
            else if(message == Messages.RECEIVE_TURN_PLAYER.ToString())
            {
                UpdateTurnPlayer();
            }
            else if(message == Messages.RECEIVE_CARD_UPDATE.ToString())
            {
                UpdatePlayerCard();
            }
            else if(message == Messages.CARD_REJECTED.ToString())
            {
                RejectCardUpdate();
            }
            else if(message == Messages.GAME_OVER.ToString())
            {
                this.TurnStatus.Invoke((MethodInvoker)delegate
                {
                    this.TurnStatus.Text = "--GAME OVER--";
                });
            }
            else if(message == Messages.RECEIVE_PLAYER_SCORE.ToString())
            {
                isGameOver = true;
                ShowPlayerScores();
                if (this.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                }
            }
            else if(message == Messages.CARD_TABLE_ERROR.ToString())
            {
                CustomMessageBox.ShowBox("Either a player disconnected or the server crashed! Going back to main menu...");
                isGameOver = true;
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }
        }

        private void ShowPlayerScores()
        {
            byte[] buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);

            if (received == 0) return;

            mClientSocket.Shutdown(SocketShutdown.Both);
            mClientSocket.BeginDisconnect(true, (IAsyncResult ar) =>
            {
                mClientSocket.EndDisconnect(ar);
                //mClientSocket.Close();
            }, null);

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server in show score...  " + message); //debugging

            message = message.Substring(0, message.Length - 1);
            string[]  scoreString = message.Split(',');
            int[] score = new int[scoreString.Length];
            for(int i=0; i<scoreString.Length; i++)
            {
                score[i] = Int32.Parse(scoreString[i]);
            }

            string scoreMessage = "";
            if (score.Min() == score[0])
            {
                scoreMessage = "YOU WON!\n\n";
            }
            else
            {
                scoreMessage = "YOU LOST :(\n\n";
            }
            for (int i=0; i<score.Length; i++)
            {
                if(i==0)
                {
                    scoreMessage += "Your Score: " + score[0] + "\n";
                }
                else
                {
                    scoreMessage += opponents.ElementAt(i - 1).mName + "'s Score: " + score[i] + "\n";
                }
            }

            //MessageBox.Show(scoreMessage, "Scores", MessageBoxButtons.OK);
            this.Invoke((MethodInvoker)delegate
            {
                CustomMessageBox.ShowBox(scoreMessage);
            });
        }

        private void RejectCardUpdate()
        {
            byte[] buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);

            if (received == 0) return;

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server in reject card update...  " + message); //debugging

            this.Invoke((MethodInvoker)delegate
            {
                if (message == mainPlayer.mName)
                {
                    mainPlayer.chips--;
                    this.MainPlayerChipCount.Text = mainPlayer.chips.ToString();
                }
                else
                {
                    for (int i = 0; i < opponents.Count; i++)
                    {
                        if (message == opponents.ElementAt(i).mName)
                        {
                            switch (i)
                            {
                                case 0:
                                    opponents.ElementAt(0).chips--;
                                    this.Opp1ChipCount.Text = opponents.ElementAt(0).chips.ToString();
                                    break;

                                case 1:
                                    opponents.ElementAt(1).chips--;
                                    this.Opp2ChipCount.Text = opponents.ElementAt(1).chips.ToString();
                                    break;

                                case 2:
                                    opponents.ElementAt(2).chips--;
                                    this.Opp3ChipCount.Text = opponents.ElementAt(2).chips.ToString();
                                    break;

                                case 3:
                                    opponents.ElementAt(3).chips--;
                                    this.Opp4ChipCount.Text = opponents.ElementAt(3).chips.ToString();
                                    break;

                                default:
                                    //should never hit this
                                    break;
                            }
                        }
                    }
                }
            });
        }

        private void UpdatePlayerCard()
        {
            byte[] buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);

            if (received == 0) return;

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server in update player card...  " + message); //debugging

            string[] playerCardInfo = message.Split(',');

            string playerName = playerCardInfo[0];
            int cardValue = Int32.Parse(playerCardInfo[1]);
            int cardChip = Int32.Parse(playerCardInfo[2]);

            if (playerName == mainPlayer.mName)
            {
                AddPlayerCard(cardValue, cardChip);
                mainPlayer.cards.Add(cardValue);
                mainPlayer.chips += cardChip;
            }
            else
            {
                for (int i = 0; i < opponents.Count; i++)
                {
                    if(playerName == opponents.ElementAt(i).mName)
                    {
                        switch(i)
                        {
                            case 0:
                                AddOpp1Card(cardValue, cardChip);
                                opponents.ElementAt(0).cards.Add(cardValue);
                                opponents.ElementAt(0).chips += cardChip;
                                break;
                            case 1:
                                AddOpp2Card(cardValue, cardChip);
                                opponents.ElementAt(1).cards.Add(cardValue);
                                opponents.ElementAt(1).chips += cardChip;
                                break;
                            case 2:
                                AddOpp3Card(cardValue, cardChip);
                                opponents.ElementAt(2).cards.Add(cardValue);
                                opponents.ElementAt(2).chips += cardChip;
                                break;
                            case 3:
                                AddOpp4Card(cardValue, cardChip);
                                opponents.ElementAt(3).cards.Add(cardValue);
                                opponents.ElementAt(3).chips += cardChip;
                                break;
                            default:
                                //should never hit this
                                break;
                        }
                    }
                }
            }
        }

        private void UpdateTurnPlayer()
        {
            byte[] buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);

            if (received == 0) return;

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server in update player...  " + message); //debugging
            
            if(message == mainPlayer.mName)
            {
                //Your Turn!
                this.TurnStatus.Invoke((MethodInvoker)delegate
                {
                    this.TurnStatus.Text = "Your Turn!";
                });
                if(mainPlayer.chips == 0)
                {
                    //Well I guess you're taking that
                    this.TurnStatus.Invoke((MethodInvoker)delegate
                    {
                        this.TurnStatus.Text += "\nWell, I guess you're taking that";
                    });
                    System.Threading.Thread.Sleep(1000);
                    /*mainPlayer.cards.Add(currentCard);
                    //Add card to main player's hand 
                    mainPlayer.chips += currentChips;
                    this.MainPlayerChipCount.Invoke((MethodInvoker)delegate
                    {
                        this.MainPlayerChipCount.Text = mainPlayer.chips.ToString();
                    });*/

                    //TODO Send ACCEPT message to server
                    Console.WriteLine(mainPlayer.mName + "'s Card Table is Sending: ACCEPT_CARD");
                    mClientSocket.Send(Encoding.ASCII.GetBytes(Messages.ACCEPT_CARD.ToString()));
                    
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.AcceptCardButton.Visible = true;
                        this.NoGraciasButton.Visible = true;
                    });
                }
            }
            else
            {
                //Someone else's turn :(
                for (int i = 0; i < opponents.Count; i++)
                {
                    if (opponents.ElementAt(i).mName == message)
                    {
                        this.TurnStatus.Invoke((MethodInvoker)delegate
                        {
                            this.TurnStatus.Text = opponents.ElementAt(i).mName + "'s Turn!";
                        });
                    }
                }
            }
        }

        private void UpdateCardInPlay()
        {
            byte[] buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);

            if (received == 0) return;

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server in update card...  " + message); //debugging

            string[] cardInfo = message.Split(',');
            int cardNumber = Int32.Parse(cardInfo[0]);
            int cardChip = Int32.Parse(cardInfo[1]);

            if (currentCard == cardNumber)
            {
                currentChips = cardChip;
                this.TopDeckChipCounter.Invoke((MethodInvoker)delegate
                {
                    this.TopDeckChipCounter.Text = cardChip.ToString();
                });
            }
            else
            {
                currentCard = cardNumber;
                currentChips = cardChip;
                if(cardsInDeck>4)
                {
                    cardsInDeck--;
                }
                else
                {
                    RemoveDeckCard();
                    cardsInDeck--;
                }

                this.TopDeckCard.Invoke((MethodInvoker)delegate
                {
                    this.TopDeckCard.BackgroundImage = imgArray[cardNumber - 1];
                    this.TopDeckCard.Visible = true;
                    this.TopDeckCard.BringToFront();
                });
                this.TopDeckChipCounter.Invoke((MethodInvoker)delegate
                {
                    this.TopDeckChipCounter.Text = cardChip.ToString();
                });
            }
        }

        private void SetupTable()
        {
            int numberOfOpp;
            byte[] buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);

            if (received == 0) return;

            byte[] data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server in setup table...  " + message); //debugging

            message = message.Substring(0, message.Length - 1);
            string[] playerData = message.Split(',');
            
            for(int i=0; i<playerData.Length; i++)
            {
                Console.WriteLine("Player Data: " + playerData[i]); //debugging
            }
            numberOfOpp = Int32.Parse(playerData[0]) - 1;
            mainPlayer.mName = playerData[1];
            for(int i=2; i<playerData.Length; i++)
            {
                Player p1 = new Player(playerData[i]);
                opponents.Add(p1);
            }

            PlayerName = mainPlayer.mName;
            Chips = 11;

            for(int i=0; i<playerData.Length - 2; i++)
            {
                switch (i)
                {
                    case 0:
                        InitializeOpp1(opponents.ElementAt(i).mName);
                        break;
                    case 1:
                        InitializeOpp2(opponents.ElementAt(i).mName);
                        break;
                    case 2:
                        InitializeOpp3(opponents.ElementAt(i).mName);
                        break;
                    case 3:
                        InitializeOpp4(opponents.ElementAt(i).mName);
                        break;
                }
            }
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
        private void InitializeOpp1(string mName)
        {
            this.Opp1Name.Invoke((MethodInvoker)delegate
            {
                this.Opp1Name.Visible = true;
                this.Opp1Name.Text = mName;
            });
            this.Opp1ChipText.Invoke((MethodInvoker)delegate
            {
                this.Opp1ChipText.Visible = true;
            });
            this.pictureBox18.Invoke((MethodInvoker)delegate
            {
                this.pictureBox18.Visible = true;
            });
            this.Opp1ChipCount.Invoke((MethodInvoker)delegate
            {
                this.Opp1ChipCount.Visible = true;
                this.Opp1ChipCount.Text = "11";
            });
        }

        private void InitializeOpp2(string mName)
        {
            this.Opp2Name.Invoke((MethodInvoker)delegate
            {
                this.Opp2Name.Visible = true;
                this.Opp2Name.Text = mName;
            });
            this.Opp2ChipText.Invoke((MethodInvoker)delegate
            {
                this.Opp2ChipText.Visible = true;
            });
            this.pictureBox17.Invoke((MethodInvoker)delegate
            {
                this.pictureBox17.Visible = true;
            });
            this.Opp2ChipCount.Invoke((MethodInvoker)delegate
            {
                this.Opp2ChipCount.Visible = true;
                this.Opp2ChipCount.Text = "11";
            });
        }

        private void InitializeOpp3(string mName)
        {
            this.Opp3Name.Invoke((MethodInvoker)delegate
            {
                this.Opp3Name.Visible = true;
                this.Opp3Name.Text = mName;
            });
            this.Opp3ChipText.Invoke((MethodInvoker)delegate
            {
                this.Opp3ChipText.Visible = true;
            });
            this.opp3ChipGraphic.Invoke((MethodInvoker)delegate
            {
                this.opp3ChipGraphic.Visible = true;
            });
            this.Opp3ChipCount.Invoke((MethodInvoker)delegate
            {
                this.Opp3ChipCount.Visible = true;
                this.Opp3ChipCount.Text = "11";
            });
        }

        private void InitializeOpp4(string mName)
        {
            this.Opp4Name.Invoke((MethodInvoker)delegate
            {
                this.Opp4Name.Visible = true;
                this.Opp4Name.Text = mName;
            });
            this.Opp4ChipText.Invoke((MethodInvoker)delegate
            {
                this.Opp4ChipText.Visible = true;
            });
            this.opp4ChipGraphic.Invoke((MethodInvoker)delegate
            {
                this.opp4ChipGraphic.Visible = true;
            });
            this.Opp4ChipCount.Invoke((MethodInvoker)delegate
            {
                this.Opp4ChipCount.Visible = true;
                this.Opp4ChipCount.Text = "11";
            });
        }

        private void AddPlayerCard(int card, int chips)
        {
            int n = mainPlayer.cards.Count;
            this.Invoke((MethodInvoker)delegate
            {
                int org_x_loc = this.TopDeckCard.Location.X;
                int org_y_loc = this.TopDeckCard.Location.Y;
                int new_x_loc;
                int new_y_loc;

                switch (n)
                {
                    case 0:
                        new_x_loc = this.MainPlayerCard1.Location.X;
                        new_y_loc = this.MainPlayerCard1.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard1.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard1.BackgroundImage = imgArray[card - 1];
                        this.MainPlayerCard1.Visible = true;
                        this.MainPlayerCard1.BringToFront();
                        break;

                    case 1:
                        new_x_loc = this.MainPlayerCard2.Location.X;
                        new_y_loc = this.MainPlayerCard2.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard2.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard2.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard2.Visible = true;
                        this.MainPlayerCard2.BringToFront();
                        break;

                    case 2:
                        new_x_loc = this.MainPlayerCard3.Location.X;
                        new_y_loc = this.MainPlayerCard3.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard3.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard3.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard3.Visible = true;
                        this.MainPlayerCard3.BringToFront();
                        break;

                    case 3:
                        new_x_loc = this.MainPlayerCard4.Location.X;
                        new_y_loc = this.MainPlayerCard4.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard4.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard4.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard4.Visible = true;
                        this.MainPlayerCard4.BringToFront();
                        break;

                    case 4:
                        new_x_loc = this.MainPlayerCard5.Location.X;
                        new_y_loc = this.MainPlayerCard5.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard5.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard5.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard5.Visible = true;
                        this.MainPlayerCard5.BringToFront();
                        break;

                    case 5:
                        new_x_loc = this.MainPlayerCard6.Location.X;
                        new_y_loc = this.MainPlayerCard6.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard6.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard6.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard6.Visible = true;
                        this.MainPlayerCard6.BringToFront();
                        break;

                    case 6:
                        new_x_loc = this.MainPlayerCard7.Location.X;
                        new_y_loc = this.MainPlayerCard7.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard7.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard7.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard7.Visible = true;
                        this.MainPlayerCard7.BringToFront();
                        break;

                    case 7:
                        new_x_loc = this.MainPlayerCard8.Location.X;
                        new_y_loc = this.MainPlayerCard8.Location.Y;
                        Console.WriteLine("Original Location:" + this.MainPlayerCard8.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard8.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard8.Visible = true;
                        this.MainPlayerCard8.BringToFront();
                        break;

                    case 8:
                        new_x_loc = this.MainPlayerCard9.Location.X;
                        new_y_loc = this.MainPlayerCard9.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard9.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard9.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard9.Visible = true;
                        this.MainPlayerCard9.BringToFront();
                        break;

                    case 9:
                        new_x_loc = this.MainPlayerCard10.Location.X;
                        new_y_loc = this.MainPlayerCard10.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard10.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard10.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard10.Visible = true;
                        this.MainPlayerCard10.BringToFront();
                        break;

                    case 10:
                        new_x_loc = this.MainPlayerCard11.Location.X;
                        new_y_loc = this.MainPlayerCard11.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard11.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard11.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard11.Visible = true;
                        this.MainPlayerCard11.BringToFront();
                        break;

                    case 11:
                        new_x_loc = this.MainPlayerCard12.Location.X;
                        new_y_loc = this.MainPlayerCard12.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard12.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard12.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard12.Visible = true;
                        this.MainPlayerCard12.BringToFront();
                        break;

                    case 12:
                        new_x_loc = this.MainPlayerCard13.Location.X;
                        new_y_loc = this.MainPlayerCard13.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard13.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard13.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard13.Visible = true;
                        this.MainPlayerCard13.BringToFront();
                        break;

                    case 13:
                        new_x_loc = this.MainPlayerCard14.Location.X;
                        new_y_loc = this.MainPlayerCard14.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard14.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard14.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard14.Visible = true;
                        this.MainPlayerCard14.BringToFront();
                        break;

                    case 14:
                        new_x_loc = this.MainPlayerCard15.Location.X;
                        new_y_loc = this.MainPlayerCard15.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard15.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard15.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard15.Visible = true;
                        this.MainPlayerCard15.BringToFront();
                        break;

                    case 15:
                        new_x_loc = this.MainPlayerCard16.Location.X;
                        new_y_loc = this.MainPlayerCard16.Location.Y;
                        Console.WriteLine("New Location:" + this.MainPlayerCard16.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.MainPlayerCard16.BackgroundImage = imgArray[card-1];
                        this.MainPlayerCard16.Visible = true;
                        this.MainPlayerCard16.BringToFront();
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
                this.TopDeckCard.Location = new Point(org_x_loc, org_y_loc);
                this.TopDeckCard.BackgroundImage = imgArray[1];
                this.TopDeckChipCounter.Text = "0";
                int playerChips = Int32.Parse(this.MainPlayerChipCount.Text);
                playerChips += chips;
                this.MainPlayerChipCount.Text = playerChips.ToString();
            });
        }

        private void AddOpp1Card(int card, int chips)
        {
            int n = opponents.ElementAt(0).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {
                int org_x_loc = this.TopDeckCard.Location.X;
                int org_y_loc = this.TopDeckCard.Location.Y;
                int new_x_loc;
                int new_y_loc;
                switch (n)
                {
                    case 0:
                        new_x_loc = this.Opp1Card1.Location.X;
                        new_y_loc = this.Opp1Card1.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card1.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card1.BackgroundImage = imgArray[card-1];
                        this.Opp1Card1.Visible = true;
                        this.Opp1Card1.BringToFront();
                        break;

                    case 1:
                        new_x_loc = this.Opp1Card2.Location.X;
                        new_y_loc = this.Opp1Card2.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card2.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card2.BackgroundImage = imgArray[card-1];
                        this.Opp1Card2.Visible = true;
                        this.Opp1Card2.BringToFront();
                        break;

                    case 2:
                        new_x_loc = this.Opp1Card3.Location.X;
                        new_y_loc = this.Opp1Card3.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card3.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card3.BackgroundImage = imgArray[card-1];
                        this.Opp1Card3.Visible = true;
                        this.Opp1Card3.BringToFront();
                        break;

                    case 3:
                        new_x_loc = this.Opp1Card4.Location.X;
                        new_y_loc = this.Opp1Card4.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card4.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card4.BackgroundImage = imgArray[card-1];
                        this.Opp1Card4.Visible = true;
                        this.Opp1Card4.BringToFront();
                        break;

                    case 4:
                        new_x_loc = this.Opp1Card5.Location.X;
                        new_y_loc = this.Opp1Card5.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card5.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card5.BackgroundImage = imgArray[card-1];
                        this.Opp1Card5.Visible = true;
                        this.Opp1Card5.BringToFront();
                        break;

                    case 5:
                        new_x_loc = this.Opp1Card6.Location.X;
                        new_y_loc = this.Opp1Card6.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card6.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card6.BackgroundImage = imgArray[card-1];
                        this.Opp1Card6.Visible = true;
                        this.Opp1Card6.BringToFront();
                        break;

                    case 6:
                        new_x_loc = this.Opp1Card7.Location.X;
                        new_y_loc = this.Opp1Card7.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card7.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card7.BackgroundImage = imgArray[card-1];
                        this.Opp1Card7.Visible = true;
                        this.Opp1Card7.BringToFront();
                        break;

                    case 7:
                        new_x_loc = this.Opp1Card8.Location.X;
                        new_y_loc = this.Opp1Card8.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card8.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card8.BackgroundImage = imgArray[card-1];
                        this.Opp1Card8.Visible = true;
                        this.Opp1Card8.BringToFront();
                        break;

                    case 8:
                        new_x_loc = this.Opp1Card9.Location.X;
                        new_y_loc = this.Opp1Card9.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card9.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card9.BackgroundImage = imgArray[card-1];
                        this.Opp1Card9.Visible = true;
                        this.Opp1Card9.BringToFront();
                        break;

                    case 9:
                        new_x_loc = this.Opp1Card10.Location.X;
                        new_y_loc = this.Opp1Card10.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card10.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card10.BackgroundImage = imgArray[card-1];
                        this.Opp1Card10.Visible = true;
                        this.Opp1Card10.BringToFront();
                        break;

                    case 10:
                        new_x_loc = this.Opp1Card11.Location.X;
                        new_y_loc = this.Opp1Card11.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card11.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card11.BackgroundImage = imgArray[card-1];
                        this.Opp1Card11.Visible = true;
                        this.Opp1Card11.BringToFront();
                        break;

                    case 11:
                        new_x_loc = this.Opp1Card12.Location.X;
                        new_y_loc = this.Opp1Card12.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card12.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card12.BackgroundImage = imgArray[card-1];
                        this.Opp1Card12.Visible = true;
                        this.Opp1Card12.BringToFront();
                        break;

                    case 12:
                        new_x_loc = this.Opp1Card13.Location.X;
                        new_y_loc = this.Opp1Card13.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card13.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card13.BackgroundImage = imgArray[card-1];
                        this.Opp1Card13.Visible = true;
                        this.Opp1Card13.BringToFront();
                        break;

                    case 13:
                        new_x_loc = this.Opp1Card14.Location.X;
                        new_y_loc = this.Opp1Card14.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card14.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card14.BackgroundImage = imgArray[card-1];
                        this.Opp1Card14.Visible = true;
                        this.Opp1Card14.BringToFront();
                        break;

                    case 14:
                        new_x_loc = this.Opp1Card15.Location.X;
                        new_y_loc = this.Opp1Card15.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card15.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card15.BackgroundImage = imgArray[card-1];
                        this.Opp1Card15.Visible = true;
                        this.Opp1Card15.BringToFront();
                        break;

                    case 15:
                        new_x_loc = this.Opp1Card16.Location.X;
                        new_y_loc = this.Opp1Card16.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp1Card16.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp1Card16.BackgroundImage = imgArray[card-1];
                        this.Opp1Card16.Visible = true;
                        this.Opp1Card16.BringToFront();
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
                this.TopDeckCard.Location = new Point(org_x_loc, org_y_loc);
                this.TopDeckCard.BackgroundImage = imgArray[1];
                this.TopDeckChipCounter.Text = "0";
                int playerChips = Int32.Parse(this.Opp1ChipCount.Text);
                playerChips += chips;
                this.Opp1ChipCount.Text = playerChips.ToString();

            });
        }

        private void AddOpp2Card(int card, int chips)
        {
            int n = opponents.ElementAt(1).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {


                int org_x_loc = this.TopDeckCard.Location.X;
                int org_y_loc = this.TopDeckCard.Location.Y;
                int new_x_loc;
                int new_y_loc;
                switch (n)
                {
                    case 0:
                        new_x_loc = this.Opp2Card1.Location.X;
                        new_y_loc = this.Opp2Card1.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card1.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card1.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card1.Visible = true;
                        this.Opp2Card1.BringToFront();
                        break;

                    case 1:
                        new_x_loc = this.Opp2Card2.Location.X;
                        new_y_loc = this.Opp2Card2.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card2.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card2.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card2.Visible = true;
                        this.Opp2Card2.BringToFront();
                        break;

                    case 2:
                        new_x_loc = this.Opp2Card3.Location.X;
                        new_y_loc = this.Opp2Card3.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card3.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card3.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card3.Visible = true;
                        this.Opp2Card3.BringToFront();
                        break;

                    case 3:
                        new_x_loc = this.Opp2Card4.Location.X;
                        new_y_loc = this.Opp2Card4.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card4.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card4.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card4.Visible = true;
                        this.Opp2Card4.BringToFront();
                        break;

                    case 4:
                        new_x_loc = this.Opp2Card5.Location.X;
                        new_y_loc = this.Opp2Card5.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card5.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card5.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card5.Visible = true;
                        this.Opp2Card5.BringToFront();
                        break;

                    case 5:
                        new_x_loc = this.Opp2Card6.Location.X;
                        new_y_loc = this.Opp2Card6.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card6.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card6.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card6.Visible = true;
                        this.Opp2Card6.BringToFront();
                        break;

                    case 6:
                        new_x_loc = this.Opp2Card7.Location.X;
                        new_y_loc = this.Opp2Card7.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card7.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card7.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card7.Visible = true;
                        this.Opp2Card7.BringToFront();
                        break;

                    case 7:
                        new_x_loc = this.Opp2Card8.Location.X;
                        new_y_loc = this.Opp2Card8.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card8.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card8.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card8.Visible = true;
                        this.Opp2Card8.BringToFront();
                        break;

                    case 8:
                        new_x_loc = this.Opp2Card9.Location.X;
                        new_y_loc = this.Opp2Card9.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card9.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card9.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card9.Visible = true;
                        this.Opp2Card9.BringToFront();
                        break;

                    case 9:
                        new_x_loc = this.Opp2Card10.Location.X;
                        new_y_loc = this.Opp2Card10.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card10.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card10.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card10.Visible = true;
                        this.Opp2Card10.BringToFront();
                        break;

                    case 10:
                        new_x_loc = this.Opp2Card11.Location.X;
                        new_y_loc = this.Opp2Card11.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card11.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card11.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card11.Visible = true;
                        this.Opp2Card11.BringToFront();
                        break;

                    case 11:
                        new_x_loc = this.Opp2Card12.Location.X;
                        new_y_loc = this.Opp2Card12.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card12.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card12.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card12.Visible = true;
                        this.Opp2Card12.BringToFront();
                        break;

                    case 12:
                        new_x_loc = this.Opp2Card13.Location.X;
                        new_y_loc = this.Opp2Card13.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card13.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card13.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card13.Visible = true;
                        this.Opp2Card13.BringToFront();
                        break;

                    case 13:
                        new_x_loc = this.Opp2Card14.Location.X;
                        new_y_loc = this.Opp2Card14.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card14.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card14.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card14.Visible = true;
                        this.Opp2Card14.BringToFront();
                        break;

                    case 14:
                        new_x_loc = this.Opp2Card15.Location.X;
                        new_y_loc = this.Opp2Card15.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card15.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card15.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card15.Visible = true;
                        this.Opp2Card15.BringToFront();
                        break;

                    case 15:
                        new_x_loc = this.Opp2Card16.Location.X;
                        new_y_loc = this.Opp2Card16.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp2Card16.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp2Card16.BackgroundImage = imgArray[card - 1];
                        this.Opp2Card16.Visible = true;
                        this.Opp2Card16.BringToFront();
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
                this.TopDeckCard.Location = new Point(org_x_loc, org_y_loc);
                this.TopDeckCard.BackgroundImage = imgArray[1];
                this.TopDeckChipCounter.Text = "0";
                int playerChips = Int32.Parse(this.Opp2ChipCount.Text);
                playerChips += chips;
                this.Opp2ChipCount.Text = playerChips.ToString();
            });
        }

        private void AddOpp3Card(int card, int chips)
        {
            int n = opponents.ElementAt(2).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {

                int org_x_loc = this.TopDeckCard.Location.X;
                int org_y_loc = this.TopDeckCard.Location.Y;
                int new_x_loc;
                int new_y_loc;
                switch (n)
                {
                    case 0:
                        new_x_loc = this.Opp3Card1.Location.X;
                        new_y_loc = this.Opp3Card1.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card1.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card1.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card1.Visible = true;
                        this.Opp3Card1.BringToFront();
                        break;

                    case 1:
                        new_x_loc = this.Opp3Card2.Location.X;
                        new_y_loc = this.Opp3Card2.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card2.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card2.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card2.Visible = true;
                        this.Opp3Card2.BringToFront();
                        break;

                    case 2:
                        new_x_loc = this.Opp3Card3.Location.X;
                        new_y_loc = this.Opp3Card3.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card3.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card3.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card3.Visible = true;
                        this.Opp3Card3.BringToFront();
                        break;

                    case 3:
                        new_x_loc = this.Opp3Card4.Location.X;
                        new_y_loc = this.Opp3Card4.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card4.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card4.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card4.Visible = true;
                        this.Opp3Card4.BringToFront();
                        break;

                    case 4:
                        new_x_loc = this.Opp3Card5.Location.X;
                        new_y_loc = this.Opp3Card5.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card5.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card5.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card5.Visible = true;
                        this.Opp3Card5.BringToFront();
                        break;

                    case 5:
                        new_x_loc = this.Opp3Card6.Location.X;
                        new_y_loc = this.Opp3Card6.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card6.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card6.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card6.Visible = true;
                        this.Opp3Card6.BringToFront();
                        break;

                    case 6:
                        new_x_loc = this.Opp3Card7.Location.X;
                        new_y_loc = this.Opp3Card7.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card7.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card7.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card7.Visible = true;
                        this.Opp3Card7.BringToFront();
                        break;

                    case 7:
                        new_x_loc = this.Opp3Card8.Location.X;
                        new_y_loc = this.Opp3Card8.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card8.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card8.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card8.Visible = true;
                        this.Opp3Card8.BringToFront();
                        break;

                    case 8:
                        new_x_loc = this.Opp3Card9.Location.X;
                        new_y_loc = this.Opp3Card9.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card9.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card9.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card9.Visible = true;
                        this.Opp3Card9.BringToFront();
                        break;

                    case 9:
                        new_x_loc = this.Opp3Card10.Location.X;
                        new_y_loc = this.Opp3Card10.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card10.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card10.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card10.Visible = true;
                        this.Opp3Card10.BringToFront();
                        break;

                    case 10:
                        new_x_loc = this.Opp3Card11.Location.X;
                        new_y_loc = this.Opp3Card11.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card11.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card11.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card11.Visible = true;
                        this.Opp3Card11.BringToFront();
                        break;

                    case 11:
                        new_x_loc = this.Opp3Card12.Location.X;
                        new_y_loc = this.Opp3Card12.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card12.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card12.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card12.Visible = true;
                        this.Opp3Card12.BringToFront();
                        break;

                    case 12:
                        new_x_loc = this.Opp3Card13.Location.X;
                        new_y_loc = this.Opp3Card13.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card13.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card13.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card13.Visible = true;
                        this.Opp3Card13.BringToFront();
                        break;

                    case 13:
                        new_x_loc = this.Opp3Card14.Location.X;
                        new_y_loc = this.Opp3Card14.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card14.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card14.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card14.Visible = true;
                        this.Opp3Card14.BringToFront();
                        break;

                    case 14:
                        new_x_loc = this.Opp3Card15.Location.X;
                        new_y_loc = this.Opp3Card15.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card15.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card15.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card15.Visible = true;
                        this.Opp3Card15.BringToFront();
                        break;

                    case 15:
                        new_x_loc = this.Opp3Card16.Location.X;
                        new_y_loc = this.Opp3Card16.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp3Card16.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp3Card16.BackgroundImage = imgArray[card - 1];
                        this.Opp3Card16.Visible = true;
                        this.Opp3Card16.BringToFront();
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
                this.TopDeckCard.Location = new Point(org_x_loc, org_y_loc);
                this.TopDeckCard.BackgroundImage = imgArray[1];
                this.TopDeckChipCounter.Text = "0";
                int playerChips = Int32.Parse(this.Opp3ChipCount.Text);
                playerChips += chips;
                this.Opp3ChipCount.Text = playerChips.ToString();
            });
        }

        private void AddOpp4Card(int card, int chips)
        {
            int n = opponents.ElementAt(3).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {

                int org_x_loc = this.TopDeckCard.Location.X;
                int org_y_loc = this.TopDeckCard.Location.Y;
                int new_x_loc;
                int new_y_loc;
                switch (n)
                {
                    case 0:
                        new_x_loc = this.Opp4Card1.Location.X;
                        new_y_loc = this.Opp4Card1.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card1.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card1.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card1.Visible = true;
                        this.Opp4Card1.BringToFront();
                        break;

                    case 1:
                        new_x_loc = this.Opp4Card2.Location.X;
                        new_y_loc = this.Opp4Card2.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card2.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card2.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card2.Visible = true;
                        this.Opp4Card2.BringToFront();
                        break;

                    case 2:
                        new_x_loc = this.Opp4Card3.Location.X;
                        new_y_loc = this.Opp4Card3.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card3.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card3.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card3.Visible = true;
                        this.Opp4Card3.BringToFront();
                        break;

                    case 3:
                        new_x_loc = this.Opp4Card4.Location.X;
                        new_y_loc = this.Opp4Card4.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card4.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card4.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card4.Visible = true;
                        this.Opp4Card4.BringToFront();
                        break;

                    case 4:
                        new_x_loc = this.Opp4Card5.Location.X;
                        new_y_loc = this.Opp4Card5.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card5.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card5.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card5.Visible = true;
                        this.Opp4Card5.BringToFront();
                        break;

                    case 5:
                        new_x_loc = this.Opp4Card6.Location.X;
                        new_y_loc = this.Opp4Card6.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card6.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card6.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card6.Visible = true;
                        this.Opp4Card6.BringToFront();
                        break;

                    case 6:
                        new_x_loc = this.Opp4Card7.Location.X;
                        new_y_loc = this.Opp4Card7.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card7.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card7.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card7.Visible = true;
                        this.Opp4Card7.BringToFront();
                        break;

                    case 7:
                        new_x_loc = this.Opp4Card8.Location.X;
                        new_y_loc = this.Opp4Card8.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card8.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card8.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card8.Visible = true;
                        this.Opp4Card8.BringToFront();
                        break;

                    case 8:
                        new_x_loc = this.Opp4Card9.Location.X;
                        new_y_loc = this.Opp4Card9.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card9.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card9.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card9.Visible = true;
                        this.Opp4Card9.BringToFront();
                        break;

                    case 9:
                        new_x_loc = this.Opp4Card10.Location.X;
                        new_y_loc = this.Opp4Card10.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card10.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card10.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card10.Visible = true;
                        this.Opp4Card10.BringToFront();
                        break;

                    case 10:
                        new_x_loc = this.Opp4Card11.Location.X;
                        new_y_loc = this.Opp4Card11.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card11.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card11.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card11.Visible = true;
                        this.Opp4Card11.BringToFront();
                        break;

                    case 11:
                        new_x_loc = this.Opp4Card12.Location.X;
                        new_y_loc = this.Opp4Card12.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card12.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card12.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card12.Visible = true;
                        this.Opp4Card12.BringToFront();
                        break;

                    case 12:
                        new_x_loc = this.Opp4Card13.Location.X;
                        new_y_loc = this.Opp4Card13.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card13.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card13.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card13.Visible = true;
                        this.Opp4Card13.BringToFront();
                        break;

                    case 13:
                        new_x_loc = this.Opp4Card14.Location.X;
                        new_y_loc = this.Opp4Card14.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card14.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card14.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card14.Visible = true;
                        this.Opp4Card14.BringToFront();
                        break;

                    case 14:
                        new_x_loc = this.Opp4Card15.Location.X;
                        new_y_loc = this.Opp4Card15.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card15.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card15.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card15.Visible = true;
                        this.Opp4Card15.BringToFront();
                        break;

                    case 15:
                        new_x_loc = this.Opp4Card16.Location.X;
                        new_y_loc = this.Opp4Card16.Location.Y;
                        Console.WriteLine("New Location:" + this.Opp4Card16.Location);

                        for (int i = 0; i < 100; i++)
                        {
                            this.TopDeckCard.Location = new Point(this.TopDeckCard.Location.X + ((new_x_loc - org_x_loc) / 100), this.TopDeckCard.Location.Y + ((new_y_loc - org_y_loc) / 100));
                        }
                        this.Opp4Card16.BackgroundImage = imgArray[card - 1];
                        this.Opp4Card16.Visible = true;
                        this.Opp4Card16.BringToFront();
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
                this.TopDeckCard.Location = new Point(org_x_loc, org_y_loc);
                this.TopDeckCard.BackgroundImage = imgArray[1];
                this.TopDeckChipCounter.Text = "0";
                int playerChips = Int32.Parse(this.Opp4ChipCount.Text);
                playerChips += chips;
                this.Opp4ChipCount.Text = playerChips.ToString();
            });
        }

        private void RemoveDeckCard()
        {
            this.Invoke((MethodInvoker)delegate
            {
                switch (cardsInDeck)
                {
                    case 1:
                        this.DeckCard4.Visible = false;
                        break;
                    case 2:
                        this.DeckCard3.Visible = false;
                        break;
                    case 3:
                        this.DeckCard2.Visible = false;
                        break;
                    case 4:
                        this.DeckCard1.Visible = false;
                        break;
                    default:
                        //should never hit this
                        Console.WriteLine("ERROR: RemoveDeckCard was called unexpectedly");
                        break;
                }
            });
        }


        #endregion

    }
}
