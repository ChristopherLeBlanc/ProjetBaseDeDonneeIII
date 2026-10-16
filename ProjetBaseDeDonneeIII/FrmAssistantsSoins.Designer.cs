namespace ProjetBaseDeDonneeIII
{
    partial class FrmAssistantsSoins
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.assistantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bDB56Projet1CKWDataSet = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSet();
            this.assistantSoinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.assistantSoinTableAdapter = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.AssistantSoinTableAdapter();
            this.tableAdapterManager = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager();
            this.assistantTableAdapter = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.AssistantTableAdapter();
            this.soinsAssBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.soinsAssTableAdapter = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.SoinsAssTableAdapter();
            this.soinsAssDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assistantDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnAjoutAss = new System.Windows.Forms.Button();
            this.BtnModAss = new System.Windows.Forms.Button();
            this.BtnAjoutSoins = new System.Windows.Forms.Button();
            this.BtnSuppSoins = new System.Windows.Forms.Button();
            this.BtnSuppAss = new System.Windows.Forms.Button();
            this.noAssistantTextBox = new System.Windows.Forms.TextBox();
            this.prenomTextBox = new System.Windows.Forms.TextBox();
            this.nomTextBox = new System.Windows.Forms.TextBox();
            this.specialitesTextBox = new System.Windows.Forms.TextBox();
            this.remarquesTextBox = new System.Windows.Forms.TextBox();
            this.noAssLabel = new System.Windows.Forms.Label();
            this.prenomLabel = new System.Windows.Forms.Label();
            this.nomLabel = new System.Windows.Forms.Label();
            this.specLabel = new System.Windows.Forms.Label();
            this.remarqueLabel = new System.Windows.Forms.Label();
            this.BtnConfirmer = new System.Windows.Forms.Button();
            this.btnAjouterSoins = new System.Windows.Forms.Button();
            this.BtnRetour = new System.Windows.Forms.Button();
            this.soinsAssBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.comSoins = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.assistantBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDB56Projet1CKWDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistantSoinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soinsAssBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soinsAssDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistantDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.soinsAssBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // assistantBindingSource
            // 
            this.assistantBindingSource.DataMember = "Assistant";
            this.assistantBindingSource.DataSource = this.bDB56Projet1CKWDataSet;
            this.assistantBindingSource.PositionChanged += new System.EventHandler(this.assistanBindingSource_PositionChanged);
            // 
            // bDB56Projet1CKWDataSet
            // 
            this.bDB56Projet1CKWDataSet.DataSetName = "BDB56Projet1CKWDataSet";
            this.bDB56Projet1CKWDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // assistantSoinBindingSource
            // 
            this.assistantSoinBindingSource.DataMember = "AssistantSoin";
            this.assistantSoinBindingSource.DataSource = this.bDB56Projet1CKWDataSet;
            this.assistantSoinBindingSource.CurrentChanged += new System.EventHandler(this.assistantSoinBindingSource_CurrentChanged);
            // 
            // assistantSoinTableAdapter
            // 
            this.assistantSoinTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AssistantSoinTableAdapter = this.assistantSoinTableAdapter;
            this.tableAdapterManager.AssistantTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChambreTableAdapter = null;
            this.tableAdapterManager.ClientTableAdapter = null;
            this.tableAdapterManager.InviteTableAdapter = null;
            this.tableAdapterManager.NoTypeChambreTableAdapter = null;
            this.tableAdapterManager.PlanifSoinTableAdapter = null;
            this.tableAdapterManager.ReservationChambreTableAdapter = null;
            this.tableAdapterManager.SoinTableAdapter = null;
            this.tableAdapterManager.TypeChambreTableAdapter = null;
            this.tableAdapterManager.TypeSoinTableAdapter = null;
            this.tableAdapterManager.TypeUtilisateurTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UtilisateurTableAdapter = null;
            // 
            // assistantTableAdapter
            // 
            this.assistantTableAdapter.ClearBeforeFill = true;
            // 
            // soinsAssBindingSource
            // 
            this.soinsAssBindingSource.DataMember = "SoinsAss";
            this.soinsAssBindingSource.DataSource = this.bDB56Projet1CKWDataSet;
            // 
            // soinsAssTableAdapter
            // 
            this.soinsAssTableAdapter.ClearBeforeFill = true;
            // 
            // soinsAssDataGridView
            // 
            this.soinsAssDataGridView.AutoGenerateColumns = false;
            this.soinsAssDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.soinsAssDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.soinsAssDataGridView.DataSource = this.soinsAssBindingSource;
            this.soinsAssDataGridView.Location = new System.Drawing.Point(570, 12);
            this.soinsAssDataGridView.Name = "soinsAssDataGridView";
            this.soinsAssDataGridView.Size = new System.Drawing.Size(545, 220);
            this.soinsAssDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "NoAssistant";
            this.dataGridViewTextBoxColumn6.HeaderText = "NoAssistant";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn7.HeaderText = "Description";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Duree";
            this.dataGridViewTextBoxColumn8.HeaderText = "Duree";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NoTypeSoin";
            this.dataGridViewTextBoxColumn9.HeaderText = "NoTypeSoin";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Prix";
            this.dataGridViewTextBoxColumn10.HeaderText = "Prix";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // assistantDataGridView
            // 
            this.assistantDataGridView.AutoGenerateColumns = false;
            this.assistantDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.assistantDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.assistantDataGridView.DataSource = this.assistantBindingSource;
            this.assistantDataGridView.Location = new System.Drawing.Point(12, 12);
            this.assistantDataGridView.Name = "assistantDataGridView";
            this.assistantDataGridView.Size = new System.Drawing.Size(552, 220);
            this.assistantDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NoAssistant";
            this.dataGridViewTextBoxColumn1.HeaderText = "NoAssistant";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Prenom";
            this.dataGridViewTextBoxColumn2.HeaderText = "Prenom";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Nom";
            this.dataGridViewTextBoxColumn3.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Specialites";
            this.dataGridViewTextBoxColumn4.HeaderText = "Specialites";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Remarques";
            this.dataGridViewTextBoxColumn5.HeaderText = "Remarques";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // BtnAjoutAss
            // 
            this.BtnAjoutAss.Location = new System.Drawing.Point(46, 254);
            this.BtnAjoutAss.Name = "BtnAjoutAss";
            this.BtnAjoutAss.Size = new System.Drawing.Size(153, 62);
            this.BtnAjoutAss.TabIndex = 2;
            this.BtnAjoutAss.Text = "Ajouter un Assistant";
            this.BtnAjoutAss.UseVisualStyleBackColor = true;
            this.BtnAjoutAss.Click += new System.EventHandler(this.BtnAjoutAss_Click);
            // 
            // BtnModAss
            // 
            this.BtnModAss.Location = new System.Drawing.Point(289, 254);
            this.BtnModAss.Name = "BtnModAss";
            this.BtnModAss.Size = new System.Drawing.Size(153, 62);
            this.BtnModAss.TabIndex = 3;
            this.BtnModAss.Text = "Modifier un assistant";
            this.BtnModAss.UseVisualStyleBackColor = true;
            this.BtnModAss.Click += new System.EventHandler(this.BtnModAss_Click);
            // 
            // BtnAjoutSoins
            // 
            this.BtnAjoutSoins.Location = new System.Drawing.Point(598, 254);
            this.BtnAjoutSoins.Name = "BtnAjoutSoins";
            this.BtnAjoutSoins.Size = new System.Drawing.Size(153, 62);
            this.BtnAjoutSoins.TabIndex = 4;
            this.BtnAjoutSoins.Text = "Ajouter un soin a un Assistant";
            this.BtnAjoutSoins.UseVisualStyleBackColor = true;
            this.BtnAjoutSoins.Click += new System.EventHandler(this.BtnAjoutSoins_Click);
            // 
            // BtnSuppSoins
            // 
            this.BtnSuppSoins.Location = new System.Drawing.Point(848, 254);
            this.BtnSuppSoins.Name = "BtnSuppSoins";
            this.BtnSuppSoins.Size = new System.Drawing.Size(153, 62);
            this.BtnSuppSoins.TabIndex = 5;
            this.BtnSuppSoins.Text = "Supprimer un soin";
            this.BtnSuppSoins.UseVisualStyleBackColor = true;
            // 
            // BtnSuppAss
            // 
            this.BtnSuppAss.Location = new System.Drawing.Point(177, 322);
            this.BtnSuppAss.Name = "BtnSuppAss";
            this.BtnSuppAss.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BtnSuppAss.Size = new System.Drawing.Size(153, 62);
            this.BtnSuppAss.TabIndex = 6;
            this.BtnSuppAss.Text = "Supprimer un Assistant";
            this.BtnSuppAss.UseVisualStyleBackColor = true;
            this.BtnSuppAss.Click += new System.EventHandler(this.BtnSuppAss_Click);
            // 
            // noAssistantTextBox
            // 
            this.noAssistantTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.assistantBindingSource, "NoAssistant", true));
            this.noAssistantTextBox.Location = new System.Drawing.Point(543, 344);
            this.noAssistantTextBox.Name = "noAssistantTextBox";
            this.noAssistantTextBox.Size = new System.Drawing.Size(100, 20);
            this.noAssistantTextBox.TabIndex = 8;
            this.noAssistantTextBox.TextChanged += new System.EventHandler(this.noAssistantTextBox_TextChanged);
            // 
            // prenomTextBox
            // 
            this.prenomTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.assistantBindingSource, "Prenom", true));
            this.prenomTextBox.Location = new System.Drawing.Point(543, 370);
            this.prenomTextBox.Name = "prenomTextBox";
            this.prenomTextBox.Size = new System.Drawing.Size(100, 20);
            this.prenomTextBox.TabIndex = 10;
            this.prenomTextBox.TextChanged += new System.EventHandler(this.prenomTextBox_TextChanged);
            // 
            // nomTextBox
            // 
            this.nomTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.assistantBindingSource, "Nom", true));
            this.nomTextBox.Location = new System.Drawing.Point(543, 396);
            this.nomTextBox.Name = "nomTextBox";
            this.nomTextBox.Size = new System.Drawing.Size(100, 20);
            this.nomTextBox.TabIndex = 12;
            this.nomTextBox.TextChanged += new System.EventHandler(this.nomTextBox_TextChanged);
            // 
            // specialitesTextBox
            // 
            this.specialitesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.assistantBindingSource, "Specialites", true));
            this.specialitesTextBox.Location = new System.Drawing.Point(543, 422);
            this.specialitesTextBox.Name = "specialitesTextBox";
            this.specialitesTextBox.Size = new System.Drawing.Size(100, 20);
            this.specialitesTextBox.TabIndex = 14;
            this.specialitesTextBox.TextChanged += new System.EventHandler(this.specialitesTextBox_TextChanged);
            // 
            // remarquesTextBox
            // 
            this.remarquesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.assistantBindingSource, "Remarques", true));
            this.remarquesTextBox.Location = new System.Drawing.Point(543, 448);
            this.remarquesTextBox.Name = "remarquesTextBox";
            this.remarquesTextBox.Size = new System.Drawing.Size(100, 20);
            this.remarquesTextBox.TabIndex = 16;
            this.remarquesTextBox.TextChanged += new System.EventHandler(this.remarquesTextBox_TextChanged);
            // 
            // noAssLabel
            // 
            this.noAssLabel.AutoSize = true;
            this.noAssLabel.Location = new System.Drawing.Point(462, 347);
            this.noAssLabel.Name = "noAssLabel";
            this.noAssLabel.Size = new System.Drawing.Size(66, 13);
            this.noAssLabel.TabIndex = 17;
            this.noAssLabel.Text = "No Assistant";
            // 
            // prenomLabel
            // 
            this.prenomLabel.AutoSize = true;
            this.prenomLabel.Location = new System.Drawing.Point(462, 371);
            this.prenomLabel.Name = "prenomLabel";
            this.prenomLabel.Size = new System.Drawing.Size(46, 13);
            this.prenomLabel.TabIndex = 18;
            this.prenomLabel.Text = "Prenom:";
            // 
            // nomLabel
            // 
            this.nomLabel.AutoSize = true;
            this.nomLabel.Location = new System.Drawing.Point(462, 399);
            this.nomLabel.Name = "nomLabel";
            this.nomLabel.Size = new System.Drawing.Size(32, 13);
            this.nomLabel.TabIndex = 19;
            this.nomLabel.Text = "Nom:";
            // 
            // specLabel
            // 
            this.specLabel.AutoSize = true;
            this.specLabel.Location = new System.Drawing.Point(462, 425);
            this.specLabel.Name = "specLabel";
            this.specLabel.Size = new System.Drawing.Size(58, 13);
            this.specLabel.TabIndex = 20;
            this.specLabel.Text = "Specialites";
            // 
            // remarqueLabel
            // 
            this.remarqueLabel.AutoSize = true;
            this.remarqueLabel.Location = new System.Drawing.Point(462, 451);
            this.remarqueLabel.Name = "remarqueLabel";
            this.remarqueLabel.Size = new System.Drawing.Size(70, 13);
            this.remarqueLabel.TabIndex = 21;
            this.remarqueLabel.Text = "Remarques : ";
            // 
            // BtnConfirmer
            // 
            this.BtnConfirmer.Location = new System.Drawing.Point(698, 387);
            this.BtnConfirmer.Name = "BtnConfirmer";
            this.BtnConfirmer.Size = new System.Drawing.Size(117, 37);
            this.BtnConfirmer.TabIndex = 22;
            this.BtnConfirmer.Text = "Confirmer";
            this.BtnConfirmer.UseVisualStyleBackColor = true;
            this.BtnConfirmer.Visible = false;
            this.BtnConfirmer.Click += new System.EventHandler(this.BtnConfirmer_Click);
            // 
            // btnAjouterSoins
            // 
            this.btnAjouterSoins.Location = new System.Drawing.Point(543, 396);
            this.btnAjouterSoins.Name = "btnAjouterSoins";
            this.btnAjouterSoins.Size = new System.Drawing.Size(102, 42);
            this.btnAjouterSoins.TabIndex = 23;
            this.btnAjouterSoins.Text = "Ajouter ce soins";
            this.btnAjouterSoins.UseVisualStyleBackColor = true;
            this.btnAjouterSoins.Visible = false;
            // 
            // BtnRetour
            // 
            this.BtnRetour.Location = new System.Drawing.Point(717, 430);
            this.BtnRetour.Name = "BtnRetour";
            this.BtnRetour.Size = new System.Drawing.Size(75, 23);
            this.BtnRetour.TabIndex = 24;
            this.BtnRetour.Text = "Retourner";
            this.BtnRetour.UseVisualStyleBackColor = true;
            this.BtnRetour.Visible = false;
            // 
            // soinsAssBindingSource1
            // 
            this.soinsAssBindingSource1.DataMember = "SoinsAss";
            this.soinsAssBindingSource1.DataSource = this.bDB56Projet1CKWDataSet;
            // 
            // comSoins
            // 
            this.comSoins.FormattingEnabled = true;
            this.comSoins.Location = new System.Drawing.Point(448, 295);
            this.comSoins.Name = "comSoins";
            this.comSoins.Size = new System.Drawing.Size(296, 21);
            this.comSoins.TabIndex = 25;
            this.comSoins.Visible = false;
            // 
            // FrmAssistantsSoins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 603);
            this.Controls.Add(this.comSoins);
            this.Controls.Add(this.BtnRetour);
            this.Controls.Add(this.btnAjouterSoins);
            this.Controls.Add(this.BtnConfirmer);
            this.Controls.Add(this.remarqueLabel);
            this.Controls.Add(this.specLabel);
            this.Controls.Add(this.nomLabel);
            this.Controls.Add(this.prenomLabel);
            this.Controls.Add(this.noAssLabel);
            this.Controls.Add(this.noAssistantTextBox);
            this.Controls.Add(this.prenomTextBox);
            this.Controls.Add(this.nomTextBox);
            this.Controls.Add(this.specialitesTextBox);
            this.Controls.Add(this.remarquesTextBox);
            this.Controls.Add(this.BtnSuppAss);
            this.Controls.Add(this.BtnSuppSoins);
            this.Controls.Add(this.BtnAjoutSoins);
            this.Controls.Add(this.BtnModAss);
            this.Controls.Add(this.BtnAjoutAss);
            this.Controls.Add(this.assistantDataGridView);
            this.Controls.Add(this.soinsAssDataGridView);
            this.Name = "FrmAssistantsSoins";
            this.Text = "FrmAssistantsSoins";
            this.Load += new System.EventHandler(this.FrmAssistantsSoins_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assistantBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bDB56Projet1CKWDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistantSoinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soinsAssBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soinsAssDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assistantDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.soinsAssBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private BDB56Projet1CKWDataSet bDB56Projet1CKWDataSet;
        private System.Windows.Forms.BindingSource assistantSoinBindingSource;
        private BDB56Projet1CKWDataSetTableAdapters.AssistantSoinTableAdapter assistantSoinTableAdapter;
        private BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource assistantBindingSource;
        private BDB56Projet1CKWDataSetTableAdapters.AssistantTableAdapter assistantTableAdapter;
        private System.Windows.Forms.BindingSource soinsAssBindingSource;
        private BDB56Projet1CKWDataSetTableAdapters.SoinsAssTableAdapter soinsAssTableAdapter;
        private System.Windows.Forms.DataGridView soinsAssDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView assistantDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button BtnAjoutAss;
        private System.Windows.Forms.Button BtnModAss;
        private System.Windows.Forms.Button BtnAjoutSoins;
        private System.Windows.Forms.Button BtnSuppSoins;
        private System.Windows.Forms.Button BtnSuppAss;
        private System.Windows.Forms.TextBox noAssistantTextBox;
        private System.Windows.Forms.TextBox prenomTextBox;
        private System.Windows.Forms.TextBox nomTextBox;
        private System.Windows.Forms.TextBox specialitesTextBox;
        private System.Windows.Forms.TextBox remarquesTextBox;
        private System.Windows.Forms.Label noAssLabel;
        private System.Windows.Forms.Label prenomLabel;
        private System.Windows.Forms.Label nomLabel;
        private System.Windows.Forms.Label specLabel;
        private System.Windows.Forms.Label remarqueLabel;
        private System.Windows.Forms.Button BtnConfirmer;
        private System.Windows.Forms.Button btnAjouterSoins;
        private System.Windows.Forms.Button BtnRetour;
        private System.Windows.Forms.BindingSource soinsAssBindingSource1;
        private System.Windows.Forms.ComboBox comSoins;
    }
}