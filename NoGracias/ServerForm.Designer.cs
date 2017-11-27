using NoGracias.Server;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Common;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace NoGracias
{
    partial class ServerForm
    {
        #region Variables
        /**
		 *	Public member variable. Holds the IP address of the server and defines getter and setter
		 */
        public string IP
        {
            get { return IP_textbox.Text; }
            set { IP_textbox.Text = value; }
        }

        /**
		 *	Public member variable. Holds the port of the server and defines getter and setter
		 */
        public string Port
        {
            get { return Port_textbox.Text; }
            set { Port_textbox.Text = value; }
        }

        /**
		 *	Public member variable. Holds the number of current players and defines getter and setter
		 */
        private int NumberOfPlayers = 0;

        /**
		 *	Public member variable. Holds the list of names to alert all players has joing and defines getter and setter
		 */
        private List<string> ToAlert = new List<string>();

        /**
		 *	Public member variable. Decideds whether all players have joined and defines getter and setter
		 */
        private bool JoiningIsDone = false;

        bool AllReady = false;

        private bool isGameStarted = false;

        private bool isServerShutDown = false;
        #endregion

        #region Generated Code
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForm));
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Status_textbox = new System.Windows.Forms.TextBox();
            this.Port_textbox = new System.Windows.Forms.TextBox();
            this.IP_textbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StartServerButton = new System.Windows.Forms.Button();
            this.ShutdownServerButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Perpetua Titling MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Location = new System.Drawing.Point(11, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 43);
            this.label5.TabIndex = 24;
            this.label5.Text = "Server Menu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(238, 286);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 21;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(238, 249);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 22);
            this.label1.TabIndex = 20;
            this.label1.Text = "IP";
            // 
            // Status_textbox
            // 
            this.Status_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Status_textbox.Location = new System.Drawing.Point(302, 325);
            this.Status_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.Status_textbox.Multiline = true;
            this.Status_textbox.Name = "Status_textbox";
            this.Status_textbox.ReadOnly = true;
            this.Status_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_textbox.Size = new System.Drawing.Size(321, 187);
            this.Status_textbox.TabIndex = 18;
            // 
            // Port_textbox
            // 
            this.Port_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Port_textbox.Location = new System.Drawing.Point(302, 289);
            this.Port_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.Port_textbox.Name = "Port_textbox";
            this.Port_textbox.ReadOnly = true;
            this.Port_textbox.Size = new System.Drawing.Size(321, 20);
            this.Port_textbox.TabIndex = 17;
            // 
            // IP_textbox
            // 
            this.IP_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IP_textbox.Location = new System.Drawing.Point(302, 252);
            this.IP_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.IP_textbox.Name = "IP_textbox";
            this.IP_textbox.ReadOnly = true;
            this.IP_textbox.Size = new System.Drawing.Size(321, 20);
            this.IP_textbox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(238, 325);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 22);
            this.label3.TabIndex = 27;
            this.label3.Text = "Status";
            // 
            // StartServerButton
            // 
            this.StartServerButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.StartServerButton.BackColor = System.Drawing.Color.Transparent;
            this.StartServerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.StartServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartServerButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServerButton.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.StartServerButton.Location = new System.Drawing.Point(302, 184);
            this.StartServerButton.Margin = new System.Windows.Forms.Padding(2);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(116, 42);
            this.StartServerButton.TabIndex = 28;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = false;
            this.StartServerButton.Click += new System.EventHandler(this.StartServer_Click);
            this.StartServerButton.MouseEnter += new System.EventHandler(this.StartServerButton_MouseEnter);
            this.StartServerButton.MouseLeave += new System.EventHandler(this.StartServerButton_MouseLeave);
            // 
            // ShutdownServerButton
            // 
            this.ShutdownServerButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ShutdownServerButton.BackColor = System.Drawing.Color.Transparent;
            this.ShutdownServerButton.Enabled = false;
            this.ShutdownServerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ShutdownServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ShutdownServerButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShutdownServerButton.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.ShutdownServerButton.Location = new System.Drawing.Point(507, 184);
            this.ShutdownServerButton.Margin = new System.Windows.Forms.Padding(2);
            this.ShutdownServerButton.Name = "ShutdownServerButton";
            this.ShutdownServerButton.Size = new System.Drawing.Size(116, 42);
            this.ShutdownServerButton.TabIndex = 29;
            this.ShutdownServerButton.Text = "Shutdown";
            this.ShutdownServerButton.UseVisualStyleBackColor = false;
            this.ShutdownServerButton.Click += new System.EventHandler(this.ShutdownServerButton_Click);
            this.ShutdownServerButton.MouseEnter += new System.EventHandler(this.ShutdownServerButton_MouseEnter);
            this.ShutdownServerButton.MouseLeave += new System.EventHandler(this.ShutdownServerButton_MouseLeave);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(665, 284);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(207, 20);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "NULL";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(665, 304);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(207, 20);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "NULL";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.ForeColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(665, 323);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(207, 20);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.Text = "NULL";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.ForeColor = System.Drawing.Color.White;
            this.checkBox4.Location = new System.Drawing.Point(665, 343);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(207, 20);
            this.checkBox4.TabIndex = 33;
            this.checkBox4.Text = "NULL";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.ForeColor = System.Drawing.Color.White;
            this.checkBox5.Location = new System.Drawing.Point(665, 362);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(207, 20);
            this.checkBox5.TabIndex = 34;
            this.checkBox5.Text = "NULL";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(661, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 22);
            this.label4.TabIndex = 35;
            this.label4.Text = "Player List";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(285, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 141);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(898, 531);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ShutdownServerButton);
            this.Controls.Add(this.StartServerButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Status_textbox);
            this.Controls.Add(this.Port_textbox);
            this.Controls.Add(this.IP_textbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(914, 570);
            this.Name = "ServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MainMenuServer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Status_textbox;
        private System.Windows.Forms.TextBox Port_textbox;
        private System.Windows.Forms.TextBox IP_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartServerButton;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private System.Windows.Forms.Button ShutdownServerButton;
        #endregion

        #region AbleOpus Adapted Code
        //The following code in this c# "region" has been adapted from a repo called NetworkingSamples by GitHub user AbleOpus
        //User: https://github.com/AbleOpus
        //Repo: https://github.com/AbleOpus/NetworkingSamples
        //Modified by Kaiser Mittenburg, Team Purple C#bras
        //This is the primary resource we used to learn about socket usage in C#. 

        //License for NetworkingSamples:
        //#An Unconditional Licence
        //
        //Anyone is free to copy, modify, publish, use, compile, sell, or distribute this software, either in source code form or as a compiled binary, 
        //for any purpose, commercial or non-commercial, and by any means.
        //
        //THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
        //FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN 
        //ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

        private Socket Server_Socket;
        private List<Player> Clients = new List<Player>();
        private const int BUFFER_SIZE = 2048;
        private const int PORT = 11203;
        private readonly byte[] Buffer = new byte[BUFFER_SIZE];

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Sets up the server
         */
        private void ServerSetup()
        {
            Server_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Clients = new List<Player>();

            Console.WriteLine("Setting up server...");
            CPrint("Setting up server...");

            //Bind socket
            Server_Socket.Bind(new IPEndPoint(IPAddress.Any, PORT));
            //Tell socket to listen
            Server_Socket.Listen(0);
            //Get async connection request
            Server_Socket.BeginAccept(Accept, null);
            Console.WriteLine("Server setup complete");
            CPrint("Server setup complete");
            Console.WriteLine("Server IP Address: " + GetLocalIPAddress() + "\nPort Number: " + PORT);

            IP = GetLocalIPAddress();
            Port = PORT.ToString();
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Connects client to the server
         */
        private void ServerShutdown()
        {
            foreach (Player player in Clients)
            {
                player.mSocket.Shutdown(SocketShutdown.Both);
                player.mSocket.Close();
            }

            Server_Socket.Close();
            Console.WriteLine("Server successfully shut down");
            CPrint("Server seccessfully shut down");
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Sets socket to accept new connections
         *	@param AR AsyncResult from socket communication
         */
        private void Accept(IAsyncResult AR)
        {
            Socket temp;

            try
            {
                temp = Server_Socket.EndAccept(AR);
            }
            catch (ObjectDisposedException)
            {
                return; //TODO determine what to do here
            }
            //New Player
            NumberOfPlayers++;
            Clients.Add(new Player(temp, NumberOfPlayers));

            //Get Name From Player
            byte[] data = Encoding.ASCII.GetBytes(Messages.SEND_PLAYER_NAME_TO_SERVER.ToString());
            Player player = Clients.Where(x => x.mSocket == temp).FirstOrDefault();
            player.mState = PlayerState.WAITING_FOR_RESPONSE;
            temp.Send(data);

            Thread thread = new Thread(ReceiveLoop);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start(temp);

            //ReceiveLoop(temp);
            //Put Socket in receive state
         
            //temp.BeginReceive(Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, temp);

            Console.WriteLine("Player Connected");
            CPrint("Player connected");
            Console.WriteLine("Beginning accept again");
            Server_Socket.BeginAccept(Accept, null);
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Enters infinite loop that sets socket to listen for communication
         *	@param temp basic object that will be casted to a socket
         */
        private void ReceiveLoop(object temp)
        {
            Console.WriteLine("Got to ReceiveLoop");
            while (!isGameStarted && !isServerShutDown)
            {
                ReceiveResponse((Socket)temp);
            }
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Receives message from clients
         *	@param temp is a player socket
         */
        private void ReceiveResponse(Socket temp)
        {
            Console.WriteLine("Got to ReceiveResponse");
            var buffer = new byte[2048];
            int received = temp.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from client...  " + message); //debugging

            if (message == Messages.SEND_READYUP_TO_SERVER.ToString())
            {
                Console.WriteLine("Ready up player recieved");
                CPrint("Ready up player recieved");
                //Clients.Where(x => x.mSocket == temp).FirstOrDefault().mState = PlayerState.READY; //WRONG
                CatchReadyUpName(temp);
                //TODO
            }
            else if (message == Messages.SEND_PLAYER_NAME_TO_SERVER.ToString()) //Name was sent
            {
                string playerName = CatchPlayerJoinName(temp);
                Console.WriteLine("Player name received: " + playerName);

                ToAlert.Add(playerName);
                var player = Clients.Where(x => x.mSocket == temp).FirstOrDefault();
                player.mName = playerName;
                player.mState = PlayerState.IDLE;
                Console.WriteLine("Adding name to checkbox...");
                //Add player to server form
                switch (NumberOfPlayers)
                {
                    case 1:
                        this.checkBox1.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            Console.WriteLine("1");
                            this.checkBox1.Visible = true;
                            this.checkBox1.Text = playerName;
                            this.checkBox1.Refresh();
                        });
                        break;
                    case 2:
                        this.checkBox2.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox2.Visible = true;
                            this.checkBox2.Text = playerName;
                        });
                        break;
                    case 3:
                        this.checkBox3.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox3.Visible = true;
                            this.checkBox3.Text = playerName;
                        });
                        break;
                    case 4:
                        this.checkBox4.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox4.Visible = true;
                            this.checkBox4.Text = playerName;
                        });
                        break;
                    case 5:
                        this.checkBox5.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox5.Visible = true;
                            this.checkBox5.Text = playerName;
                        });
                        break;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Refresh();
                });
            }
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Alternate method to receive message from clients
         *	@param AR AsyncResult from socket communication
         */
        private void Recieve(IAsyncResult AR)
        {
            Socket temp = (Socket)AR.AsyncState;
            Console.WriteLine("Got to Recieve AR");
            ReceiveLoop(temp); //STAY HERE
            ///////////////////////////////////////////////////////////
            Debugger.Break();
            int recieved;

            try
            {
                recieved = temp.EndReceive(AR);
            }
            catch (SocketException)
            {
                Console.WriteLine("Player Disconnected");//FOR NOW
                CPrint("Player Disconnected");
                temp.Close();
                Clients.RemoveAll(x => x.mSocket == temp);
                return;
            }

            //Handle recieved message
            byte[] Recieved_Buffer = new byte[recieved];
            Array.Copy(Buffer, Recieved_Buffer, recieved);
            string message = Encoding.ASCII.GetString(Recieved_Buffer);

            Console.WriteLine(message); //FOR NOW
            CPrint(message);

            if (message.ToLower() == "get time") // Client requested time
            {
                Console.WriteLine("Text is a get time request");
                byte[] data = Encoding.ASCII.GetBytes(DateTime.Now.ToLongTimeString());
                temp.Send(data);
                Console.WriteLine("Time sent to client");
            }
            else if (message.ToLower() == "exit")
            {
                temp.Shutdown(SocketShutdown.Both);
                temp.Close();
                Clients.RemoveAll(x => x.mSocket == temp);

                //TODO write to server form "console" that a player disconnected
                //TODO handle player disconnect in game driver.
            }
            else if (message == Messages.SEND_READYUP_TO_SERVER.ToString())
            {
                Console.WriteLine("Ready up player recieved");
                CPrint("Ready up player recieved");
                //Clients.Where(x => x.mSocket == temp).FirstOrDefault().mState = PlayerState.READY; //WRONG
                //CatchReadyUpName();
                //TODO
            }
            else if (message == Messages.SEND_PLAYER_NAME_TO_SERVER.ToString()) //Name was sent
            {
                ToAlert.Add(message);
                var player = Clients.Where(x => x.mSocket == temp).FirstOrDefault();
                player.mName = message;
                player.mState = PlayerState.IDLE;

                //Add player to server form
                switch(NumberOfPlayers)
                {
                    case 1:
                        this.checkBox1.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox1.Visible = true;
                            this.checkBox1.Text = message;
                        });
                        break;
                    case 2:
                        this.checkBox2.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox2.Visible = true;
                            this.checkBox2.Text = message;
                        });
                        break;
                    case 3:
                        this.checkBox3.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox3.Visible = true;
                            this.checkBox3.Text = message;
                        });
                        break;
                    case 4:
                        this.checkBox4.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox4.Visible = true;
                            this.checkBox4.Text = message;
                        });
                        break;
                    case 5:
                        this.checkBox5.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox5.Visible = true;
                            this.checkBox5.Text = message;
                        });
                        break;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Refresh();
                });
            }
            //else
            //{
            //    Console.WriteLine("Text is an invalid request");
            //    CPrint(message + "-- Text is an invalid request");
            //    byte[] data = Encoding.ASCII.GetBytes("Invalid request");
            //    temp.Send(data);
            //    Console.WriteLine("Warning Sent");
            //    CPrint("Warning sent");
            //}

            
            
            //TODO send message to communication helper, which will help the game driver progress.
            //temp.BeginReceive(Recieved_Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, temp);
        }

        #endregion

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Handle client sending their name
         *	@param playerSocket is a player socket used for communication
         */
        private string CatchPlayerJoinName(Socket playerSocket)
        {
            var buffer = new byte[2048];
            int received = playerSocket.Receive(buffer, SocketFlags.None);
            //if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Receive player name...  " + message); //debugging

            Clients.Where(x => x.mSocket == playerSocket).FirstOrDefault().mName = message;

            return message;
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Handle client pushing ready button
         *	@param playerSocket is a player socket used for communication
         */
        private void CatchReadyUpName(Socket playerSocket)
        {
            var buffer = new byte[2048];
            int received = playerSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Receive ready-up player name...  " + message); //debugging

            Clients.Where(x => x.mName == message).FirstOrDefault().mState = PlayerState.READY;

            if (checkBox1.Text == message)
            {
                this.checkBox1.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox1.Checked = true;
                    this.Refresh();
                });
            }
            else if (checkBox2.Text == message)
            {
                this.checkBox2.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox2.Checked = true;
                    this.Refresh();
                });
            }
            else if (checkBox3.Text == message)
            {
                this.checkBox3.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox3.Checked = true;
                    this.Refresh();
                });
            }
            else if (checkBox4.Text == message)
            {
                this.checkBox4.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox4.Checked = true;
                    this.Refresh();
                });
            }
            else if (checkBox5.Text == message)
            {
                this.checkBox5.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox5.Checked = true;
                    this.Refresh();
                });
            }

            AlertPlayerReadyUp(message);
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Alert all players that there is a new player and send name
         */
        private void AlertNewPlayer()
        {
            while (!JoiningIsDone && !isServerShutDown)
            {
                if (ToAlert.Count > 0)
                {
                    string names = "";
                    foreach (Player p in Clients.ToList())
                    {
                        names += p.mName + ",";
                    }
                    foreach (Player player in Clients.ToList())
                    {
                        byte[] data = Encoding.ASCII.GetBytes(Messages.ALERT_PLAYER_JOINED.ToString());
                        player.mSocket.Send(data);
                        Console.WriteLine("Sent New Player Alert");
                        System.Threading.Thread.Sleep(250); //wait, then send names
                        Console.WriteLine("spept");
                        data = Encoding.ASCII.GetBytes(names);
                        Console.WriteLine("These are the names that are sent: " + names);//debugging
                        player.mSocket.Send(data);
                        Console.WriteLine("Sent names");


                        ///////////////////////////debug//////////////////////
                        //Pretend to add another player

                        //data = Encoding.ASCII.GetBytes(Messages.ALERT_PLAYER_JOINED.ToString());
                        //player.mSocket.Send(data);
                        //Console.WriteLine("Sent Player Alert");
                        //System.Threading.Thread.Sleep(250); //wait, then send another message
                        //Console.WriteLine("spept");
                        //data = Encoding.ASCII.GetBytes("Brock");
                        //player.mSocket.Send(data);
                        //Console.WriteLine("Sent name");
                    }
                    System.Threading.Thread.Sleep(100);
                    ToAlert.RemoveAt(0);
                    System.Threading.Thread.Sleep(100);
                }
            }
            if (!isServerShutDown)
            {
                Server_Socket.BeginReceive(Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, Server_Socket);
            }
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Alert all players that a player is ready
         *	@param playerName is a string that is the player's name
         */
        private void AlertPlayerReadyUp(string playerName)
        {
            foreach (Player player in Clients)
            {
                byte[] data = Encoding.ASCII.GetBytes(Messages.ALERT_PLAYER_READY_UPPED.ToString());
                player.mSocket.Send(data);
                Console.WriteLine("Sent Player ready up alert");
                System.Threading.Thread.Sleep(250); //wait, then send another message
                Console.WriteLine("spept");
                data = Encoding.ASCII.GetBytes(playerName);
                player.mSocket.Send(data);
                Console.WriteLine("Sent name");
                //player.mSocket.BeginReceive(Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, player.mSocket);//KHM may break here
            }
        }

        /** 
         *  Public static method that takes no arguments and does not return.
         *  Details: Gets the IP address of the current machine
         *  Source: https://stackoverflow.com/questions/6803073/get-local-ip-address 
         *  Was top selected answer submitted by user: Mrchief
         *  Accessed: 10/26/2017
         */
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

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Checks if all players are ready, then starts game.
         */
        private void ReadyUp()
        {
            //bool AllReady = false;
            while (!AllReady && !isServerShutDown)
            {
                AllReady = true;
                if (Clients.Count >= 3)
                {
                    foreach (var player in Clients.ToList())
                    {
                        if (player.mState == PlayerState.READY)
                        {

                        }
                        else
                        {
                            AllReady = false;
                            break; //No need to continue, at least one is not ready
                        }
                    }
                }
                else
                {
                    AllReady = false;
                }

                //Debugging to show that thread is still cycling

                //CPrint(AllReady.ToString());
                //Console.WriteLine(AllReady.ToString());
            }
            
            if (!isServerShutDown)
            {
                isGameStarted = true;
                StartGame();
            }
        }

        private void StartGame()
        {
            //send message to all players
            foreach (Player player in Clients.ToList())
            {
                byte[] data = Encoding.ASCII.GetBytes(Messages.START_GAME.ToString());
                player.mSocket.Send(data);
                Console.WriteLine("Sent start game message");
                
                //player.mSocket.Send(data);
            }
            //TODO start card table logic
            GameDriver driver = new GameDriver(Clients);
            System.Threading.Thread.Sleep(2000);
            driver.Setup();
            System.Threading.Thread.Sleep(2000);
            driver.Run();
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Print parameter to form textbox
         */
        public void CPrint(string s)
        {
            this.Status_textbox.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                this.Status_textbox.AppendText("\r\n" + s);
            });
        }

        private Label label4;
        private PictureBox pictureBox1;
    }
}
