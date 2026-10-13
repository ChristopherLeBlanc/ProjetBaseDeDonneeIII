using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
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

            using (FrmConnexion frmConnexion = new FrmConnexion())
            {
                if (frmConnexion.ShowDialog() != DialogResult.OK)
                    return; // annulé, erreur de base de données ou 3 échecs : l'application se ferme
            }

            Application.Run(new FrmMenu());
        }
    }
}
