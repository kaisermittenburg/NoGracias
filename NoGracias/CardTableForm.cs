using NoGracias.Communication;
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

namespace NoGracias
{
    public partial class CardTableForm : Form
    {
        #region Variables
        private List<Player> opponents = new List<Player>();
        private Player mainPlayer = new Player();
        int currentCard;
        int currentChips;
        
        #endregion
        public CardTableForm(Socket aClientSocket)
        {
            InitializeComponent();
            mClientSocket = aClientSocket;
            mClientSocket.Send(Encoding.ASCII.GetBytes("MESSAGE_TO_CRASH_RECEIVE_LOOP"));
            ListenToServer();
        }

        #region Event Handlers
        private void CardTableForm_Load(object sender, EventArgs e)
        {

        }

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox2_TextChanged_1(object sender, EventArgs e)
		{

		}

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card9_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num7_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num6_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num5_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num4_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num3_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num2_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num1_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num9_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num10_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num11_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num12_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num13_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num14_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num15_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num16_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card16_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card15_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card14_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card13_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card12_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card11_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card10_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Num8_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card8_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card7_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card6_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card5_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card4_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void Opp2Card2_Click(object sender, EventArgs e)
        {

        }

        private void Opp2Card1_Click(object sender, EventArgs e)
        {

        }

        private void Opp2ChipCount_Click(object sender, EventArgs e)
        {

        }

        private void Opp2ChipText_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void AcceptCardButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(mainPlayer.mName + "'s Card Table is Sending: ACCEPT_CARD");
            this.Invoke((MethodInvoker)delegate
            {
                mClientSocket.Send(Encoding.ASCII.GetBytes(Messages.ACCEPT_CARD.ToString()));
            });
        }

        private void NoGraciasButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(mainPlayer.mName + "'s Card Table is Sending: REJECT_CARD");
            this.Invoke((MethodInvoker)delegate
            {
                mClientSocket.Send(Encoding.ASCII.GetBytes(Messages.REJECT_CARD.ToString()));
            });
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
            while(true)
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
                    mainPlayer.mSocket.Send(Encoding.ASCII.GetBytes(Messages.ACCEPT_CARD.ToString()));
                    
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

            currentCard = cardNumber;
            currentChips = cardChip;

            this.TopDeckCardNum.Invoke((MethodInvoker)delegate
            {
                this.TopDeckCardNum.Visible = true;
                this.TopDeckCardNum.Text = cardNumber.ToString();
            });
            this.TopDeckChipCounter.Invoke((MethodInvoker)delegate
            {
                this.TopDeckChipCounter.Text = cardChip.ToString();
            });
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
                int playerChips = Int32.Parse(this.MainPlayerChipCount.Text);
                playerChips += chips;
                this.MainPlayerChipCount.Text = playerChips.ToString();

                switch (n)
                {
                    case 0:
                        this.MainPlayerNum1.Text = card.ToString();
                        this.MainPlayerCard1.Visible = true;
                        this.MainPlayerNum1.Visible = true;
                        this.MainPlayerNum1.BringToFront();
                        break;

                    case 1:
                        this.MainPlayerNum2.Text = card.ToString();
                        this.MainPlayerCard2.Visible = true;
                        this.MainPlayerNum2.Visible = true;
                        this.MainPlayerNum2.BringToFront();
                        break;

                    case 2:
                        this.MainPlayerNum3.Text = card.ToString();
                        this.MainPlayerCard3.Visible = true;
                        this.MainPlayerNum3.Visible = true;
                        this.MainPlayerNum3.BringToFront();
                        break;

                    case 3:
                        this.MainPlayerNum4.Text = card.ToString();
                        this.MainPlayerCard4.Visible = true;
                        this.MainPlayerNum4.Visible = true;
                        this.MainPlayerNum4.BringToFront();
                        break;

                    case 4:
                        this.MainPlayerNum5.Text = card.ToString();
                        this.MainPlayerCard5.Visible = true;
                        this.MainPlayerNum5.Visible = true;
                        break;

                    case 5:
                        this.MainPlayerNum6.Text = card.ToString();
                        this.MainPlayerCard6.Visible = true;
                        this.MainPlayerNum6.Visible = true;
                        break;

                    case 6:
                        this.MainPlayerNum7.Text = card.ToString();
                        this.MainPlayerCard7.Visible = true;
                        this.MainPlayerNum7.Visible = true;
                        break;

                    case 7:
                        this.MainPlayerNum8.Text = card.ToString();
                        this.MainPlayerCard8.Visible = true;
                        this.MainPlayerNum8.Visible = true;
                        break;

                    case 8:
                        this.MainPlayerNum9.Text = card.ToString();
                        this.MainPlayerCard9.Visible = true;
                        this.MainPlayerNum9.Visible = true;
                        break;

                    case 9:
                        this.MainPlayerNum10.Text = card.ToString();
                        this.MainPlayerCard10.Visible = true;
                        this.MainPlayerNum10.Visible = true;
                        break;

                    case 10:
                        this.MainPlayerNum11.Text = card.ToString();
                        this.MainPlayerCard11.Visible = true;
                        this.MainPlayerNum11.Visible = true;
                        break;

                    case 11:
                        this.MainPlayerNum12.Text = card.ToString();
                        this.MainPlayerCard12.Visible = true;
                        this.MainPlayerNum12.Visible = true;
                        break;

                    case 12:
                        this.MainPlayerNum13.Text = card.ToString();
                        this.MainPlayerCard13.Visible = true;
                        this.MainPlayerNum13.Visible = true;
                        break;

                    case 13:
                        this.MainPlayerNum14.Text = card.ToString();
                        this.MainPlayerCard14.Visible = true;
                        this.MainPlayerNum14.Visible = true;
                        break;

                    case 14:
                        this.MainPlayerNum15.Text = card.ToString();
                        this.MainPlayerCard15.Visible = true;
                        this.MainPlayerNum15.Visible = true;
                        break;

                    case 15:
                        this.MainPlayerNum16.Text = card.ToString();
                        this.MainPlayerCard16.Visible = true;
                        this.MainPlayerNum16.Visible = true;
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
            });
        }

        private void AddOpp1Card(int card, int chips)
        {
            int n = opponents.ElementAt(0).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {
                int playerChips = Int32.Parse(this.Opp1ChipCount.Text);
                playerChips += chips;
                this.Opp1ChipCount.Text = playerChips.ToString();

                switch (n)
                {
                    case 0:
                        this.Opp1Num1.Text = card.ToString();
                        this.Opp1Card1.Visible = true;
                        this.Opp1Num1.Visible = true;
                        break;

                    case 1:
                        this.Opp1Num2.Text = card.ToString();
                        this.Opp1Card2.Visible = true;
                        this.Opp1Num2.Visible = true;
                        break;

                    case 2:
                        this.Opp1Num3.Text = card.ToString();
                        this.Opp1Card3.Visible = true;
                        this.Opp1Num3.Visible = true;
                        break;

                    case 3:
                        this.Opp1Num4.Text = card.ToString();
                        this.Opp1Card4.Visible = true;
                        this.Opp1Num4.Visible = true;
                        break;

                    case 4:
                        this.Opp1Num5.Text = card.ToString();
                        this.Opp1Card5.Visible = true;
                        this.Opp1Num5.Visible = true;
                        break;

                    case 5:
                        this.Opp1Num6.Text = card.ToString();
                        this.Opp1Card6.Visible = true;
                        this.Opp1Num6.Visible = true;
                        break;

                    case 6:
                        this.Opp1Num7.Text = card.ToString();
                        this.Opp1Card7.Visible = true;
                        this.Opp1Num7.Visible = true;
                        break;

                    case 7:
                        this.Opp1Num8.Text = card.ToString();
                        this.Opp1Card8.Visible = true;
                        this.Opp1Num8.Visible = true;
                        break;

                    case 8:
                        this.Opp1Num9.Text = card.ToString();
                        this.Opp1Card9.Visible = true;
                        this.Opp1Num9.Visible = true;
                        break;

                    case 9:
                        this.Opp1Num10.Text = card.ToString();
                        this.Opp1Card10.Visible = true;
                        this.Opp1Num10.Visible = true;
                        break;

                    case 10:
                        this.Opp1Num11.Text = card.ToString();
                        this.Opp1Card11.Visible = true;
                        this.Opp1Num11.Visible = true;
                        break;

                    case 11:
                        this.Opp1Num12.Text = card.ToString();
                        this.Opp1Card12.Visible = true;
                        this.Opp1Num12.Visible = true;
                        break;

                    case 12:
                        this.Opp1Num13.Text = card.ToString();
                        this.Opp1Card13.Visible = true;
                        this.Opp1Num13.Visible = true;
                        break;

                    case 13:
                        this.Opp1Num14.Text = card.ToString();
                        this.Opp1Card14.Visible = true;
                        this.Opp1Num14.Visible = true;
                        break;

                    case 14:
                        this.Opp1Num15.Text = card.ToString();
                        this.Opp1Card15.Visible = true;
                        this.Opp1Num15.Visible = true;
                        break;

                    case 15:
                        this.Opp1Num16.Text = card.ToString();
                        this.Opp1Card16.Visible = true;
                        this.Opp1Num16.Visible = true;
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
            });
        }

        private void AddOpp2Card(int card, int chips)
        {
            int n = opponents.ElementAt(1).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {
                int playerChips = Int32.Parse(this.Opp2ChipCount.Text);
                playerChips += chips;
                this.Opp2ChipCount.Text = playerChips.ToString();

                switch (n)
                {
                    case 0:
                        this.Opp2Num1.Text = card.ToString();
                        this.Opp2Card1.Visible = true;
                        this.Opp2Num1.Visible = true;
                        break;

                    case 1:
                        this.Opp2Num2.Text = card.ToString();
                        this.Opp2Card2.Visible = true;
                        this.Opp2Num2.Visible = true;
                        break;

                    case 2:
                        this.Opp2Num3.Text = card.ToString();
                        this.Opp2Card3.Visible = true;
                        this.Opp2Num3.Visible = true;
                        break;

                    case 3:
                        this.Opp2Num4.Text = card.ToString();
                        this.Opp2Card4.Visible = true;
                        this.Opp2Num4.Visible = true;
                        break;

                    case 4:
                        this.Opp2Num5.Text = card.ToString();
                        this.Opp2Card5.Visible = true;
                        this.Opp2Num5.Visible = true;
                        break;

                    case 5:
                        this.Opp2Num6.Text = card.ToString();
                        this.Opp2Card6.Visible = true;
                        this.Opp2Num6.Visible = true;
                        break;

                    case 6:
                        this.Opp2Num7.Text = card.ToString();
                        this.Opp2Card7.Visible = true;
                        this.Opp2Num7.Visible = true;
                        break;

                    case 7:
                        this.Opp2Num8.Text = card.ToString();
                        this.Opp2Card8.Visible = true;
                        this.Opp2Num8.Visible = true;
                        break;

                    case 8:
                        this.Opp2Num9.Text = card.ToString();
                        this.Opp2Card9.Visible = true;
                        this.Opp2Num9.Visible = true;
                        break;

                    case 9:
                        this.Opp2Num10.Text = card.ToString();
                        this.Opp2Card10.Visible = true;
                        this.Opp2Num10.Visible = true;
                        break;

                    case 10:
                        this.Opp2Num11.Text = card.ToString();
                        this.Opp2Card11.Visible = true;
                        this.Opp2Num11.Visible = true;
                        break;

                    case 11:
                        this.Opp2Num12.Text = card.ToString();
                        this.Opp2Card12.Visible = true;
                        this.Opp2Num12.Visible = true;
                        break;

                    case 12:
                        this.Opp2Num13.Text = card.ToString();
                        this.Opp2Card13.Visible = true;
                        this.Opp2Num13.Visible = true;
                        break;

                    case 13:
                        this.Opp2Num14.Text = card.ToString();
                        this.Opp2Card14.Visible = true;
                        this.Opp2Num14.Visible = true;
                        break;

                    case 14:
                        this.Opp2Num15.Text = card.ToString();
                        this.Opp2Card15.Visible = true;
                        this.Opp2Num15.Visible = true;
                        break;

                    case 15:
                        this.Opp2Num16.Text = card.ToString();
                        this.Opp2Card16.Visible = true;
                        this.Opp2Num16.Visible = true;
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
            });
        }

        private void AddOpp3Card(int card, int chips)
        {
            int n = opponents.ElementAt(2).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {
                int playerChips = Int32.Parse(this.Opp3ChipCount.Text);
                playerChips += chips;
                this.Opp3ChipCount.Text = playerChips.ToString();

                switch (n)
                {
                    case 0:
                        this.Opp3Num1.Text = card.ToString();
                        this.Opp3Card1.Visible = true;
                        this.Opp3Num1.Visible = true;
                        break;

                    case 1:
                        this.Opp3Num2.Text = card.ToString();
                        this.Opp3Card2.Visible = true;
                        this.Opp3Num2.Visible = true;
                        break;

                    case 2:
                        this.Opp3Num3.Text = card.ToString();
                        this.Opp3Card3.Visible = true;
                        this.Opp3Num3.Visible = true;
                        break;

                    case 3:
                        this.Opp3Num4.Text = card.ToString();
                        this.Opp3Card4.Visible = true;
                        this.Opp3Num4.Visible = true;
                        break;

                    case 4:
                        this.Opp3Num5.Text = card.ToString();
                        this.Opp3Card5.Visible = true;
                        this.Opp3Num5.Visible = true;
                        break;

                    case 5:
                        this.Opp3Num6.Text = card.ToString();
                        this.Opp3Card6.Visible = true;
                        this.Opp3Num6.Visible = true;
                        break;

                    case 6:
                        this.Opp3Num7.Text = card.ToString();
                        this.Opp3Card7.Visible = true;
                        this.Opp3Num7.Visible = true;
                        break;

                    case 7:
                        this.Opp3Num8.Text = card.ToString();
                        this.Opp3Card8.Visible = true;
                        this.Opp3Num8.Visible = true;
                        break;

                    case 8:
                        this.Opp3Num9.Text = card.ToString();
                        this.Opp3Card9.Visible = true;
                        this.Opp3Num9.Visible = true;
                        break;

                    case 9:
                        this.Opp3Num10.Text = card.ToString();
                        this.Opp3Card10.Visible = true;
                        this.Opp3Num10.Visible = true;
                        break;

                    case 10:
                        this.Opp3Num11.Text = card.ToString();
                        this.Opp3Card11.Visible = true;
                        this.Opp3Num11.Visible = true;
                        break;

                    case 11:
                        this.Opp3Num12.Text = card.ToString();
                        this.Opp3Card12.Visible = true;
                        this.Opp3Num12.Visible = true;
                        break;

                    case 12:
                        this.Opp3Num13.Text = card.ToString();
                        this.Opp3Card13.Visible = true;
                        this.Opp3Num13.Visible = true;
                        break;

                    case 13:
                        this.Opp3Num14.Text = card.ToString();
                        this.Opp3Card14.Visible = true;
                        this.Opp3Num14.Visible = true;
                        break;

                    case 14:
                        this.Opp3Num15.Text = card.ToString();
                        this.Opp3Card15.Visible = true;
                        this.Opp3Num15.Visible = true;
                        break;

                    case 15:
                        this.Opp3Num16.Text = card.ToString();
                        this.Opp3Card16.Visible = true;
                        this.Opp3Num16.Visible = true;
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
            });
        }

        private void AddOpp4Card(int card, int chips)
        {
            int n = opponents.ElementAt(3).cards.Count;
            this.Invoke((MethodInvoker)delegate
            {
                int playerChips = Int32.Parse(this.Opp4ChipCount.Text);
                playerChips += chips;
                this.Opp4ChipCount.Text = playerChips.ToString();

                switch (n)
                {
                    case 0:
                        this.Opp4Num1.Text = card.ToString();
                        this.Opp4Card1.Visible = true;
                        this.Opp4Num1.Visible = true;
                        break;

                    case 1:
                        this.Opp4Num2.Text = card.ToString();
                        this.Opp4Card2.Visible = true;
                        this.Opp4Num2.Visible = true;
                        break;

                    case 2:
                        this.Opp4Num3.Text = card.ToString();
                        this.Opp4Card3.Visible = true;
                        this.Opp4Num3.Visible = true;
                        break;

                    case 3:
                        this.Opp4Num4.Text = card.ToString();
                        this.Opp4Card4.Visible = true;
                        this.Opp4Num4.Visible = true;
                        break;

                    case 4:
                        this.Opp4Num5.Text = card.ToString();
                        this.Opp4Card5.Visible = true;
                        this.Opp4Num5.Visible = true;
                        break;

                    case 5:
                        this.Opp4Num6.Text = card.ToString();
                        this.Opp4Card6.Visible = true;
                        this.Opp4Num6.Visible = true;
                        break;

                    case 6:
                        this.Opp4Num7.Text = card.ToString();
                        this.Opp4Card7.Visible = true;
                        this.Opp4Num7.Visible = true;
                        break;

                    case 7:
                        this.Opp4Num8.Text = card.ToString();
                        this.Opp4Card8.Visible = true;
                        this.Opp4Num8.Visible = true;
                        break;

                    case 8:
                        this.Opp4Num9.Text = card.ToString();
                        this.Opp4Card9.Visible = true;
                        this.Opp4Num9.Visible = true;
                        break;

                    case 9:
                        this.Opp4Num10.Text = card.ToString();
                        this.Opp4Card10.Visible = true;
                        this.Opp4Num10.Visible = true;
                        break;

                    case 10:
                        this.Opp4Num11.Text = card.ToString();
                        this.Opp4Card11.Visible = true;
                        this.Opp4Num11.Visible = true;
                        break;

                    case 11:
                        this.Opp4Num12.Text = card.ToString();
                        this.Opp4Card12.Visible = true;
                        this.Opp4Num12.Visible = true;
                        break;

                    case 12:
                        this.Opp4Num13.Text = card.ToString();
                        this.Opp4Card13.Visible = true;
                        this.Opp4Num13.Visible = true;
                        break;

                    case 13:
                        this.Opp4Num14.Text = card.ToString();
                        this.Opp4Card14.Visible = true;
                        this.Opp4Num14.Visible = true;
                        break;

                    case 14:
                        this.Opp4Num15.Text = card.ToString();
                        this.Opp4Card15.Visible = true;
                        this.Opp4Num15.Visible = true;
                        break;

                    case 15:
                        this.Opp4Num16.Text = card.ToString();
                        this.Opp4Card16.Visible = true;
                        this.Opp4Num16.Visible = true;
                        break;
                    default:
                        //We have run out of cards. I miscalculated, I'm not a math major
                        break;
                }
            });
        }
        #endregion


    }
}
