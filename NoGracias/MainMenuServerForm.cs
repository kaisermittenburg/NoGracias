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
	public partial class MainMenuServerForm : Form
	{
		public MainMenuServerForm()
		{
			InitializeComponent();
		}

		private void button2_Click(object sender, EventArgs e)
		{

		}

        private void StartServer_Click(object sender, EventArgs e)
        {
            Status_textbox.Clear();
            StartServerButton.Enabled = false;
            ShutdownServerButton.Enabled = true;
            ServerSetup();
            Console.ReadLine(); //Keep on this thread
        }

        private void ShutdownServerButton_Click(object sender, EventArgs e)
        {
            StartServerButton.Enabled = true;
            ShutdownServerButton.Enabled = false;
            ServerShutdown();
        }
    }
}
