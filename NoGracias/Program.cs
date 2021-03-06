﻿using System;
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
            //Setup
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainMenuForm MainMenu = new MainMenuForm();
            MainMenuServerForm ServerForm = new MainMenuServerForm();
            CardTableForm Table = new CardTableForm();

            #region Thread Example
            //var thread = new Thread(ThreadStart);
            //thread.TrySetApartmentState(ApartmentState.STA);
            //thread.Start(ServerForm);
            #endregion

            //Start Server Form
            Application.Run(MainMenu);
           
            Application.Run(ServerForm);
        }
    }
}
