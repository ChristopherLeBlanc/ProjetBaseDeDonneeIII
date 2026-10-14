using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmUtilisateurs : Form
    {
        private const int ADMIN_INITIAL = 1;

        // Modèle en mémoire (mode déconnecté)
        private DataSet ds = new DataSet();

        private bool modeAjout = false;

        public FrmUtilisateurs()
        {
            InitializeComponent();

            Load += FrmUtilisateurs_Load;
            btnAjouter.Click += btnAjouter_Click;
            btnModifier.Click += btnModifier_Click;
            btnSupprimer.Click += btnSupprimer_Click;
            btnAnnuler.Click += btnAnnuler_Click;
            dgvUtilisateurs.SelectionChanged += dgvUtilisateurs_SelectionChanged;
        }

        // =====================================================
        //  Chargement (mode déconnecté : DataAdapter + Fill)
        // =====================================================
        private void FrmUtilisateurs_Load(object sender, EventArgs e)
        {
            txtNo.DataBindings.Clear();
            txtNom.DataBindings.Clear();
            txtMdp.DataBindings.Clear();
            cboType.DataBindings.Clear();

            try
            {
                ChargerTypes();
                ChargerUtilisateurs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            AfficherSelection();
        }

        private void ChargerTypes()
        {
            string requete = "SELECT NoTypeUtilisateur, Identification FROM TypeUtilisateur";
            SqlDataAdapter da = new SqlDataAdapter(requete, new SqlConnection(ConnexionBD.Chaine));

            if (ds.Tables.Contains("typeUtilisateur"))
                ds.Tables.Remove("typeUtilisateur");
            da.Fill(ds, "typeUtilisateur");

            cboType.DataSource = ds.Tables["typeUtilisateur"];
            cboType.DisplayMember = "Identification";
            cboType.ValueMember = "NoTypeUtilisateur";
        }

        private void ChargerUtilisateurs()
        {
            string requete = "SELECT NoUtilisateur, NomUtilisateur, MotDePasse, NoTypeUtilisateur " +
                             "FROM Utilisateur ORDER BY NoUtilisateur";
            SqlDataAdapter da = new SqlDataAdapter(requete, new SqlConnection(ConnexionBD.Chaine));

            dgvUtilisateurs.DataSource = null;
            if (ds.Tables.Contains("utilisateur"))
                ds.Tables.Remove("utilisateur");
            da.Fill(ds, "utilisateur");

            dgvUtilisateurs.DataSource = ds.Tables["utilisateur"];
            if (dgvUtilisateurs.Columns["MotDePasse"] != null)
                dgvUtilisateurs.Columns["MotDePasse"].Visible = false;   // on n'affiche pas les mots de passe
        }

        // =====================================================
        //  Affichage de la ligne sélectionnée
        // =====================================================
        private void dgvUtilisateurs_SelectionChanged(object sender, EventArgs e)
        {
            if (!modeAjout) AfficherSelection();
        }

        private DataRow LigneSelectionnee()
        {
            if (dgvUtilisateurs.CurrentRow == null) return null;
            DataRowView vue = dgvUtilisateurs.CurrentRow.DataBoundItem as DataRowView;
            return vue == null ? null : vue.Row;
        }

        private void AfficherSelection()
        {
            DataRow ligne = LigneSelectionnee();
            if (ligne == null)
            {
                txtNo.Clear(); txtNom.Clear(); txtMdp.Clear();
                btnModifier.Enabled = false;
                btnSupprimer.Enabled = false;
                cboType.Enabled = false;
                MettreAJourEtat();
                return;
            }

            txtNo.Text = ligne["NoUtilisateur"].ToString();
            txtNom.Text = ligne["NomUtilisateur"].ToString();
            txtMdp.Text = ligne["MotDePasse"].ToString();
            cboType.SelectedValue = ligne["NoTypeUtilisateur"];

            MettreAJourEtat();
        }

        private void MettreAJourEtat()
        {
            DataRow ligne = LigneSelectionnee();
            bool aUneLigne = ligne != null;

            btnAjouter.Text = modeAjout ? "Confirmer l'ajout" : "Ajouter";
            btnAjouter.Enabled = true;
            btnModifier.Enabled = aUneLigne && !modeAjout;
            btnSupprimer.Enabled = aUneLigne && !modeAjout;
            btnAnnuler.Enabled = modeAjout;
            dgvUtilisateurs.Enabled = !modeAjout;

            // Le nom n'est modifiable que lors de l'ajout (unique et non modifiable ensuite)
            txtNom.ReadOnly = !modeAjout;
            txtNom.Enabled = true;
            txtMdp.Enabled = true;
            // Un utilisateur ne peut pas modifier son propre type
            bool estMoi = aUneLigne && !modeAjout
                          && (int)ligne["NoUtilisateur"] == Session.NoUtilisateur;
            cboType.Enabled = modeAjout || (aUneLigne && !estMoi);
        }

        // =====================================================
        //  Validation des champs obligatoires
        // =====================================================
        private bool ChampsValides()
        {
            if (txtNom.Text.Trim() == "")
            {
                MessageBox.Show("Le nom d'utilisateur est obligatoire.", "Champ obligatoire",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return false;
            }
            if (txtMdp.Text == "")
            {
                MessageBox.Show("Le mot de passe est obligatoire.", "Champ obligatoire",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMdp.Focus();
                return false;
            }
            if (cboType.SelectedValue == null)
            {
                MessageBox.Show("Le type d'utilisateur est obligatoire.", "Champ obligatoire",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboType.Focus();
                return false;
            }
            return true;
        }

        // =====================================================
        //  Ajouter (1er clic : préparer, 2e clic : confirmer)
        // =====================================================
        private int ProchainNumero()
        {
            object max = ds.Tables["utilisateur"].Compute("MAX(NoUtilisateur)", "");
            return max == DBNull.Value ? 1 : Convert.ToInt32(max) + 1;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!modeAjout) PreparerAjout();
            else ConfirmerAjout();
        }

        private void PreparerAjout()
        {
            if (ds.Tables["typeUtilisateur"].Rows.Count == 0)
            {
                MessageBox.Show("Aucun type d'utilisateur n'existe dans la base.", "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            modeAjout = true;
            txtNo.Text = ProchainNumero().ToString();   // numéro automatique, non modifiable
            txtNom.Clear();
            txtMdp.Clear();
            cboType.SelectedIndex = 0;

            MettreAJourEtat();
            txtNom.Focus();
        }

        private void ConfirmerAjout()
        {
            if (!ChampsValides()) return;

            string nom = txtNom.Text.Trim();
            if (NomExiste(nom))
            {
                MessageBox.Show("Ce nom d'utilisateur existe déjà.", "Doublon",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNom.Focus();
                return;
            }

            int no = int.Parse(txtNo.Text);
            string mdp = txtMdp.Text;
            int type = Convert.ToInt32(cboType.SelectedValue);

            // 1. Base de données (avec transaction)
            bool ok = ExecuterTransaction(
                "INSERT INTO Utilisateur (NoUtilisateur, NomUtilisateur, MotDePasse, NoTypeUtilisateur) " +
                "VALUES (@no, @nom, @mdp, @type)",
                new SqlParameter("@no", no),
                new SqlParameter("@nom", nom),
                new SqlParameter("@mdp", mdp),
                new SqlParameter("@type", type));
            if (!ok) return;

            // 2. Mémoire (DataTable)
            DataTable table = ds.Tables["utilisateur"];
            table.Rows.Add(no, nom, mdp, type);
            table.AcceptChanges();

            modeAjout = false;
            MettreAJourEtat();
            SelectionnerNumero(no);
            MessageBox.Show("Utilisateur ajouté.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            modeAjout = false;
            AfficherSelection();
        }

        private bool NomExiste(string nom)
        {
            foreach (DataRow l in ds.Tables["utilisateur"].Rows)
                if (string.Equals(l["NomUtilisateur"].ToString(), nom, StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        // =====================================================
        //  Modifier
        // =====================================================
        private void btnModifier_Click(object sender, EventArgs e)
        {
            DataRow ligne = LigneSelectionnee();
            if (modeAjout || ligne == null) return;
            if (!ChampsValides()) return;

            int no = (int)ligne["NoUtilisateur"];
            string mdp = txtMdp.Text;

            // Le type ne change que pour un autre utilisateur
            int type = (no == Session.NoUtilisateur)
                       ? (int)ligne["NoTypeUtilisateur"]
                       : Convert.ToInt32(cboType.SelectedValue);

            if (mdp == ligne["MotDePasse"].ToString() && type == (int)ligne["NoTypeUtilisateur"])
            {
                MessageBox.Show("Aucune modification à enregistrer.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1. Base de données (avec transaction)
            bool ok = ExecuterTransaction(
                "UPDATE Utilisateur SET MotDePasse = @mdp, NoTypeUtilisateur = @type " +
                "WHERE NoUtilisateur = @no",
                new SqlParameter("@mdp", mdp),
                new SqlParameter("@type", type),
                new SqlParameter("@no", no));
            if (!ok) return;

            // 2. Mémoire (DataTable)
            ligne["MotDePasse"] = mdp;
            ligne["NoTypeUtilisateur"] = type;
            ligne.AcceptChanges();

            MessageBox.Show("Utilisateur modifié.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================
        //  Supprimer
        // =====================================================
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DataRow ligne = LigneSelectionnee();
            if (modeAjout || ligne == null) return;

            int no = (int)ligne["NoUtilisateur"];
            string nom = ligne["NomUtilisateur"].ToString();

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

            // 1. Base de données (avec transaction)
            bool ok = ExecuterTransaction(
                "DELETE FROM Utilisateur WHERE NoUtilisateur = @no",
                new SqlParameter("@no", no));
            if (!ok) return;

            // 2. Mémoire (DataTable)
            ligne.Delete();
            ds.Tables["utilisateur"].AcceptChanges();

            AfficherSelection();
        }

        // =====================================================
        //  Mode connecté : requête dans une transaction (Labo 4, section 3.3)
        // =====================================================
        private bool ExecuterTransaction(string requete, params SqlParameter[] parametres)
        {
            SqlConnection maConnexion = new SqlConnection(ConnexionBD.Chaine);
            SqlTransaction maTransaction = null;
            try
            {
                maConnexion.Open();
                maTransaction = maConnexion.BeginTransaction();

                SqlCommand maCommande = new SqlCommand(requete, maConnexion);
                maCommande.Transaction = maTransaction;          // la commande fait partie de la transaction
                maCommande.Parameters.AddRange(parametres);
                maCommande.ExecuteNonQuery();

                maTransaction.Commit();                          // tout a réussi
                return true;
            }
            catch (Exception ex)
            {
                if (maTransaction != null)
                {
                    try { maTransaction.Rollback(); } catch { }  // annule ce qui a été exécuté
                }
                MessageBox.Show("Erreur lors de la sauvegarde dans la base de données :\n" + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                maConnexion.Close();                             // IMPORTANT DE FERMER LA CONNEXION
            }
        }

        private void SelectionnerNumero(int no)
        {
            foreach (DataGridViewRow r in dgvUtilisateurs.Rows)
            {
                DataRowView vue = r.DataBoundItem as DataRowView;
                if (vue != null && Convert.ToInt32(vue.Row["NoUtilisateur"]) == no)
                {
                    dgvUtilisateurs.CurrentCell = r.Cells[0];   // par position, pas par nom
                    r.Selected = true;
                    break;
                }
            }
            AfficherSelection();
        }
    }
}