using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Basic_Command
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginForm = new LoginForm();
            
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                SessionManager.Login(
                    loginForm.LoggedInAccountID,
                    loginForm.LoggedInUsername,
                    loginForm.LoggedInDisplayName
                );

                Application.Run(new MainForm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
