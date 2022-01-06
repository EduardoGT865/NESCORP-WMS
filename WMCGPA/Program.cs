using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Net4Sage;

namespace WMCP001
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SageSession session;
            if (args.Length == 0)
            {
                session = new SageSession();
                session.ShowLogin(10000001);
            }
            else
                session = new SageSession(args);
            if (session.State == SessionStates.Connected)
            { Application.Run(new GenerarPuertas(ref session)); }
                
        }
    }
}
