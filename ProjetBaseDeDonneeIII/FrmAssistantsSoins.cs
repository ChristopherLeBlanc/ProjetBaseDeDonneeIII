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
    public partial class FrmAssistantsSoins : Form
    {
      
        String maChaineDeConnexion = "Data Source=424sql.cgodin.qc.ca,5433;Initial Catalog=BDB56Carter;User ID=B56Carter;Password=Mxltoonooragan@futur";
        SqlConnection maConnexion = new SqlConnection();

        int largeur;
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
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.SoinsAss' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.Assistant' table. You can move, or remove it, as needed.
            this.assistantTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Assistant);
            // TODO: This line of code loads data into the 'bDB56Projet1CKWDataSet.AssistantSoin' table. You can move, or remove it, as needed.
            this.assistantSoinTableAdapter.Fill(this.bDB56Projet1CKWDataSet.AssistantSoin);
            int largeur = this.Width;
            int hauteur = this.Height;

            Size interieur = this.ClientSize;  // usable area inside the borders
            int largeurUtile = this.ClientSize.Width;
            int hauteurUtile = this.ClientSize.Height;

        }

        private void assistantDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void assistanBindingSource_PositionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("PositionChanged appelé");
            int noEnregistrement = assistantBindingSource.Position;
            int nbEnregistrements = assistantBindingSource.Count;
            if (noEnregistrement >= 0 && noEnregistrement < nbEnregistrements )
            {
                dynamic enregistrementSelectionne = assistantBindingSource.Current;
                if (enregistrementSelectionne is DataRowView data && data["NoAssistant"] != DBNull.Value)
                {
                    int noAssistantSelectionne = enregistrementSelectionne["NoAssistant"];
                    soinsAssTableAdapter.ClearBeforeFill = true;
                    soinsAssTableAdapter.Fill(this.bDB56Projet1CKWDataSet.SoinsAss, noAssistantSelectionne);
                }
            }
        }

        private void assistantSoinBindingSource_CurrentChanged(object sender, EventArgs e)
        {
         
        }

        private void BtnAjoutAss_Click(object sender, EventArgs e)
        {
            assistantBindingSource.AddNew();
            AfficherBoutons(false);
            AfficherTexteAss(true);

            FocusAssistant();

            noAssistantTextBox.Enabled = false;
            int noAssistantMax = bDB56Projet1CKWDataSet.Assistant.Rows.Cast<DataRow>().Max(row => Convert.ToInt32(row["NoAssistant"]))+1;
            noAssistantTextBox.Text = (noAssistantMax).ToString();



        }
        private void AfficherBtnConfirmer(Boolean visible)
        {
            BtnConfirmer.Visible = visible;
        }

        private void FocusAssistant()
        {
            soinsAssDataGridView.Hide();
            assistantDataGridView.Left = (ClientSize.Width - assistantDataGridView.Width) / 2;
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
    }
}