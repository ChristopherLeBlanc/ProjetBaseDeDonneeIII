using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmClientsInvites : Form
    {

        private const int MAX_INVITES = 9;

        String maChaineDeConnexion = ConnexionBD.Chaine;
        DataSet monDataSet = new DataSet();

        private bool modeAjoutClient = false;
        private bool modeAjoutInvite = false;
        private bool chargement = false;

        public FrmClientsInvites()
        {
            InitializeComponent();

            Load += FrmClientsInvites_Load;
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
            dgvInvites.SelectionChanged += dgvInvites_SelectionChanged;

            btnAjouterClient.Click += btnAjouterClient_Click;
            btnModifierClient.Click += btnModifierClient_Click;
            btnSupprimerClient.Click += btnSupprimerClient_Click;
            btnAnnulerClient.Click += btnAnnulerClient_Click;

            btnAjouterInvite.Click += btnAjouterInvite_Click;
            btnModifierInvite.Click += btnModifierInvite_Click;
            btnSupprimerInvite.Click += btnSupprimerInvite_Click;
            btnAnnulerInvite.Click += btnAnnulerInvite_Click;
        }

        // =====================================================
        //  Chargement (mode déconnecté : DataAdapter + Fill)
        // =====================================================
        private void FrmClientsInvites_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerClients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }
            AfficherClient();
        }

        private void ChargerClients()
        {
            String maRequeteSQL = "SELECT NoClient, Nom, Prenom, Ville, Pays, Adresse, CodePostal, DateInscription " +
                                  "FROM Client ORDER BY NoClient";
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            SqlDataAdapter dataAdapterClients = new SqlDataAdapter(maRequeteSQL, maConnexion);

            chargement = true;
            dgvClients.DataSource = null;
            dgvClients.Columns.Clear();
            dgvClients.AutoGenerateColumns = true;

            if (monDataSet.Tables.Contains("client"))
                monDataSet.Tables.Remove("client");
            dataAdapterClients.Fill(monDataSet, "client");

            dgvClients.DataSource = monDataSet.Tables["client"];
            chargement = false;
        }

        private void ChargerInvites(int noClient)
        {
            String maRequeteSQL = "SELECT NoInvite, NomPrenom, NoClient FROM Invite " +
                                  "WHERE NoClient = @noClient ORDER BY NoInvite";
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            SqlDataAdapter dataAdapterInvites = new SqlDataAdapter(maRequeteSQL, maConnexion);
            dataAdapterInvites.SelectCommand.Parameters.AddWithValue("@noClient", noClient);

            chargement = true;
            dgvInvites.DataSource = null;
            dgvInvites.Columns.Clear();
            dgvInvites.AutoGenerateColumns = true;

            if (monDataSet.Tables.Contains("invite"))
                monDataSet.Tables.Remove("invite");
            dataAdapterInvites.Fill(monDataSet, "invite");

            dgvInvites.DataSource = monDataSet.Tables["invite"];
            chargement = false;
        }

        // =====================================================
        //  Affichage
        // =====================================================
        private DataRow ClientCourant()
        {
            if (dgvClients.CurrentRow == null) return null;
            DataRowView vue = dgvClients.CurrentRow.DataBoundItem as DataRowView;
            return vue == null ? null : vue.Row;
        }

        private DataRow InviteCourant()
        {
            if (dgvInvites.CurrentRow == null) return null;
            DataRowView vue = dgvInvites.CurrentRow.DataBoundItem as DataRowView;
            return vue == null ? null : vue.Row;
        }

        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (chargement) return;
            modeAjoutClient = false;     // changer de ligne annule un ajout en cours
            modeAjoutInvite = false;
            AfficherClient();
        }

        private void dgvInvites_SelectionChanged(object sender, EventArgs e)
        {
            if (chargement) return;
            modeAjoutInvite = false;
            AfficherInvite();
        }

        private void AfficherClient()
        {
            DataRow ligne = ClientCourant();
            if (ligne == null)
            {
                txtNoClient.Clear(); txtNom.Clear(); txtPrenom.Clear(); txtVille.Clear();
                txtPays.Clear(); txtAdresse.Clear(); txtCodePostal.Clear(); txtDateInscription.Clear();
                chargement = true;
                dgvInvites.DataSource = null;
                chargement = false;
                AfficherInvite();
                return;
            }

            txtNoClient.Text = ligne["NoClient"].ToString();
            txtNom.Text = ligne["Nom"].ToString();
            txtPrenom.Text = ligne["Prenom"].ToString();
            txtVille.Text = ligne["Ville"].ToString();
            txtPays.Text = ligne["Pays"].ToString();
            txtAdresse.Text = ligne["Adresse"].ToString();
            txtCodePostal.Text = ligne["CodePostal"].ToString();
            txtDateInscription.Text = Convert.ToDateTime(ligne["DateInscription"]).ToString("yyyy-MM-dd");

            ChargerInvites(Convert.ToInt32(ligne["NoClient"]));
            AfficherInvite();
        }

        private void AfficherInvite()
        {
            DataRow ligne = InviteCourant();
            if (ligne != null)
            {
                txtNoInvite.Text = ligne["NoInvite"].ToString();
                txtNomPrenomInvite.Text = ligne["NomPrenom"].ToString();
            }
            else
            {
                txtNoInvite.Clear();
                txtNomPrenomInvite.Clear();
            }
            MettreAJourEtat();
        }

        private void MettreAJourEtat()
        {
            bool aClient = ClientCourant() != null;
            bool aInvite = InviteCourant() != null;

            txtNoClient.ReadOnly = true;
            txtDateInscription.ReadOnly = true;
            txtNoInvite.ReadOnly = true;

            // Clients
            btnAjouterClient.Text = modeAjoutClient ? "Confirmer l'ajout" : "Ajouter";
            btnAjouterClient.Enabled = !modeAjoutInvite;
            btnModifierClient.Enabled = aClient && !modeAjoutClient && !modeAjoutInvite;
            btnSupprimerClient.Enabled = aClient && !modeAjoutClient && !modeAjoutInvite;
            btnAnnulerClient.Enabled = modeAjoutClient;

            // Invités
            btnAjouterInvite.Text = modeAjoutInvite ? "Confirmer l'ajout" : "Ajouter";
            btnAjouterInvite.Enabled = aClient && !modeAjoutClient;
            btnModifierInvite.Enabled = aInvite && !modeAjoutInvite && !modeAjoutClient;
            btnSupprimerInvite.Enabled = aInvite && !modeAjoutInvite && !modeAjoutClient;
            btnAnnulerInvite.Enabled = modeAjoutInvite;
        }

        // =====================================================
        //  Requêtes en mode connecté
        // =====================================================
        private object ExecuterScalaire(String maRequeteSQL, params SqlParameter[] parametres)
        {
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            try
            {
                maConnexion.Open();
                SqlCommand maCommande = new SqlCommand(maRequeteSQL, maConnexion);
                maCommande.Parameters.AddRange(parametres);
                return maCommande.ExecuteScalar();
            }
            finally
            {
                maConnexion.Close();
            }
        }

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

        private int Compter(String maRequeteSQL, params SqlParameter[] parametres)
        {
            return Convert.ToInt32(ExecuterScalaire(maRequeteSQL, parametres));
        }

        // =====================================================
        //  CLIENTS : validation
        // =====================================================
        private bool ChampsClientValides()
        {
            TextBox[] champs = { txtNom, txtPrenom, txtVille, txtPays, txtAdresse, txtCodePostal };
            String[] noms = { "Le nom", "Le prénom", "La ville", "Le pays", "L'adresse", "Le code postal" };

            for (int i = 0; i < champs.Length; i++)
            {
                if (champs[i].Text.Trim() == "")
                {
                    MessageBox.Show(noms[i] + " est obligatoire.", "Champ obligatoire",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    champs[i].Focus();
                    return false;
                }
            }
            return true;   // le code postal n'est pas validé (varie selon le pays)
        }

        private void SelectionnerClient(int no)
        {
            foreach (DataGridViewRow r in dgvClients.Rows)
            {
                DataRowView vue = r.DataBoundItem as DataRowView;
                if (vue != null && Convert.ToInt32(vue.Row["NoClient"]) == no)
                {
                    chargement = true;
                    dgvClients.CurrentCell = r.Cells[0];
                    r.Selected = true;
                    chargement = false;
                    break;
                }
            }
            AfficherClient();
        }

        // =====================================================
        //  CLIENTS : ajouter
        // =====================================================
        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            if (!modeAjoutClient) PreparerAjoutClient();
            else ConfirmerAjoutClient();
        }

        private void PreparerAjoutClient()
        {
            try
            {
                object max = ExecuterScalaire("SELECT MAX(NoClient) FROM Client");
                int no = (max == null || max == DBNull.Value) ? 10 : Convert.ToInt32(max) + 10;

                modeAjoutClient = true;
                txtNoClient.Text = no.ToString();                          // numéro automatique
                txtDateInscription.Text = DateTime.Today.ToString("yyyy-MM-dd");   // date du jour
                txtNom.Clear(); txtPrenom.Clear(); txtVille.Clear();
                txtPays.Clear(); txtAdresse.Clear(); txtCodePostal.Clear();

                MettreAJourEtat();
                txtNom.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmerAjoutClient()
        {
            if (!ChampsClientValides()) return;

            int no = int.Parse(txtNoClient.Text);

            bool ok = ExecuterRequete(
                "INSERT INTO Client (NoClient, Nom, Prenom, Ville, Pays, Adresse, CodePostal, DateInscription) " +
                "VALUES (@no, @nom, @prenom, @ville, @pays, @adresse, @cp, @date)",
                new SqlParameter("@no", no),
                new SqlParameter("@nom", txtNom.Text.Trim()),
                new SqlParameter("@prenom", txtPrenom.Text.Trim()),
                new SqlParameter("@ville", txtVille.Text.Trim()),
                new SqlParameter("@pays", txtPays.Text.Trim()),
                new SqlParameter("@adresse", txtAdresse.Text.Trim()),
                new SqlParameter("@cp", txtCodePostal.Text.Trim()),
                new SqlParameter("@date", DateTime.Today));
            if (!ok) return;

            modeAjoutClient = false;
            ChargerClients();                  // met à jour la mémoire
            SelectionnerClient(no);

            MessageBox.Show("Client ajouté.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnnulerClient_Click(object sender, EventArgs e)
        {
            modeAjoutClient = false;
            AfficherClient();
        }

        // =====================================================
        //  CLIENTS : modifier
        // =====================================================
        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            DataRow ligne = ClientCourant();
            if (ligne == null || modeAjoutClient || modeAjoutInvite) return;
            if (!ChampsClientValides()) return;

            int no = Convert.ToInt32(ligne["NoClient"]);

            // Le numéro et la date d'inscription ne sont jamais modifiés
            bool ok = ExecuterRequete(
                "UPDATE Client SET Nom = @nom, Prenom = @prenom, Ville = @ville, Pays = @pays, " +
                "Adresse = @adresse, CodePostal = @cp WHERE NoClient = @no",
                new SqlParameter("@nom", txtNom.Text.Trim()),
                new SqlParameter("@prenom", txtPrenom.Text.Trim()),
                new SqlParameter("@ville", txtVille.Text.Trim()),
                new SqlParameter("@pays", txtPays.Text.Trim()),
                new SqlParameter("@adresse", txtAdresse.Text.Trim()),
                new SqlParameter("@cp", txtCodePostal.Text.Trim()),
                new SqlParameter("@no", no));
            if (!ok) return;

            ChargerClients();
            SelectionnerClient(no);

            MessageBox.Show("Client modifié.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================
        //  CLIENTS : supprimer
        // =====================================================
        private void btnSupprimerClient_Click(object sender, EventArgs e)
        {
            DataRow ligne = ClientCourant();
            if (ligne == null || modeAjoutClient || modeAjoutInvite) return;

            int no = Convert.ToInt32(ligne["NoClient"]);
            String nomComplet = ligne["Prenom"] + " " + ligne["Nom"];

            try
            {
                if (Compter("SELECT COUNT(*) FROM Invite WHERE NoClient = @no",
                            new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show("Ce client a des invités : suppression impossible.", "Refusé",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Compter("SELECT COUNT(*) FROM ReservationChambre WHERE NoClient = @no",
                            new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show("Ce client a réservé une chambre : suppression impossible.", "Refusé",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (Compter("SELECT COUNT(*) FROM PlanifSoin WHERE NoPersonne = @no",
                            new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show("Des soins sont planifiés pour ce client : suppression impossible.", "Refusé",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Supprimer le client « " + nomComplet + " » ?", "Confirmation",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            bool ok = ExecuterRequete("DELETE FROM Client WHERE NoClient = @no",
                                      new SqlParameter("@no", no));
            if (!ok) return;

            ChargerClients();
            AfficherClient();
        }

        // =====================================================
        //  INVITÉS : ajouter (numéro = plus petit libre de la plage du client)
        // =====================================================
        private int ProchainNumeroInvite(int noClient)
        {
            SqlConnection maConnexion = new SqlConnection(maChaineDeConnexion);
            DataTable utilises = new DataTable();
            String maRequeteSQL = "SELECT NoInvite FROM Invite WHERE NoClient = @noClient";
            SqlDataAdapter da = new SqlDataAdapter(maRequeteSQL, maConnexion);
            da.SelectCommand.Parameters.AddWithValue("@noClient", noClient);
            da.Fill(utilises);

            for (int i = 1; i <= MAX_INVITES; i++)
            {
                int candidat = noClient + i;
                if (utilises.Select("NoInvite = " + candidat).Length == 0)
                    return candidat;               // premier trou ou premier numéro libre
            }
            return -1;                             // maximum atteint
        }

        private void btnAjouterInvite_Click(object sender, EventArgs e)
        {
            if (!modeAjoutInvite) PreparerAjoutInvite();
            else ConfirmerAjoutInvite();
        }

        private void PreparerAjoutInvite()
        {
            DataRow client = ClientCourant();
            if (client == null) return;

            try
            {
                int noClient = Convert.ToInt32(client["NoClient"]);
                int no = ProchainNumeroInvite(noClient);
                if (no == -1)
                {
                    MessageBox.Show("Ce client a déjà le nombre maximum d'invités (" + MAX_INVITES + ").",
                                    "Maximum atteint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                modeAjoutInvite = true;
                txtNoInvite.Text = no.ToString();
                txtNomPrenomInvite.Clear();
                MettreAJourEtat();
                txtNomPrenomInvite.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfirmerAjoutInvite()
        {
            if (txtNomPrenomInvite.Text.Trim() == "")
            {
                MessageBox.Show("Le nom de l'invité est obligatoire.", "Champ obligatoire",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomPrenomInvite.Focus();
                return;
            }

            int noClient = Convert.ToInt32(ClientCourant()["NoClient"]);
            int no = int.Parse(txtNoInvite.Text);

            bool ok = ExecuterRequete(
                "INSERT INTO Invite (NoInvite, NomPrenom, NoClient) VALUES (@no, @nom, @noClient)",
                new SqlParameter("@no", no),
                new SqlParameter("@nom", txtNomPrenomInvite.Text.Trim()),
                new SqlParameter("@noClient", noClient));
            if (!ok) return;

            modeAjoutInvite = false;
            ChargerInvites(noClient);
            AfficherInvite();

            MessageBox.Show("Invité ajouté.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAnnulerInvite_Click(object sender, EventArgs e)
        {
            modeAjoutInvite = false;
            AfficherInvite();
        }

        // =====================================================
        //  INVITÉS : modifier (seul le nom)
        // =====================================================
        private void btnModifierInvite_Click(object sender, EventArgs e)
        {
            DataRow ligne = InviteCourant();
            if (ligne == null || modeAjoutInvite || modeAjoutClient) return;

            if (txtNomPrenomInvite.Text.Trim() == "")
            {
                MessageBox.Show("Le nom de l'invité est obligatoire.", "Champ obligatoire",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomPrenomInvite.Focus();
                return;
            }

            int no = Convert.ToInt32(ligne["NoInvite"]);
            int noClient = Convert.ToInt32(ligne["NoClient"]);

            bool ok = ExecuterRequete(
                "UPDATE Invite SET NomPrenom = @nom WHERE NoInvite = @no",
                new SqlParameter("@nom", txtNomPrenomInvite.Text.Trim()),
                new SqlParameter("@no", no));
            if (!ok) return;

            ChargerInvites(noClient);
            AfficherInvite();

            MessageBox.Show("Invité modifié.", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // =====================================================
        //  INVITÉS : supprimer
        // =====================================================
        private void btnSupprimerInvite_Click(object sender, EventArgs e)
        {
            DataRow ligne = InviteCourant();
            if (ligne == null || modeAjoutInvite || modeAjoutClient) return;

            int no = Convert.ToInt32(ligne["NoInvite"]);
            int noClient = Convert.ToInt32(ligne["NoClient"]);
            String nom = ligne["NomPrenom"].ToString();

            try
            {
                if (Compter("SELECT COUNT(*) FROM PlanifSoin WHERE NoPersonne = @no",
                            new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show("Des soins sont planifiés pour cet invité : suppression impossible.", "Refusé",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message, "Erreur",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Supprimer l'invité « " + nom + " » ?", "Confirmation",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            bool ok = ExecuterRequete("DELETE FROM Invite WHERE NoInvite = @no",
                                      new SqlParameter("@no", no));
            if (!ok) return;

            ChargerInvites(noClient);
            AfficherInvite();
        }
    }
}
