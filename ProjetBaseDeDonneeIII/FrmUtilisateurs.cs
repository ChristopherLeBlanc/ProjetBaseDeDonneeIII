using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmUtilisateurs : Form
    {
        private const int ADMIN_INITIAL = 1;
        private bool modeAjout = false;
        private bool modeModification = false;

        public FrmUtilisateurs()
        {
            InitializeComponent();
            this.Load -= FrmUtilisateurs_Load;
            this.Load += FrmUtilisateurs_Load;
        }

        private void FrmUtilisateurs_Load(object sender, EventArgs e)
        {
            ChargerTypes();
            this.utilisateurTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Utilisateur);
            txtNo.DataBindings.Clear();
            txtNom.DataBindings.Clear();
            txtMdp.DataBindings.Clear();
            cboType.DataBindings.Clear();
            txtNo.DataBindings.Add("Text", utilisateurBindingSource, "NoUtilisateur", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNom.DataBindings.Add("Text", utilisateurBindingSource, "NomUtilisateur", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMdp.DataBindings.Add("Text", utilisateurBindingSource, "MotDePasse", true, DataSourceUpdateMode.OnPropertyChanged);
            cboType.DataBindings.Add("SelectedValue", utilisateurBindingSource, "NoTypeUtilisateur", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNo.ReadOnly = true;
            txtMdp.TextChanged += txtMdp_TextChanged;
            cboType.SelectionChangeCommitted += cboType_SelectionChangeCommitted;
            utilisateurBindingSource.CurrentChanged += utilisateurBindingSource_CurrentChanged;
            MasquerMotDePasse();
            utilisateurBindingSource.ResetBindings(false);
            MettreAJourControles();
        }

        private void ChargerTypes()
        {
            using (SqlConnection connexion = new SqlConnection(ConnexionBD.Chaine))
            {
                connexion.Open();
                string requete = "SELECT NoTypeUtilisateur, Identification FROM TypeUtilisateur ORDER BY Identification";

                using (SqlDataAdapter adaptateur = new SqlDataAdapter(requete, connexion))
                {
                    DataTable tableTypes = new DataTable();
                    adaptateur.Fill(tableTypes);
                    cboType.DataSource = tableTypes;
                    cboType.DisplayMember = "Identification";
                    cboType.ValueMember = "NoTypeUtilisateur";
                }
            }
        }

        private void MasquerMotDePasse()
        {
            foreach (DataGridViewColumn colonne in dgvUtilisateurs.Columns)
            {
                if (colonne.DataPropertyName == "MotDePasse") colonne.Visible = false;
            }
        }

        private void ChargerUtilisateurs()
        {
            this.utilisateurTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Utilisateur);
            utilisateurBindingSource.ResetBindings(false);
            MasquerMotDePasse();
            modeAjout = false;
            modeModification = false;
            MettreAJourControles();
        }

        private void MettreAJourControles()
        {
            bool estMoi = false;
            DataRowView vue = utilisateurBindingSource.Current as DataRowView;

            if (vue != null && !modeAjout && vue["NoUtilisateur"] != DBNull.Value)
            {
                estMoi = Convert.ToInt32(vue["NoUtilisateur"]) == Session.NoUtilisateur;
            }

            txtNo.ReadOnly = true;
            txtNom.ReadOnly = !modeAjout;
            cboType.Enabled = modeAjout || !estMoi;
        }

        private void utilisateurBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            MettreAJourControles();
        }

        private void txtMdp_TextChanged(object sender, EventArgs e)
        {
            if (!modeAjout && txtMdp.Focused) modeModification = true;
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!modeAjout) modeModification = true;
        }

        private int ObtenirProchainNumero()
        {
            int numeroMax = 0;

            foreach (DataRow ligne in bDB56Projet1CKWDataSet.Utilisateur.Rows)
            {
                if (ligne.RowState != DataRowState.Deleted)
                {
                    int numero = Convert.ToInt32(ligne["NoUtilisateur"]);
                    if (numero > numeroMax) numeroMax = numero;
                }
            }

            return numeroMax + 1;
        }

        private bool NomExiste(string nom)
        {
            using (SqlConnection connexion = new SqlConnection(ConnexionBD.Chaine))
            {
                connexion.Open();
                string requete = "SELECT COUNT(*) FROM Utilisateur WHERE NomUtilisateur = @nom";

                using (SqlCommand commande = new SqlCommand(requete, connexion))
                {
                    commande.Parameters.Add("@nom", SqlDbType.NVarChar).Value = nom;
                    return Convert.ToInt32(commande.ExecuteScalar()) > 0;
                }
            }
        }

        private void utilisateurBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            btnEnregistrer_Click(sender, e);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (modeAjout || modeModification) return;

            modeAjout = true;
            DataRowView nouvelleLigne = (DataRowView)utilisateurBindingSource.AddNew();
            nouvelleLigne["NoUtilisateur"] = ObtenirProchainNumero();
            nouvelleLigne["NomUtilisateur"] = "";
            nouvelleLigne["MotDePasse"] = "";

            if (cboType.Items.Count > 0)
            {
                nouvelleLigne["NoTypeUtilisateur"] = ((DataRowView)cboType.Items[0])["NoTypeUtilisateur"];
            }

            MettreAJourControles();
            txtNom.Focus();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (modeAjout || modeModification)
            {
                MessageBox.Show("Enregistrez ou annulez l'opération en cours.");
                return;
            }

            if (utilisateurBindingSource.Current == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.");
                return;
            }

            DataRowView ligne = (DataRowView)utilisateurBindingSource.Current;
            int numero = Convert.ToInt32(ligne["NoUtilisateur"]);
            string nom = ligne["NomUtilisateur"].ToString();

            if (numero == Session.NoUtilisateur)
            {
                MessageBox.Show("Vous ne pouvez pas supprimer votre propre compte.", "Suppression refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numero == ADMIN_INITIAL)
            {
                MessageBox.Show("L'administrateur initial ne peut pas être supprimé.", "Suppression refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer l'utilisateur « " + nom + " » ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (reponse != DialogResult.Yes) return;

            try
            {
                utilisateurBindingSource.RemoveCurrent();
                this.Validate();
                utilisateurBindingSource.EndEdit();
                this.utilisateurTableAdapter.Update(this.bDB56Projet1CKWDataSet.Utilisateur);
                MessageBox.Show("L'utilisateur a été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChargerUtilisateurs();
            }
        }

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!modeAjout && !modeModification)
            {
                MessageBox.Show("Aucune opération n'est en cours.");
                return;
            }

            if (!ValiderChamps()) return;

            try
            {
                this.Validate();
                utilisateurBindingSource.EndEdit();
                this.utilisateurTableAdapter.Update(this.bDB56Projet1CKWDataSet.Utilisateur);
                modeAjout = false;
                modeModification = false;
                ChargerUtilisateurs();
                MessageBox.Show("Les modifications ont été enregistrées dans la base de données.", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderChamps()
        {
            errMessage.Clear();

            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                errMessage.SetError(txtNom, "Le nom d'utilisateur est obligatoire.");
                txtNom.Focus();
                return false;
            }

            if (modeAjout && NomExiste(txtNom.Text.Trim()))
            {
                errMessage.SetError(txtNom, "Ce nom d'utilisateur existe déjà.");
                txtNom.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMdp.Text))
            {
                errMessage.SetError(txtMdp, "Le mot de passe est obligatoire.");
                txtMdp.Focus();
                return false;
            }

            if (cboType.SelectedValue == null || cboType.SelectedValue is DataRowView)
            {
                errMessage.SetError(cboType, "Le type d'utilisateur est obligatoire.");
                cboType.Focus();
                return false;
            }

            return true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            bDB56Projet1CKWDataSet.Utilisateur.RejectChanges();
            utilisateurBindingSource.CancelEdit();
            utilisateurBindingSource.ResetBindings(false);
            errMessage.Clear();
            modeAjout = false;
            modeModification = false;
            ChargerUtilisateurs();
            MessageBox.Show("Les modifications non enregistrées ont été annulées.", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}