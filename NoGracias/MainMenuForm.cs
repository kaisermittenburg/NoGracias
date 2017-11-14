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
    public partial class MainMenuForm : Form
    {
        public MainMenuForm(Socket aClientSocket)
        {
            InitializeComponent();
            mClientSocket = aClientSocket;
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

        /**
		 *	Private method that takes two arguments of type object and EventArgs and does not return.
		 *	Details: Connects to the server, disables the connect button, enables the ready up button and refreshes the page along with starting new thread.
		 *	@param sender the first argument describes the player entering the game.
         *	@param e the second argument describes the clicking of the button.
		 */
        private void Connect_Button_Click(object sender, EventArgs e)
        {
            ConnectToServer();

            Connect_Button.Enabled = false;
            Ready_Up_Button.Enabled = true;

            you_checkBox.Visible = true;
            YouCheckBox = PlayerName;

            this.Refresh();

            var thread = new Thread(ReceiveLoop);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        /**
		 *	Private method that takes two arguments of type object and EventArgs and does not return.
		 *	Details: Ready's up to the server along with starting new thread.
		 *	@param sender the first argument describes the player being ready for the game.
         *	@param e the second argument describes the clicking of the button.
		 */
        private void Ready_Up_Button_Click(object sender, EventArgs e)
        {
            you_checkBox.Checked = true;

            var thread = new Thread(ReadyUp);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void you_checkBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        /**
		 *	Private method that takes two arguments of type object and EventArgs and does not return.
		 *	Details: Closes out of the main menu and starts the server from the main menu page
		 *	@param sender the first argument describes the player becoming the server/host.
         *	@param e the second argument describes the clicking of the button.
		 */
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
