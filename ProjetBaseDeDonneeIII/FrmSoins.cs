
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmSoins : Form
    {
        public Regex exprMontant { get; }

        private bool modeAjout = false;
        private bool modeModification = false;

        public FrmSoins()
        {
            InitializeComponent();

            this.Load += FrmSoins_Load;


            char point = Convert.ToChar(
                CultureInfo.CurrentCulture.NumberFormat
                    .NumberDecimalSeparator);

            exprMontant = new Regex(
                "^[0-9]{1,6}(" +
                Regex.Escape(point.ToString()) +
                "[0-9]{1,2})?$");
        }




        private void FrmSoins_Load(object sender, EventArgs e)
        {
            ChargerTypesSoins();

            this.soinTableAdapter.Fill(
                this.bDB56Projet1CKWDataSet.Soin);

            // Relier le ComboBox à la colonne NoTypeSoin du soin courant.
            cmbTypeSoin.DataBindings.Clear();

            cmbTypeSoin.DataBindings.Add(
                "SelectedValue",
                soinBindingSource,
                "NoTypeSoin",
                true,
                DataSourceUpdateMode.OnPropertyChanged);

            txtNoSoin.ReadOnly = true;
            txtDuree.ReadOnly = true;

            soinBindingSource.ResetBindings(false);
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



        private int ObtenirProchainNumero()
        {
            int numeroMax = 0;

            foreach (DataRow ligne in
                bDB56Projet1CKWDataSet.Soin.Rows)
            {
                if (ligne.RowState != DataRowState.Deleted)
                {
                    int numero = Convert.ToInt32(
                        ligne["NoSoin"]);

                    if (numero > numeroMax)
                        numeroMax = numero;
                }
            }

            return numeroMax + 1;
        }

        private void soinBindingNavigatorSaveItem_Click(
            object sender, EventArgs e)
        {
            btnEnregistrer_Click(sender, e);
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (modeAjout || modeModification)
                return;

            modeAjout = true;

            DataRowView nouvelleLigne =
                (DataRowView)soinBindingSource.AddNew();

            nouvelleLigne["NoSoin"] = ObtenirProchainNumero();
            nouvelleLigne["Duree"] = 60;

            txtNoSoin.ReadOnly = true;
            txtDuree.ReadOnly = true;
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

            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer le soin " +
                numero + " ?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (reponse != DialogResult.Yes)
                return;

            // Vérifier les relations avant la suppression.
            try
            {
                using (SqlConnection connexion =
                    new SqlConnection(ConnexionBD.Chaine))
                {
                    connexion.Open();

                    string requete =
                        @"SELECT
                            CASE WHEN EXISTS
                            (SELECT 1 FROM AssistantSoin WHERE NoSoin = @NoSoin)
                            OR EXISTS
                            (SELECT 1 FROM PlanifSoin WHERE NoSoin = @NoSoin)
                            THEN 1 ELSE 0 END";

                    using (SqlCommand commande =
                        new SqlCommand(requete, connexion))
                    {
                        commande.Parameters.Add(
                            "@NoSoin",
                            SqlDbType.Int).Value = numero;

                        int utilise = Convert.ToInt32(
                            commande.ExecuteScalar());

                        if (utilise == 1)
                        {
                            MessageBox.Show(
                                "Impossible de supprimer ce soin. " +
                                "Il est offert par un assistant ou " +
                                "utilisé dans une planification.",
                                "Suppression refusée",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                soinBindingSource.RemoveCurrent();

                this.Validate();
                soinBindingSource.EndEdit();

                this.tableAdapterManager.UpdateAll(
                    this.bDB56Projet1CKWDataSet);

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

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!modeAjout && !modeModification)
            {
                MessageBox.Show(
                    "Aucune opération n'est en cours.");
                return;
            }

            if (!ValiderPrix())
                return;

            try
            {
                // La durée est toujours de 60 minutes.
                if (soinBindingSource.Current is DataRowView ligne)
                    ligne["Duree"] = 60;

                this.Validate();
                soinBindingSource.EndEdit();

                this.tableAdapterManager.UpdateAll(
                    this.bDB56Projet1CKWDataSet);

                modeAjout = false;
                modeModification = false;

                ChargerSoins();

                MessageBox.Show(
                    "Les modifications ont été enregistrées " +
                    "dans la base de données.",
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

        private bool ValiderPrix()
        {
            errMessage.Clear();

            if (!exprMontant.IsMatch(txtPrix.Text))
            {
                errMessage.SetError(
                    txtPrix,
                    "Le prix n'est pas dans un format valide.");
                txtPrix.Focus();
                return false;
            }

            decimal prix;

            if (!decimal.TryParse(
                txtPrix.Text,
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

            return true;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            bDB56Projet1CKWDataSet.Soin.RejectChanges();

            soinBindingSource.CancelEdit();
            soinBindingSource.ResetBindings(false);

            modeAjout = false;
            modeModification = false;

            ChargerSoins();

            MessageBox.Show(
                "Les modifications non enregistrées ont été annulées.",
                "Annulation",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        

        private void ChargerSoins()
        {
            this.soinTableAdapter.Fill(
                this.bDB56Projet1CKWDataSet.Soin);

            soinBindingSource.ResetBindings(false);

            modeAjout = false;
            modeModification = false;
        }
    }
}
