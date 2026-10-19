
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmRapports : Form
    {
        private readonly string chaine = ConnexionBD.Chaine;

        public FrmRapports()
        {
            InitializeComponent();

            this.Load += FrmRapport_Load;
            cmbTypePersonne.SelectedIndexChanged += cmbTypePersonne_SelectedIndexChanged;
            cmbPersonne.SelectedIndexChanged += cmbPersonne_SelectedIndexChanged;
            cmbChambre.SelectedIndexChanged += cmbChambre_SelectedIndexChanged;
            cmbAssistant.SelectedIndexChanged += cmbAssistant_SelectedIndexChanged;
            dtpDateSoin.ValueChanged += dtpDateSoin_ValueChanged;
            btnAfficherSoinsJournaliers.Click += btnAfficherSoinsJournaliers_Click;
            dgvSoinsJournaliers.SelectionChanged += dgvSoinsJournaliers_SelectionChanged;
            btnFermer.Click += btnFermer_Click;
        }

        private void FrmRapport_Load(object sender, EventArgs e)
        {
            cmbTypePersonne.Items.Clear();
            cmbTypePersonne.Items.Add("Client");
            cmbTypePersonne.Items.Add("Invité");
            cmbTypePersonne.SelectedIndex = 0;

            dtpDateSoin.Format = DateTimePickerFormat.Short;

            ChargerChambres();
            ChargerAssistants();
        }

        private DataTable ExecuterRequete(string requete, params SqlParameter[] parametres)
        {
            DataTable table = new DataTable();

            using (SqlConnection connexion = new SqlConnection(chaine))
            using (SqlCommand commande = new SqlCommand(requete, connexion))
            {
                if (parametres != null)
                    commande.Parameters.AddRange(parametres);

                using (SqlDataAdapter adaptateur = new SqlDataAdapter(commande))
                {
                    adaptateur.Fill(table);
                }
            }

            return table;
        }

        private void cmbTypePersonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerPersonnes();
        }

        private void ChargerPersonnes()
        {
            cmbPersonne.DataSource = null;
            dgvSoinsPersonne.DataSource = null;
            lblTotalSoins.Text = "Montant total : 0,00 $";

            if (cmbTypePersonne.SelectedItem == null)
                return;

            try
            {
                DataTable personnes;

                if (cmbTypePersonne.SelectedItem.ToString() == "Client")
                {
                    personnes = ExecuterRequete("SELECT NoClient AS NoPersonne, CAST(NoClient AS varchar(20)) + ' - ' + Prenom + ' ' + Nom AS NomComplet FROM Client ORDER BY Nom, Prenom");
                }
                else
                {
                    personnes = ExecuterRequete("SELECT NoInvite AS NoPersonne, CAST(NoInvite AS varchar(20)) + ' - ' + NomPrenom AS NomComplet FROM Invite ORDER BY NomPrenom");
                }

                cmbPersonne.DisplayMember = "NomComplet";
                cmbPersonne.ValueMember = "NoPersonne";
                cmbPersonne.DataSource = personnes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des personnes :\n" + ex.Message);
            }
        }

        private void cmbPersonne_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerSoinsPersonne();
        }

        private void ChargerSoinsPersonne()
        {
            dgvSoinsPersonne.DataSource = null;
            lblTotalSoins.Text = "Montant total : 0,00 $";

            if (cmbPersonne.SelectedValue == null || cmbPersonne.SelectedValue is DataRowView)
                return;

            try
            {
                int noPersonne = Convert.ToInt32(cmbPersonne.SelectedValue);

                DataTable soins = ExecuterRequete("SELECT s.Description AS Soin, ps.DateHeure AS [Date et heure], s.Prix AS Prix, a.Prenom + ' ' + a.Nom AS Assistant FROM PlanifSoin ps INNER JOIN Soin s ON s.NoSoin = ps.NoSoin INNER JOIN Assistant a ON a.NoAssistant = ps.NoAssistant WHERE ps.NoPersonne = @NoPersonne ORDER BY ps.DateHeure", new SqlParameter("@NoPersonne", noPersonne));

                dgvSoinsPersonne.DataSource = soins;

                decimal total = 0m;

                foreach (DataRow ligne in soins.Rows)
                {
                    if (ligne["Prix"] != DBNull.Value)
                        total += Convert.ToDecimal(ligne["Prix"]);
                }

                lblTotalSoins.Text = "Montant total : " + total.ToString("N2") + " $";

                if (soins.Rows.Count == 0)
                    lblTotalSoins.Text = "Montant total : 0,00 $ (aucun soin trouvé)";

                FormaterGrille(dgvSoinsPersonne);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des soins :\n" + ex.Message);
            }
        }

        private void ChargerChambres()
        {
            try
            {
                DataTable chambres = ExecuterRequete("SELECT NoChambre, CAST(NoChambre AS varchar(20)) + ' - ' + Emplacement AS ChambreAffichee FROM Chambre ORDER BY NoChambre");

                cmbChambre.DisplayMember = "ChambreAffichee";
                cmbChambre.ValueMember = "NoChambre";
                cmbChambre.DataSource = chambres;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des chambres :\n" + ex.Message);
            }
        }

        private void cmbChambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerReservations();
        }

        private void ChargerReservations()
        {
            dgvReservations.DataSource = null;

            if (cmbChambre.SelectedValue == null || cmbChambre.SelectedValue is DataRowView)
                return;

            try
            {
                int noChambre = Convert.ToInt32(cmbChambre.SelectedValue);

                DataTable reservations = ExecuterRequete("SELECT c.Prenom + ' ' + c.Nom AS Client, r.DateArrivee AS [Date d'arrivée], r.DateDepart AS [Date de départ], r.NbPersonnes AS [Nombre de personnes] FROM ReservationChambre r INNER JOIN Client c ON c.NoClient = r.NoClient WHERE r.NoChambre = @NoChambre ORDER BY r.DateArrivee", new SqlParameter("@NoChambre", noChambre));

                dgvReservations.DataSource = reservations;
                FormaterGrille(dgvReservations);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des réservations :\n" + ex.Message);
            }
        }

        private void ChargerAssistants()
        {
            try
            {
                DataTable assistants = ExecuterRequete("SELECT NoAssistant, CAST(NoAssistant AS varchar(20)) + ' - ' + Prenom + ' ' + Nom AS AssistantAffiche FROM Assistant ORDER BY Nom, Prenom");

                cmbAssistant.DisplayMember = "AssistantAffiche";
                cmbAssistant.ValueMember = "NoAssistant";
                cmbAssistant.DataSource = assistants;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des assistants :\n" + ex.Message);
            }
        }

        private void btnAfficherSoinsJournaliers_Click(object sender, EventArgs e)
        {
            ChargerSoinsJournaliers();
        }

        private void cmbAssistant_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerSoinsJournaliers();
        }

        private void dtpDateSoin_ValueChanged(object sender, EventArgs e)
        {
            ChargerSoinsJournaliers();
        }

        private void ChargerSoinsJournaliers()
        {
            dgvSoinsJournaliers.DataSource = null;
            dgvPersonnesSoin.DataSource = null;

            if (cmbAssistant.SelectedValue == null || cmbAssistant.SelectedValue is DataRowView)
                return;

            try
            {
                int noAssistant = Convert.ToInt32(cmbAssistant.SelectedValue);

                DataTable soins = ExecuterRequete("SELECT ps.NoSoin, s.Description AS Soin, ps.DateHeure AS [Date et heure] FROM PlanifSoin ps INNER JOIN Soin s ON s.NoSoin = ps.NoSoin WHERE ps.NoAssistant = @NoAssistant AND ps.DateHeure >= @DateDebut AND ps.DateHeure < @DateFin ORDER BY ps.DateHeure", new SqlParameter("@NoAssistant", noAssistant), new SqlParameter("@DateDebut", dtpDateSoin.Value.Date), new SqlParameter("@DateFin", dtpDateSoin.Value.Date.AddDays(1)));

                dgvSoinsJournaliers.DataSource = soins;
                FormaterGrille(dgvSoinsJournaliers);

                if (dgvSoinsJournaliers.Columns.Contains("NoSoin"))
                    dgvSoinsJournaliers.Columns["NoSoin"].Visible = false;

                if (soins.Rows.Count == 0)
                    return;

                dgvSoinsJournaliers.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des soins journaliers :\n" + ex.Message);
            }
        }

        private void dgvSoinsJournaliers_SelectionChanged(object sender, EventArgs e)
        {
            ChargerPersonnesSoin();
        }

        private void ChargerPersonnesSoin()
        {
            dgvPersonnesSoin.DataSource = null;

            if (dgvSoinsJournaliers.CurrentRow == null)
                return;

            if (!dgvSoinsJournaliers.Columns.Contains("NoSoin"))
                return;

            object valeur = dgvSoinsJournaliers.CurrentRow.Cells["NoSoin"].Value;

            if (valeur == null || valeur == DBNull.Value)
                return;

            try
            {
                int noSoin = Convert.ToInt32(valeur);
                int noAssistant = Convert.ToInt32(cmbAssistant.SelectedValue);
                DateTime date = dtpDateSoin.Value.Date;

                DataTable personnes = ExecuterRequete("SELECT s.Description AS Soin, ps.DateHeure AS [Date et heure], CASE WHEN c.NoClient IS NOT NULL THEN c.Prenom + ' ' + c.Nom ELSE i.NomPrenom END AS [Personne] FROM PlanifSoin ps INNER JOIN Soin s ON s.NoSoin = ps.NoSoin LEFT JOIN Client c ON c.NoClient = ps.NoPersonne LEFT JOIN Invite i ON i.NoInvite = ps.NoPersonne WHERE ps.NoAssistant = @NoAssistant AND ps.NoSoin = @NoSoin AND ps.DateHeure >= @DateDebut AND ps.DateHeure < @DateFin ORDER BY ps.DateHeure", new SqlParameter("@NoAssistant", noAssistant), new SqlParameter("@NoSoin", noSoin), new SqlParameter("@DateDebut", date), new SqlParameter("@DateFin", date.AddDays(1)));

                dgvPersonnesSoin.DataSource = personnes;
                FormaterGrille(dgvPersonnesSoin);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des personnes ayant reçu le soin :\n" + ex.Message);
            }
        }

        private void FormaterGrille(DataGridView grille)
        {
            grille.ReadOnly = true;
            grille.AllowUserToAddRows = false;
            grille.AllowUserToDeleteRows = false;
            grille.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grille.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grille.MultiSelect = false;

            if (grille.Columns.Contains("Prix"))
                grille.Columns["Prix"].DefaultCellStyle.Format = "C2";

            if (grille.Columns.Contains("Date et heure"))
                grille.Columns["Date et heure"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

            if (grille.Columns.Contains("Date d'arrivée"))
                grille.Columns["Date d'arrivée"].DefaultCellStyle.Format = "yyyy-MM-dd";

            if (grille.Columns.Contains("Date de départ"))
                grille.Columns["Date de départ"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
