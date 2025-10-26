using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Evaluation_Tool_for_ENNA_;
using Testing_final;
using DataModels;
using System.Threading.Tasks;
using Evaluation_Tool_for_ENNA_.GUI_Forms;


namespace Evaluation_Tool_for_ENNA_
{
    class Program
    {


        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Console.WriteLine("Starting up HCP 3 Evaluation Tool");

            try
            {
                Form1 mainWindow = new Form1();

                Application.Run(mainWindow);

            }
            catch (Exception)
            {
                MessageBox.Show("Please connect with VPN to run the Tool!");
            }


        }

    }
}