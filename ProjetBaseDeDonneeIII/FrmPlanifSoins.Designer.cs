namespace ProjetBaseDeDonneeIII
{
    partial class FrmPlanifSoins
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bDB56Projet1CKWDataSet = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSet();
            this.planifSoinBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.planifSoinTableAdapter = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.PlanifSoinTableAdapter();
            this.tableAdapterManager = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager();
            this.errMessage = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvPlanifSoins = new System.Windows.Forms.DataGridView();
            this.colNoPersonne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoAssistant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateHeure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNoSoin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPersonne = new System.Windows.Forms.Label();
            this.lblSoin = new System.Windows.Forms.Label();
            this.lblAssistant = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblHeure = new System.Windows.Forms.Label();
            this.cmbPersonne = new System.Windows.Forms.ComboBox();
            this.cmbSoin = new System.Windows.Forms.ComboBox();
            this.cmbAssistant = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbHeure = new System.Windows.Forms.ComboBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bDB56Projet1CKWDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planifSoinBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanifSoins)).BeginInit();
            this.SuspendLayout();
            // 
            // bDB56Projet1CKWDataSet
            // 
            this.bDB56Projet1CKWDataSet.DataSetName = "BDB56Projet1CKWDataSet";
            this.bDB56Projet1CKWDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // planifSoinBindingSource
            // 
            this.planifSoinBindingSource.DataMember = "PlanifSoin";
            this.planifSoinBindingSource.DataSource = this.bDB56Projet1CKWDataSet;
            // 
            // planifSoinTableAdapter
            // 
            this.planifSoinTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.AssistantSoinTableAdapter = null;
            this.tableAdapterManager.AssistantTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChambreTableAdapter = null;
            this.tableAdapterManager.ClientTableAdapter = null;
            this.tableAdapterManager.InviteTableAdapter = null;
            this.tableAdapterManager.NoTypeChambreTableAdapter = null;
            this.tableAdapterManager.PlanifSoinTableAdapter = this.planifSoinTableAdapter;
            this.tableAdapterManager.ReservationChambreTableAdapter = null;
            this.tableAdapterManager.SoinTableAdapter = null;
            this.tableAdapterManager.TypeChambreTableAdapter = null;
            this.tableAdapterManager.TypeSoinTableAdapter = null;
            this.tableAdapterManager.TypeUtilisateurTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UtilisateurTableAdapter = null;
            // 
            // errMessage
            // 
            this.errMessage.ContainerControl = this;
            // 
            // dgvPlanifSoins
            // 
            this.dgvPlanifSoins.AllowUserToAddRows = false;
            this.dgvPlanifSoins.AllowUserToDeleteRows = false;
            this.dgvPlanifSoins.AutoGenerateColumns = false;
            this.dgvPlanifSoins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanifSoins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNoPersonne,
            this.colNoAssistant,
            this.colDateHeure,
            this.colNoSoin});
            this.dgvPlanifSoins.DataSource = this.planifSoinBindingSource;
            this.dgvPlanifSoins.Location = new System.Drawing.Point(12, 12);
            this.dgvPlanifSoins.MultiSelect = false;
            this.dgvPlanifSoins.Name = "dgvPlanifSoins";
            this.dgvPlanifSoins.ReadOnly = true;
            this.dgvPlanifSoins.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanifSoins.Size = new System.Drawing.Size(483, 220);
            this.dgvPlanifSoins.TabIndex = 0;
            // 
            // colNoPersonne
            // 
            this.colNoPersonne.DataPropertyName = "NoPersonne";
            this.colNoPersonne.HeaderText = "No personne";
            this.colNoPersonne.Name = "colNoPersonne";
            this.colNoPersonne.ReadOnly = true;
            // 
            // colNoAssistant
            // 
            this.colNoAssistant.DataPropertyName = "NoAssistant";
            this.colNoAssistant.HeaderText = "No assistant";
            this.colNoAssistant.Name = "colNoAssistant";
            this.colNoAssistant.ReadOnly = true;
            // 
            // colDateHeure
            // 
            this.colDateHeure.DataPropertyName = "DateHeure";
            dataGridViewCellStyle4.Format = "yyyy-MM-dd HH:mm";
            this.colDateHeure.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDateHeure.HeaderText = "Date et heure";
            this.colDateHeure.Name = "colDateHeure";
            this.colDateHeure.ReadOnly = true;
            this.colDateHeure.Width = 140;
            // 
            // colNoSoin
            // 
            this.colNoSoin.DataPropertyName = "NoSoin";
            this.colNoSoin.HeaderText = "No soin";
            this.colNoSoin.Name = "colNoSoin";
            this.colNoSoin.ReadOnly = true;
            // 
            // lblPersonne
            // 
            this.lblPersonne.AutoSize = true;
            this.lblPersonne.Location = new System.Drawing.Point(20, 258);
            this.lblPersonne.Name = "lblPersonne";
            this.lblPersonne.Size = new System.Drawing.Size(82, 13);
            this.lblPersonne.TabIndex = 1;
            this.lblPersonne.Text = "Client ou invité :";
            // 
            // lblSoin
            // 
            this.lblSoin.AutoSize = true;
            this.lblSoin.Location = new System.Drawing.Point(20, 293);
            this.lblSoin.Name = "lblSoin";
            this.lblSoin.Size = new System.Drawing.Size(34, 13);
            this.lblSoin.TabIndex = 2;
            this.lblSoin.Text = "Soin :";
            // 
            // lblAssistant
            // 
            this.lblAssistant.AutoSize = true;
            this.lblAssistant.Location = new System.Drawing.Point(20, 328);
            this.lblAssistant.Name = "lblAssistant";
            this.lblAssistant.Size = new System.Drawing.Size(55, 13);
            this.lblAssistant.TabIndex = 3;
            this.lblAssistant.Text = "Assistant :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(20, 363);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(36, 13);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "Date :";
            // 
            // lblHeure
            // 
            this.lblHeure.AutoSize = true;
            this.lblHeure.Location = new System.Drawing.Point(20, 398);
            this.lblHeure.Name = "lblHeure";
            this.lblHeure.Size = new System.Drawing.Size(42, 13);
            this.lblHeure.TabIndex = 5;
            this.lblHeure.Text = "Heure :";
            // 
            // cmbPersonne
            // 
            this.cmbPersonne.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonne.FormattingEnabled = true;
            this.cmbPersonne.Location = new System.Drawing.Point(150, 255);
            this.cmbPersonne.Name = "cmbPersonne";
            this.cmbPersonne.Size = new System.Drawing.Size(300, 21);
            this.cmbPersonne.TabIndex = 6;
            // 
            // cmbSoin
            // 
            this.cmbSoin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSoin.FormattingEnabled = true;
            this.cmbSoin.Location = new System.Drawing.Point(150, 290);
            this.cmbSoin.Name = "cmbSoin";
            this.cmbSoin.Size = new System.Drawing.Size(300, 21);
            this.cmbSoin.TabIndex = 7;
            // 
            // cmbAssistant
            // 
            this.cmbAssistant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssistant.FormattingEnabled = true;
            this.cmbAssistant.Location = new System.Drawing.Point(150, 325);
            this.cmbAssistant.Name = "cmbAssistant";
            this.cmbAssistant.Size = new System.Drawing.Size(300, 21);
            this.cmbAssistant.TabIndex = 8;
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(150, 360);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(120, 20);
            this.dtpDate.TabIndex = 9;
            // 
            // cmbHeure
            // 
            this.cmbHeure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeure.FormattingEnabled = true;
            this.cmbHeure.Location = new System.Drawing.Point(150, 395);
            this.cmbHeure.Name = "cmbHeure";
            this.cmbHeure.Size = new System.Drawing.Size(120, 21);
            this.cmbHeure.TabIndex = 10;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(500, 250);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(130, 40);
            this.btnAjouter.TabIndex = 11;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(500, 300);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(130, 40);
            this.btnEnregistrer.TabIndex = 12;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(500, 350);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(130, 40);
            this.btnSupprimer.TabIndex = 13;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(500, 400);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(130, 40);
            this.btnAnnuler.TabIndex = 14;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // FrmPlanifSoins
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 460);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.cmbHeure);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbAssistant);
            this.Controls.Add(this.cmbSoin);
            this.Controls.Add(this.cmbPersonne);
            this.Controls.Add(this.lblHeure);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblAssistant);
            this.Controls.Add(this.lblSoin);
            this.Controls.Add(this.lblPersonne);
            this.Controls.Add(this.dgvPlanifSoins);
            this.Name = "FrmPlanifSoins";
            this.Text = "Planification des soins";
            ((System.ComponentModel.ISupportInitialize)(this.bDB56Projet1CKWDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planifSoinBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanifSoins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BDB56Projet1CKWDataSet bDB56Projet1CKWDataSet;
        private System.Windows.Forms.BindingSource planifSoinBindingSource;
        private BDB56Projet1CKWDataSetTableAdapters.PlanifSoinTableAdapter planifSoinTableAdapter;
        private BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ErrorProvider errMessage;
        private System.Windows.Forms.DataGridView dgvPlanifSoins;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoPersonne;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoAssistant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateHeure;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNoSoin;
        private System.Windows.Forms.Label lblPersonne;
        private System.Windows.Forms.Label lblSoin;
        private System.Windows.Forms.Label lblAssistant;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblHeure;
        private System.Windows.Forms.ComboBox cmbPersonne;
        private System.Windows.Forms.ComboBox cmbSoin;
        private System.Windows.Forms.ComboBox cmbAssistant;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbHeure;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}