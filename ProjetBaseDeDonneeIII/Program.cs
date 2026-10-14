using System;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    internal static class Program
    {
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
                        break;                      // annulé ou 3 échecs : on quitte
                }

                using (FrmMenu frmMenu = new FrmMenu())
                {
                    frmMenu.ShowDialog();
                    continuer = frmMenu.Deconnexion;   // true : retour à la connexion
                }
            }

                         // avant de quitter l'application
        }
    }
}