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

            bool continuer = true;
            while (continuer)
            {
                using (FrmConnexion frmConnexion = new FrmConnexion())
                {
                    if (frmConnexion.ShowDialog() != DialogResult.OK)
                        return; // annulé ou 3 échecs : on quitte
                }

                using (FrmMenu frmPrincipal = new FrmMenu())
                {
                    frmPrincipal.ShowDialog();
                    continuer = frmPrincipal.Deconnexion; // true : retour à la connexion
                }
            }
        }
    }
}
