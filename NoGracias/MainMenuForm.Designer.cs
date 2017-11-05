using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using NoGracias.Communication;

namespace NoGracias
{
    partial class MainMenuForm
    {
        private static int attempts = 0;

        private int NumberOfPlayers = 1;

        public string IP
        {
            get { return IP_textbox.Text; }
            set
            {
                this.IP_textbox.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.IP_textbox.Text = value;
                });
            }
        }
        public string Port
        {
            get { return Port_textbox.Text; }
            set
            {
                this.Port_textbox.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Port_textbox.Text = value;
                });
            }
        }
        public string PlayerName
        {
            get { return PlayerName_textbox.Text; }
            set
            {
                this.PlayerName_textbox.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.PlayerName_textbox.Text = value;
                });
            }
        }
        public string ConnectedPlayers
        {
            get { return ConnectedPlayers_textbox.Text; }
            set
            {
                this.PlayerName_textbox.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.ConnectedPlayers_textbox.AppendText(", " + value);
                });
            }
        }
        public string Status
        {
            get { return Status_Textbox.Text; }
            set
            {
                this.Status_Textbox.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.Status_Textbox.AppendText("\r\n" + value);
                });
            }
        }
        public string YouCheckBox
        {
            get { return you_checkBox.Text; }
            set
            {
                this.you_checkBox.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.you_checkBox.Text = value;
                });
            }
        }
        public string CheckBox2
        {
            get { return checkBox2.Text; }
            set
            {
                this.checkBox2.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox2.Text = value;
                });
            }
        }
        public string CheckBox3
        {
            get { return checkBox3.Text; }
            set
            {
                this.checkBox3.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox3.Text = value;
                });
            }
        }
        public string CheckBox4
        {
            get { return checkBox4.Text; }
            set
            {
                this.checkBox4.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox4.Text = value;
                });
            }
        }
        public string CheckBox5
        {
            get { return checkBox5.Text; }
            set
            {
                this.checkBox5.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox5.Text = value;
                });
            }
        }

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
            this.IP_textbox = new System.Windows.Forms.TextBox();
            this.Port_textbox = new System.Windows.Forms.TextBox();
            this.PlayerName_textbox = new System.Windows.Forms.TextBox();
            this.ConnectedPlayers_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Ready_Up_Button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Connect_Button = new System.Windows.Forms.Button();
            this.Status_Label = new System.Windows.Forms.Label();
            this.Status_Textbox = new System.Windows.Forms.TextBox();
            this.you_checkBox = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // IP_textbox
            // 
            this.IP_textbox.Location = new System.Drawing.Point(417, 226);
            this.IP_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IP_textbox.Name = "IP_textbox";
            this.IP_textbox.Size = new System.Drawing.Size(480, 26);
            this.IP_textbox.TabIndex = 5;
            this.IP_textbox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // Port_textbox
            // 
            this.Port_textbox.Location = new System.Drawing.Point(417, 289);
            this.Port_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Port_textbox.Name = "Port_textbox";
            this.Port_textbox.Size = new System.Drawing.Size(480, 26);
            this.Port_textbox.TabIndex = 6;
            // 
            // PlayerName_textbox
            // 
            this.PlayerName_textbox.Location = new System.Drawing.Point(417, 355);
            this.PlayerName_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PlayerName_textbox.Name = "PlayerName_textbox";
            this.PlayerName_textbox.Size = new System.Drawing.Size(480, 26);
            this.PlayerName_textbox.TabIndex = 7;
            // 
            // ConnectedPlayers_textbox
            // 
            this.ConnectedPlayers_textbox.Location = new System.Drawing.Point(417, 414);
            this.ConnectedPlayers_textbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConnectedPlayers_textbox.Name = "ConnectedPlayers_textbox";
            this.ConnectedPlayers_textbox.Size = new System.Drawing.Size(480, 26);
            this.ConnectedPlayers_textbox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(321, 232);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(321, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(321, 355);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(321, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Players";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(263, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(744, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Welcome";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // Ready_Up_Button
            // 
            this.Ready_Up_Button.Enabled = false;
            this.Ready_Up_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ready_Up_Button.Location = new System.Drawing.Point(715, 785);
            this.Ready_Up_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Ready_Up_Button.Name = "Ready_Up_Button";
            this.Ready_Up_Button.Size = new System.Drawing.Size(182, 58);
            this.Ready_Up_Button.TabIndex = 14;
            this.Ready_Up_Button.Text = "Ready Up";
            this.Ready_Up_Button.UseVisualStyleBackColor = true;
            this.Ready_Up_Button.Click += new System.EventHandler(this.Ready_Up_Button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(28, 32);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 46);
            this.button2.TabIndex = 15;
            this.button2.Text = "Server";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Connect_Button
            // 
            this.Connect_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_Button.Location = new System.Drawing.Point(417, 785);
            this.Connect_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(182, 58);
            this.Connect_Button.TabIndex = 16;
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.UseVisualStyleBackColor = true;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            // 
            // Status_Label
            // 
            this.Status_Label.AutoSize = true;
            this.Status_Label.Location = new System.Drawing.Point(325, 468);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(56, 20);
            this.Status_Label.TabIndex = 17;
            this.Status_Label.Text = "Status";
            // 
            // Status_Textbox
            // 
            this.Status_Textbox.Location = new System.Drawing.Point(417, 468);
            this.Status_Textbox.Multiline = true;
            this.Status_Textbox.Name = "Status_Textbox";
            this.Status_Textbox.ReadOnly = true;
            this.Status_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_Textbox.Size = new System.Drawing.Size(480, 282);
            this.Status_Textbox.TabIndex = 18;
            // 
            // you_checkBox
            // 
            this.you_checkBox.AutoSize = true;
            this.you_checkBox.Location = new System.Drawing.Point(1032, 259);
            this.you_checkBox.Name = "you_checkBox";
            this.you_checkBox.Size = new System.Drawing.Size(76, 24);
            this.you_checkBox.TabIndex = 19;
            this.you_checkBox.Text = "NULL";
            this.you_checkBox.UseVisualStyleBackColor = true;
            this.you_checkBox.Visible = false;
            this.you_checkBox.CheckedChanged += new System.EventHandler(this.you_checkBox_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(1032, 302);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(76, 24);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "NULL";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(1032, 342);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(76, 24);
            this.checkBox3.TabIndex = 21;
            this.checkBox3.Text = "NULL";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(1032, 383);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(76, 24);
            this.checkBox4.TabIndex = 22;
            this.checkBox4.Text = "NULL";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(1032, 418);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(76, 24);
            this.checkBox5.TabIndex = 23;
            this.checkBox5.Text = "NULL";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Visible = false;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 886);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.you_checkBox);
            this.Controls.Add(this.Status_Textbox);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.Connect_Button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Ready_Up_Button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectedPlayers_textbox);
            this.Controls.Add(this.PlayerName_textbox);
            this.Controls.Add(this.Port_textbox);
            this.Controls.Add(this.IP_textbox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainMenuForm";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.TextBox IP_textbox;
		private System.Windows.Forms.TextBox Port_textbox;
		private System.Windows.Forms.TextBox PlayerName_textbox;
		private System.Windows.Forms.TextBox ConnectedPlayers_textbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button Ready_Up_Button;
		private System.Windows.Forms.Button button2;

        #region AbleOpus Adapted Code
        //The following code in this c# "region" has been adapted from a repo called NetworkingSamples by GitHub user AbleOpus
        //User: https://github.com/AbleOpus
        //Repo: https://github.com/AbleOpus/NetworkingSamples
        //Modified by Kaiser Mittenburg, Team Purple C#bras
        //This is the primary resource we used to learn about socket usage in C#. 

        //    License for NetworkingSamples:
        //    #An Unconditional Licence
        //
        //    Anyone is free to copy, modify, publish, use, compile, sell, or distribute this software, either in source code form or as a compiled binary, 
        //    for any purpose, commercial or non-commercial, and by any means.
        //
        //    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
        //    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN 
        //    ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

        private Socket ClientSocket;

            //ConnectToServer();
            //RequestLoop();
            //Exit();
       

        private void ConnectToServer()
        {
            ClientSocket = new Socket
            (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            

            while (!ClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts); //DEBUG
                    Status = "Connection attempt " + attempts;

                    ClientSocket.Connect(IP, int.Parse(Port)); //IPAddress.Loopback, PORT);
                }
                catch (SocketException)
                {
                    Console.Clear();
                }
            }

            ReceiveResponse();

            Console.WriteLine("Connected");
            Status = "Connected";
        }

        private void ReceiveLoop()
        {
            while (true)
            {
                //SendRequest(); //TODO fix this call when kaiser figures out what to do
                ReceiveResponse();
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        private void Exit()
        {
            SendMessage("exit"); // Tell the server we are exiting
            ClientSocket.Shutdown(SocketShutdown.Both);
            ClientSocket.Close();
            Environment.Exit(0);
        }


        /// <summary>
        /// Sends a string to the server with ASCII encoding.
        /// </summary>
        private void SendMessage(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            ClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        private void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server...  " + message); //debugging


            if(message == Messages.SEND_PLAYER_NAME_TO_SERVER.ToString())
            {
                SendMessage(PlayerName);
                Console.WriteLine("Sent Name");
            }
            else if(message == Messages.ALERT_PLAYER_JOINED.ToString())
            {
                ReceivePlayerName();
            }
            else if(message == Messages.ALERT_PLAYER_READY_UPPED.ToString())
            {
                RecievePlayerReadyUp();
            }

            
        }
        private void RecievePlayerReadyUp()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Receive player ready up...  " + message); //debugging

            if(CheckBox2 == message)
            {
                this.checkBox2.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox2.Checked = true;
                });
            }
            else if (CheckBox3 == message)
            {
                this.checkBox3.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox3.Checked = true;
                });
            }
            else if (CheckBox4 == message)
            {
                this.checkBox4.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox4.Checked = true;
                });
            }
            else if (CheckBox5 == message)
            {
                this.checkBox5.Invoke((MethodInvoker)delegate
                {
                    // Running on the UI thread
                    this.checkBox5.Checked = true;
                });
            }
        }
        private void ReceivePlayerName()
        {
            var buffer = new byte[2048];
            int received = ClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Receive player name...  " + message); //debugging
            if (message != PlayerName)
            {
                NumberOfPlayers++;

                switch (NumberOfPlayers)
                {
                    case 2:
                        this.checkBox2.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox2.Visible = true;
                            this.checkBox2.Text = message;
                            this.Refresh();
                        });
                        break;
                    case 3:
                        this.checkBox3.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox3.Visible = true;
                            this.checkBox3.Text = message;
                            this.Refresh();
                        });
                        break;
                    case 4:
                        this.checkBox4.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox4.Visible = true;
                            this.checkBox4.Text = message;
                            this.Refresh();
                        });
                        break;
                    case 5:
                        this.checkBox5.Invoke((MethodInvoker)delegate
                        {
                            // Running on the UI thread
                            this.checkBox5.Visible = true;
                            this.checkBox5.Text = message;
                            this.Refresh();
                        });
                        break;
                }
                
            }
        
        }

        #endregion

        private System.Windows.Forms.Button Connect_Button;
        private Label Status_Label;
        private TextBox Status_Textbox;
        private CheckBox you_checkBox;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;

        private void ReadyUp()
        {
            SendMessage(Messages.SEND_READYUP_TO_SERVER.ToString());
        }
    }
}