
namespace ProjetBaseDeDonneeIII
{
    partial class FrmSoins
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.bDB56Projet1CKWDataSet =
                new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSet();

            this.soinBindingSource =
                new System.Windows.Forms.BindingSource(this.components);

            this.soinTableAdapter =
                new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.SoinTableAdapter();

            this.tableAdapterManager =
                new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager();

            this.soinDataGridView =
                new System.Windows.Forms.DataGridView();

            this.dataGridViewTextBoxColumn1 =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.dataGridViewTextBoxColumn2 =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.dataGridViewTextBoxColumn3 =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.dataGridViewTextBoxColumn4 =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.dataGridViewTextBoxColumn5 =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblNoSoin = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDuree = new System.Windows.Forms.Label();
            this.lblTypeSoin = new System.Windows.Forms.Label();
            this.lblPrix = new System.Windows.Forms.Label();

            this.label7 = new System.Windows.Forms.Label();

            this.txtNoSoin = new System.Windows.Forms.TextBox();
            this.txtPrix = new System.Windows.Forms.TextBox();
            this.txtDuree = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.cmbTypeSoin = new System.Windows.Forms.ComboBox();

            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();

            this.errMessage =
                new System.Windows.Forms.ErrorProvider(this.components);

            ((System.ComponentModel.ISupportInitialize)
                (this.bDB56Projet1CKWDataSet)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.soinBindingSource)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.soinDataGridView)).BeginInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.errMessage)).BeginInit();

            this.SuspendLayout();

            // DataSet
            this.bDB56Projet1CKWDataSet.DataSetName =
                "BDB56Projet1CKWDataSet";

            this.bDB56Projet1CKWDataSet.SchemaSerializationMode =
                System.Data.SchemaSerializationMode.IncludeSchema;

            // BindingSource
            this.soinBindingSource.DataMember = "Soin";
            this.soinBindingSource.DataSource =
                this.bDB56Projet1CKWDataSet;

            // TableAdapter
            this.soinTableAdapter.ClearBeforeFill = true;

            // TableAdapterManager
            this.tableAdapterManager.AssistantSoinTableAdapter = null;
            this.tableAdapterManager.AssistantTableAdapter = null;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.ChambreTableAdapter = null;
            this.tableAdapterManager.ClientTableAdapter = null;
            this.tableAdapterManager.InviteTableAdapter = null;
            this.tableAdapterManager.NoTypeChambreTableAdapter = null;
            this.tableAdapterManager.PlanifSoinTableAdapter = null;
            this.tableAdapterManager.ReservationChambreTableAdapter = null;
            this.tableAdapterManager.SoinTableAdapter =
                this.soinTableAdapter;
            this.tableAdapterManager.TypeChambreTableAdapter = null;
            this.tableAdapterManager.TypeSoinTableAdapter = null;
            this.tableAdapterManager.TypeUtilisateurTableAdapter = null;
            this.tableAdapterManager.UtilisateurTableAdapter = null;

            this.tableAdapterManager.UpdateOrder =
                ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters
                .TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;

            // DataGridView
            this.soinDataGridView.AllowUserToAddRows = false;
            this.soinDataGridView.AllowUserToDeleteRows = false;
            this.soinDataGridView.AutoGenerateColumns = false;
            this.soinDataGridView.ReadOnly = true;
            this.soinDataGridView.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.soinDataGridView.MultiSelect = false;
            this.soinDataGridView.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.soinDataGridView.RowHeadersWidth = 50;

            this.dataGridViewTextBoxColumn1.DataPropertyName = "NoSoin";
            this.dataGridViewTextBoxColumn1.HeaderText = "No de soin";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;

            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;

            this.dataGridViewTextBoxColumn3.DataPropertyName = "Duree";
            this.dataGridViewTextBoxColumn3.HeaderText = "Durée (minutes)";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;

            this.dataGridViewTextBoxColumn4.DataPropertyName = "NoTypeSoin";
            this.dataGridViewTextBoxColumn4.HeaderText = "No de type";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;

            this.dataGridViewTextBoxColumn5.DataPropertyName = "Prix";
            this.dataGridViewTextBoxColumn5.HeaderText = "Prix";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle.Format = "C2";

            this.soinDataGridView.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    this.dataGridViewTextBoxColumn1,
                    this.dataGridViewTextBoxColumn2,
                    this.dataGridViewTextBoxColumn3,
                    this.dataGridViewTextBoxColumn4,
                    this.dataGridViewTextBoxColumn5
                });

            this.soinDataGridView.DataSource = this.soinBindingSource;
            this.soinDataGridView.Location =
                new System.Drawing.Point(25, 50);
            this.soinDataGridView.Name = "soinDataGridView";
            this.soinDataGridView.Size =
                new System.Drawing.Size(700, 260);
            this.soinDataGridView.TabIndex = 0;

            // Numéro du soin
            this.lblNoSoin.AutoSize = true;
            this.lblNoSoin.Location =
                new System.Drawing.Point(25, 345);
            this.lblNoSoin.Text = "Numéro du soin :";

            this.txtNoSoin.Location =
                new System.Drawing.Point(150, 342);
            this.txtNoSoin.Name = "txtNoSoin";
            this.txtNoSoin.ReadOnly = true;
            this.txtNoSoin.Size =
                new System.Drawing.Size(150, 23);
            this.txtNoSoin.TabIndex = 1;

            // Description
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location =
                new System.Drawing.Point(25, 385);
            this.lblDescription.Text = "Description :";

            this.txtDescription.Location =
                new System.Drawing.Point(150, 382);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.MaxLength = 100;
            this.txtDescription.Size =
                new System.Drawing.Size(220, 23);
            this.txtDescription.TabIndex = 2;

            // Durée
            this.lblDuree.AutoSize = true;
            this.lblDuree.Location =
                new System.Drawing.Point(25, 425);
            this.lblDuree.Text = "Durée (minutes) :";

            this.txtDuree.Location =
                new System.Drawing.Point(150, 422);
            this.txtDuree.Name = "txtDuree";
            this.txtDuree.ReadOnly = true;
            this.txtDuree.Size =
                new System.Drawing.Size(150, 23);
            this.txtDuree.TabIndex = 3;

            // Type de soin
            this.lblTypeSoin.AutoSize = true;
            this.lblTypeSoin.Location =
                new System.Drawing.Point(25, 465);
            this.lblTypeSoin.Text = "Type de soin :";

            this.cmbTypeSoin.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeSoin.FormattingEnabled = true;
            this.cmbTypeSoin.Location =
                new System.Drawing.Point(150, 462);
            this.cmbTypeSoin.Name = "cmbTypeSoin";
            this.cmbTypeSoin.Size =
                new System.Drawing.Size(220, 23);
            this.cmbTypeSoin.TabIndex = 4;

            // Prix
            this.lblPrix.AutoSize = true;
            this.lblPrix.Location =
                new System.Drawing.Point(25, 505);
            this.lblPrix.Text = "Prix :";

            this.txtPrix.Location =
                new System.Drawing.Point(150, 502);
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.MaxLength = 10;
            this.txtPrix.Size =
                new System.Drawing.Size(150, 23);
            this.txtPrix.TabIndex = 5;

            // Label conservé pour compatibilité
            this.label7.AutoSize = true;
            this.label7.Location =
                new System.Drawing.Point(25, 540);
            this.label7.Name = "label7";
            this.label7.Text = "";

            // Bouton Ajouter
            this.btnAjouter.Location =
                new System.Drawing.Point(430, 345);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size =
                new System.Drawing.Size(130, 45);
            this.btnAjouter.TabIndex = 6;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click +=
                new System.EventHandler(this.btnAjouter_Click);

            // Bouton Supprimer
            this.btnSupprimer.Location =
                new System.Drawing.Point(580, 345);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size =
                new System.Drawing.Size(130, 45);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click +=
                new System.EventHandler(this.btnSupprimer_Click);

            // Bouton Enregistrer
            this.btnEnregistrer.Location =
                new System.Drawing.Point(430, 410);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size =
                new System.Drawing.Size(130, 45);
            this.btnEnregistrer.TabIndex = 8;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click +=
                new System.EventHandler(this.btnEnregistrer_Click);

            // Bouton Annuler
            this.btnAnnuler.Location =
                new System.Drawing.Point(580, 410);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size =
                new System.Drawing.Size(130, 45);
            this.btnAnnuler.TabIndex = 9;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click +=
                new System.EventHandler(this.btnAnnuler_Click);

            // ErrorProvider
            this.errMessage.ContainerControl = this;

            // Formulaire
            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize =
                new System.Drawing.Size(770, 570);

            this.Controls.Add(this.soinDataGridView);

            this.Controls.Add(this.lblNoSoin);
            this.Controls.Add(this.txtNoSoin);

            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);

            this.Controls.Add(this.lblDuree);
            this.Controls.Add(this.txtDuree);

            this.Controls.Add(this.lblTypeSoin);
            this.Controls.Add(this.cmbTypeSoin);

            this.Controls.Add(this.lblPrix);
            this.Controls.Add(this.txtPrix);

            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAnnuler);

            this.Name = "FrmSoins";
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des soins";

            this.Load +=
                new System.EventHandler(this.FrmSoins_Load);

            ((System.ComponentModel.ISupportInitialize)
                (this.bDB56Projet1CKWDataSet)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.soinBindingSource)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.soinDataGridView)).EndInit();

            ((System.ComponentModel.ISupportInitialize)
                (this.errMessage)).EndInit();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private BDB56Projet1CKWDataSet bDB56Projet1CKWDataSet;
        private System.Windows.Forms.BindingSource soinBindingSource;
        private BDB56Projet1CKWDataSetTableAdapters.SoinTableAdapter soinTableAdapter;
        private BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager tableAdapterManager;

        private System.Windows.Forms.DataGridView soinDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

        private System.Windows.Forms.Label lblNoSoin;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDuree;
        private System.Windows.Forms.Label lblTypeSoin;
        private System.Windows.Forms.Label lblPrix;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.TextBox txtNoSoin;
        private System.Windows.Forms.TextBox txtPrix;
        private System.Windows.Forms.TextBox txtDuree;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.ComboBox cmbTypeSoin;

        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;

        private System.Windows.Forms.ErrorProvider errMessage;
    }
}
