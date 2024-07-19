using System;
using System.Windows.Forms;
using AADL.Companies.CompanyAims;
namespace AADL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCompaniesAimsList());
        }
    }
}
