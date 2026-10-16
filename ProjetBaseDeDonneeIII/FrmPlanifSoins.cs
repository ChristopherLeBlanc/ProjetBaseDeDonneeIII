using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmPlanifSoins : Form
    {
        private const int HEURE_DEBUT = 8;
        private const int HEURE_FIN = 17;

        private bool modeAjout = false;
        private bool enChargement = false;

        // La ligne créée par AddNew() pendant un ajout.
        private DataRowView ligneEnCours = null;

        public FrmPlanifSoins()
        {
            InitializeComponent();

            this.Load -= FrmPlanifSoins_Load;
            this.Load += FrmPlanifSoins_Load;

            cmbSoin.SelectedIndexChanged -= cmbSoin_SelectedIndexChanged;
            cmbSoin.SelectedIndexChanged += cmbSoin_SelectedIndexChanged;

            planifSoinBindingSource.CurrentChanged -=
                planifSoinBindingSource_CurrentChanged;
            planifSoinBindingSource.CurrentChanged +=
                planifSoinBindingSource_CurrentChanged;
        }

        // =====================================================
        // CHARGEMENT
        // =====================================================

        private void FrmPlanifSoins_Load(object sender, EventArgs e)
        {
            try
            {
                ChargerPersonnes();
                ChargerListeSoins();
                ChargerHeures();

                ChargerPlanifs();
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

        private DataTable RemplirTable(
            string requete, params SqlParameter[] parametres)
        {
            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            {
                connexion.Open();

                using (SqlDataAdapter adaptateur =
                    new SqlDataAdapter(requete, connexion))
                {
                    adaptateur.SelectCommand.Parameters.AddRange(parametres);

                    DataTable table = new DataTable();
                    adaptateur.Fill(table);
                    return table;
                }
            }
        }

        // Clients et invités : nom et numéro.
        private void ChargerPersonnes()
        {
            string requete =
                "SELECT NoClient AS NoPersonne, " +
                "Prenom + ' ' + Nom + ' (' + " +
                "CAST(NoClient AS varchar(10)) + ')' AS Affichage " +
                "FROM Client " +
                "UNION ALL " +
                "SELECT NoInvite, " +
                "NomPrenom + ' (' + " +
                "CAST(NoInvite AS varchar(10)) + ')' " +
                "FROM Invite " +
                "ORDER BY Affichage";

            enChargement = true;

            cmbPersonne.DataSource = RemplirTable(requete);
            cmbPersonne.DisplayMember = "Affichage";
            cmbPersonne.ValueMember = "NoPersonne";
            cmbPersonne.SelectedIndex = -1;

            enChargement = false;
        }

        // Soins : numéro et description.
        // Soins : numéro et description.
        private void ChargerListeSoins()
        {
            string requete =
                "SELECT NoSoin, " +
                "CAST(NoSoin AS varchar(10)) + ' - ' + Description AS Affichage " +
                "FROM Soin " +
                "ORDER BY NoSoin";

            enChargement = true;

            cmbSoin.DataSource = RemplirTable(requete);
            cmbSoin.DisplayMember = "Affichage";
            cmbSoin.ValueMember = "NoSoin";
            cmbSoin.SelectedIndex = -1;

            enChargement = false;
        }

        // Assistants (numéro, prénom, nom) qui offrent le soin choisi.
        private void ChargerAssistants(int noSoin)
        {
            string requete =
                "SELECT a.NoAssistant, " +
                "CAST(a.NoAssistant AS varchar(10)) + ' - ' + " +
                "a.Prenom + ' ' + a.Nom AS Affichage " +
                "FROM Assistant a " +
                "INNER JOIN AssistantSoin s " +
                "ON s.NoAssistant = a.NoAssistant " +
                "WHERE s.NoSoin = @NoSoin " +
                "ORDER BY a.Nom, a.Prenom";

            SqlParameter p = new SqlParameter("@NoSoin", SqlDbType.Int);
            p.Value = noSoin;

            cmbAssistant.DataSource = RemplirTable(requete, p);
            cmbAssistant.DisplayMember = "Affichage";
            cmbAssistant.ValueMember = "NoAssistant";
            cmbAssistant.SelectedIndex = -1;
        }

        // Heures de 8 h à 17 h.
        private void ChargerHeures()
        {
            cmbHeure.Items.Clear();

            for (int h = HEURE_DEBUT; h <= HEURE_FIN; h++)
                cmbHeure.Items.Add(h.ToString("00") + " h");

            cmbHeure.SelectedIndex = -1;
        }

        private void ChargerPlanifs()
        {
            this.planifSoinTableAdapter.Fill(
                this.bDB56Projet1CKWDataSet.PlanifSoin);

            planifSoinBindingSource.ResetBindings(false);

            modeAjout = false;
            ligneEnCours = null;

            AfficherSelection();
            MettreAJourEtat();
        }

        // =====================================================
        // AFFICHAGE DE LA RÉSERVATION SÉLECTIONNÉE
        // =====================================================

        private void planifSoinBindingSource_CurrentChanged(
            object sender, EventArgs e)
        {
            if (!modeAjout)
                AfficherSelection();

            MettreAJourEtat();
        }

        private void cmbSoin_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            if (enChargement)
                return;

            int? noSoin = ValeurChoisie(cmbSoin);

            if (noSoin == null)
            {
                cmbAssistant.DataSource = null;
                return;
            }

            ChargerAssistants(noSoin.Value);
        }

        // Retourne la valeur choisie d'une liste, ou null si rien n'est choisi.
        private int? ValeurChoisie(ComboBox liste)
        {
            if (liste.SelectedValue == null ||
                liste.SelectedValue is DataRowView)
                return null;

            return Convert.ToInt32(liste.SelectedValue);
        }

        private void AfficherSelection()
        {
            if (modeAjout)
                return;

            DataRowView ligne =
                planifSoinBindingSource.Current as DataRowView;

            if (ligne == null)
            {
                cmbPersonne.SelectedIndex = -1;
                cmbSoin.SelectedIndex = -1;
                cmbAssistant.DataSource = null;
                cmbHeure.SelectedIndex = -1;
                return;
            }

            cmbPersonne.SelectedValue =
                Convert.ToInt32(ligne["NoPersonne"]);

            // Charge aussi la liste des assistants de ce soin.
            cmbSoin.SelectedValue =
                Convert.ToInt32(ligne["NoSoin"]);

            cmbAssistant.SelectedValue =
                Convert.ToInt32(ligne["NoAssistant"]);

            DateTime dateHeure = Convert.ToDateTime(ligne["DateHeure"]);

            dtpDate.Value = dateHeure.Date;

            int index = dateHeure.Hour - HEURE_DEBUT;

            cmbHeure.SelectedIndex =
                (index >= 0 && index < cmbHeure.Items.Count)
                    ? index : -1;
        }

        // =====================================================
        // ÉTAT DES CONTRÔLES
        // =====================================================

        private void MettreAJourEtat()
        {
            bool aUneLigne = planifSoinBindingSource.Current != null;

            btnAjouter.Enabled = !modeAjout;
            btnEnregistrer.Enabled = modeAjout;
            btnAnnuler.Enabled = modeAjout;
            btnSupprimer.Enabled = !modeAjout && aUneLigne;

            // Les champs ne sont modifiables que pendant l'ajout.
            cmbPersonne.Enabled = modeAjout;
            cmbSoin.Enabled = modeAjout;
            cmbAssistant.Enabled = modeAjout;
            dtpDate.Enabled = modeAjout;
            cmbHeure.Enabled = modeAjout;

            // Empêcher de changer de ligne pendant l'ajout.
            dgvPlanifSoins.Enabled = !modeAjout;
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
                (DataRowView)planifSoinBindingSource.AddNew();

            errMessage.Clear();

            cmbPersonne.SelectedIndex = -1;
            cmbSoin.SelectedIndex = -1;
            cmbAssistant.DataSource = null;
            cmbHeure.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;

            MettreAJourEtat();
            cmbPersonne.Focus();
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

            if (planifSoinBindingSource.Current == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner une réservation.");
                return;
            }

            DataRowView ligne =
                (DataRowView)planifSoinBindingSource.Current;

            DateTime dateHeure = Convert.ToDateTime(ligne["DateHeure"]);

            // On ne peut pas supprimer un soin déjà offert.
            if (dateHeure <= DateTime.Now)
            {
                MessageBox.Show(
                    "Impossible de supprimer ce soin : il a déjà été offert.",
                    "Suppression refusée",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer cette réservation du " +
                dateHeure.ToString("yyyy-MM-dd HH:mm") + " ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (reponse != DialogResult.Yes)
                return;

            try
            {
                planifSoinBindingSource.RemoveCurrent();

                this.Validate();
                planifSoinBindingSource.EndEdit();

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

                ChargerPlanifs();
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
                int noPersonne = ValeurChoisie(cmbPersonne).Value;
                int noAssistant = ValeurChoisie(cmbAssistant).Value;
                DateTime dateHeure = DateReservation();

                // Compléter la nouvelle ligne (la clé complète).
                ligneEnCours["NoPersonne"] = noPersonne;
                ligneEnCours["NoAssistant"] = noAssistant;
                ligneEnCours["DateHeure"] = dateHeure;
                ligneEnCours["NoSoin"] = ValeurChoisie(cmbSoin).Value;

                this.Validate();
                planifSoinBindingSource.EndEdit();

                this.tableAdapterManager.UpdateAll(
                    this.bDB56Projet1CKWDataSet);

                ChargerPlanifs();
                SelectionnerReservation(
                    noPersonne, noAssistant, dateHeure);

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

        private DateTime DateReservation()
        {
            int heure = HEURE_DEBUT + cmbHeure.SelectedIndex;
            return dtpDate.Value.Date.AddHours(heure);
        }

        // =====================================================
        // VALIDATION
        // =====================================================

        private bool ValiderChamps()
        {
            errMessage.Clear();

            if (ValeurChoisie(cmbPersonne) == null)
            {
                errMessage.SetError(
                    cmbPersonne, "Choisissez un client ou un invité.");
                cmbPersonne.Focus();
                return false;
            }

            if (ValeurChoisie(cmbSoin) == null)
            {
                errMessage.SetError(
                    cmbSoin, "Choisissez un soin.");
                cmbSoin.Focus();
                return false;
            }

            if (ValeurChoisie(cmbAssistant) == null)
            {
                errMessage.SetError(
                    cmbAssistant, "Choisissez un assistant.");
                cmbAssistant.Focus();
                return false;
            }

            if (cmbHeure.SelectedIndex < 0)
            {
                errMessage.SetError(
                    cmbHeure,
                    "Choisissez l'heure de la réservation.");
                cmbHeure.Focus();
                return false;
            }

            DateTime date = dtpDate.Value.Date;

            if (date < DateTime.Today)
            {
                errMessage.SetError(
                    dtpDate,
                    "La date ne doit pas être antérieure à aujourd'hui.");
                dtpDate.Focus();
                return false;
            }

            if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday)
            {
                errMessage.SetError(
                    dtpDate,
                    "La date ne peut pas être un samedi ou un dimanche.");
                dtpDate.Focus();
                return false;
            }

            if (AssistantOccupe(
                    ValeurChoisie(cmbAssistant).Value,
                    DateReservation()))
            {
                errMessage.SetError(
                    cmbAssistant,
                    "Cet assistant a déjà un soin à cette date et heure.");
                cmbAssistant.Focus();
                return false;
            }

            return true;
        }

        // Un assistant ne peut pas donner deux soins à la même date/heure.
        private bool AssistantOccupe(int noAssistant, DateTime dateHeure)
        {
            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            {
                connexion.Open();

                string requete =
                    "SELECT COUNT(*) FROM PlanifSoin " +
                    "WHERE NoAssistant = @NoAssistant " +
                    "AND DateHeure = @DateHeure";

                using (SqlCommand commande =
                    new SqlCommand(requete, connexion))
                {
                    commande.Parameters.Add(
                        "@NoAssistant", SqlDbType.Int).Value = noAssistant;
                    commande.Parameters.Add(
                        "@DateHeure", SqlDbType.DateTime).Value = dateHeure;

                    return Convert.ToInt32(
                        commande.ExecuteScalar()) > 0;
                }
            }
        }

        // =====================================================
        // ANNULER
        // =====================================================

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            planifSoinBindingSource.CancelEdit();
            bDB56Projet1CKWDataSet.PlanifSoin.RejectChanges();

            planifSoinBindingSource.ResetBindings(false);

            errMessage.Clear();

            ChargerPlanifs();

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
            int noPersonne, int noAssistant, DateTime dateHeure)
        {
            for (int i = 0; i < planifSoinBindingSource.Count; i++)
            {
                DataRowView vue =
                    planifSoinBindingSource[i] as DataRowView;

                if (vue != null &&
                    Convert.ToInt32(vue["NoPersonne"]) == noPersonne &&
                    Convert.ToInt32(vue["NoAssistant"]) == noAssistant &&
                    Convert.ToDateTime(vue["DateHeure"]) == dateHeure)
                {
                    planifSoinBindingSource.Position = i;
                    break;
                }
            }

            AfficherSelection();
        }
    }
}