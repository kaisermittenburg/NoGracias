namespace NoGracias
{
    partial class MainMenuForm
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
        public string PlayerName
        {
            get { return PlayerName_textbox.Text; }
            set { PlayerName_textbox.Text = value; }
        }
        public string ConnectedPlayers
        {
            get { return ConnectedPlayers_textbox.Text; }
            set { ConnectedPlayers_textbox.Text = value; }
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(501, 490);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(267, 58);
            this.button1.TabIndex = 14;
            this.button1.Text = "Enter The Game";
            this.button1.UseVisualStyleBackColor = true;
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
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1239, 879);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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

        #region ManipulationMethods
        public void SetIPTextbox(string IP)
        {
            IP_textbox.Text = IP;
        }
        public void SetPortTextbox(string Port)
        {
            Port_textbox.Text = Port;
        }
        public void SetPlayerNameTextbox(string PlayerName)
        {
            PlayerName_textbox.Text = PlayerName;
        }
        public void SetConnectedPlayersTextbox(string ConnectedPlayers)
        {
            ConnectedPlayers_textbox.Text = ConnectedPlayers;
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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
	}
}