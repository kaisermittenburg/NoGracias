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
	public partial class MainMenuServerForm : Form
	{
		public MainMenuServerForm()
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
            ServerSetup();

            var thread = new Thread(ReadyUp);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

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
            ServerShutdown();
        }
    }
}
