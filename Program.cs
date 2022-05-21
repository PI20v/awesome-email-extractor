using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Data.Sqlite;

namespace AwesomeEmailExtractor
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            preMain();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            postMain();
        }

        static void preMain()
        {
            if (!Directory.Exists(Globals.getAppDirectory()))
            {
                Directory.CreateDirectory(Globals.getAppDirectory());
            }

            Globals.db = new SqliteConnection("Data Source=" + Globals.getAppDatabase());
            Globals.db.Open();

            Globals.CreateTables();
        }

        static void postMain()
        {
            Globals.db.Close();
        }
    }
}
