
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmTypesChambres : Form
    {
        private DataTable tableTypes = new DataTable();
        private DataTable tableChambres = new DataTable();

        private bool modeAjoutType = false;
        private bool modeModificationType = false;
        private bool modeAjoutChambre = false;
        private bool modeModificationChambre = false;
        private bool chargement = false;

        private int noTypeOriginal = -1;
        private int noChambreOriginal = -1;

        public FrmTypesChambres()
        {
            InitializeComponent();

            Load -= FrmTypesChambres_Load;
            Load += FrmTypesChambres_Load;
        }

        // =====================================================
        // CHARGEMENT
        // =====================================================

        private void FrmTypesChambres_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurerTableaux();
                ChargerTypes();
                ChargerChambres();

                MettreAJourEtatType();
                MettreAJourEtatChambre();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur au chargement :\n" + ex.Message,
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ConfigurerTableaux()
        {
            dgvTypes.AutoGenerateColumns = true;
            dgvTypes.ReadOnly = true;
            dgvTypes.AllowUserToAddRows = false;
            dgvTypes.AllowUserToDeleteRows = false;
            dgvTypes.MultiSelect = false;
            dgvTypes.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvChambres.AutoGenerateColumns = true;
            dgvChambres.ReadOnly = true;
            dgvChambres.AllowUserToAddRows = false;
            dgvChambres.AllowUserToDeleteRows = false;
            dgvChambres.MultiSelect = false;
            dgvChambres.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvTypes.SelectionChanged -= dgvTypes_SelectionChanged;
            dgvTypes.SelectionChanged += dgvTypes_SelectionChanged;

            dgvChambres.SelectionChanged -= dgvChambres_SelectionChanged;
            dgvChambres.SelectionChanged += dgvChambres_SelectionChanged;
        }

        private void ChargerTypes()
        {
            chargement = true;

            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            using (SqlDataAdapter adaptateur =
                new SqlDataAdapter(
                    "SELECT NoTypeChambre, Description, " +
                    "PrixHaut, PrixBas, PrixMoyen " +
                    "FROM TypeChambre ORDER BY NoTypeChambre",
                    connexion))
            {
                tableTypes = new DataTable();
                adaptateur.Fill(tableTypes);
            }

            dgvTypes.DataSource = tableTypes;

            if (dgvTypes.Columns.Contains("NoTypeChambre"))
                dgvTypes.Columns["NoTypeChambre"].HeaderText = "No du type";

            if (dgvTypes.Columns.Contains("Description"))
                dgvTypes.Columns["Description"].HeaderText = "Description";

            if (dgvTypes.Columns.Contains("PrixHaut"))
                dgvTypes.Columns["PrixHaut"].HeaderText = "Prix haut";

            if (dgvTypes.Columns.Contains("PrixBas"))
                dgvTypes.Columns["PrixBas"].HeaderText = "Prix bas";

            if (dgvTypes.Columns.Contains("PrixMoyen"))
                dgvTypes.Columns["PrixMoyen"].HeaderText = "Prix moyen";

            chargement = false;

            if (dgvTypes.Rows.Count > 0)
            {
                dgvTypes.Rows[0].Selected = true;
                AfficherTypeSelectionne();
            }
            else
            {
                ViderChampsType();
                ChargerChambres(-1);
            }
        }

        private void ChargerChambres()
        {
            int noType = ObtenirNoTypeSelectionne();
            ChargerChambres(noType);
        }

        private void ChargerChambres(int noType)
        {
            chargement = true;

            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            using (SqlDataAdapter adaptateur =
                new SqlDataAdapter(
                    "SELECT NoChambre, Emplacement, Decorations, " +
                    "NoTypeChambre FROM Chambre " +
                    "WHERE NoTypeChambre = @noType " +
                    "ORDER BY NoChambre", connexion))
            {
                adaptateur.SelectCommand.Parameters.Add(
                    "@noType", SqlDbType.Int).Value = noType;

                tableChambres = new DataTable();
                adaptateur.Fill(tableChambres);
            }

            dgvChambres.DataSource = tableChambres;

            if (dgvChambres.Columns.Contains("NoChambre"))
                dgvChambres.Columns["NoChambre"].HeaderText = "No chambre";

            if (dgvChambres.Columns.Contains("Emplacement"))
                dgvChambres.Columns["Emplacement"].HeaderText = "Emplacement";

            if (dgvChambres.Columns.Contains("Decorations"))
                dgvChambres.Columns["Decorations"].HeaderText = "Décoration";

            if (dgvChambres.Columns.Contains("NoTypeChambre"))
                dgvChambres.Columns["NoTypeChambre"].Visible = false;

            chargement = false;

            if (dgvChambres.Rows.Count > 0)
            {
                dgvChambres.Rows[0].Selected = true;
                AfficherChambreSelectionnee();
            }
            else
            {
                ViderChampsChambre();
            }

            MettreAJourEtatChambre();
        }

        private int ObtenirNoTypeSelectionne()
        {
            if (dgvTypes.CurrentRow == null ||
                dgvTypes.CurrentRow.IsNewRow)
                return -1;

            object valeur =
                dgvTypes.CurrentRow.Cells["NoTypeChambre"].Value;

            if (valeur == null || valeur == DBNull.Value)
                return -1;

            return Convert.ToInt32(valeur);
        }

        private int ObtenirNoChambreSelectionnee()
        {
            if (dgvChambres.CurrentRow == null ||
                dgvChambres.CurrentRow.IsNewRow)
                return -1;

            object valeur =
                dgvChambres.CurrentRow.Cells["NoChambre"].Value;

            if (valeur == null || valeur == DBNull.Value)
                return -1;

            return Convert.ToInt32(valeur);
        }

        // =====================================================
        // SÉLECTION DES TYPES
        // =====================================================

        private void dgvTypes_SelectionChanged(object sender, EventArgs e)
        {
            if (chargement || modeAjoutType ||
                modeModificationType || modeAjoutChambre ||
                modeModificationChambre)
                return;

            AfficherTypeSelectionne();
            ChargerChambres();
            MettreAJourEtatType();
            MettreAJourEtatChambre();
        }

        private void AfficherTypeSelectionne()
        {
            if (dgvTypes.CurrentRow == null ||
                dgvTypes.CurrentRow.IsNewRow)
            {
                ViderChampsType();
                return;
            }

            DataGridViewRow ligne = dgvTypes.CurrentRow;

            txtNoType.Text =
                Convert.ToString(ligne.Cells["NoTypeChambre"].Value);

            txtDescription.Text =
                Convert.ToString(ligne.Cells["Description"].Value);

            txtPrixHaut.Text =
                Convert.ToString(ligne.Cells["PrixHaut"].Value);

            txtPrixBas.Text =
                Convert.ToString(ligne.Cells["PrixBas"].Value);

            txtPrixMoyen.Text =
                Convert.ToString(ligne.Cells["PrixMoyen"].Value);
        }

        private void ViderChampsType()
        {
            txtNoType.Clear();
            txtDescription.Clear();
            txtPrixHaut.Clear();
            txtPrixBas.Clear();
            txtPrixMoyen.Clear();
        }

        // =====================================================
        // TYPES : AJOUTER
        // =====================================================

        private void btnAjouterType_Click(object sender, EventArgs e)
        {
            if (UneOperationEstEnCours())
                return;

            modeAjoutType = true;
            noTypeOriginal = -1;

            int maximum = 0;

            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            using (SqlCommand commande = new SqlCommand(
                "SELECT ISNULL(MAX(NoTypeChambre), 0) " +
                "FROM TypeChambre", connexion))
            {
                connexion.Open();
                maximum = Convert.ToInt32(commande.ExecuteScalar());
            }

            txtNoType.Text = (maximum + 1).ToString();
            txtDescription.Clear();
            txtPrixHaut.Clear();
            txtPrixBas.Clear();
            txtPrixMoyen.Clear();

            dgvTypes.Enabled = false;
            dgvChambres.Enabled = false;

            MettreAJourEtatType();
            MettreAJourEtatChambre();
            txtDescription.Focus();
        }

        // =====================================================
        // TYPES : MODIFIER
        // =====================================================

        private void btnModifierType_Click(object sender, EventArgs e)
        {
            if (UneOperationEstEnCours())
                return;

            int numero = ObtenirNoTypeSelectionne();

            if (numero == -1)
            {
                MessageBox.Show("Sélectionne un type de chambre.");
                return;
            }

            noTypeOriginal = numero;
            modeModificationType = true;

            dgvTypes.Enabled = false;
            dgvChambres.Enabled = false;

            MettreAJourEtatType();
            MettreAJourEtatChambre();
            txtDescription.Focus();
        }

        // =====================================================
        // TYPES : ENREGISTRER
        // =====================================================

        private void btnEnregistrerType_Click(object sender, EventArgs e)
        {
            if (!modeAjoutType && !modeModificationType)
                return;

            errMessage.Clear();

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                errMessage.SetError(
                    txtDescription, "La description est obligatoire.");
                txtDescription.Focus();
                return;
            }

            decimal prixHaut;
            decimal prixBas;
            decimal prixMoyen;

            if (!decimal.TryParse(txtPrixHaut.Text, out prixHaut) ||
                !decimal.TryParse(txtPrixBas.Text, out prixBas) ||
                !decimal.TryParse(txtPrixMoyen.Text, out prixMoyen))
            {
                MessageBox.Show(
                    "Les trois prix doivent être des nombres valides.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (prixHaut < 0 || prixBas < 0 || prixMoyen < 0)
            {
                MessageBox.Show("Les prix ne peuvent pas être négatifs.");
                return;
            }

            string description = txtDescription.Text.Trim();
            int numero = Convert.ToInt32(txtNoType.Text);

            try
            {
                using (SqlConnection connexion =
                    new SqlConnection(ConnexionBD.Chaine))
                {
                    connexion.Open();

                    string sqlUnique =
                        "SELECT COUNT(*) FROM TypeChambre " +
                        "WHERE Description = @description " +
                        "AND NoTypeChambre <> @numero";

                    using (SqlCommand commandeUnique =
                        new SqlCommand(sqlUnique, connexion))
                    {
                        commandeUnique.Parameters.Add(
                            "@description", SqlDbType.NVarChar, 100)
                            .Value = description;

                        commandeUnique.Parameters.Add(
                            "@numero", SqlDbType.Int).Value =
                            modeAjoutType ? -1 : noTypeOriginal;

                        if (Convert.ToInt32(
                            commandeUnique.ExecuteScalar()) > 0)
                        {
                            errMessage.SetError(
                                txtDescription,
                                "Cette description existe déjà.");

                            txtDescription.Focus();

                            MessageBox.Show(
                                "La description du type doit être unique.");
                            return;
                        }
                    }

                    string sql;

                    if (modeAjoutType)
                    {
                        sql =
                            "INSERT INTO TypeChambre " +
                            "(NoTypeChambre, Description, PrixHaut, " +
                            "PrixBas, PrixMoyen) " +
                            "VALUES (@numero, @description, @haut, " +
                            "@bas, @moyen)";
                    }
                    else
                    {
                        sql =
                            "UPDATE TypeChambre SET " +
                            "Description = @description, " +
                            "PrixHaut = @haut, PrixBas = @bas, " +
                            "PrixMoyen = @moyen " +
                            "WHERE NoTypeChambre = @numero";
                    }

                    using (SqlCommand commande =
                        new SqlCommand(sql, connexion))
                    {
                        commande.Parameters.Add(
                            "@numero", SqlDbType.Int).Value = numero;

                        commande.Parameters.Add(
                            "@description", SqlDbType.NVarChar, 100)
                            .Value = description;

                        commande.Parameters.Add(
                            "@haut", SqlDbType.Decimal).Value = prixHaut;

                        commande.Parameters["@haut"].Precision = 8;
                        commande.Parameters["@haut"].Scale = 2;

                        commande.Parameters.Add(
                            "@bas", SqlDbType.Decimal).Value = prixBas;

                        commande.Parameters["@bas"].Precision = 8;
                        commande.Parameters["@bas"].Scale = 2;

                        commande.Parameters.Add(
                            "@moyen", SqlDbType.Decimal).Value = prixMoyen;

                        commande.Parameters["@moyen"].Precision = 8;
                        commande.Parameters["@moyen"].Scale = 2;

                        commande.ExecuteNonQuery();
                    }
                }

                modeAjoutType = false;
                modeModificationType = false;

                ChargerTypes();
                SelectionnerType(numero);
                ChargerChambres();

                dgvTypes.Enabled = true;
                dgvChambres.Enabled = true;

                MettreAJourEtatType();
                MettreAJourEtatChambre();

                MessageBox.Show(
                    "Le type de chambre a été enregistré.",
                    "Enregistrement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement du type :\n" +
                    ex.Message);
            }
        }

        // =====================================================
        // TYPES : SUPPRIMER
        // =====================================================

        private void btnSupprimerType_Click(object sender, EventArgs e)
        {
            if (UneOperationEstEnCours())
                return;

            int numero = ObtenirNoTypeSelectionne();

            if (numero == -1)
            {
                MessageBox.Show("Sélectionne un type de chambre.");
                return;
            }

            try
            {
                using (SqlConnection connexion =
                    new SqlConnection(ConnexionBD.Chaine))
                {
                    connexion.Open();

                    using (SqlCommand commande = new SqlCommand(
                        "SELECT COUNT(*) FROM Chambre " +
                        "WHERE NoTypeChambre = @numero", connexion))
                    {
                        commande.Parameters.Add(
                            "@numero", SqlDbType.Int).Value = numero;

                        if (Convert.ToInt32(
                            commande.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show(
                                "Impossible de supprimer ce type : " +
                                "il existe encore des chambres de ce type.",
                                "Suppression refusée",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult reponse = MessageBox.Show(
                        "Veux-tu vraiment supprimer ce type de chambre ?",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (reponse != DialogResult.Yes)
                        return;

                    using (SqlCommand commande = new SqlCommand(
                        "DELETE FROM TypeChambre " +
                        "WHERE NoTypeChambre = @numero", connexion))
                    {
                        commande.Parameters.Add(
                            "@numero", SqlDbType.Int).Value = numero;

                        commande.ExecuteNonQuery();
                    }
                }

                ChargerTypes();
                ChargerChambres();

                MettreAJourEtatType();
                MettreAJourEtatChambre();

                MessageBox.Show("Le type de chambre a été supprimé.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression du type :\n" +
                    ex.Message);
            }
        }

        // =====================================================
        // TYPES : ANNULER
        // =====================================================

        private void btnAnnulerType_Click(object sender, EventArgs e)
        {
            modeAjoutType = false;
            modeModificationType = false;
            errMessage.Clear();

            dgvTypes.Enabled = true;
            dgvChambres.Enabled = true;

            ChargerTypes();
            ChargerChambres();

            MettreAJourEtatType();
            MettreAJourEtatChambre();
        }

        // =====================================================
        // SÉLECTION DES CHAMBRES
        // =====================================================

        private void dgvChambres_SelectionChanged(
            object sender, EventArgs e)
        {
            if (chargement || modeAjoutChambre ||
                modeModificationChambre || modeAjoutType ||
                modeModificationType)
                return;

            AfficherChambreSelectionnee();
            MettreAJourEtatChambre();
        }

        private void AfficherChambreSelectionnee()
        {
            if (dgvChambres.CurrentRow == null ||
                dgvChambres.CurrentRow.IsNewRow)
            {
                ViderChampsChambre();
                return;
            }

            DataGridViewRow ligne = dgvChambres.CurrentRow;

            txtNoChambre.Text =
                Convert.ToString(ligne.Cells["NoChambre"].Value);

            txtEmplacement.Text =
                Convert.ToString(ligne.Cells["Emplacement"].Value);

            txtDecorations.Text =
                Convert.ToString(ligne.Cells["Decorations"].Value);
        }

        private void ViderChampsChambre()
        {
            txtNoChambre.Clear();
            txtEmplacement.Clear();
            txtDecorations.Clear();
        }

        // =====================================================
        // CHAMBRES : AJOUTER
        // =====================================================

        private void btnAjouterChambre_Click(object sender, EventArgs e)
        {
            if (UneOperationEstEnCours())
                return;

            int noType = Convert.ToInt32(txtNoType.Text);
            int prochainNoChambre = noType * 100 + 1;

            if (noType == -1)
            {
                MessageBox.Show(
                    "Sélectionne d'abord un type de chambre.");
                return;
            }

            modeAjoutChambre = true;
            noChambreOriginal = -1;

            int maximum = 0;

            using (SqlConnection connexion =
                new SqlConnection(ConnexionBD.Chaine))
            using (SqlCommand commande = new SqlCommand(
                "SELECT ISNULL(MAX(NoChambre), 0) FROM Chambre",
                connexion))
            {
                connexion.Open();
                maximum = Convert.ToInt32(commande.ExecuteScalar());
            }

            txtNoChambre.Text = (prochainNoChambre).ToString();
            txtEmplacement.Clear();
            txtDecorations.Clear();

            dgvTypes.Enabled = false;
            dgvChambres.Enabled = false;

            MettreAJourEtatType();
            MettreAJourEtatChambre();
            txtEmplacement.Focus();
        }

        // =====================================================
        // CHAMBRES : MODIFIER
        // =====================================================

        private void btnModifierChambre_Click(object sender, EventArgs e)
        {
            if (UneOperationEstEnCours())
                return;

            int numero = ObtenirNoChambreSelectionnee();

            if (numero == -1)
            {
                MessageBox.Show("Sélectionne une chambre.");
                return;
            }

            noChambreOriginal = numero;
            modeModificationChambre = true;

            dgvTypes.Enabled = false;
            dgvChambres.Enabled = false;

            MettreAJourEtatType();
            MettreAJourEtatChambre();
            txtEmplacement.Focus();
        }

        // =====================================================
        // CHAMBRES : ENREGISTRER
        // =====================================================

        private void btnEnregistrerChambre_Click(
            object sender, EventArgs e)
        {
            if (!modeAjoutChambre && !modeModificationChambre)
                return;

            errMessage.Clear();

            if (string.IsNullOrWhiteSpace(txtEmplacement.Text))
            {
                errMessage.SetError(
                    txtEmplacement, "L'emplacement est obligatoire.");
                txtEmplacement.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDecorations.Text))
            {
                errMessage.SetError(
                    txtDecorations, "La décoration est obligatoire.");
                txtDecorations.Focus();
                return;
            }

            int noType = ObtenirNoTypeSelectionne();
            int numero = Convert.ToInt32(txtNoChambre.Text);

            if (noType == -1)
            {
                MessageBox.Show("Sélectionne un type de chambre.");
                return;
            }

            try
            {
                using (SqlConnection connexion =
                    new SqlConnection(ConnexionBD.Chaine))
                {
                    connexion.Open();

                    string sql;

                    if (modeAjoutChambre)
                    {
                        sql =
                            "INSERT INTO Chambre " +
                            "(NoChambre, Emplacement, Decorations, " +
                            "NoTypeChambre) " +
                            "VALUES (@numero, @emplacement, " +
                            "@decorations, @type)";
                    }
                    else
                    {
                        sql =
                            "UPDATE Chambre SET " +
                            "Emplacement = @emplacement, " +
                            "Decorations = @decorations, " +
                            "NoTypeChambre = @type " +
                            "WHERE NoChambre = @numero";
                    }

                    using (SqlCommand commande =
                        new SqlCommand(sql, connexion))
                    {
                        commande.Parameters.Add(
                            "@numero", SqlDbType.Int).Value = numero;

                        commande.Parameters.Add(
                            "@emplacement", SqlDbType.NVarChar, 100)
                            .Value = txtEmplacement.Text.Trim();

                        commande.Parameters.Add(
                            "@decorations", SqlDbType.NVarChar, 100)
                            .Value = txtDecorations.Text.Trim();

                        commande.Parameters.Add(
                            "@type", SqlDbType.Int).Value = noType;

                        commande.ExecuteNonQuery();
                    }
                }

                modeAjoutChambre = false;
                modeModificationChambre = false;

                dgvTypes.Enabled = true;
                dgvChambres.Enabled = true;

                ChargerTypes();
                SelectionnerType(noType);
                ChargerChambres(noType);
                SelectionnerChambre(numero);

                MettreAJourEtatType();
                MettreAJourEtatChambre();

                MessageBox.Show(
                    "La chambre a été enregistrée.",
                    "Enregistrement",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de l'enregistrement de la chambre :\n" +
                    ex.Message);
            }
        }

        // =====================================================
        // CHAMBRES : SUPPRIMER
        // =====================================================

        private void btnSupprimerChambre_Click(
            object sender, EventArgs e)
        {
            if (UneOperationEstEnCours())
                return;

            int numero = ObtenirNoChambreSelectionnee();

            if (numero == -1)
            {
                MessageBox.Show("Sélectionne une chambre.");
                return;
            }

            try
            {
                using (SqlConnection connexion =
                    new SqlConnection(ConnexionBD.Chaine))
                {
                    connexion.Open();

                    using (SqlCommand commande = new SqlCommand(
                        "SELECT COUNT(*) FROM ReservationChambre " +
                        "WHERE NoChambre = @numero", connexion))
                    {
                        commande.Parameters.Add(
                            "@numero", SqlDbType.Int).Value = numero;

                        if (Convert.ToInt32(
                            commande.ExecuteScalar()) > 0)
                        {
                            MessageBox.Show(
                                "Impossible de supprimer cette chambre : " +
                                "elle figure dans une réservation.",
                                "Suppression refusée",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DialogResult reponse = MessageBox.Show(
                        "Veux-tu vraiment supprimer cette chambre ?",
                        "Confirmation",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (reponse != DialogResult.Yes)
                        return;

                    using (SqlCommand commande = new SqlCommand(
                        "DELETE FROM Chambre WHERE NoChambre = @numero",
                        connexion))
                    {
                        commande.Parameters.Add(
                            "@numero", SqlDbType.Int).Value = numero;

                        commande.ExecuteNonQuery();
                    }
                }

                ChargerChambres();
                MettreAJourEtatChambre();

                MessageBox.Show("La chambre a été supprimée.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erreur lors de la suppression de la chambre :\n" +
                    ex.Message);
            }
        }

        // =====================================================
        // CHAMBRES : ANNULER
        // =====================================================

        private void btnAnnulerChambre_Click(object sender, EventArgs e)
        {
            modeAjoutChambre = false;
            modeModificationChambre = false;
            errMessage.Clear();

            dgvTypes.Enabled = true;
            dgvChambres.Enabled = true;

            ChargerTypes();
            ChargerChambres();

            MettreAJourEtatType();
            MettreAJourEtatChambre();
        }

        // =====================================================
        // ÉTAT DES CONTRÔLES
        // =====================================================

        private bool UneOperationEstEnCours()
        {
            return modeAjoutType || modeModificationType ||
                   modeAjoutChambre || modeModificationChambre;
        }

        private void MettreAJourEtatType()
        {
            bool operation =
                modeAjoutType || modeModificationType;

            bool aType = ObtenirNoTypeSelectionne() != -1;

            txtNoType.ReadOnly = true;
            txtDescription.ReadOnly = !operation;
            txtPrixHaut.ReadOnly = !operation;
            txtPrixBas.ReadOnly = !operation;
            txtPrixMoyen.ReadOnly = !operation;

            btnAjouterType.Enabled = !UneOperationEstEnCours();
            btnModifierType.Enabled =
                !UneOperationEstEnCours() && aType;
            btnSupprimerType.Enabled =
                !UneOperationEstEnCours() && aType;
            btnEnregistrerType.Enabled = operation;
            btnAnnulerType.Enabled = operation;
        }

        private void MettreAJourEtatChambre()
        {
            bool operation =
                modeAjoutChambre || modeModificationChambre;

            bool aChambre = ObtenirNoChambreSelectionnee() != -1;
            bool aType = ObtenirNoTypeSelectionne() != -1;

            txtNoChambre.ReadOnly = true;
            txtEmplacement.ReadOnly = !operation;
            txtDecorations.ReadOnly = !operation;

            btnAjouterChambre.Enabled =
                !UneOperationEstEnCours() && aType;
            btnModifierChambre.Enabled =
                !UneOperationEstEnCours() && aChambre;
            btnSupprimerChambre.Enabled =
                !UneOperationEstEnCours() && aChambre;
            btnEnregistrerChambre.Enabled = operation;
            btnAnnulerChambre.Enabled = operation;
        }

        // =====================================================
        // SÉLECTION APRÈS ENREGISTREMENT
        // =====================================================

        private void SelectionnerType(int numero)
        {
            foreach (DataGridViewRow ligne in dgvTypes.Rows)
            {
                if (Convert.ToInt32(
                    ligne.Cells["NoTypeChambre"].Value) == numero)
                {
                    ligne.Selected = true;
                    dgvTypes.CurrentCell = ligne.Cells[0];
                    AfficherTypeSelectionne();
                    break;
                }
            }
        }

        private void SelectionnerChambre(int numero)
        {
            foreach (DataGridViewRow ligne in dgvChambres.Rows)
            {
                if (Convert.ToInt32(
                    ligne.Cells["NoChambre"].Value) == numero)
                {
                    ligne.Selected = true;
                    dgvChambres.CurrentCell = ligne.Cells[0];
                    AfficherChambreSelectionnee();
                    break;
                }
            }
        }
    }
}
