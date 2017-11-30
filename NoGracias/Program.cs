/**************************************************************
 * File:  Program.cs
 * 
 * Authors: Andrew Growney, Kaiser Mittenburg, Juzer Zarif          
 * 
 * Description: Main method and entry point for the program
 *                                                            
 * ***********************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoGracias.Server;
using System.Threading;
using System.Net.Sockets;

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

            Socket ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //TestForm test = new TestForm();
            //Application.Run(test);
            MainMenuForm MainMenu = new MainMenuForm(ClientSocket);
            #region Thread Example
            //var thread = new Thread(ThreadStart);
            //thread.TrySetApartmentState(ApartmentState.STA);
            //thread.Start(ServerForm);
            #endregion
            #region WCF Example
            /////////////////////////////////////////////////////////////////////////////////////
            //   Remote Azure WCF Service Concept Prototype.
            //   Sends int, 2, to the service, service returns string, we print string to console

            //ConnectService.ConnectClient service = new ConnectService.ConnectClient();
            //Console.WriteLine(service.GetData(2));
            //Console.WriteLine(service.GetBent());

            //GameDriverService.GameDriverClient service = new GameDriverService.GameDriverClient();
            //Console.WriteLine(service.GetData(2));
            //Console.WriteLine(service.GetBent());
            /////////////////////////////////////////////////////////////////////////////////////
            #endregion

            //Start Server Form
            Application.Run(MainMenu);
            //Kill all threads
            Environment.Exit(0);
        }
    }
}
