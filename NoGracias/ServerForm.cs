using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoGracias
{
	public partial class ServerForm : Form
	{
		public ServerForm()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

        /**
		 *	Private method that takes two arguments of type object and EventArgs and does not return.
		 *	Details: Connects to the server, disables the connect button, enables the ready up button and refreshes the page along with starting new thread.
		 *	@param sender the first argument describes the player entering the game.
         *	@param e the second argument describes the clicking of the button.
		 */
        private void StartServer_Click(object sender, EventArgs e)
        {
            Status_textbox.Clear();
            StartServerButton.Enabled = false;
            ShutdownServerButton.Enabled = true;
            this.Refresh();
            isServerShutDown = false;
            ServerSetup();

            AllReady = false;
            var thread = new Thread(ReadyUp);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            JoiningIsDone = false;
            var thread2 = new Thread(AlertNewPlayer);
            thread2.TrySetApartmentState(ApartmentState.STA);
            thread2.Start();


            Console.ReadLine(); //Keep on this thread
            //Debug.Assert(false); //Don't get here
        }

        /**
		 *	Private method that takes two arguments of type object and EventArgs and does not return.
		 *	Details: Connects to the server, disables the connect button, enables the ready up button and refreshes the page along with starting new thread.
		 *	@param sender the first argument describes the player entering the game.
         *	@param e the second argument describes the clicking of the button.
		 */
        private void ShutdownServerButton_Click(object sender, EventArgs e)
        {
            StartServerButton.Enabled = true;
            ShutdownServerButton.Enabled = false;
            isServerShutDown = true;
            
            AllReady = true;              //I think these are uneeded. isServerShutDown will successfully terminate all loops.
            JoiningIsDone = true;

            SendShutDownNotice();
            ServerShutdown();
            System.Threading.Thread.Sleep(2000);
            Reset();
        }

        private void Reset()
        {
            this.NumberOfPlayers = 0;   
            this.IP_textbox.ResetText();
            this.Port_textbox.Clear();
            this.checkBox1.ResetText();
            this.checkBox2.ResetText();
            this.checkBox3.ResetText();
            this.checkBox4.ResetText();
            this.checkBox5.ResetText();
            this.checkBox1.Checked = false;
            this.checkBox2.Checked = false;
            this.checkBox3.Checked = false;
            this.checkBox4.Checked = false;
            this.checkBox5.Checked = false;
            this.Refresh();
            this.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void StartServerButton_MouseEnter(object sender, EventArgs e)
        {
            this.StartServerButton.BackColor = Color.FromArgb(90, 90, 90);
        }

        private void StartServerButton_MouseLeave(object sender, EventArgs e)
        {
            this.StartServerButton.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void ShutdownServerButton_MouseEnter(object sender, EventArgs e)
        {
            this.ShutdownServerButton.BackColor = Color.FromArgb(90, 90, 90);
        }

        private void ShutdownServerButton_MouseLeave(object sender, EventArgs e)
        {
            this.ShutdownServerButton.BackColor = Color.FromArgb(48, 48, 48);
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
