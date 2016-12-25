using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Tanks_2D
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            Controller_MainField cm;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch (arg.Length)
            {
                case 0: cm = new Controller_MainField(); break;
                case 1: cm = new Controller_MainField(Convert.ToInt32(arg[0])); break;
                case 2: cm = new Controller_MainField(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1])); break;
                case 3: cm = new Controller_MainField(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2])); break;
                case 4: cm = new Controller_MainField(Convert.ToInt32(arg[0]), Convert.ToInt32(arg[1]), Convert.ToInt32(arg[2]), Convert.ToInt32(arg[3])); break;
                default: cm = new Controller_MainField(); break;
            }

            Application.Run(cm);
        }
    }
}
