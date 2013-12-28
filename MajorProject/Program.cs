using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MajorProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Calculator calc = new Calculator();
            if (args.Length == 1)
            {
               calc.OpenFile(args[0]);
            } 

            Application.Run(calc);

        }
    }
}
