using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmConnexion : Form
    {
        string maChaineDeConnexion = ConnexionBD.Chaine;
        SqlConnection maConnexion = new SqlConnection();

        private int nbEssais = 0;
        private const int MAX_ESSAIS = 3;

        public FrmConnexion()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text.Trim();
            string mdp = txtMdp.Text;

            if (nom == "" || mdp == "")
            {
                MessageBox.Show("Veuillez entrer votre nom d'utilisateur et votre mot de passe.",
                                "Champs obligatoires", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            object noUtilisateur = null;
            object noType = null;

            try
            {
                maConnexion.ConnectionString = maChaineDeConnexion;
                maConnexion.Open();

                // 1re requête : le numéro de l'utilisateur
                String maRequeteSQL = "SELECT NoUtilisateur FROM Utilisateur " +
                                      "WHERE NomUtilisateur = @nom AND MotDePasse = @mdp";
                SqlCommand maCommande = new SqlCommand(maRequeteSQL, maConnexion);

                SqlParameter parametreNom = new SqlParameter("@nom", SqlDbType.VarChar, 30);
                maCommande.Parameters.Add(parametreNom);
                parametreNom.Value = nom;

                SqlParameter parametreMdp = new SqlParameter("@mdp", SqlDbType.VarChar, 100);
                maCommande.Parameters.Add(parametreMdp);
                parametreMdp.Value = mdp;

                noUtilisateur = maCommande.ExecuteScalar();

                // 2e requête : le type de l'utilisateur (seulement s'il existe)
                if (noUtilisateur != null)
                {
                    String requeteType = "SELECT NoTypeUtilisateur FROM Utilisateur WHERE NoUtilisateur = @no";
                    SqlCommand commandeType = new SqlCommand(requeteType, maConnexion);
                    commandeType.Parameters.AddWithValue("@no", noUtilisateur);
                    noType = commandeType.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données :\n" + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;   // une erreur de base de données n'est pas un essai raté
            }
            finally
            {
                maConnexion.Close();   // IMPORTANT DE FERMER LA CONNEXION
            }

            if (noUtilisateur == null)
            {
                nbEssais++;
                if (nbEssais >= MAX_ESSAIS)
                {
                    MessageBox.Show("Trop d'échecs. L'application va se fermer.",
                                    "Accès refusé", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.\nEssai " + nbEssais + " sur " + MAX_ESSAIS + ".",
                                "Échec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMdp.Clear();
                txtMdp.Focus();
                return;
            }

            Session.NoUtilisateur = Convert.ToInt32(noUtilisateur);
            Session.NoType = Convert.ToInt32(noType);
            Session.NomUtilisateur = nom;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}