﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoGracias
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox5_TextChanged(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            ConnectToServer();

            Connect_Button.Enabled = false;
            Ready_Up_Button.Enabled = true;

            you_checkBox.Visible = true;
            you_checkBox.Text = PlayerName;

            this.Refresh();

            var thread = new Thread(ReceiveLoop);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            //ReceiveLoop(); //Will get here after player name is sent. 
        }

        private void Ready_Up_Button_Click(object sender, EventArgs e)
        {
            you_checkBox.Checked = true;

            var thread = new Thread(ReadyUp);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            //ReadyUp();
        }

        private void you_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MainMenuServerForm myServeMenu = new MainMenuServerForm();
            //myServeMenu.Show();
            this.Close();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
