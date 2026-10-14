using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmUtilisateurs : Form
    {
        private const int ADMIN_INITIAL = 1;

        String maChaineDeConnexion = ConnexionBD.Chaine;
        DataSet monDataSet = new DataSet();
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
            String maRequeteSQL = "SELECT NoTypeUtilisateur, Identification FROM TypeUtilisateur";
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            SqlDataAdapter dataAdapterTypes = new SqlDataAdapter(maRequeteSQL, maConnexion);

            if (monDataSet.Tables.Contains("typeUtilisateur"))
                monDataSet.Tables.Remove("typeUtilisateur");

            dataAdapterTypes.Fill(monDataSet, "typeUtilisateur");

            cboType.DataSource = monDataSet.Tables["typeUtilisateur"];
            cboType.DisplayMember = "Identification";
            cboType.ValueMember = "NoTypeUtilisateur";
        }

        private void ChargerUtilisateurs()
        {
            String maRequeteSQL = "SELECT NoUtilisateur, NomUtilisateur, MotDePasse, NoTypeUtilisateur " +
                                  "FROM Utilisateur ORDER BY NoUtilisateur";
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            SqlDataAdapter dataAdapterUtilisateurs = new SqlDataAdapter(maRequeteSQL, maConnexion);

            dgvUtilisateurs.DataSource = null;
            dgvUtilisateurs.Columns.Clear();
            dgvUtilisateurs.AutoGenerateColumns = true;

            if (monDataSet.Tables.Contains("utilisateur"))
                monDataSet.Tables.Remove("utilisateur");

            dataAdapterUtilisateurs.Fill(monDataSet, "utilisateur");

            dgvUtilisateurs.DataSource = monDataSet.Tables["utilisateur"];

            foreach (DataGridViewColumn col in dgvUtilisateurs.Columns)
                if (col.DataPropertyName == "MotDePasse") col.Visible = false;
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
            if (ligne != null)
            {
                txtNo.Text = ligne["NoUtilisateur"].ToString();
                txtNom.Text = ligne["NomUtilisateur"].ToString();
                txtMdp.Text = ligne["MotDePasse"].ToString();
                cboType.SelectedValue = ligne["NoTypeUtilisateur"];
            }
            else
            {
                txtNo.Clear();
                txtNom.Clear();
                txtMdp.Clear();
            }
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

            // Le nom n'est modifiable que lors de l'ajout (unique et non modifiable ensuite)
            txtNom.ReadOnly = !modeAjout;
            txtNo.ReadOnly = true;

            // Un utilisateur ne peut pas modifier son propre type
            bool estMoi = aUneLigne && !modeAjout
                          && Convert.ToInt32(ligne["NoUtilisateur"]) == Session.NoUtilisateur;
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
        //  Requêtes en mode connecté (ExecuteScalar)
        // =====================================================
        private int ObtenirProchainNumero()
        {
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            try
            {
                maConnexion.Open();
                String maRequeteSQL = "SELECT MAX(NoUtilisateur) FROM Utilisateur";
                SqlCommand maCommande = new SqlCommand(maRequeteSQL, maConnexion);
                object resultat = maCommande.ExecuteScalar();
                return (resultat == null || resultat == DBNull.Value) ? 1 : Convert.ToInt32(resultat) + 1;
            }
            finally
            {
                maConnexion.Close();
            }
        }

        private bool NomExiste(String nom)
        {
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            try
            {
                maConnexion.Open();
                String maRequeteSQL = "SELECT COUNT(*) FROM Utilisateur WHERE NomUtilisateur = @nom";
                SqlCommand maCommande = new SqlCommand(maRequeteSQL, maConnexion);
                maCommande.Parameters.AddWithValue("@nom", nom);
                return Convert.ToInt32(maCommande.ExecuteScalar()) > 0;
            }
            finally
            {
                maConnexion.Close();
            }
        }

        // =====================================================
        //  Requête d'écriture dans une transaction (ExecuteNonQuery)
        // =====================================================
        private bool ExecuterRequete(String maRequeteSQL, params SqlParameter[] parametres)
        {
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            SqlTransaction maTransaction = null;
            try
            {
                maConnexion.Open();
                maTransaction = maConnexion.BeginTransaction();

                SqlCommand maCommande = new SqlCommand(maRequeteSQL, maConnexion);
                maCommande.Transaction = maTransaction;
                maCommande.Parameters.AddRange(parametres);
                maCommande.ExecuteNonQuery();

                maTransaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                if (maTransaction != null)
                {
                    try { maTransaction.Rollback(); } catch { }
                }
                MessageBox.Show("Erreur lors de la sauvegarde dans la base de données :\n" + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                maConnexion.Close();
            }
        }

        // =====================================================
        //  Ajouter (1er clic : préparer, 2e clic : confirmer)
        // =====================================================
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!modeAjout) PreparerAjout();
            else ConfirmerAjout();
        }

        private void PreparerAjout()
        {
            try
            {
                int no = ObtenirProchainNumero();      // numéro automatique

                modeAjout = true;
                txtNo.Text = no.ToString();
                txtNom.Clear();
                txtMdp.Clear();
                cboType.SelectedIndex = 0;

                MettreAJourEtat();
                txtNom.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmerAjout()
        {
            if (!ChampsValides()) return;

            String nom = txtNom.Text.Trim();

            try
            {
                if (NomExiste(nom))
                {
                    MessageBox.Show("Ce nom d'utilisateur existe déjà.", "Doublon",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNom.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int no = int.Parse(txtNo.Text);

            bool ok = ExecuterRequete(
                "INSERT INTO Utilisateur (NoUtilisateur, NomUtilisateur, MotDePasse, NoTypeUtilisateur) " +
                "VALUES (@no, @nom, @mdp, @type)",
                new SqlParameter("@no", no),
                new SqlParameter("@nom", nom),
                new SqlParameter("@mdp", txtMdp.Text),
                new SqlParameter("@type", Convert.ToInt32(cboType.SelectedValue)));
            if (!ok) return;

            modeAjout = false;
            ChargerUtilisateurs();                     // met à jour la mémoire (DataTable)
            SelectionnerNumero(no);

            MessageBox.Show("Utilisateur ajouté.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            modeAjout = false;
            AfficherSelection();
        }

        // =====================================================
        //  Modifier
        // =====================================================
        private void btnModifier_Click(object sender, EventArgs e)
        {
            DataRow ligne = LigneSelectionnee();
            if (modeAjout || ligne == null) return;
            if (!ChampsValides()) return;

            int no = Convert.ToInt32(ligne["NoUtilisateur"]);
            int typeActuel = Convert.ToInt32(ligne["NoTypeUtilisateur"]);

            // Le type ne change que pour un autre utilisateur
            int type = (no == Session.NoUtilisateur) ? typeActuel : Convert.ToInt32(cboType.SelectedValue);

            if (txtMdp.Text == ligne["MotDePasse"].ToString() && type == typeActuel)
            {
                MessageBox.Show("Aucune modification à enregistrer.", "Information",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            bool ok = ExecuterRequete(
                "UPDATE Utilisateur SET MotDePasse = @mdp, NoTypeUtilisateur = @type " +
                "WHERE NoUtilisateur = @no",
                new SqlParameter("@mdp", txtMdp.Text),
                new SqlParameter("@type", type),
                new SqlParameter("@no", no));
            if (!ok) return;

            ChargerUtilisateurs();                     // met à jour la mémoire (DataTable)
            SelectionnerNumero(no);

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

            int no = Convert.ToInt32(ligne["NoUtilisateur"]);
            String nom = ligne["NomUtilisateur"].ToString();

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

            bool ok = ExecuterRequete(
                "DELETE FROM Utilisateur WHERE NoUtilisateur = @no",
                new SqlParameter("@no", no));
            if (!ok) return;

            ChargerUtilisateurs();                     // met à jour la mémoire (DataTable)
            AfficherSelection();
        }

        private void SelectionnerNumero(int no)
        {
            foreach (DataGridViewRow r in dgvUtilisateurs.Rows)
            {
                DataRowView vue = r.DataBoundItem as DataRowView;
                if (vue != null && Convert.ToInt32(vue.Row["NoUtilisateur"]) == no)
                {
                    dgvUtilisateurs.CurrentCell = r.Cells[0];
                    r.Selected = true;
                    break;
                }
            }
            AfficherSelection();
        }
    }
}