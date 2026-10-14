
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmClientsInvites : Form
    {
        private const int MAX_INVITES = 9;

        private string maChaineDeConnexion = ConnexionBD.Chaine;

        private bool modeAjoutClient = false;
        private bool modeAjoutInvite = false;

        public FrmClientsInvites()
        {
            InitializeComponent();
            // charge client a ouverture
            this.Load += FrmClientsInvites_Load;

            // charge invite selon client
            dgvClients.SelectionChanged += dgvClients_SelectionChanged;
            dgvInvites.SelectionChanged += dgvInvites_SelectionChanged;
        }

        //etat

        private void MettreAJourEtat()
        {
            bool aClient = !string.IsNullOrWhiteSpace(txtNoClient.Text);
            bool aInvite = !string.IsNullOrWhiteSpace(txtNoInvite.Text);

            txtNoClient.ReadOnly = true;
            txtDateInscription.ReadOnly = true;
            txtNoInvite.ReadOnly = true;

            btnAjouterClient.Text =
                modeAjoutClient ? "Confirmer l'ajout" : "Ajouter";

            btnAjouterClient.Enabled = !modeAjoutInvite;
            btnModifierClient.Enabled =
                aClient && !modeAjoutClient && !modeAjoutInvite;
            btnSupprimerClient.Enabled =
                aClient && !modeAjoutClient && !modeAjoutInvite;
            btnAnnulerClient.Enabled = modeAjoutClient;

            btnAjouterInvite.Text =
                modeAjoutInvite ? "Confirmer l'ajout" : "Ajouter";

            btnAjouterInvite.Enabled = aClient && !modeAjoutClient;
            btnModifierInvite.Enabled =
                aInvite && !modeAjoutInvite && !modeAjoutClient;
            btnSupprimerInvite.Enabled =
                aInvite && !modeAjoutInvite && !modeAjoutClient;
            btnAnnulerInvite.Enabled = modeAjoutInvite;
        }

        //sql

        private object ExecuterScalaire(
            string maRequeteSQL,
            params SqlParameter[] parametres)
        {
            using (SqlConnection maConnexion =
                   new SqlConnection(maChaineDeConnexion))
            using (SqlCommand maCommande =
                   new SqlCommand(maRequeteSQL, maConnexion))
            {
                maCommande.Parameters.AddRange(parametres);
                maConnexion.Open();

                return maCommande.ExecuteScalar();
            }
        }

        private bool ExecuterRequete(
            string maRequeteSQL,
            params SqlParameter[] parametres)
        {
            using (SqlConnection maConnexion =
                   new SqlConnection(maChaineDeConnexion))
            {
                SqlTransaction maTransaction = null;

                try
                {
                    maConnexion.Open();
                    maTransaction = maConnexion.BeginTransaction();

                    using (SqlCommand maCommande =
                           new SqlCommand(maRequeteSQL, maConnexion))
                    {
                        maCommande.Transaction = maTransaction;
                        maCommande.Parameters.AddRange(parametres);
                        maCommande.ExecuteNonQuery();
                    }

                    maTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    if (maTransaction != null)
                    {
                        try { maTransaction.Rollback(); }
                        catch { }
                    }

                    MessageBox.Show(
                        "Erreur lors de la sauvegarde :\n" + ex.Message,
                        "Erreur",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return false;
                }
            }
        }

        private int Compter(
            string maRequeteSQL,
            params SqlParameter[] parametres)
        {
            return Convert.ToInt32(
                ExecuterScalaire(maRequeteSQL, parametres));
        }

        private bool NumeroValide(TextBox champ, out int numero)
        {
            return int.TryParse(champ.Text, out numero);
        }

        //validation client
        private bool ChampsClientValides()
        {
            TextBox[] champs =
            {
                txtNom, txtPrenom, txtVille,
                txtPays, txtAdresse, txtCodePostal
            };

            string[] noms =
            {
                "Le nom", "Le prénom", "La ville",
                "Le pays", "L'adresse", "Le code postal"
            };

            for (int i = 0; i < champs.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(champs[i].Text))
                {
                    MessageBox.Show(
                        noms[i] + " est obligatoire.",
                        "Champ obligatoire",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    champs[i].Focus();
                    return false;
                }
            }

            return true;
        }


        //client ajouter

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            if (!modeAjoutClient)
                PreparerAjoutClient();
            else
                ConfirmerAjoutClient();
        }

        private void PreparerAjoutClient()
        {
            try
            {
                object maximum =
                    ExecuterScalaire("SELECT MAX(NoClient) FROM Client");

                int no = (maximum == null || maximum == DBNull.Value)
                    ? 10
                    : Convert.ToInt32(maximum) + 10;

                modeAjoutClient = true;

                txtNoClient.Text = no.ToString();
                txtDateInscription.Text =
                    DateTime.Today.ToString("yyyy-MM-dd");

                txtNom.Clear();
                txtPrenom.Clear();
                txtVille.Clear();
                txtPays.Clear();
                txtAdresse.Clear();
                txtCodePostal.Clear();

                MettreAJourEtat();
                txtNom.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message);
            }
        }

        private void ConfirmerAjoutClient()
        {
            if (!ChampsClientValides())
                return;

            if (!NumeroValide(txtNoClient, out int no))
            {
                MessageBox.Show("Numéro de client invalide.");
                return;
            }

            bool ok = ExecuterRequete(
                "INSERT INTO Client " +
                "(NoClient, Nom, Prenom, Ville, Pays, Adresse, CodePostal, DateInscription) " +
                "VALUES (@no, @nom, @prenom, @ville, @pays, @adresse, @cp, @date)",

                new SqlParameter("@no", no),
                new SqlParameter("@nom", txtNom.Text.Trim()),
                new SqlParameter("@prenom", txtPrenom.Text.Trim()),
                new SqlParameter("@ville", txtVille.Text.Trim()),
                new SqlParameter("@pays", txtPays.Text.Trim()),
                new SqlParameter("@adresse", txtAdresse.Text.Trim()),
                new SqlParameter("@cp", txtCodePostal.Text.Trim()),
                new SqlParameter("@date", DateTime.Today));

            if (!ok)
                return;
            ChargerClients();
            modeAjoutClient = false;
            MettreAJourEtat();

            MessageBox.Show("Client ajouté.");
        }

        private void btnAnnulerClient_Click(object sender, EventArgs e)
        {
            modeAjoutClient = false;
            MettreAJourEtat();
        }

       
        //client modifier
        private void btnModifierClient_Click(object sender, EventArgs e)
        {
            if (modeAjoutClient || modeAjoutInvite)
                return;

            if (!NumeroValide(txtNoClient, out int no))
            {
                MessageBox.Show("Sélectionne un client.");
                return;
            }

            if (!ChampsClientValides())
                return;

            bool ok = ExecuterRequete(
                "UPDATE Client SET Nom = @nom, Prenom = @prenom, " +
                "Ville = @ville, Pays = @pays, Adresse = @adresse, " +
                "CodePostal = @cp WHERE NoClient = @no",

                new SqlParameter("@nom", txtNom.Text.Trim()),
                new SqlParameter("@prenom", txtPrenom.Text.Trim()),
                new SqlParameter("@ville", txtVille.Text.Trim()),
                new SqlParameter("@pays", txtPays.Text.Trim()),
                new SqlParameter("@adresse", txtAdresse.Text.Trim()),
                new SqlParameter("@cp", txtCodePostal.Text.Trim()),
                new SqlParameter("@no", no));

            if (ok)
                MessageBox.Show("Client modifié.");
        }

        //Client supprimer
        private void btnSupprimerClient_Click(object sender, EventArgs e)
        {
            if (modeAjoutClient || modeAjoutInvite)
                return;

            if (!NumeroValide(txtNoClient, out int no))
            {
                MessageBox.Show("Sélectionne un client.");
                return;
            }

            string nomComplet =
                txtPrenom.Text + " " + txtNom.Text;

            try
            {
                if (Compter(
                    "SELECT COUNT(*) FROM Invite WHERE NoClient = @no",
                    new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show(
                        "Ce client a des invités : suppression impossible.");
                    return;
                }

                if (Compter(
                    "SELECT COUNT(*) FROM ReservationChambre WHERE NoClient = @no",
                    new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show(
                        "Ce client a réservé une chambre : suppression impossible.");
                    return;
                }

                if (Compter(
                    "SELECT COUNT(*) FROM PlanifSoin WHERE NoPersonne = @no",
                    new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show(
                        "Des soins sont planifiés pour ce client : suppression impossible.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message);
                return;
            }

            if (MessageBox.Show(
                "Supprimer le client « " + nomComplet + " » ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (ExecuterRequete(
                "DELETE FROM Client WHERE NoClient = @no",
                new SqlParameter("@no", no)))
            {
                MessageBox.Show("Client supprimé.");
                MettreAJourEtat();
            }
        }

        //prochain numero de l'invite
        private int ProchainNumeroInvite(int noClient)
        {
            DataTable utilises = new DataTable();

            using (SqlConnection maConnexion =
                   new SqlConnection(maChaineDeConnexion))
            using (SqlCommand commande = new SqlCommand(
                "SELECT NoInvite FROM Invite WHERE NoClient = @noClient",
                maConnexion))
            using (SqlDataAdapter da = new SqlDataAdapter(commande))
            {
                commande.Parameters.AddWithValue("@noClient", noClient);
                da.Fill(utilises);
            }

            for (int i = 1; i <= MAX_INVITES; i++)
            {
                int candidat = noClient + i;

                if (utilises.Select("NoInvite = " + candidat).Length == 0)
                    return candidat;
            }

            return -1;
        }

        //inviter ajouter
        private void btnAjouterInvite_Click(object sender, EventArgs e)
        {
            if (!modeAjoutInvite)
                PreparerAjoutInvite();
            else
                ConfirmerAjoutInvite();
        }

        private void PreparerAjoutInvite()
        {
            if (!NumeroValide(txtNoClient, out int noClient))
            {
                MessageBox.Show("Sélectionne un client.");
                return;
            }

            try
            {
                int no = ProchainNumeroInvite(noClient);

                if (no == -1)
                {
                    MessageBox.Show(
                        "Ce client a déjà le nombre maximum d'invités (" +
                        MAX_INVITES + ").");

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
                MessageBox.Show("Erreur :\n" + ex.Message);
            }
        }

        private void ConfirmerAjoutInvite()
        {
            if (string.IsNullOrWhiteSpace(txtNomPrenomInvite.Text))
            {
                MessageBox.Show("Le nom de l'invité est obligatoire.");
                txtNomPrenomInvite.Focus();
                return;
            }

            if (!NumeroValide(txtNoClient, out int noClient) ||
                !NumeroValide(txtNoInvite, out int no))
            {
                MessageBox.Show("Numéro de client ou d'invité invalide.");
                return;
            }

            bool ok = ExecuterRequete(
                "INSERT INTO Invite (NoInvite, NomPrenom, NoClient) " +
                "VALUES (@no, @nom, @noClient)",

                new SqlParameter("@no", no),
                new SqlParameter("@nom", txtNomPrenomInvite.Text.Trim()),
                new SqlParameter("@noClient", noClient));

            if (!ok)
                return;
            ChargerInvites(noClient);
            modeAjoutInvite = false;
            MettreAJourEtat();

            MessageBox.Show("Invité ajouté.");
        }

        private void btnAnnulerInvite_Click(object sender, EventArgs e)
        {
            modeAjoutInvite = false;
            MettreAJourEtat();
        }

        //inviter modifier
        private void btnModifierInvite_Click(object sender, EventArgs e)
        {
            if (modeAjoutInvite || modeAjoutClient)
                return;

            if (!NumeroValide(txtNoInvite, out int no))
            {
                MessageBox.Show("Sélectionne un invité.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomPrenomInvite.Text))
            {
                MessageBox.Show("Le nom de l'invité est obligatoire.");
                txtNomPrenomInvite.Focus();
                return;
            }

            bool ok = ExecuterRequete(
                "UPDATE Invite SET NomPrenom = @nom WHERE NoInvite = @no",
                new SqlParameter("@nom", txtNomPrenomInvite.Text.Trim()),
                new SqlParameter("@no", no));

            if (ok)
                MessageBox.Show("Invité modifié.");
        }

        // invite supprimer
        private void btnSupprimerInvite_Click(object sender, EventArgs e)
        {
            if (modeAjoutInvite || modeAjoutClient)
                return;

            if (!NumeroValide(txtNoInvite, out int no))
            {
                MessageBox.Show("Sélectionne un invité.");
                return;
            }

            string nom = txtNomPrenomInvite.Text;

            try
            {
                if (Compter(
                    "SELECT COUNT(*) FROM PlanifSoin WHERE NoPersonne = @no",
                    new SqlParameter("@no", no)) > 0)
                {
                    MessageBox.Show(
                        "Des soins sont planifiés pour cet invité : suppression impossible.");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message);
                return;
            }

            if (MessageBox.Show(
                "Supprimer l'invité « " + nom + " » ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (ExecuterRequete(
                "DELETE FROM Invite WHERE NoInvite = @no",
                new SqlParameter("@no", no)))
            {
                MessageBox.Show("Invité supprimé.");
                MettreAJourEtat();
            }
        }

        private void FrmClientsInvites_Load(object sender, EventArgs e)
        {
            ChargerClients();
        }

        private void ChargerClients()
        {
            try
            {
                DataTable tableClients = new DataTable();

                using (SqlConnection maConnexion =
                       new SqlConnection(maChaineDeConnexion))
                using (SqlDataAdapter adaptateur = new SqlDataAdapter(
                       "SELECT * FROM Client", maConnexion))
                {
                    adaptateur.Fill(tableClients);
                }

                dgvClients.DataSource = tableClients;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement des clients :\n"
                                + ex.Message);
            }
        }

        private void ChargerInvites(int noClient)
        {
            try
            {
                DataTable tableInvites = new DataTable();

                using (SqlConnection maConnexion =
                       new SqlConnection(maChaineDeConnexion))
                using (SqlCommand commande = new SqlCommand(
                       "SELECT * FROM Invite WHERE NoClient = @noClient",
                       maConnexion))
                using (SqlDataAdapter adaptateur =
                       new SqlDataAdapter(commande))
                {
                    commande.Parameters.AddWithValue("@noClient", noClient);
                    adaptateur.Fill(tableInvites);
                }

                dgvInvites.DataSource = tableInvites;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de chargement des invités :\n"
                                + ex.Message);
            }
        }




        private void dgvClients_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null ||
                dgvClients.CurrentRow.IsNewRow)
                return;

            DataGridViewRow ligne = dgvClients.CurrentRow;

            object valeur = LireValeurLigne(ligne, "NoClient");

            if (valeur == null || valeur == DBNull.Value)
                return;

            if (!int.TryParse(valeur.ToString(), out int noClient))
                return;

            // Remplir les champs du client sélectionné
            txtNoClient.Text = noClient.ToString();
            txtNom.Text = Convert.ToString(LireValeurLigne(ligne, "Nom"));
            txtPrenom.Text = Convert.ToString(LireValeurLigne(ligne, "Prenom"));
            txtVille.Text = Convert.ToString(LireValeurLigne(ligne, "Ville"));
            txtPays.Text = Convert.ToString(LireValeurLigne(ligne, "Pays"));
            txtAdresse.Text = Convert.ToString(LireValeurLigne(ligne, "Adresse"));
            txtCodePostal.Text = Convert.ToString(LireValeurLigne(ligne, "CodePostal"));
            txtDateInscription.Text = Convert.ToString(
                LireValeurLigne(ligne, "DateInscription"));

            // Charger les invités de ce client
            ChargerInvites(noClient);

            // Mettre à jour les boutons
            MettreAJourEtat();
        }


        private void dgvInvites_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvites.CurrentRow == null ||
                dgvInvites.CurrentRow.IsNewRow)
            {
                return;
            }

            DataGridViewRow ligne = dgvInvites.CurrentRow;

            txtNoInvite.Text = Convert.ToString(
                LireValeurLigne(ligne, "NoInvite"));

            txtNomPrenomInvite.Text = Convert.ToString(
                LireValeurLigne(ligne, "NomPrenom"));

            MettreAJourEtat();
        }


        private object LireValeurLigne(
            DataGridViewRow ligne,
            string nomChamp)
        {
            if (ligne == null || ligne.DataGridView == null)
                return null;

            foreach (DataGridViewColumn colonne in ligne.DataGridView.Columns)
            {
                if (string.Equals(colonne.Name, nomChamp,
                        StringComparison.OrdinalIgnoreCase)
                    || string.Equals(colonne.DataPropertyName, nomChamp,
                        StringComparison.OrdinalIgnoreCase)
                    || string.Equals(colonne.HeaderText, nomChamp,
                        StringComparison.OrdinalIgnoreCase))
                {
                    return ligne.Cells[colonne.Index].Value;
                }
            }

            
            DataRowView client = ligne.DataBoundItem as DataRowView;

            if (client != null &&
                client.Row.Table.Columns.Contains(nomChamp))
            {
                return client[nomChamp];
            }

            return null;
        }




    }
}