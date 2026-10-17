
namespace ProjetBaseDeDonneeIII
{
    partial class FrmRapports
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TabControl tabRapports;
        private System.Windows.Forms.TabPage tabSoinsPersonne;
        private System.Windows.Forms.TabPage tabReservations;
        private System.Windows.Forms.TabPage tabSoinsJournaliers;

        private System.Windows.Forms.Label lblTypePersonne;
        private System.Windows.Forms.ComboBox cmbTypePersonne;
        private System.Windows.Forms.Label lblPersonne;
        private System.Windows.Forms.ComboBox cmbPersonne;
        private System.Windows.Forms.DataGridView dgvSoinsPersonne;
        private System.Windows.Forms.Label lblTotalSoins;

        private System.Windows.Forms.Label lblChambre;
        private System.Windows.Forms.ComboBox cmbChambre;
        private System.Windows.Forms.DataGridView dgvReservations;

        private System.Windows.Forms.Label lblAssistant;
        private System.Windows.Forms.ComboBox cmbAssistant;
        private System.Windows.Forms.Label lblDateSoin;
        private System.Windows.Forms.DateTimePicker dtpDateSoin;
        private System.Windows.Forms.Button btnAfficherSoinsJournaliers;
        private System.Windows.Forms.Label lblListeSoins;
        private System.Windows.Forms.DataGridView dgvSoinsJournaliers;
        private System.Windows.Forms.Label lblListePersonnes;
        private System.Windows.Forms.DataGridView dgvPersonnesSoin;

        private System.Windows.Forms.Button btnFermer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabRapports = new System.Windows.Forms.TabControl();
            this.tabSoinsPersonne = new System.Windows.Forms.TabPage();
            this.lblTypePersonne = new System.Windows.Forms.Label();
            this.cmbTypePersonne = new System.Windows.Forms.ComboBox();
            this.lblPersonne = new System.Windows.Forms.Label();
            this.cmbPersonne = new System.Windows.Forms.ComboBox();
            this.dgvSoinsPersonne = new System.Windows.Forms.DataGridView();
            this.lblTotalSoins = new System.Windows.Forms.Label();
            this.tabReservations = new System.Windows.Forms.TabPage();
            this.lblChambre = new System.Windows.Forms.Label();
            this.cmbChambre = new System.Windows.Forms.ComboBox();
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.tabSoinsJournaliers = new System.Windows.Forms.TabPage();
            this.lblAssistant = new System.Windows.Forms.Label();
            this.cmbAssistant = new System.Windows.Forms.ComboBox();
            this.lblDateSoin = new System.Windows.Forms.Label();
            this.dtpDateSoin = new System.Windows.Forms.DateTimePicker();
            this.btnAfficherSoinsJournaliers = new System.Windows.Forms.Button();
            this.lblListeSoins = new System.Windows.Forms.Label();
            this.dgvSoinsJournaliers = new System.Windows.Forms.DataGridView();
            this.lblListePersonnes = new System.Windows.Forms.Label();
            this.dgvPersonnesSoin = new System.Windows.Forms.DataGridView();
            this.btnFermer = new System.Windows.Forms.Button();
            this.tabRapports.SuspendLayout();
            this.tabSoinsPersonne.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoinsPersonne)).BeginInit();
            this.tabReservations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.tabSoinsJournaliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoinsJournaliers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnesSoin)).BeginInit();
            this.SuspendLayout();
            // 
            // tabRapports
            // 
            this.tabRapports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabRapports.Controls.Add(this.tabSoinsPersonne);
            this.tabRapports.Controls.Add(this.tabReservations);
            this.tabRapports.Controls.Add(this.tabSoinsJournaliers);
            this.tabRapports.Location = new System.Drawing.Point(10, 10);
            this.tabRapports.Name = "tabRapports";
            this.tabRapports.SelectedIndex = 0;
            this.tabRapports.Size = new System.Drawing.Size(794, 503);
            this.tabRapports.TabIndex = 0;
            // 
            // tabSoinsPersonne
            // 
            this.tabSoinsPersonne.Controls.Add(this.lblTypePersonne);
            this.tabSoinsPersonne.Controls.Add(this.cmbTypePersonne);
            this.tabSoinsPersonne.Controls.Add(this.lblPersonne);
            this.tabSoinsPersonne.Controls.Add(this.cmbPersonne);
            this.tabSoinsPersonne.Controls.Add(this.dgvSoinsPersonne);
            this.tabSoinsPersonne.Controls.Add(this.lblTotalSoins);
            this.tabSoinsPersonne.Location = new System.Drawing.Point(4, 22);
            this.tabSoinsPersonne.Name = "tabSoinsPersonne";
            this.tabSoinsPersonne.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.tabSoinsPersonne.Size = new System.Drawing.Size(786, 477);
            this.tabSoinsPersonne.TabIndex = 0;
            this.tabSoinsPersonne.Text = "Soins d\'une personne";
            // 
            // lblTypePersonne
            // 
            this.lblTypePersonne.AutoSize = true;
            this.lblTypePersonne.Location = new System.Drawing.Point(13, 17);
            this.lblTypePersonne.Name = "lblTypePersonne";
            this.lblTypePersonne.Size = new System.Drawing.Size(99, 13);
            this.lblTypePersonne.TabIndex = 0;
            this.lblTypePersonne.Text = "Type de personne :";
            // 
            // cmbTypePersonne
            // 
            this.cmbTypePersonne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypePersonne.Location = new System.Drawing.Point(129, 14);
            this.cmbTypePersonne.Name = "cmbTypePersonne";
            this.cmbTypePersonne.Size = new System.Drawing.Size(155, 21);
            this.cmbTypePersonne.TabIndex = 1;
            // 
            // lblPersonne
            // 
            this.lblPersonne.AutoSize = true;
            this.lblPersonne.Location = new System.Drawing.Point(13, 50);
            this.lblPersonne.Name = "lblPersonne";
            this.lblPersonne.Size = new System.Drawing.Size(58, 13);
            this.lblPersonne.TabIndex = 2;
            this.lblPersonne.Text = "Personne :";
            // 
            // cmbPersonne
            // 
            this.cmbPersonne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonne.Location = new System.Drawing.Point(129, 47);
            this.cmbPersonne.Name = "cmbPersonne";
            this.cmbPersonne.Size = new System.Drawing.Size(343, 21);
            this.cmbPersonne.TabIndex = 3;
            // 
            // dgvSoinsPersonne
            // 
            this.dgvSoinsPersonne.AllowUserToAddRows = false;
            this.dgvSoinsPersonne.AllowUserToDeleteRows = false;
            this.dgvSoinsPersonne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSoinsPersonne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoinsPersonne.Location = new System.Drawing.Point(13, 82);
            this.dgvSoinsPersonne.Name = "dgvSoinsPersonne";
            this.dgvSoinsPersonne.ReadOnly = true;
            this.dgvSoinsPersonne.Size = new System.Drawing.Size(750, 212);
            this.dgvSoinsPersonne.TabIndex = 4;
            // 
            // lblTotalSoins
            // 
            this.lblTotalSoins.AutoSize = true;
            this.lblTotalSoins.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalSoins.Location = new System.Drawing.Point(12, 297);
            this.lblTotalSoins.Name = "lblTotalSoins";
            this.lblTotalSoins.Size = new System.Drawing.Size(163, 20);
            this.lblTotalSoins.TabIndex = 5;
            this.lblTotalSoins.Text = "Montant total : 0,00 $";
            // 
            // tabReservations
            // 
            this.tabReservations.Controls.Add(this.lblChambre);
            this.tabReservations.Controls.Add(this.cmbChambre);
            this.tabReservations.Controls.Add(this.dgvReservations);
            this.tabReservations.Location = new System.Drawing.Point(4, 22);
            this.tabReservations.Name = "tabReservations";
            this.tabReservations.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.tabReservations.Size = new System.Drawing.Size(786, 477);
            this.tabReservations.TabIndex = 1;
            this.tabReservations.Text = "Réservations de chambres";
            // 
            // lblChambre
            // 
            this.lblChambre.AutoSize = true;
            this.lblChambre.Location = new System.Drawing.Point(13, 17);
            this.lblChambre.Name = "lblChambre";
            this.lblChambre.Size = new System.Drawing.Size(55, 13);
            this.lblChambre.TabIndex = 0;
            this.lblChambre.Text = "Chambre :";
            // 
            // cmbChambre
            // 
            this.cmbChambre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChambre.Location = new System.Drawing.Point(86, 14);
            this.cmbChambre.Name = "cmbChambre";
            this.cmbChambre.Size = new System.Drawing.Size(343, 21);
            this.cmbChambre.TabIndex = 1;
            // 
            // dgvReservations
            // 
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReservations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservations.Location = new System.Drawing.Point(13, 52);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.Size = new System.Drawing.Size(750, 377);
            this.dgvReservations.TabIndex = 2;
            // 
            // tabSoinsJournaliers
            // 
            this.tabSoinsJournaliers.Controls.Add(this.lblAssistant);
            this.tabSoinsJournaliers.Controls.Add(this.cmbAssistant);
            this.tabSoinsJournaliers.Controls.Add(this.lblDateSoin);
            this.tabSoinsJournaliers.Controls.Add(this.dtpDateSoin);
            this.tabSoinsJournaliers.Controls.Add(this.btnAfficherSoinsJournaliers);
            this.tabSoinsJournaliers.Controls.Add(this.lblListeSoins);
            this.tabSoinsJournaliers.Controls.Add(this.dgvSoinsJournaliers);
            this.tabSoinsJournaliers.Controls.Add(this.lblListePersonnes);
            this.tabSoinsJournaliers.Controls.Add(this.dgvPersonnesSoin);
            this.tabSoinsJournaliers.Location = new System.Drawing.Point(4, 22);
            this.tabSoinsJournaliers.Name = "tabSoinsJournaliers";
            this.tabSoinsJournaliers.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.tabSoinsJournaliers.Size = new System.Drawing.Size(786, 477);
            this.tabSoinsJournaliers.TabIndex = 2;
            this.tabSoinsJournaliers.Text = "Soins journaliers";
            // 
            // lblAssistant
            // 
            this.lblAssistant.AutoSize = true;
            this.lblAssistant.Location = new System.Drawing.Point(13, 16);
            this.lblAssistant.Name = "lblAssistant";
            this.lblAssistant.Size = new System.Drawing.Size(55, 13);
            this.lblAssistant.TabIndex = 0;
            this.lblAssistant.Text = "Assistant :";
            // 
            // cmbAssistant
            // 
            this.cmbAssistant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssistant.Location = new System.Drawing.Point(81, 12);
            this.cmbAssistant.Name = "cmbAssistant";
            this.cmbAssistant.Size = new System.Drawing.Size(215, 21);
            this.cmbAssistant.TabIndex = 1;
            // 
            // lblDateSoin
            // 
            this.lblDateSoin.AutoSize = true;
            this.lblDateSoin.Location = new System.Drawing.Point(313, 16);
            this.lblDateSoin.Name = "lblDateSoin";
            this.lblDateSoin.Size = new System.Drawing.Size(36, 13);
            this.lblDateSoin.TabIndex = 2;
            this.lblDateSoin.Text = "Date :";
            // 
            // dtpDateSoin
            // 
            this.dtpDateSoin.Location = new System.Drawing.Point(356, 12);
            this.dtpDateSoin.Name = "dtpDateSoin";
            this.dtpDateSoin.Size = new System.Drawing.Size(121, 20);
            this.dtpDateSoin.TabIndex = 3;
            // 
            // btnAfficherSoinsJournaliers
            // 
            this.btnAfficherSoinsJournaliers.Location = new System.Drawing.Point(493, 10);
            this.btnAfficherSoinsJournaliers.Name = "btnAfficherSoinsJournaliers";
            this.btnAfficherSoinsJournaliers.Size = new System.Drawing.Size(154, 24);
            this.btnAfficherSoinsJournaliers.TabIndex = 4;
            this.btnAfficherSoinsJournaliers.Text = "Afficher les soins";
            // 
            // lblListeSoins
            // 
            this.lblListeSoins.AutoSize = true;
            this.lblListeSoins.Location = new System.Drawing.Point(13, 48);
            this.lblListeSoins.Name = "lblListeSoins";
            this.lblListeSoins.Size = new System.Drawing.Size(162, 13);
            this.lblListeSoins.TabIndex = 5;
            this.lblListeSoins.Text = "Soins de l\'assistant à cette date :";
            // 
            // dgvSoinsJournaliers
            // 
            this.dgvSoinsJournaliers.AllowUserToAddRows = false;
            this.dgvSoinsJournaliers.AllowUserToDeleteRows = false;
            this.dgvSoinsJournaliers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSoinsJournaliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSoinsJournaliers.Location = new System.Drawing.Point(13, 68);
            this.dgvSoinsJournaliers.Name = "dgvSoinsJournaliers";
            this.dgvSoinsJournaliers.ReadOnly = true;
            this.dgvSoinsJournaliers.Size = new System.Drawing.Size(750, 165);
            this.dgvSoinsJournaliers.TabIndex = 6;
            // 
            // lblListePersonnes
            // 
            this.lblListePersonnes.AutoSize = true;
            this.lblListePersonnes.Location = new System.Drawing.Point(13, 247);
            this.lblListePersonnes.Name = "lblListePersonnes";
            this.lblListePersonnes.Size = new System.Drawing.Size(298, 13);
            this.lblListePersonnes.TabIndex = 7;
            this.lblListePersonnes.Text = "Personnes ayant reçu ou devant recevoir le soin sélectionné :";
            // 
            // dgvPersonnesSoin
            // 
            this.dgvPersonnesSoin.AllowUserToAddRows = false;
            this.dgvPersonnesSoin.AllowUserToDeleteRows = false;
            this.dgvPersonnesSoin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersonnesSoin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonnesSoin.Location = new System.Drawing.Point(13, 267);
            this.dgvPersonnesSoin.Name = "dgvPersonnesSoin";
            this.dgvPersonnesSoin.ReadOnly = true;
            this.dgvPersonnesSoin.Size = new System.Drawing.Size(750, 160);
            this.dgvPersonnesSoin.TabIndex = 8;
            // 
            // btnFermer
            // 
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Location = new System.Drawing.Point(705, 524);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(99, 26);
            this.btnFermer.TabIndex = 1;
            this.btnFermer.Text = "Fermer";
            // 
            // FrmRapports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 563);
            this.Controls.Add(this.tabRapports);
            this.Controls.Add(this.btnFermer);
            this.Name = "FrmRapports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapports - Hôtel Plage Santé";
            this.tabRapports.ResumeLayout(false);
            this.tabSoinsPersonne.ResumeLayout(false);
            this.tabSoinsPersonne.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoinsPersonne)).EndInit();
            this.tabReservations.ResumeLayout(false);
            this.tabReservations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.tabSoinsJournaliers.ResumeLayout(false);
            this.tabSoinsJournaliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoinsJournaliers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonnesSoin)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
