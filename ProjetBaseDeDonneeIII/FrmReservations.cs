using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmReservations : Form
    {
        private const int MIN_PERSONNES = 1;
        private const int MAX_PERSONNES = 6;

        private bool modeAjout = false;

        // La ligne créée par AddNew() pendant un ajout.
        private DataRowView ligneEnCours = null;

        public FrmReservations()
        {
            InitializeComponent();

            this.Load -= FrmReservations_Load;
            this.Load += FrmReservations_Load;

            reservationChambreBindingSource.CurrentChanged -=
                reservationChambreBindingSource_CurrentChanged;
            reservationChambreBindingSource.CurrentChanged +=
                reservationChambreBindingSource_CurrentChanged;

            dtpArrivee.ValueChanged -= dtpArrivee_ValueChanged;
            dtpArrivee.ValueChanged += dtpArrivee_ValueChanged;
        }

        // =====================================================
        // CHARGEMENT
        // =====================================================

        private void FrmReservations_Load(object sender, EventArgs e)
        {
            try
            {
                nudPersonnes.Minimum = MIN_PERSONNES;
                nudPersonnes.Maximum = MAX_PERSONNES;
                nudPersonnes.Value = MIN_PERSONNES;

                ChargerClients();
                ChargerChambres();
                ChargerReservations();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur de chargement :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private DataTable RemplirTable(string requete)
        {
            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            {
                connexion.Open();

                using (SqlDataAdapter adaptateur =
                    new SqlDataAdapter(requete, connexion))
                {
                    DataTable table = new DataTable();
                    adaptateur.Fill(table);
                    return table;
                }
            }
        }

        // Clients : nom et numéro.
        private void ChargerClients()
        {
            string requete =
                "SELECT NoClient, " +
                "Prenom + ' ' + Nom + ' (' + " +
                "CAST(NoClient AS varchar(10)) + ')' AS Affichage " +
                "FROM Client " +
                "ORDER BY Nom, Prenom";

            cmbClient.DataSource = RemplirTable(requete);
            cmbClient.DisplayMember = "Affichage";
            cmbClient.ValueMember = "NoClient";
            cmbClient.SelectedIndex = -1;
        }

        // Chambres : numéro, emplacement, décoration et les trois prix.
        private void ChargerChambres()
        {
            string requete =
                "SELECT c.NoChambre, c.Emplacement, c.Decorations, " +
                "t.PrixHaut, t.PrixBas, t.PrixMoyen " +
                "FROM Chambre c " +
                "INNER JOIN TypeChambre t " +
                "ON t.NoTypeChambre = c.NoTypeChambre " +
                "ORDER BY c.NoChambre";

            dgvChambres.DataSource = RemplirTable(requete);
        }

        private void ChargerReservations()
        {
            this.reservationChambreTableAdapter.Fill(
                this.bDB56Projet1CKWDataSet.ReservationChambre);

            reservationChambreBindingSource.ResetBindings(false);

            modeAjout = false;
            ligneEnCours = null;

            AfficherSelection();
            MettreAJourEtat();
        }

        // =====================================================
        // AFFICHAGE DE LA RÉSERVATION SÉLECTIONNÉE
        // =====================================================

        private void reservationChambreBindingSource_CurrentChanged(
            object sender, EventArgs e)
        {
            if (!modeAjout)
                AfficherSelection();

            MettreAJourEtat();
        }

        // Pendant l'ajout, le départ doit rester après l'arrivée.
        private void dtpArrivee_ValueChanged(object sender, EventArgs e)
        {
            if (!modeAjout)
                return;

            if (dtpDepart.Value.Date <= dtpArrivee.Value.Date)
                dtpDepart.Value = dtpArrivee.Value.Date.AddDays(1);
        }

        // Retourne la valeur choisie d'une liste, ou null si rien n'est choisi.
        private int? ValeurChoisie(ComboBox liste)
        {
            if (liste.SelectedValue == null ||
                liste.SelectedValue is DataRowView)
                return null;

            return Convert.ToInt32(liste.SelectedValue);
        }

        // Numéro de la chambre sélectionnée dans la grille, ou null.
        private int? ChambreChoisie()
        {
            if (dgvChambres.SelectedRows.Count == 0)
                return null;

            DataRowView vue =
                dgvChambres.SelectedRows[0].DataBoundItem as DataRowView;

            if (vue == null)
                return null;

            return Convert.ToInt32(vue["NoChambre"]);
        }

        private void SelectionnerChambre(int numero)
        {
            foreach (DataGridViewRow ligne in dgvChambres.Rows)
            {
                DataRowView vue = ligne.DataBoundItem as DataRowView;

                if (vue != null &&
                    Convert.ToInt32(vue["NoChambre"]) == numero)
                {
                    dgvChambres.CurrentCell = ligne.Cells[0];
                    ligne.Selected = true;
                    return;
                }
            }

            dgvChambres.ClearSelection();
        }

        private void AfficherSelection()
        {
            if (modeAjout)
                return;

            DataRowView ligne =
                reservationChambreBindingSource.Current as DataRowView;

            if (ligne == null)
            {
                cmbClient.SelectedIndex = -1;
                dgvChambres.ClearSelection();
                return;
            }

            cmbClient.SelectedValue = Convert.ToInt32(ligne["NoClient"]);

            SelectionnerChambre(Convert.ToInt32(ligne["NoChambre"]));

            dtpArrivee.Value = Convert.ToDateTime(ligne["DateArrivee"]).Date;
            dtpDepart.Value = Convert.ToDateTime(ligne["DateDepart"]).Date;

            int nb = ligne["NbPersonnes"] == DBNull.Value
                ? MIN_PERSONNES
                : Convert.ToInt32(ligne["NbPersonnes"]);

            nudPersonnes.Value =
                Math.Max(MIN_PERSONNES, Math.Min(MAX_PERSONNES, nb));
        }

        // =====================================================
        // ÉTAT DES CONTRÔLES
        // =====================================================

        private void MettreAJourEtat()
        {
            bool aUneLigne =
                reservationChambreBindingSource.Current != null;

            btnAjouter.Enabled = !modeAjout;
            btnEnregistrer.Enabled = modeAjout;
            btnAnnuler.Enabled = modeAjout;
            btnSupprimer.Enabled = !modeAjout && aUneLigne;

            // Les champs ne sont modifiables que pendant l'ajout.
            cmbClient.Enabled = modeAjout;
            dgvChambres.Enabled = modeAjout;
            dtpArrivee.Enabled = modeAjout;
            dtpDepart.Enabled = modeAjout;
            nudPersonnes.Enabled = modeAjout;

            // Empêcher de changer de ligne pendant l'ajout.
            dgvReservations.Enabled = !modeAjout;
        }

        // =====================================================
        // AJOUTER
        // =====================================================

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (modeAjout)
                return;

            modeAjout = true;

            ligneEnCours =
                (DataRowView)reservationChambreBindingSource.AddNew();

            errMessage.Clear();

            cmbClient.SelectedIndex = -1;

            dtpArrivee.Value = DateTime.Today;
            dtpDepart.Value = DateTime.Today.AddDays(1);
            nudPersonnes.Value = MIN_PERSONNES;

            MettreAJourEtat();

            // Aucune chambre choisie au départ.
            dgvChambres.ClearSelection();
            dgvChambres.CurrentCell = null;

            cmbClient.Focus();
        }

        // =====================================================
        // SUPPRIMER
        // =====================================================

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (modeAjout)
            {
                MessageBox.Show(
                    "Enregistrez ou annulez l'opération en cours.");
                return;
            }

            if (reservationChambreBindingSource.Current == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une réservation.");
                return;
            }

            DataRowView ligne =
                (DataRowView)reservationChambreBindingSource.Current;

            int noChambre = Convert.ToInt32(ligne["NoChambre"]);
            DateTime arrivee = Convert.ToDateTime(ligne["DateArrivee"]);

            // On ne peut pas annuler une réservation dont le séjour
            // a déjà commencé.
            if (arrivee.Date < DateTime.Today)
            {
                MessageBox.Show(
                    "Impossible d'annuler cette réservation : " +
                    "la date de début du séjour est antérieure à aujourd'hui.",
                    "Suppression refusée",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer la réservation de la " +
                "chambre " + noChambre + " du " +
                arrivee.ToString("yyyy-MM-dd") + " ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (reponse != DialogResult.Yes)
                return;

            try
            {
                reservationChambreBindingSource.RemoveCurrent();

                this.Validate();
                reservationChambreBindingSource.EndEdit();

                this.tableAdapterManager.UpdateAll(
                    this.bDB56Projet1CKWDataSet);

                MessageBox.Show(
                    "La réservation a été supprimée.",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                ChargerReservations();
            }
        }

        // =====================================================
        // ENREGISTRER
        // =====================================================

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!modeAjout || ligneEnCours == null)
            {
                MessageBox.Show("Aucune opération n'est en cours.");
                return;
            }

            if (!ValiderChamps())
                return;

            try
            {
                int noClient = ValeurChoisie(cmbClient).Value;
                int noChambre = ChambreChoisie().Value;
                DateTime arrivee = dtpArrivee.Value.Date;
                DateTime depart = dtpDepart.Value.Date;

                // Compléter la nouvelle ligne (la clé complète).
                ligneEnCours["NoClient"] = noClient;
                ligneEnCours["NoChambre"] = noChambre;
                ligneEnCours["DateArrivee"] = arrivee;
                ligneEnCours["DateDepart"] = depart;
                ligneEnCours["NbPersonnes"] = (int)nudPersonnes.Value;

                this.Validate();
                reservationChambreBindingSource.EndEdit();

                this.tableAdapterManager.UpdateAll(
                    this.bDB56Projet1CKWDataSet);

                ChargerReservations();
                SelectionnerReservation(noClient, noChambre, arrivee);

                MessageBox.Show(
                    "La réservation a été enregistrée " +
                    "dans la base de données.",
                    "Enregistrement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // =====================================================
        // VALIDATION
        // =====================================================

        private bool ValiderChamps()
        {
            errMessage.Clear();

            if (ValeurChoisie(cmbClient) == null)
            {
                errMessage.SetError(
                    cmbClient, "Choisissez un client.");
                cmbClient.Focus();
                return false;
            }

            int? noChambre = ChambreChoisie();

            if (noChambre == null)
            {
                errMessage.SetError(
                    dgvChambres, "Choisissez une chambre.");
                dgvChambres.Focus();
                return false;
            }

            DateTime arrivee = dtpArrivee.Value.Date;
            DateTime depart = dtpDepart.Value.Date;

            if (arrivee < DateTime.Today)
            {
                errMessage.SetError(
                    dtpArrivee,
                    "La date d'arrivée ne doit pas être antérieure à aujourd'hui.");
                dtpArrivee.Focus();
                return false;
            }

            if (depart <= arrivee)
            {
                errMessage.SetError(
                    dtpDepart,
                    "La date de départ doit être après la date d'arrivée.");
                dtpDepart.Focus();
                return false;
            }

            if (nudPersonnes.Value < MIN_PERSONNES ||
                nudPersonnes.Value > MAX_PERSONNES)
            {
                errMessage.SetError(
                    nudPersonnes,
                    "Le nombre de personnes doit être entre " +
                    MIN_PERSONNES + " et " + MAX_PERSONNES + ".");
                nudPersonnes.Focus();
                return false;
            }

            if (!ChambreDisponible(noChambre.Value, arrivee, depart))
            {
                errMessage.SetError(
                    dgvChambres,
                    "Cette chambre n'est pas disponible pour toute la période choisie.");
                dgvChambres.Focus();
                return false;
            }

            return true;
        }

        // La chambre est libre si aucune réservation ne chevauche la période.
        private bool ChambreDisponible(
            int noChambre, DateTime arrivee, DateTime depart)
        {
            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            {
                connexion.Open();

                string requete =
                    "SELECT COUNT(*) FROM ReservationChambre " +
                    "WHERE NoChambre = @NoChambre " +
                    "AND DateArrivee < @Depart " +
                    "AND DateDepart > @Arrivee";

                using (SqlCommand commande =
                    new SqlCommand(requete, connexion))
                {
                    commande.Parameters.Add(
                        "@NoChambre", SqlDbType.Int).Value = noChambre;
                    commande.Parameters.Add(
                        "@Arrivee", SqlDbType.DateTime).Value = arrivee;
                    commande.Parameters.Add(
                        "@Depart", SqlDbType.DateTime).Value = depart;

                    return Convert.ToInt32(
                        commande.ExecuteScalar()) == 0;
                }
            }
        }

        // =====================================================
        // ANNULER
        // =====================================================

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            reservationChambreBindingSource.CancelEdit();
            bDB56Projet1CKWDataSet.ReservationChambre.RejectChanges();

            reservationChambreBindingSource.ResetBindings(false);

            errMessage.Clear();

            ChargerReservations();

            MessageBox.Show(
                "Les modifications non enregistrées ont été annulées.",
                "Annulation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // =====================================================
        // SÉLECTIONNER UNE RÉSERVATION APRÈS UNE OPÉRATION
        // =====================================================

        private void SelectionnerReservation(
            int noClient, int noChambre, DateTime arrivee)
        {
            for (int i = 0;
                 i < reservationChambreBindingSource.Count;
                 i++)
            {
                DataRowView vue =
                    reservationChambreBindingSource[i] as DataRowView;

                if (vue != null &&
                    Convert.ToInt32(vue["NoClient"]) == noClient &&
                    Convert.ToInt32(vue["NoChambre"]) == noChambre &&
                    Convert.ToDateTime(vue["DateArrivee"]).Date == arrivee)
                {
                    reservationChambreBindingSource.Position = i;
                    break;
                }
            }

            AfficherSelection();
        }
    }
}