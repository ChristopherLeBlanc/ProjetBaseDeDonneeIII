namespace ProjetBaseDeDonneeIII
{
    partial class FrmReservations
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
            this.bDB56Projet1CKWDataSet = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSet();
            this.reservationChambreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reservationChambreTableAdapter = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.ReservationChambreTableAdapter();
            this.tableAdapterManager = new ProjetBaseDeDonneeIII.BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager();
            this.errMessage = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.colResNoClient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResNoChambre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResArrivee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResDepart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResNbPersonnes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblClient = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblChambre = new System.Windows.Forms.Label();
            this.dgvChambres = new System.Windows.Forms.DataGridView();
            this.colChNoChambre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChEmplacement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChDecorations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChPrixHaut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChPrixBas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChPrixMoyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblArrivee = new System.Windows.Forms.Label();
            this.dtpArrivee = new System.Windows.Forms.DateTimePicker();
            this.lblDepart = new System.Windows.Forms.Label();
            this.dtpDepart = new System.Windows.Forms.DateTimePicker();
            this.lblPersonnes = new System.Windows.Forms.Label();
            this.nudPersonnes = new System.Windows.Forms.NumericUpDown();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bDB56Projet1CKWDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationChambreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChambres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonnes)).BeginInit();
            this.SuspendLayout();
            // 
            // bDB56Projet1CKWDataSet
            // 
            this.bDB56Projet1CKWDataSet.DataSetName = "BDB56Projet1CKWDataSet";
            this.bDB56Projet1CKWDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reservationChambreBindingSource
            // 
            this.reservationChambreBindingSource.DataMember = "ReservationChambre";
            this.reservationChambreBindingSource.DataSource = this.bDB56Projet1CKWDataSet;
            // 
            // reservationChambreTableAdapter
            // 
            this.reservationChambreTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.PlanifSoinTableAdapter = null;
            this.tableAdapterManager.ReservationChambreTableAdapter = this.reservationChambreTableAdapter;
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
            // dgvReservations
            // 
            this.dgvReservations.AllowUserToAddRows = false;
            this.dgvReservations.AllowUserToDeleteRows = false;
            this.dgvReservations.AutoGenerateColumns = false;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colResNoClient,
            this.colResNoChambre,
            this.colResArrivee,
            this.colResDepart,
            this.colResNbPersonnes});
            this.dgvReservations.DataSource = this.reservationChambreBindingSource;
            this.dgvReservations.Location = new System.Drawing.Point(12, 12);
            this.dgvReservations.MultiSelect = false;
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.ReadOnly = true;
            this.dgvReservations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservations.Size = new System.Drawing.Size(960, 170);
            this.dgvReservations.TabIndex = 0;
            // 
            // colResNoClient
            // 
            this.colResNoClient.DataPropertyName = "NoClient";
            this.colResNoClient.HeaderText = "No client";
            this.colResNoClient.Name = "colResNoClient";
            this.colResNoClient.ReadOnly = true;
            // 
            // colResNoChambre
            // 
            this.colResNoChambre.DataPropertyName = "NoChambre";
            this.colResNoChambre.HeaderText = "No chambre";
            this.colResNoChambre.Name = "colResNoChambre";
            this.colResNoChambre.ReadOnly = true;
            // 
            // colResArrivee
            // 
            this.colResArrivee.DataPropertyName = "DateArrivee";
            this.colResArrivee.DefaultCellStyle.Format = "yyyy-MM-dd";
            this.colResArrivee.HeaderText = "Date d\'arrivée";
            this.colResArrivee.Name = "colResArrivee";
            this.colResArrivee.ReadOnly = true;
            // 
            // colResDepart
            // 
            this.colResDepart.DataPropertyName = "DateDepart";
            this.colResDepart.DefaultCellStyle.Format = "yyyy-MM-dd";
            this.colResDepart.HeaderText = "Date de départ";
            this.colResDepart.Name = "colResDepart";
            this.colResDepart.ReadOnly = true;
            // 
            // colResNbPersonnes
            // 
            this.colResNbPersonnes.DataPropertyName = "NbPersonnes";
            this.colResNbPersonnes.HeaderText = "Nb personnes";
            this.colResNbPersonnes.Name = "colResNbPersonnes";
            this.colResNbPersonnes.ReadOnly = true;
            // 
            // lblClient
            // 
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 200);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(39, 13);
            this.lblClient.TabIndex = 1;
            this.lblClient.Text = "Client :";
            // 
            // cmbClient
            // 
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(150, 197);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(300, 21);
            this.cmbClient.TabIndex = 2;
            // 
            // lblChambre
            // 
            this.lblChambre.AutoSize = true;
            this.lblChambre.Location = new System.Drawing.Point(20, 232);
            this.lblChambre.Name = "lblChambre";
            this.lblChambre.Size = new System.Drawing.Size(56, 13);
            this.lblChambre.TabIndex = 3;
            this.lblChambre.Text = "Chambre :";
            // 
            // dgvChambres
            // 
            this.dgvChambres.AllowUserToAddRows = false;
            this.dgvChambres.AllowUserToDeleteRows = false;
            this.dgvChambres.AutoGenerateColumns = false;
            this.dgvChambres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChambres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChNoChambre,
            this.colChEmplacement,
            this.colChDecorations,
            this.colChPrixHaut,
            this.colChPrixBas,
            this.colChPrixMoyen});
            this.dgvChambres.Location = new System.Drawing.Point(20, 250);
            this.dgvChambres.MultiSelect = false;
            this.dgvChambres.Name = "dgvChambres";
            this.dgvChambres.ReadOnly = true;
            this.dgvChambres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChambres.Size = new System.Drawing.Size(950, 150);
            this.dgvChambres.TabIndex = 4;
            // 
            // colChNoChambre
            // 
            this.colChNoChambre.DataPropertyName = "NoChambre";
            this.colChNoChambre.HeaderText = "No chambre";
            this.colChNoChambre.Name = "colChNoChambre";
            this.colChNoChambre.ReadOnly = true;
            // 
            // colChEmplacement
            // 
            this.colChEmplacement.DataPropertyName = "Emplacement";
            this.colChEmplacement.HeaderText = "Emplacement";
            this.colChEmplacement.Name = "colChEmplacement";
            this.colChEmplacement.ReadOnly = true;
            this.colChEmplacement.Width = 200;
            // 
            // colChDecorations
            // 
            this.colChDecorations.DataPropertyName = "Decorations";
            this.colChDecorations.HeaderText = "Décoration";
            this.colChDecorations.Name = "colChDecorations";
            this.colChDecorations.ReadOnly = true;
            this.colChDecorations.Width = 150;
            // 
            // colChPrixHaut
            // 
            this.colChPrixHaut.DataPropertyName = "PrixHaut";
            this.colChPrixHaut.DefaultCellStyle.Format = "N2";
            this.colChPrixHaut.HeaderText = "Prix saison haute";
            this.colChPrixHaut.Name = "colChPrixHaut";
            this.colChPrixHaut.ReadOnly = true;
            // 
            // colChPrixBas
            // 
            this.colChPrixBas.DataPropertyName = "PrixBas";
            this.colChPrixBas.DefaultCellStyle.Format = "N2";
            this.colChPrixBas.HeaderText = "Prix saison basse";
            this.colChPrixBas.Name = "colChPrixBas";
            this.colChPrixBas.ReadOnly = true;
            // 
            // colChPrixMoyen
            // 
            this.colChPrixMoyen.DataPropertyName = "PrixMoyen";
            this.colChPrixMoyen.DefaultCellStyle.Format = "N2";
            this.colChPrixMoyen.HeaderText = "Prix saison moyenne";
            this.colChPrixMoyen.Name = "colChPrixMoyen";
            this.colChPrixMoyen.ReadOnly = true;
            // 
            // lblArrivee
            // 
            this.lblArrivee.AutoSize = true;
            this.lblArrivee.Location = new System.Drawing.Point(20, 418);
            this.lblArrivee.Name = "lblArrivee";
            this.lblArrivee.Size = new System.Drawing.Size(84, 13);
            this.lblArrivee.TabIndex = 5;
            this.lblArrivee.Text = "Date d\'arrivée :";
            // 
            // dtpArrivee
            // 
            this.dtpArrivee.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpArrivee.Location = new System.Drawing.Point(150, 414);
            this.dtpArrivee.Name = "dtpArrivee";
            this.dtpArrivee.Size = new System.Drawing.Size(120, 20);
            this.dtpArrivee.TabIndex = 6;
            // 
            // lblDepart
            // 
            this.lblDepart.AutoSize = true;
            this.lblDepart.Location = new System.Drawing.Point(20, 450);
            this.lblDepart.Name = "lblDepart";
            this.lblDepart.Size = new System.Drawing.Size(88, 13);
            this.lblDepart.TabIndex = 7;
            this.lblDepart.Text = "Date de départ :";
            // 
            // dtpDepart
            // 
            this.dtpDepart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDepart.Location = new System.Drawing.Point(150, 446);
            this.dtpDepart.Name = "dtpDepart";
            this.dtpDepart.Size = new System.Drawing.Size(120, 20);
            this.dtpDepart.TabIndex = 8;
            // 
            // lblPersonnes
            // 
            this.lblPersonnes.AutoSize = true;
            this.lblPersonnes.Location = new System.Drawing.Point(20, 482);
            this.lblPersonnes.Name = "lblPersonnes";
            this.lblPersonnes.Size = new System.Drawing.Size(105, 13);
            this.lblPersonnes.TabIndex = 9;
            this.lblPersonnes.Text = "Nombre de personnes :";
            // 
            // nudPersonnes
            // 
            this.nudPersonnes.Location = new System.Drawing.Point(150, 478);
            this.nudPersonnes.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nudPersonnes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPersonnes.Name = "nudPersonnes";
            this.nudPersonnes.ReadOnly = true;
            this.nudPersonnes.Size = new System.Drawing.Size(60, 20);
            this.nudPersonnes.TabIndex = 10;
            this.nudPersonnes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(20, 520);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(130, 40);
            this.btnAjouter.TabIndex = 11;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(170, 520);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(130, 40);
            this.btnEnregistrer.TabIndex = 12;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(320, 520);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(130, 40);
            this.btnSupprimer.TabIndex = 13;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(470, 520);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(130, 40);
            this.btnAnnuler.TabIndex = 14;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // FrmReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 580);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.nudPersonnes);
            this.Controls.Add(this.lblPersonnes);
            this.Controls.Add(this.dtpDepart);
            this.Controls.Add(this.lblDepart);
            this.Controls.Add(this.dtpArrivee);
            this.Controls.Add(this.lblArrivee);
            this.Controls.Add(this.dgvChambres);
            this.Controls.Add(this.lblChambre);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.lblClient);
            this.Controls.Add(this.dgvReservations);
            this.Name = "FrmReservations";
            this.Text = "Réservation des chambres";
            ((System.ComponentModel.ISupportInitialize)(this.bDB56Projet1CKWDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationChambreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChambres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonnes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BDB56Projet1CKWDataSet bDB56Projet1CKWDataSet;
        private System.Windows.Forms.BindingSource reservationChambreBindingSource;
        private BDB56Projet1CKWDataSetTableAdapters.ReservationChambreTableAdapter reservationChambreTableAdapter;
        private BDB56Projet1CKWDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.ErrorProvider errMessage;
        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResNoClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResNoChambre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResArrivee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResDepart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResNbPersonnes;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblChambre;
        private System.Windows.Forms.DataGridView dgvChambres;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChNoChambre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChEmplacement;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChDecorations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChPrixHaut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChPrixBas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChPrixMoyen;
        private System.Windows.Forms.Label lblArrivee;
        private System.Windows.Forms.DateTimePicker dtpArrivee;
        private System.Windows.Forms.Label lblDepart;
        private System.Windows.Forms.DateTimePicker dtpDepart;
        private System.Windows.Forms.Label lblPersonnes;
        private System.Windows.Forms.NumericUpDown nudPersonnes;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}