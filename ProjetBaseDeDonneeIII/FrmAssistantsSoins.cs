using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmAssistantsSoins : Form
    {
        String maChaineDeConnexion = "Data Source=tcp:424sql.cgodin.qc.ca,5433;Initial Catalog=BDB56Projet1CKW;Persist Security Info=True;User ID=B56Projet1CKW;Password=Password2;Encrypt=True;TrustServerCertificate=True";
      
        SqlConnection maConnexion = new SqlConnection();

        int largeur;
        bool btnRetourClicked = false;

        int positionOrigineAssistant;   // field, at the top of the class
        bool modeAjout = false;
        Boolean ajoutSoins = false;
        Boolean suppSoins = false;
        public FrmAssistantsSoins()
        {
            InitializeComponent();
        }

        private void assistantSoinBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.assistantSoinBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bDB56Projet1CKWDataSet);

        }

        private void FrmAssistantsSoins_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.Soin' table. You can move, or remove it, as needed.
            this.soinTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Soin);
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.SoinsAss' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.Assistant' table. You can move, or remove it, as needed.
            this.assistantTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Assistant);
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.AssistantSoin' table. You can move, or remove it, as needed.
            this.assistantSoinTableAdapter.Fill(this.bDB56Projet1CKWDataSet.AssistantSoin);
            this.soinTableAdapter.Fill(bDB56Projet1CKWDataSet.Soin);
            int largeur = this.Width;
            int hauteur = this.Height;

            Size interieur = this.ClientSize;  // usable area inside the borders
            int largeurUtile = this.ClientSize.Width;
            int hauteurUtile = this.ClientSize.Height;
            positionOrigineAssistant = assistantDataGridView.Left;


        }

        private void assistantDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void assistanBindingSource_PositionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("PositionChanged appelé");

            int noEnregistrement = assistantBindingSource.Position;
            int nbEnregistrements = assistantBindingSource.Count;

                if (noEnregistrement >= 0 && noEnregistrement < nbEnregistrements)
                {
                    dynamic enregistrementSelectionne = assistantBindingSource.Current;
                    if (enregistrementSelectionne is DataRowView data && data["NoAssistant"] != DBNull.Value)
                    {
                        int noAssistantSelectionne = enregistrementSelectionne["NoAssistant"];
                        soinsAssTableAdapter.ClearBeforeFill = true;
                        soinsAssTableAdapter.Fill(this.bDB56Projet1CKWDataSet.SoinsAss, noAssistantSelectionne);
                    }
                }
            if (comSoins.Visible&&!suppSoins)
            {
                RemplirComboAjout();
            }else if (comSoins.Visible && suppSoins)
            {
                remplirComboSupp();
            }

        }

        private void remplirComboSupp()
        {
            if (!(assistantBindingSource.Current is DataRowView ass) || ass["NoAssistant"] == DBNull.Value)
            {
                comSoins.DataSource = null;
                comSoins.Enabled = false;
                return;
            }

            int noAssistant = Convert.ToInt32(ass["NoAssistant"]);

            var offerts = bDB56Projet1CKWDataSet.SoinsAss.AsEnumerable().Select(r => r["NoSoin"].ToString()).ToList();

            var planifies = new List<string>();
            using (SqlConnection conn = new SqlConnection(maChaineDeConnexion))
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT NoSoin FROM PlanifSoin WHERE NoAssistant = @a", conn))
            {
                cmd.Parameters.AddWithValue("@a", noAssistant);
                conn.Open();
                using (SqlDataReader dataR = cmd.ExecuteReader())
                    while (dataR.Read()) planifies.Add(dataR["NoSoin"].ToString());
            }

            var supprimables = offerts.Except(planifies).ToList();

            DataView dataV = new DataView(bDB56Projet1CKWDataSet.Soin);
            dataV.RowFilter = supprimables.Count > 0 ? $"NoSoin IN ({string.Join(",", supprimables)})" : "1 = 0";
            
            if (offerts.Count > 0 && supprimables.Count == 0&& !btnRetourClicked)
                MessageBox.Show("Les soins de cet assistant sont tous planifiés : aucun ne peut être retiré.");
            comSoins.DataSource = dataV;
            comSoins.DisplayMember = "Description";
            comSoins.ValueMember = "NoSoin";
            comSoins.Enabled = dataV.Count > 0;


        }
        private void RemplirComboAjout(){
            foreach (DataColumn c in bDB56Projet1CKWDataSet.SoinsAss.Columns)
                System.Diagnostics.Debug.WriteLine("colonne SoinsAss : " + c.ColumnName);
            var dejaOfferts = bDB56Projet1CKWDataSet.SoinsAss.AsEnumerable().Select(r => r["NoSoin"].ToString()).ToList();

            DataView dataV = new DataView(bDB56Projet1CKWDataSet.Soin);
            if (dejaOfferts.Count > 0) { dataV.RowFilter = $"NoSoin NOT IN ({string.Join(",", dejaOfferts)})";}

            comSoins.DataSource = dataV;
            comSoins.DisplayMember = "Description";
            comSoins.ValueMember = "NoSoin";
            comSoins.Enabled = dataV.Count > 0;
        }

        private void assistantSoinBindingSource_CurrentChanged(object sender, EventArgs e)
        {
         
        }

        private void BtnAjoutAss_Click(object sender, EventArgs e)
        {
            BtnRetour.Visible = true;
            modeAjout = true;
            assistantBindingSource.AddNew();
            AfficherBoutons(false);
            AfficherTexteAss(true);

            FocusAssistant(true);

            noAssistantTextBox.Enabled = false;
            int noAssistantMax = bDB56Projet1CKWDataSet.Assistant.Rows.Cast<DataRow>().Max(row => Convert.ToInt32(row["NoAssistant"]))+1;
            noAssistantTextBox.Text = (noAssistantMax).ToString();



        }
        private void AfficherBtnConfirmer(Boolean visible)
        {
            BtnConfirmer.Visible = visible;
        }

        private void FocusAssistant(Boolean focus)
        {
            if (focus)
            {
                soinsAssDataGridView.Hide();
                assistantDataGridView.Left = (ClientSize.Width - assistantDataGridView.Width) / 2;
                AfficherBtnConfirmer(true);
            }
            else
            {
                soinsAssDataGridView.Show();
                assistantDataGridView.Left = positionOrigineAssistant;
                AfficherBtnConfirmer(false);
            }
        }

        private void AfficherTexteAss(Boolean visible)
        {
            noAssistantTextBox.Visible = visible;
            prenomTextBox.Visible = visible;
            nomTextBox.Visible = visible;
            specialitesTextBox.Visible = visible;
            remarquesTextBox.Visible = visible;


            noAssLabel.Visible = visible;
            prenomLabel.Visible = visible;
            nomLabel.Visible = visible;
            specLabel.Visible = visible;
            remarqueLabel.Visible = visible;
        }


        private void AfficherBoutons(Boolean visible)
        {
            BtnAjoutAss.Visible = visible;
            BtnAjoutSoins.Visible = visible;
            BtnModAss.Visible = visible;
            BtnSuppSoins.Visible = visible;
            BtnSuppAss.Visible = visible;
        }

        private void noAssistantLabel_Click(object sender, EventArgs e)
        {

        }

        private void noAssistantTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void prenomLabel_Click(object sender, EventArgs e)
        {

        }

        private void prenomTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void nomLabel_Click(object sender, EventArgs e)
        {

        }

        private void nomTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void specialitesLabel_Click(object sender, EventArgs e)
        {

        }

        private void specialitesTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void remarquesLabel_Click(object sender, EventArgs e)
        {

        }

        private void remarquesTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ajouterSoinsAss()
        {
            if (comSoins.SelectedValue == null)
            {
                MessageBox.Show("Veuillez choisir un soin.");
                return;
            }

            int noAssistant = Convert.ToInt32(((DataRowView)assistantBindingSource.Current)["NoAssistant"]);
            int noSoin = Convert.ToInt32(comSoins.SelectedValue);
            try
            {
                using (SqlConnection conn = new SqlConnection(maChaineDeConnexion))
                using (SqlCommand cmd = new SqlCommand("INSERT into AssistantSoin (NoAssistant, NoSoin) VALUES (@ass, @soin)", conn))
                {
                    cmd.Parameters.AddWithValue("@ass", noAssistant);
                    cmd.Parameters.AddWithValue("@soin", noSoin);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Soin ajouté à l'assistant.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Impossible d'ajouter le soin : " + ex.Message);
            }


            FinSoin();
        }
        private void suppSoinsAss()
        {
            if (comSoins.SelectedValue == null)
            {
                MessageBox.Show("Veuillez choisir un soin.");
                return;
            }

            int noAssistant = Convert.ToInt32(((DataRowView)assistantBindingSource.Current)["NoAssistant"]);
            int noSoin = Convert.ToInt32(comSoins.SelectedValue);
            try
            {
                using (SqlConnection conn = new SqlConnection(maChaineDeConnexion))
                using (SqlCommand cmd = new SqlCommand("Delete from AssistantSoin where noSoin = @soin and NoAssistant = @ass", conn))
                {
                    cmd.Parameters.AddWithValue("@ass", noAssistant);
                    cmd.Parameters.AddWithValue("@soin", noSoin);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Soin supprimer de l'assistant.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Impossible d'ajouter le soin : " + ex.Message);
            }
            FinSoin();
        }
        private void FinSoin()
        { 
               this.soinTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Soin);
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.SoinsAss' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.Assistant' table. You can move, or remove it, as needed.
            this.assistantTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Assistant);
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.AssistantSoin' table. You can move, or remove it, as needed.
            this.assistantSoinTableAdapter.Fill(this.bDB56Projet1CKWDataSet.AssistantSoin);
        ajoutSoins = false;
            suppSoins = false;
            BtnRetour.Visible = false;

            comSoins.Visible = false;
            AfficherBtnConfirmer(false);
            AfficherBoutons(true);
            FocusAssistant(false);
        }


        private void BtnConfirmer_Click(object sender, EventArgs e)
        {
            ErrorProvider errMessage = new ErrorProvider();
            errMessage.Clear();
            bool valide = true;
            if (comSoins.Visible&&!suppSoins) {

                ajouterSoinsAss();

                return;
            }else if (comSoins.Visible && suppSoins)
            {
                suppSoinsAss();
                return;
            }
            
            if (string.IsNullOrWhiteSpace(prenomTextBox.Text))
            { 
                errMessage.SetError(prenomTextBox, "Le prénom est requis."); 
                valide = false; 
            }

            if (string.IsNullOrWhiteSpace(nomTextBox.Text))
            { errMessage.SetError(nomTextBox, "Le nom est requis."); valide = false; }

            if (string.IsNullOrWhiteSpace(specialitesTextBox.Text))
            { errMessage.SetError(specialitesTextBox, "La spécialité est requise."); valide = false; }


            if (!valide) return;
            AfficherBtnConfirmer(valide);
            try
            {
                this.Validate();                     
                assistantBindingSource.EndEdit();   
                assistantTableAdapter.Update(bDB56Projet1CKWDataSet.Assistant);
                if(modeAjout)
                {
                    MessageBox.Show("Assistant ajouté.");
                }
                else
                {
                    MessageBox.Show("Assistant modifié.");
                }
                finAss();

            }

            catch (SqlException ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message);
            }
        }

        private void BtnModAss_Click(object sender, EventArgs e)
        {
            BtnRetour.Visible = true;
            modeAjout = false;
            AfficherBoutons(false);
            AfficherTexteAss(true);

            FocusAssistant(true);

            noAssistantTextBox.Enabled = false;
        }
        private void finAss()
        {
            assistantBindingSource.CancelEdit();
            BtnRetour.Visible=false;
            AfficherBoutons(true);
            AfficherBtnConfirmer(false);
            FocusAssistant(false);
            AfficherTexteAss(false);



            assistantTableAdapter.Fill(bDB56Projet1CKWDataSet.Assistant);
            assistantSoinTableAdapter.Fill(bDB56Projet1CKWDataSet.AssistantSoin);
        }
        private void BtnSuppAss_Click(object sender, EventArgs e)
        {
            if (!(assistantBindingSource.Current is DataRowView drv) || drv["NoAssistant"] == DBNull.Value)
            {
                MessageBox.Show("Veuillez sélectionner un assistant.");
                return;
            }

            int noAssistant = Convert.ToInt32(drv["NoAssistant"]);

            using (SqlConnection conn = new SqlConnection(maChaineDeConnexion))
            {
                conn.Open();

                SqlCommand verif = new SqlCommand("SELECT COUNT(*) FROM PlanifSoin WHERE NoAssistant = @no", conn);
                verif.Parameters.AddWithValue("@no", noAssistant);
                if ((int)verif.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Des soins planifiés sont assignés à cet assistant.",
                        "Suppression refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    {
                        return;
                            };
                }

                if (MessageBox.Show($"Supprimer {drv["Prenom"]} {drv["Nom"]} et tous les soins qu'il offre ?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return; 
                };

                using (SqlTransaction tryconn = conn.BeginTransaction())
                {
                    try
                    {
                        SqlCommand cmdSoins = new SqlCommand("DELETE FROM AssistantSoin WHERE NoAssistant = @no", conn, tryconn);
                        cmdSoins.Parameters.AddWithValue("@no", noAssistant);
                        cmdSoins.ExecuteNonQuery();
                        SqlCommand cmdAss = new SqlCommand("DELETE FROM Assistant WHERE NoAssistant = @no", conn, tryconn);
                        cmdAss.Parameters.AddWithValue("@no", noAssistant);
                        cmdAss.ExecuteNonQuery();

                        tryconn.Commit();
                    }
                    catch (Exception ex)
                    {
                        tryconn.Rollback();
                        MessageBox.Show("Erreur, aucune suppression : " + ex.Message);
                        return;
                    }
                }
            }
            assistantTableAdapter.Fill(bDB56Projet1CKWDataSet.Assistant);
            assistantSoinTableAdapter.Fill(bDB56Projet1CKWDataSet.AssistantSoin);
        }



        private void BtnAjoutSoins_Click(object sender, EventArgs e)
        {
            assistantDataGridView.ClearSelection();
            comSoins.Visible = true;
            comSoins.Enabled = true;
            BtnRetour.Visible = true;

            FocusAssistant(true);
            AfficherBoutons(false);
            AfficherBtnConfirmer(true);
            AfficherTexteAss(false);
            
        }

        private void BtnSuppSoins_Click(object sender, EventArgs e)
        {
            assistantDataGridView.ClearSelection();
            suppSoins = true;
            comSoins.Visible = true;
            comSoins.Enabled = true;
            BtnRetour.Visible = true;

            FocusAssistant(true);
            AfficherBoutons(false);
            AfficherBtnConfirmer(true);
            AfficherTexteAss(false);



        }

        private void BtnRetour_Click(object sender, EventArgs e)
        {
            btnRetourClicked = true;
            if (comSoins.Visible) FinSoin();
            else  finAss() ;
            btnRetourClicked = false;

        }


    }
}
