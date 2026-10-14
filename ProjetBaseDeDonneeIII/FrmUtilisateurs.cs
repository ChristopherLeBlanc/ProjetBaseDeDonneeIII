using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;
using ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmUtilisateurs : Form
    {
        private const int ADMIN_INITIAL = 1;


        private BDB56Projet1CKWDataSet ds = new BDB56Projet1CKWDataSet();
        private UtilisateurTableAdapter taUtilisateur = new UtilisateurTableAdapter();
        private TypeUtilisateurTableAdapter taType = new TypeUtilisateurTableAdapter();

        private BindingSource bsUtilisateur = new BindingSource();
        private BindingSource bsType = new BindingSource();

        private bool modeAjout = false;

        public FrmUtilisateurs()
        {
            InitializeComponent();

            Load += FrmUtilisateurs_Load;
            btnAjouter.Click += btnAjouter_Click;
            btnModifier.Click += btnModifier_Click;
            btnSupprimer.Click += btnSupprimer_Click;
            btnAnnuler.Click += btnAnnuler_Click;
            txtNom.Validating += txtNom_Validating;
            txtMdp.Validating += txtMdp_Validating;
            dgvUtilisateurs.DataError += dgvUtilisateurs_DataError;
        }

        private void FrmUtilisateurs_Load(object sender, EventArgs e)
        {
            try
            {
                taType.Fill(ds.TypeUtilisateur);
                taUtilisateur.Fill(ds.Utilisateur);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            bsUtilisateur.DataSource = ds.Utilisateur;
            bsType.DataSource = ds.TypeUtilisateur;

            dgvUtilisateurs.DataSource = bsUtilisateur;
            foreach (DataGridViewColumn col in dgvUtilisateurs.Columns)
                if (col.DataPropertyName == "MotDePasse") col.Visible = false;

            cboType.DataSource = bsType;
            cboType.DisplayMember = "Identification";
            cboType.ValueMember = "NoTypeUtilisateur";

            txtNo.DataBindings.Clear();
            txtNom.DataBindings.Clear();
            txtMdp.DataBindings.Clear();
            cboType.DataBindings.Clear();

            txtNo.DataBindings.Add("Text", bsUtilisateur, "NoUtilisateur");
            txtNom.DataBindings.Add("Text", bsUtilisateur, "NomUtilisateur");
            txtMdp.DataBindings.Add("Text", bsUtilisateur, "MotDePasse");
            cboType.DataBindings.Add("SelectedValue", bsUtilisateur, "NoTypeUtilisateur");

            bsUtilisateur.CurrentChanged += bsUtilisateur_CurrentChanged;
            MettreAJourEtat();
        }

        private void bsUtilisateur_CurrentChanged(object sender, EventArgs e)
        {
            MettreAJourEtat();
        }

        private void MettreAJourEtat()
        {
            DataRowView vue = bsUtilisateur.Current as DataRowView;
            bool aUneLigne = vue != null;

            btnAjouter.Text = modeAjout ? "Confirmer l'ajout" : "Ajouter";
            btnAjouter.Enabled = true;                       
            btnModifier.Enabled = aUneLigne && !modeAjout;
            btnSupprimer.Enabled = aUneLigne && !modeAjout;
            btnAnnuler.Enabled = modeAjout;
            dgvUtilisateurs.Enabled = !modeAjout;

            txtNom.ReadOnly = !modeAjout;

            bool estMoi = aUneLigne && !modeAjout
                          && vue["NoUtilisateur"] != DBNull.Value
                          && (int)vue["NoUtilisateur"] == Session.NoUtilisateur;
            cboType.Enabled = aUneLigne && !estMoi;
        }


        private void txtNom_Validating(object sender, CancelEventArgs e)
        {

            if (txtNom.Text.Trim() == "")
            {
                e.Cancel = true;           
                MessageBox.Show("Le nom d'utilisateur est obligatoire.", "Champ obligatoire",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtMdp_Validating(object sender, CancelEventArgs e)
        {
            if (bsUtilisateur.Current == null) return;

            if (txtMdp.Text == "")
            {
                e.Cancel = true;
                MessageBox.Show("Le mot de passe est obligatoire.", "Champ obligatoire",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void dgvUtilisateurs_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Donnée invalide dans la grille.", "Erreur de données",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.ThrowException = false;
        }

        private int ProchainNumero()
        {
            int max = 0;
            foreach (BDB56Projet1CKWDataSet.UtilisateurRow l in ds.Utilisateur)
            {
                if (l.RowState == DataRowState.Deleted) continue;
                if (l.NoUtilisateur > max) max = l.NoUtilisateur;
            }
            return max + 1;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!modeAjout) PreparerAjout();
            else ConfirmerAjout();
        }
        private void PreparerAjout()
        {
            if (ds.TypeUtilisateur.Count == 0)
            {
                MessageBox.Show("Aucun type d'utilisateur n'existe dans la base.", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int no = ProchainNumero();
            modeAjout = true;

            DataRowView nouvelle = (DataRowView)bsUtilisateur.AddNew();
            nouvelle["NoUtilisateur"] = no;
            nouvelle["NomUtilisateur"] = "";
            nouvelle["MotDePasse"] = "";
            nouvelle["NoTypeUtilisateur"] = ds.TypeUtilisateur[0].NoTypeUtilisateur;

            MettreAJourEtat();
            txtNom.Focus();
        }

        private void ConfirmerAjout()
        {
            if (!ValidateChildren()) return;

            string nom = txtNom.Text.Trim();
            if (NomExiste(nom))
            {
                MessageBox.Show("Ce nom d'utilisateur existe déjà.", "Doublon",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return;
            }

            bsUtilisateur.EndEdit();

            if (EnregistrerBD())
            {
                modeAjout = false;
                MettreAJourEtat();
                MessageBox.Show("Utilisateur ajouté.", "Succès",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            bsUtilisateur.CancelEdit();   
            modeAjout = false;
            MettreAJourEtat();
        }

       
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (modeAjout || bsUtilisateur.Current == null) return;
            if (!ValidateChildren()) return;

            bsUtilisateur.EndEdit();

            DataRowView vue = (DataRowView)bsUtilisateur.Current;
            if (vue.Row.RowState == DataRowState.Unchanged)
            {
                MessageBox.Show("Aucune modification à enregistrer.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (EnregistrerBD())
                MessageBox.Show("Utilisateur modifié.", "Succès",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool NomExiste(string nom)
        {
            int noCourant = txtNo.Text == "" ? -1 : int.Parse(txtNo.Text);
            foreach (BDB56Projet1CKWDataSet.UtilisateurRow l in ds.Utilisateur)
            {
                if (l.RowState == DataRowState.Deleted) continue;
                if (l.NoUtilisateur != noCourant &&
                    string.Equals(l.NomUtilisateur, nom, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DataRowView vue = bsUtilisateur.Current as DataRowView;
            if (vue == null || modeAjout) return;

            int no = (int)vue["NoUtilisateur"];
            string nom = vue["NomUtilisateur"].ToString();

            if (no == Session.NoUtilisateur)
            {
                MessageBox.Show("Vous ne pouvez pas supprimer votre propre compte.", "Refusé",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (no == ADMIN_INITIAL)
            {
                MessageBox.Show("L'administrateur initial ne peut pas être supprimé.", "Refusé",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Supprimer l'utilisateur « " + nom + " » ?", "Confirmation",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            bsUtilisateur.RemoveCurrent();        // suppression en mémoire
            EnregistrerBD();                      // suppression dans la base de données
            MettreAJourEtat();
        }

        private bool EnregistrerBD()
        {
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    taUtilisateur.Update(ds.Utilisateur);
                    transaction.Complete();       
                }
                return true;
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("Un autre utilisateur a modifié ces données.\n" +
                                "Les données vont être rechargées.", "Conflit d'accès",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Recharger();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la sauvegarde :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ds.Utilisateur.RejectChanges();   
                modeAjout = false;
                MettreAJourEtat();
                return false;
            }
        }

        private void Recharger()
        {
            ds.Utilisateur.Clear();
            taUtilisateur.Fill(ds.Utilisateur);
            modeAjout = false;
            MettreAJourEtat();
        }
    }
}