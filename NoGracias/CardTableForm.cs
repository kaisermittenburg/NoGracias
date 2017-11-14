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
        
        #endregion
        public CardTableForm(Socket aClientSocket)
        {
            InitializeComponent();
            mClientSocket = aClientSocket;
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
            Console.WriteLine("Message from server...  " + message); //debugging

            if(message == Messages.RECEIVE_PLAYER_POSITION.ToString())
            {
                SetupTable();
            }
            else if(message == Messages.RECEIVE_TURN_CARD.ToString())
            {

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
            Console.WriteLine("Message from server...  " + message); //debugging

            string[] playerData = message.Split(',');
            numberOfOpp = Int32.Parse(playerData[0]) - 1;
            mainPlayer.mName = playerData[1];
            for(int i=2; i<playerData.Length; i++)
            {
                Player p1 = new Player(playerData[i]);
                opponents.Add(p1);
            }

            PlayerName = mainPlayer.mName;
            Chips = 11;

            for(int i=0; i<numberOfOpp; i++)
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
        #endregion
    }
}
