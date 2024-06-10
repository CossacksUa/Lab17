using System;
using System.Windows.Forms;

namespace Lab17
{
    static class Program
    {
        /// <summary>
        ///  Головна точка входу для додатка.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
