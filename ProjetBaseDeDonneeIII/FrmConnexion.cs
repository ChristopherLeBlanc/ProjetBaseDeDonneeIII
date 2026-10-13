using System;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmConnexion : Form
    {
        private int nbEssais = 0;
        private const int MAX_ESSAIS = 3;

        public FrmConnexion()
        {
            InitializeComponent();
        }

        private void FrmConnexion_Load(object sender, EventArgs e)
        {
            try
            {
                utilisateurTableAdapter.Fill(bDB56Projet1CKWDataSet.Utilisateur);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données :\n" + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
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

            BDB56Projet1CKWDataSet.UtilisateurRow trouve = null;
            foreach (BDB56Projet1CKWDataSet.UtilisateurRow ligne in bDB56Projet1CKWDataSet.Utilisateur)
            {
                if (ligne.NomUtilisateur == nom && ligne.MotDePasse == mdp)
                {
                    trouve = ligne;
                    break;
                }
            }

            if (trouve == null)
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

            Session.NoUtilisateur = trouve.NoUtilisateur;
            Session.NoType = trouve.NoTypeUtilisateur;
            Session.NomUtilisateur = trouve.NomUtilisateur;

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