using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoGracias.Server;
using System.Threading;

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


            MainMenuForm MainMenu = new MainMenuForm();
            MainMenuServerForm ServerForm = new MainMenuServerForm();
            CardTableForm Table = new CardTableForm();

            //Start Main Menu Form

            //Application.Run(MainMenu);


            

            //var thread = new Thread(ThreadStart);
            //thread.TrySetApartmentState(ApartmentState.STA);
            //thread.Start(ServerForm);


            //Start Server Form
            Application.Run(MainMenu);


            
           
        }
        private static void ThreadStart(Object form)
        {
            MainMenuServerForm form1 = (MainMenuServerForm)form;
            //Application.Run(new frmTwo()); // <-- other form started on its own UI thread
            GameServer Server = new GameServer(form1);
        }
    }
}
