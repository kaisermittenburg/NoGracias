using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Common;
using System.Collections.Generic;
using System.Diagnostics;

namespace NoGracias
{
    partial class MainMenuForm
    {
        #region Variables
        private List<string> players = new List<string>();

        private static int attempts = 0;

        private bool isCardTableLaunched = false;

        /**
		 *	Public member variable. Holds the IP address of the server and defines getter and setter
		 */
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
        /**
		 *	Public member variable. Holds the Port address of the server and defines getter and setter
		 */
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
        /**
		 *	Public member variable. Holds the string of the player and defines getter and setter
		 */
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
        /**
		 *	Public member variable. Holds the status of the player and defines getter and setter
		 */
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
        /**
		 *	Public member variable. Holds the string of the player's checkbox and defines getter and setter
		 */
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
        /**
		 *	Public member variable. Holds the second checkbox status in a string and defines getter and setter
		 */
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
        /**
        *	Public member variable. Holds the third checkbox status in a string and defines getter and setter
        */
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
        /**
		 *	Public member variable. Holds the fourth checkbox status in a string and defines getter and setter
		 */
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
        /**
		 *	Public member variable. Holds the fifth checkbox status in a string and defines getter and setter
		 */
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

        #endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            this.IP_textbox = new System.Windows.Forms.TextBox();
            this.Port_textbox = new System.Windows.Forms.TextBox();
            this.PlayerName_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.CreditsPanel = new System.Windows.Forms.Panel();
            this.HomeButton1 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.CreditsButton = new System.Windows.Forms.Button();
            this.JoinGameButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.CreditsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // IP_textbox
            // 
            this.IP_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.IP_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IP_textbox.Location = new System.Drawing.Point(297, 184);
            this.IP_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.IP_textbox.Name = "IP_textbox";
            this.IP_textbox.Size = new System.Drawing.Size(342, 20);
            this.IP_textbox.TabIndex = 5;
            this.IP_textbox.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // Port_textbox
            // 
            this.Port_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Port_textbox.Location = new System.Drawing.Point(297, 224);
            this.Port_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.Port_textbox.Name = "Port_textbox";
            this.Port_textbox.Size = new System.Drawing.Size(342, 20);
            this.Port_textbox.TabIndex = 6;
            // 
            // PlayerName_textbox
            // 
            this.PlayerName_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayerName_textbox.Location = new System.Drawing.Point(297, 266);
            this.PlayerName_textbox.Margin = new System.Windows.Forms.Padding(2);
            this.PlayerName_textbox.Name = "PlayerName_textbox";
            this.PlayerName_textbox.Size = new System.Drawing.Size(342, 20);
            this.PlayerName_textbox.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(228, 188);
            this.label1.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label2.Location = new System.Drawing.Point(228, 224);
            this.label2.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label3.Location = new System.Drawing.Point(228, 266);
            this.label3.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label4.Location = new System.Drawing.Point(690, 307);
            this.label4.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "Players";
            // 
            // Ready_Up_Button
            // 
            this.Ready_Up_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Ready_Up_Button.AutoSize = true;
            this.Ready_Up_Button.BackColor = System.Drawing.Color.Transparent;
            this.Ready_Up_Button.Enabled = false;
            this.Ready_Up_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Ready_Up_Button.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Ready_Up_Button.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.Ready_Up_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ready_Up_Button.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ready_Up_Button.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Ready_Up_Button.Location = new System.Drawing.Point(509, 511);
            this.Ready_Up_Button.Margin = new System.Windows.Forms.Padding(2, 24, 2, 24);
            this.Ready_Up_Button.MinimumSize = new System.Drawing.Size(130, 37);
            this.Ready_Up_Button.Name = "Ready_Up_Button";
            this.Ready_Up_Button.Size = new System.Drawing.Size(130, 37);
            this.Ready_Up_Button.TabIndex = 14;
            this.Ready_Up_Button.Text = "Ready Up";
            this.Ready_Up_Button.UseVisualStyleBackColor = false;
            this.Ready_Up_Button.Click += new System.EventHandler(this.Ready_Up_Button_Click);
            this.Ready_Up_Button.MouseEnter += new System.EventHandler(this.Ready_Up_Button_MouseEnter);
            this.Ready_Up_Button.MouseLeave += new System.EventHandler(this.Ready_Up_Button_MouseLeave);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::NoGracias.Properties.Resources.server2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Berlin Sans FB Demi", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(38, 261);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(288, 311);
            this.button2.TabIndex = 15;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Connect_Button
            // 
            this.Connect_Button.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Connect_Button.AutoSize = true;
            this.Connect_Button.BackColor = System.Drawing.Color.Transparent;
            this.Connect_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Connect_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Connect_Button.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_Button.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Connect_Button.Location = new System.Drawing.Point(297, 511);
            this.Connect_Button.Margin = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.Connect_Button.MinimumSize = new System.Drawing.Size(130, 37);
            this.Connect_Button.Name = "Connect_Button";
            this.Connect_Button.Size = new System.Drawing.Size(130, 37);
            this.Connect_Button.TabIndex = 16;
            this.Connect_Button.Text = "Connect";
            this.Connect_Button.UseVisualStyleBackColor = false;
            this.Connect_Button.Click += new System.EventHandler(this.Connect_Button_Click);
            this.Connect_Button.MouseEnter += new System.EventHandler(this.Connect_Button_MouseEnter);
            this.Connect_Button.MouseLeave += new System.EventHandler(this.Connect_Button_MouseLeave);
            // 
            // Status_Label
            // 
            this.Status_Label.AutoSize = true;
            this.Status_Label.BackColor = System.Drawing.Color.Transparent;
            this.Status_Label.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_Label.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.Status_Label.Location = new System.Drawing.Point(231, 307);
            this.Status_Label.Margin = new System.Windows.Forms.Padding(24, 0, 24, 0);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(57, 22);
            this.Status_Label.TabIndex = 17;
            this.Status_Label.Text = "Status";
            // 
            // Status_Textbox
            // 
            this.Status_Textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Status_Textbox.Location = new System.Drawing.Point(297, 307);
            this.Status_Textbox.Margin = new System.Windows.Forms.Padding(2);
            this.Status_Textbox.Multiline = true;
            this.Status_Textbox.Name = "Status_Textbox";
            this.Status_Textbox.ReadOnly = true;
            this.Status_Textbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Status_Textbox.Size = new System.Drawing.Size(342, 182);
            this.Status_Textbox.TabIndex = 18;
            // 
            // you_checkBox
            // 
            this.you_checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.you_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.you_checkBox.ForeColor = System.Drawing.Color.White;
            this.you_checkBox.Location = new System.Drawing.Point(693, 335);
            this.you_checkBox.Margin = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.you_checkBox.Name = "you_checkBox";
            this.you_checkBox.Size = new System.Drawing.Size(247, 20);
            this.you_checkBox.TabIndex = 19;
            this.you_checkBox.Text = "NULL";
            this.you_checkBox.UseVisualStyleBackColor = true;
            this.you_checkBox.Visible = false;
            this.you_checkBox.CheckedChanged += new System.EventHandler(this.you_checkBox_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(693, 353);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(247, 20);
            this.checkBox2.TabIndex = 20;
            this.checkBox2.Text = "NULL";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.ForeColor = System.Drawing.Color.White;
            this.checkBox3.Location = new System.Drawing.Point(693, 371);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(247, 20);
            this.checkBox3.TabIndex = 21;
            this.checkBox3.Text = "NULL";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // checkBox4
            // 
            this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox4.ForeColor = System.Drawing.Color.White;
            this.checkBox4.Location = new System.Drawing.Point(693, 389);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(247, 20);
            this.checkBox4.TabIndex = 22;
            this.checkBox4.Text = "NULL";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.Visible = false;
            // 
            // checkBox5
            // 
            this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox5.ForeColor = System.Drawing.Color.White;
            this.checkBox5.Location = new System.Drawing.Point(693, 407);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(24, 2, 24, 2);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(247, 20);
            this.checkBox5.TabIndex = 23;
            this.checkBox5.Text = "NULL";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(291, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(352, 141);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.CreditsPanel);
            this.MainPanel.Controls.Add(this.pictureBox2);
            this.MainPanel.Controls.Add(this.button2);
            this.MainPanel.Controls.Add(this.CreditsButton);
            this.MainPanel.Controls.Add(this.JoinGameButton);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(985, 617);
            this.MainPanel.TabIndex = 38;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // CreditsPanel
            // 
            this.CreditsPanel.Controls.Add(this.HomeButton1);
            this.CreditsPanel.Controls.Add(this.pictureBox3);
            this.CreditsPanel.Controls.Add(this.label5);
            this.CreditsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreditsPanel.Location = new System.Drawing.Point(0, 0);
            this.CreditsPanel.MinimumSize = new System.Drawing.Size(985, 617);
            this.CreditsPanel.Name = "CreditsPanel";
            this.CreditsPanel.Size = new System.Drawing.Size(985, 617);
            this.CreditsPanel.TabIndex = 41;
            this.CreditsPanel.Visible = false;
            // 
            // HomeButton1
            // 
            this.HomeButton1.BackgroundImage = global::NoGracias.Properties.Resources.home;
            this.HomeButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HomeButton1.FlatAppearance.BorderSize = 0;
            this.HomeButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton1.Location = new System.Drawing.Point(16, 14);
            this.HomeButton1.Name = "HomeButton1";
            this.HomeButton1.Padding = new System.Windows.Forms.Padding(5);
            this.HomeButton1.Size = new System.Drawing.Size(60, 48);
            this.HomeButton1.TabIndex = 42;
            this.HomeButton1.UseVisualStyleBackColor = true;
            this.HomeButton1.Click += new System.EventHandler(this.HomeButton1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox3.BackgroundImage = global::NoGracias.Properties.Resources.Title;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(235, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(470, 192);
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label5.Location = new System.Drawing.Point(38, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(906, 306);
            this.label5.TabIndex = 0;
            this.label5.Text = "Royalty free music from Bensound";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(235, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(470, 192);
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // CreditsButton
            // 
            this.CreditsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CreditsButton.BackgroundImage = global::NoGracias.Properties.Resources.credits;
            this.CreditsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CreditsButton.FlatAppearance.BorderSize = 0;
            this.CreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreditsButton.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditsButton.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.CreditsButton.Location = new System.Drawing.Point(648, 261);
            this.CreditsButton.Name = "CreditsButton";
            this.CreditsButton.Size = new System.Drawing.Size(288, 311);
            this.CreditsButton.TabIndex = 40;
            this.CreditsButton.UseVisualStyleBackColor = true;
            this.CreditsButton.Click += new System.EventHandler(this.CreditsButton_Click);
            // 
            // JoinGameButton
            // 
            this.JoinGameButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.JoinGameButton.BackgroundImage = global::NoGracias.Properties.Resources.join;
            this.JoinGameButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.JoinGameButton.FlatAppearance.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.JoinGameButton.FlatAppearance.BorderSize = 0;
            this.JoinGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinGameButton.Font = new System.Drawing.Font("Berlin Sans FB Demi", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinGameButton.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.JoinGameButton.Location = new System.Drawing.Point(343, 261);
            this.JoinGameButton.Name = "JoinGameButton";
            this.JoinGameButton.Size = new System.Drawing.Size(288, 311);
            this.JoinGameButton.TabIndex = 39;
            this.JoinGameButton.UseVisualStyleBackColor = true;
            this.JoinGameButton.Click += new System.EventHandler(this.JoinGameButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackgroundImage = global::NoGracias.Properties.Resources.home;
            this.HomeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Location = new System.Drawing.Point(12, 12);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Padding = new System.Windows.Forms.Padding(5);
            this.HomeButton.Size = new System.Drawing.Size(60, 48);
            this.HomeButton.TabIndex = 41;
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // MainMenuForm
            // 
            this.AcceptButton = this.Connect_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(985, 617);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.you_checkBox);
            this.Controls.Add(this.Status_Textbox);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.Connect_Button);
            this.Controls.Add(this.Ready_Up_Button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayerName_textbox);
            this.Controls.Add(this.Port_textbox);
            this.Controls.Add(this.IP_textbox);
            this.Controls.Add(this.HomeButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "No Gracias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.CreditsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IP_textbox;
		private System.Windows.Forms.TextBox Port_textbox;
		private System.Windows.Forms.TextBox PlayerName_textbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button Ready_Up_Button;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Connect_Button;
        private Label Status_Label;
        private TextBox Status_Textbox;
        private CheckBox you_checkBox;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;

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

        private Socket mClientSocket;

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Connects client to the server
         */
        private void ConnectToServer()
        {
            /*players.Add(PlayerName);
            while (!mClientSocket.Connected)
            {
                try
                {
                    attempts++;
                    Console.WriteLine("Connection attempt " + attempts); //DEBUG
                    Status = "Connection attempt " + attempts;

                    mClientSocket.Connect(IP, int.Parse(Port)); //IPAddress.Loopback, PORT);
                }
                catch (SocketException)
                {
                    //Console.Clear();
                    CustomMessageBox.ShowBox("INVALID CONNECTION PARAMETERS");
                    throw new System.ArgumentException();
                    //break;
                }
                catch (FormatException)
                {
                    CustomMessageBox.ShowBox("INVALID CONNECTION PARAMETERS");
                    throw new System.ArgumentException();
                    //break;
                }
            }*/

            Console.WriteLine("Connection attempt...");
            Status = "Connection attempt...";
            try
            {
                IAsyncResult result = mClientSocket.BeginConnect(IP, int.Parse(Port), null, null);
                bool successConnect = result.AsyncWaitHandle.WaitOne(5000, true);

                if (mClientSocket.Connected)
                {
                    Console.WriteLine("Connected");
                    Status = "Connected";
                    this.HomeButton.Visible = false;
                    mClientSocket.EndConnect(result);
                    players.Add(PlayerName);
                    ReceiveResponse();
                }
                else
                {
                    //mClientSocket.Disconnect(true);
                    CustomMessageBox.ShowBox("CONNECTION FAILED\nINVALID CONNECTION PARAMETERS");
                    throw new System.Exception();
                }
            }
            catch(SocketException)
            {
                CustomMessageBox.ShowBox("CONNECTION ERROR" + "\nSOCKET EXCEPTION");
                throw new System.Exception();
            }
            catch(FormatException)
            {
                CustomMessageBox.ShowBox("CONNECTION FAILED" + "\nINVALID PORT");
                throw new System.Exception();
            }
                     

            //Console.WriteLine("Connected");
            //Status = "Connected";
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Enters an infinite loop to listen for communication from the server
         */
        private void ReceiveLoop()
        {
            while (!isCardTableLaunched)
            {
                ReceiveResponse();
            }
        }

        /// <summary>
        /// Close socket and exit program.
        /// </summary>
        /**
		 *	Public method that takes no arguments and does not return.
		 *	Details: Sends exit message and shutsdown client socket.
         */
        private void Exit()
        {
            SendMessage("exit"); // Tell the server we are exiting
            mClientSocket.Shutdown(SocketShutdown.Both);
            mClientSocket.Close();
            Environment.Exit(0);
        }


        /// <summary>
        ///  Sends a string to the server with ASCII encoding
        /// </summary>
        /**
		 *	Public method that takes one argument of type string and does not return.
		 *	Details: Sends a string to the server with ASCII encoding.
		 *	@param text the first argument.

         */
        private void SendMessage(string text)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(text);
            mClientSocket.Send(buffer, 0, buffer.Length, SocketFlags.None);
        }

        /**
		 *	Public method that takes no arguments and does not return.
		 *	Details: Creates buffer to recieve from the client socket in order to send a message to the console and act upon the response.
         */
        private void ReceiveResponse()
        {
            var buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Message from server...  " + message); //debugging


            if(message == Messages.SEND_PLAYER_NAME_TO_SERVER.ToString())
            {
                SendMessage(Messages.SEND_PLAYER_NAME_TO_SERVER.ToString());
                System.Threading.Thread.Sleep(1000);

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
            else if(message == Messages.START_GAME.ToString())
            {
                StartGame(mClientSocket);
            }
        }

        /**
		 *	Public method that takes no arguments and does not return.
		 *	Details: Creates buffer to recieve from the client socket in order to send a message to the console and act upon the response.
         */

        #endregion

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Gets player name who has ready-upped and checks checkbox
         */
        private void RecievePlayerReadyUp()
        {
            var buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Receive player ready up...  " + message); //debugging

            if (CheckBox2 == message)
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


        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Gets player name from newly joined players
         */
        private void ReceivePlayerName()
        {
            var buffer = new byte[2048];
            int received = mClientSocket.Receive(buffer, SocketFlags.None);
            if (received == 0) return;
            var data = new byte[received];
            Array.Copy(buffer, data, received);
            string message = Encoding.ASCII.GetString(data);
            Console.WriteLine("Receive all player names...  " + message); //debugging

            ////////////////PARSE NAMES/////////////////////
            message = message.TrimEnd(' ');
            message = message.TrimEnd(',');
            Console.WriteLine(message);
            string[] names = message.Split(',');



            ////////////////////////////////////////////////
            int checkboxNum = 2;
            foreach (string s in names)
            {
                Console.WriteLine(s);//debugging 
                if (s != PlayerName)
                {
                    if(!players.Contains(s))
                    {
                        players.Add(s);

                    }
                    switch (checkboxNum)
                    {
                        case 2:
                            this.checkBox2.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread
                                this.checkBox2.Visible = true;
                                this.checkBox2.Text = s;
                                this.Refresh();
                            });
                            break;
                        case 3:
                            this.checkBox3.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread
                                this.checkBox3.Visible = true;
                                this.checkBox3.Text = s;
                                this.Refresh();
                            });
                            break;
                        case 4:
                            this.checkBox4.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread
                                this.checkBox4.Visible = true;
                                this.checkBox4.Text = s;
                                this.Refresh();
                            });
                            break;
                        case 5:
                            this.checkBox5.Invoke((MethodInvoker)delegate
                            {
                                // Running on the UI thread
                                this.checkBox5.Visible = true;
                                this.checkBox5.Text = s;
                                this.Refresh();
                            });
                            break;
                    }
                    checkboxNum++;
                }
            }
        }

        /**
		 *	Private method that takes no arguments and does not return.
		 *	Details: Tells server you are ready to play
         */
        private void ReadyUp()
        {
            SendMessage(Messages.SEND_READYUP_TO_SERVER.ToString());
            System.Threading.Thread.Sleep(200);
            SendMessage(PlayerName);
        }

        /**
		 *	Private method that takes one argument of type socket and does not return.
		 *	Details: Starts the game by sending the client socket and starting a new form
		 *	@param client socket, the first and only parameter
         */
        private void StartGame(Socket aClientSocket)
        {
            this.Invoke((MethodInvoker)delegate
            {
                // Running on the UI thread
                this.Hide();
                var TableForm = new CardTableForm(mClientSocket);
                TableForm.Closed += (s, args) => this.Reset();
                TableForm.Show();
                isCardTableLaunched = true;
                /*TableForm.PlayerName = PlayerName;
                
                for(int i = 0; i < players.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            break;
                        case 1:
                            TableForm.Opp1PlayerName = players[i];
                            break;
                        case 2:
                            TableForm.Opp2PlayerName = players[i];
                            break;
                        case 3:
                            TableForm.Opp3PlayerName = players[i];
                            TableForm.Opp3ChipGraphic = true;
                            TableForm.Opp3ChipLabel = true;
                            TableForm.Opp3ChipNumberVisible = true;
                            TableForm.Opp3ChipNumber = "11";
                            break;
                        case 4:
                            TableForm.Opp4PlayerName = players[i];
                            TableForm.Opp4ChipGraphic = true;
                            TableForm.Opp4ChipLabel = true;
                            TableForm.Opp4ChipNumberVisible = true;
                            TableForm.Opp4ChipNumber = "11";
                            break;
                    }
                }
                TableForm.Refresh();*/
            });
        }

        private PictureBox pictureBox1;
        private Panel MainPanel;
        private Button JoinGameButton;
        private PictureBox pictureBox2;
        private Button CreditsButton;
        private Button HomeButton;
        private Panel CreditsPanel;
        private Label label5;
        private PictureBox pictureBox3;
        private Button HomeButton1;
    }
}