
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmSoins : Form
    {
        private bool modeAjout = false;
        private bool modeModification = false;

        private readonly Regex exprMontant;

        public FrmSoins()
        {
            InitializeComponent();

            char separateur = Convert.ToChar(
                CultureInfo.CurrentCulture.NumberFormat
                    .NumberDecimalSeparator);

            exprMontant = new Regex(
                @"^[0-9]{1,6}(" +
                Regex.Escape(separateur.ToString()) +
                @"[0-9]{1,2})?$");
        }

        private void FrmSoins_Load(object sender, EventArgs e)
        {
            ChargerTypesSoins();
            ChargerSoins();

            txtNoSoin.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            txtDuree.DataBindings.Clear();
            txtPrix.DataBindings.Clear();
            cmbTypeSoin.DataBindings.Clear();

            txtNoSoin.DataBindings.Add(
                "Text", soinBindingSource, "NoSoin",
                true, DataSourceUpdateMode.OnPropertyChanged);

            txtDescription.DataBindings.Add(
                "Text", soinBindingSource, "Description",
                true, DataSourceUpdateMode.OnPropertyChanged);

            txtDuree.DataBindings.Add(
                "Text", soinBindingSource, "Duree",
                true, DataSourceUpdateMode.OnPropertyChanged);

            txtPrix.DataBindings.Add(
                "Text", soinBindingSource, "Prix",
                true, DataSourceUpdateMode.OnPropertyChanged,
                "0.00");

            cmbTypeSoin.DataBindings.Add(
                "SelectedValue", soinBindingSource, "NoTypeSoin",
                true, DataSourceUpdateMode.OnPropertyChanged);

            txtDescription.TextChanged +=
                txtDescription_TextChanged;

            txtPrix.TextChanged += txtPrix_TextChanged;

            cmbTypeSoin.SelectionChangeCommitted +=
                cmbTypeSoin_SelectionChangeCommitted;

            soinBindingSource.CurrentChanged +=
                soinBindingSource_CurrentChanged;

            MettreAJourControles();
        }

        private void ChargerTypesSoins()
        {
            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            {
                connexion.Open();

                string requete =
                    "SELECT NoTypeSoin, Description " +
                    "FROM TypeSoin ORDER BY Description";

                using (SqlDataAdapter adaptateur =
                    new SqlDataAdapter(requete, connexion))
                {
                    DataTable tableTypes = new DataTable();
                    adaptateur.Fill(tableTypes);

                    cmbTypeSoin.DataSource = tableTypes;
                    cmbTypeSoin.DisplayMember = "Description";
                    cmbTypeSoin.ValueMember = "NoTypeSoin";
                }
            }
        }

        private void ChargerSoins()
        {
            soinTableAdapter.Fill(
                bDB56Projet1CKWDataSet.Soin);

            soinBindingSource.ResetBindings(false);

            modeAjout = false;
            modeModification = false;

            errMessage.Clear();

            MettreAJourControles();
        }

        private int ObtenirProchainNumero()
        {
            int maximum = 0;

            foreach (DataRow ligne in
                bDB56Projet1CKWDataSet.Soin.Rows)
            {
                if (ligne.RowState != DataRowState.Deleted)
                {
                    int numero = Convert.ToInt32(
                        ligne["NoSoin"]);

                    if (numero > maximum)
                        maximum = numero;
                }
            }

            return maximum + 1;
        }

        private void MettreAJourControles()
        {
            txtNoSoin.ReadOnly = true;
            txtDuree.ReadOnly = true;

            txtDescription.ReadOnly = false;
            txtPrix.ReadOnly = false;

            bool operationEnCours = modeAjout || modeModification;

            btnAjouter.Enabled = !operationEnCours;
            btnSupprimer.Enabled = !operationEnCours;
            btnEnregistrer.Enabled = operationEnCours;
            btnAnnuler.Enabled = operationEnCours;

            cmbTypeSoin.Enabled = modeAjout || !operationEnCours;

            // Pendant une modification, les champs doivent rester
            // accessibles afin de permettre l'édition.
            if (modeModification)
            {
                txtDescription.ReadOnly = false;
                txtPrix.ReadOnly = false;
                cmbTypeSoin.Enabled = true;
            }

            if (modeAjout)
            {
                txtDescription.ReadOnly = false;
                txtPrix.ReadOnly = false;
                cmbTypeSoin.Enabled = true;
            }

            if (!modeAjout && !modeModification)
            {
                txtDescription.ReadOnly = false;
                txtPrix.ReadOnly = false;
                cmbTypeSoin.Enabled = true;
            }
        }

        private void soinBindingSource_CurrentChanged(
            object sender, EventArgs e)
        {
            if (!modeAjout && !modeModification)
                MettreAJourControles();
        }

        private void txtDescription_TextChanged(
            object sender, EventArgs e)
        {
            if (!modeAjout && txtDescription.Focused)
            {
                modeModification = true;
                MettreAJourControles();
            }
        }

        private void txtPrix_TextChanged(
            object sender, EventArgs e)
        {
            if (!modeAjout && txtPrix.Focused)
            {
                modeModification = true;
                MettreAJourControles();
            }
        }

        private void cmbTypeSoin_SelectionChangeCommitted(
            object sender, EventArgs e)
        {
            if (!modeAjout)
            {
                modeModification = true;
                MettreAJourControles();
            }
        }

        private void soinBindingNavigatorSaveItem_Click(
            object sender, EventArgs e)
        {
            btnEnregistrer_Click(sender, e);
        }


        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (modeAjout || modeModification)
            {
                MessageBox.Show(
                    "Enregistrez ou annulez l'opération en cours.");
                return;
            }

            if (cmbTypeSoin.Items.Count == 0 ||
                cmbTypeSoin.SelectedValue == null ||
                cmbTypeSoin.SelectedValue is DataRowView)
            {
                MessageBox.Show(
                    "Aucun type de soin n'est disponible.");
                return;
            }

            int prochainNumero = ObtenirProchainNumero();

            modeAjout = true;
            modeModification = false;

            DataRowView nouvelleLigne =
                (DataRowView)soinBindingSource.AddNew();

            nouvelleLigne["NoSoin"] = prochainNumero;
            nouvelleLigne["Description"] = "";
            nouvelleLigne["Duree"] = 60;
            nouvelleLigne["Prix"] = 0m;
            nouvelleLigne["NoTypeSoin"] =
                Convert.ToInt32(cmbTypeSoin.SelectedValue);

            soinBindingSource.ResetBindings(false);

            errMessage.Clear();
            MettreAJourControles();

            txtDescription.Clear();
            txtPrix.Clear();
            txtDescription.Focus();
        }


        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!modeAjout && !modeModification)
            {
                MessageBox.Show(
                    "Aucune opération n'est en cours.");
                return;
            }

            this.Validate();
            soinBindingSource.EndEdit();

            if (!ValiderChamps())
                return;

            try
            {
                DataRowView ligne =
                    soinBindingSource.Current as DataRowView;

                if (ligne == null)
                {
                    MessageBox.Show(
                        "Aucun soin n'est sélectionné.");
                    return;
                }

                // La durée est fixée à 60 minutes à l'ajout.
                // En modification, elle ne doit jamais changer.
                if (modeAjout)
                    ligne["Duree"] = 60;

                soinTableAdapter.Update(
                    bDB56Projet1CKWDataSet.Soin);

                ChargerSoins();

                MessageBox.Show(
                    "Le soin a été enregistré dans la base de données.",
                    "Enregistrement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValiderChamps()
        {
            errMessage.Clear();

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errMessage.SetError(
                    txtDescription,
                    "La description du soin est obligatoire.");
                txtDescription.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrix.Text))
            {
                errMessage.SetError(
                    txtPrix,
                    "Le prix du soin est obligatoire.");
                txtPrix.Focus();
                return false;
            }

            if (!exprMontant.IsMatch(txtPrix.Text.Trim()))
            {
                errMessage.SetError(
                    txtPrix,
                    "Le prix doit être un montant valide.");
                txtPrix.Focus();
                return false;
            }

            decimal prix;

            if (!decimal.TryParse(
                txtPrix.Text.Trim(),
                NumberStyles.Number,
                CultureInfo.CurrentCulture,
                out prix))
            {
                errMessage.SetError(
                    txtPrix,
                    "Veuillez saisir un prix valide.");
                txtPrix.Focus();
                return false;
            }

            if (prix <= 0 || prix > 999999.99m)
            {
                errMessage.SetError(
                    txtPrix,
                    "Le prix doit être entre 0,01 et 999999,99.");
                txtPrix.Focus();
                return false;
            }

            if (cmbTypeSoin.SelectedValue == null ||
                cmbTypeSoin.SelectedValue is DataRowView)
            {
                errMessage.SetError(
                    cmbTypeSoin,
                    "Le type de soin est obligatoire.");
                cmbTypeSoin.Focus();
                return false;
            }

            return true;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (modeAjout || modeModification)
            {
                MessageBox.Show(
                    "Enregistrez ou annulez l'opération en cours.");
                return;
            }

            if (soinBindingSource.Current == null)
            {
                MessageBox.Show(
                    "Veuillez sélectionner un soin.");
                return;
            }

            DataRowView ligne =
                (DataRowView)soinBindingSource.Current;

            int numero = Convert.ToInt32(ligne["NoSoin"]);
            string description = ligne["Description"].ToString();

            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer le soin « " +
                description + " » ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (reponse != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection connexion =
                    new SqlConnection(ConnexionBD.Chaine))
                {
                    connexion.Open();

                    string requete =
                        @"SELECT CASE
                            WHEN EXISTS (
                                SELECT 1
                                FROM AssistantSoin
                                WHERE NoSoin = @NoSoin
                            )
                            OR EXISTS (
                                SELECT 1
                                FROM PlanifSoin
                                WHERE NoSoin = @NoSoin
                            )
                            THEN 1 ELSE 0 END";

                    using (SqlCommand commande =
                        new SqlCommand(requete, connexion))
                    {
                        commande.Parameters.Add(
                            "@NoSoin", SqlDbType.Int).Value = numero;

                        int utilise = Convert.ToInt32(
                            commande.ExecuteScalar());

                        if (utilise == 1)
                        {
                            MessageBox.Show(
                                "Impossible de supprimer ce soin, car il est " +
                                "offert par un assistant ou utilisé dans " +
                                "une planification.",
                                "Suppression refusée",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                soinBindingSource.RemoveCurrent();
                soinBindingSource.EndEdit();

                soinTableAdapter.Update(
                    bDB56Projet1CKWDataSet.Soin);

                ChargerSoins();

                MessageBox.Show(
                    "Le soin a été supprimé.",
                    "Suppression",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression :\n" +
                    ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                ChargerSoins();
            }
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            bDB56Projet1CKWDataSet.Soin.RejectChanges();
            soinBindingSource.CancelEdit();
            soinBindingSource.ResetBindings(false);

            errMessage.Clear();

            ChargerSoins();

            MessageBox.Show(
                "Les modifications non enregistrées ont été annulées.",
                "Annulation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
