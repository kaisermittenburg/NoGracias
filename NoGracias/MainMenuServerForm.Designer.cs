using NoGracias.Server;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using NoGracias.Communication;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NoGracias
{
    partial class MainMenuServerForm
    {

        public string IP
        {
            get { return IP_textbox.Text; }
            set { IP_textbox.Text = value; }
        }
        public string Port
        {
            get { return Port_textbox.Text; }
            set { Port_textbox.Text = value; }
        }
        private int NumberOfPlayers = 0;
        private List<string> ToAlert = new List<string>();
        private bool JoiningIsDone = false;

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
            this.button2 = new System.Windows.Forms.Button();
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
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(57, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 37);
            this.button2.TabIndex = 26;
            this.button2.Text = "Player";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.YellowGreen;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(266, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(661, 53);
            this.label5.TabIndex = 24;
            this.label5.Text = "No Gracias Server Menu";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.ForestGreen;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.ForestGreen;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(317, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 23);
            this.label1.TabIndex = 20;
            this.label1.Text = "IP";
            // 
            // Status_textbox
            // 
            this.Status_textbox.Location = new System.Drawing.Point(403, 314);
            this.Status_textbox.Multiline = true;
            this.Status_textbox.Name = "Status_textbox";
            this.Status_textbox.ReadOnly = true;
            this.Status_textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_textbox.Size = new System.Drawing.Size(427, 229);
            this.Status_textbox.TabIndex = 18;
            // 
            // Port_textbox
            // 
            this.Port_textbox.Location = new System.Drawing.Point(403, 274);
            this.Port_textbox.Name = "Port_textbox";
            this.Port_textbox.ReadOnly = true;
            this.Port_textbox.Size = new System.Drawing.Size(427, 22);
            this.Port_textbox.TabIndex = 17;
            // 
            // IP_textbox
            // 
            this.IP_textbox.Location = new System.Drawing.Point(403, 224);
            this.IP_textbox.Name = "IP_textbox";
            this.IP_textbox.ReadOnly = true;
            this.IP_textbox.Size = new System.Drawing.Size(427, 22);
            this.IP_textbox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 23);
            this.label3.TabIndex = 27;
            this.label3.Text = "Status";
            // 
            // StartServerButton
            // 
            this.StartServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartServerButton.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServerButton.Location = new System.Drawing.Point(57, 490);
            this.StartServerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartServerButton.Name = "StartServerButton";
            this.StartServerButton.Size = new System.Drawing.Size(154, 52);
            this.StartServerButton.TabIndex = 28;
            this.StartServerButton.Text = "Start Server";
            this.StartServerButton.UseVisualStyleBackColor = true;
            this.StartServerButton.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // ShutdownServerButton
            // 
            this.ShutdownServerButton.Enabled = false;
            this.ShutdownServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ShutdownServerButton.Font = new System.Drawing.Font("Palatino Linotype", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShutdownServerButton.Location = new System.Drawing.Point(239, 490);
            this.ShutdownServerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ShutdownServerButton.Name = "ShutdownServerButton";
            this.ShutdownServerButton.Size = new System.Drawing.Size(112, 52);
            this.ShutdownServerButton.TabIndex = 29;
            this.ShutdownServerButton.Text = "Shutdown";
            this.ShutdownServerButton.UseVisualStyleBackColor = true;
            this.ShutdownServerButton.Click += new System.EventHandler(this.ShutdownServerButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(884, 314);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 21);
            this.checkBox1.TabIndex = 30;
            this.checkBox1.Text = "NULL";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(884, 338);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(66, 21);
            this.checkBox2.TabIndex = 31;
            this.checkBox2.Text = "NULL";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(884, 362);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 21);
            this.checkBox3.TabIndex = 32;
            this.checkBox3.Text = "NULL";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(884, 386);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 21);
            this.checkBox4.TabIndex = 33;
            this.checkBox4.Text = "NULL";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(884, 410);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(66, 21);
            this.checkBox5.TabIndex = 34;
            this.checkBox5.Text = "NULL";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // MainMenuServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(1198, 566);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ShutdownServerButton);
            this.Controls.Add(this.StartServerButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Status_textbox);
            this.Controls.Add(this.Port_textbox);
            this.Controls.Add(this.IP_textbox);
            this.Name = "MainMenuServerForm";
            this.Text = "MainMenuServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Status_textbox;
        private System.Windows.Forms.TextBox Port_textbox;
        private System.Windows.Forms.TextBox IP_textbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StartServerButton;




        #region ServerCode


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

            //ReceiveLoop(temp);
            //Put Socket in receive state
            temp.BeginReceive(Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, temp);
            
            Console.WriteLine("Player Connected");
            CPrint("Player connected");
            Console.WriteLine("Beginning accept again");
            Server_Socket.BeginAccept(Accept, null);
        }

        private void ReceiveLoop(Socket temp)
        {
            Console.WriteLine("Got to ReceiveLoop");
            while (true)
            {
                ReceiveResponse(temp);
            }
        }

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

        private string CatchPlayerJoinName(Socket playerSocket)
        {
            var buffer = new byte[2048];
            int received = playerSocket.Receive(buffer, SocketFlags.None);
            //if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Receive ready-up player name...  " + message); //debugging

            return message;
        }

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

            if( checkBox1.Text == message)
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

        private void AlertNewPlayer()
        {
            while (!JoiningIsDone)
            {
                if (ToAlert.Count > 0)
                {
                    string name = ToAlert[0];
                    foreach (Player player in Clients)
                    {
                        byte[] data = Encoding.ASCII.GetBytes(Messages.ALERT_PLAYER_JOINED.ToString());
                        player.mSocket.Send(data);
                        Console.WriteLine("Sent Player Alert");
                        System.Threading.Thread.Sleep(250); //wait, then send another message
                        Console.WriteLine("spept");
                        data = Encoding.ASCII.GetBytes(name);
                        player.mSocket.Send(data);
                        Console.WriteLine("Sent name");
                        //player.mSocket.BeginReceive(Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, player.mSocket);//KHM may break here


                        ///////////////////////////debug//////////////////

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
            Server_Socket.BeginReceive(Buffer, 0, BUFFER_SIZE, SocketFlags.None, Recieve, Server_Socket);
        }

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

        /*Method: GetLocalIPAddress() 
         *Source: https://stackoverflow.com/questions/6803073/get-local-ip-address 
          Was top selected answer submitted by user: Mrchief
         *Accessed: 10/26/2017
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

        private System.Windows.Forms.Button ShutdownServerButton;

        #endregion

        private void ReadyUp()
        {
            bool AllReady = false;
            while(!AllReady)
            {
                AllReady = true;
                if (Clients.Count != 0)
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
        }

        //Print to server form "console"
        public void CPrint(string s)
        {
            //Status_textbox.AppendText("\r\n" + s);

            this.Status_textbox.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                this.Status_textbox.AppendText("\r\n" + s);
            });
        }

        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
    }
}
