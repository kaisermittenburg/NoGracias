using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

            ReceiveLoop(); //Will get here after player name is sent. 
        }

        private void Ready_Up_Button_Click(object sender, EventArgs e)
        {

        }

        private void you_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
