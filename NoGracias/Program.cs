using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoGracias.Server;

namespace NoGracias
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Start Server for debugging
            GameServer DebugServer = new GameServer();

            //Start Main Menu Form
            Application.Run(new CardTableForm());
        }
    }
}
