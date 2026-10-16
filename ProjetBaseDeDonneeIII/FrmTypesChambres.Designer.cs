
namespace ProjetBaseDeDonneeIII
{
    partial class FrmTypesChambres
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTypes;
        private System.Windows.Forms.Label lblNoType;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrixHaut;
        private System.Windows.Forms.Label lblPrixBas;
        private System.Windows.Forms.Label lblPrixMoyen;
        private System.Windows.Forms.TextBox txtNoType;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtPrixHaut;
        private System.Windows.Forms.TextBox txtPrixBas;
        private System.Windows.Forms.TextBox txtPrixMoyen;

        private System.Windows.Forms.Button btnAjouterType;
        private System.Windows.Forms.Button btnModifierType;
        private System.Windows.Forms.Button btnSupprimerType;
        private System.Windows.Forms.Button btnEnregistrerType;
        private System.Windows.Forms.Button btnAnnulerType;
        private System.Windows.Forms.DataGridView dgvChambres;
        private System.Windows.Forms.Label lblNoChambre;
        private System.Windows.Forms.Label lblEmplacement;
        private System.Windows.Forms.Label lblDecorations;
        private System.Windows.Forms.TextBox txtNoChambre;
        private System.Windows.Forms.TextBox txtEmplacement;
        private System.Windows.Forms.TextBox txtDecorations;

        private System.Windows.Forms.Button btnAjouterChambre;
        private System.Windows.Forms.Button btnModifierChambre;
        private System.Windows.Forms.Button btnSupprimerChambre;
        private System.Windows.Forms.Button btnEnregistrerChambre;
        private System.Windows.Forms.Button btnAnnulerChambre;

        private System.Windows.Forms.ErrorProvider errMessage;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvTypes = new System.Windows.Forms.DataGridView();
            this.lblNoType = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrixHaut = new System.Windows.Forms.Label();
            this.lblPrixBas = new System.Windows.Forms.Label();
            this.lblPrixMoyen = new System.Windows.Forms.Label();
            this.txtNoType = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPrixHaut = new System.Windows.Forms.TextBox();
            this.txtPrixBas = new System.Windows.Forms.TextBox();
            this.txtPrixMoyen = new System.Windows.Forms.TextBox();
            this.btnAjouterType = new System.Windows.Forms.Button();
            this.btnModifierType = new System.Windows.Forms.Button();
            this.btnSupprimerType = new System.Windows.Forms.Button();
            this.btnEnregistrerType = new System.Windows.Forms.Button();
            this.btnAnnulerType = new System.Windows.Forms.Button();
            this.dgvChambres = new System.Windows.Forms.DataGridView();
            this.lblNoChambre = new System.Windows.Forms.Label();
            this.lblEmplacement = new System.Windows.Forms.Label();
            this.lblDecorations = new System.Windows.Forms.Label();
            this.txtNoChambre = new System.Windows.Forms.TextBox();
            this.txtEmplacement = new System.Windows.Forms.TextBox();
            this.txtDecorations = new System.Windows.Forms.TextBox();
            this.btnAjouterChambre = new System.Windows.Forms.Button();
            this.btnModifierChambre = new System.Windows.Forms.Button();
            this.btnSupprimerChambre = new System.Windows.Forms.Button();
            this.btnEnregistrerChambre = new System.Windows.Forms.Button();
            this.btnAnnulerChambre = new System.Windows.Forms.Button();
            this.errMessage = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChambres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTypes
            // 
            this.dgvTypes.AllowUserToAddRows = false;
            this.dgvTypes.AllowUserToDeleteRows = false;
            this.dgvTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTypes.Location = new System.Drawing.Point(13, 74);
            this.dgvTypes.MultiSelect = false;
            this.dgvTypes.Name = "dgvTypes";
            this.dgvTypes.ReadOnly = true;
            this.dgvTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTypes.Size = new System.Drawing.Size(471, 165);
            this.dgvTypes.TabIndex = 2;
            // 
            // lblNoType
            // 
            this.lblNoType.AutoSize = true;
            this.lblNoType.Location = new System.Drawing.Point(13, 256);
            this.lblNoType.Name = "lblNoType";
            this.lblNoType.Size = new System.Drawing.Size(88, 13);
            this.lblNoType.TabIndex = 3;
            this.lblNoType.Text = "Numéro du type :";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(13, 286);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description :";
            // 
            // lblPrixHaut
            // 
            this.lblPrixHaut.AutoSize = true;
            this.lblPrixHaut.Location = new System.Drawing.Point(13, 316);
            this.lblPrixHaut.Name = "lblPrixHaut";
            this.lblPrixHaut.Size = new System.Drawing.Size(54, 13);
            this.lblPrixHaut.TabIndex = 5;
            this.lblPrixHaut.Text = "Prix haut :";
            // 
            // lblPrixBas
            // 
            this.lblPrixBas.AutoSize = true;
            this.lblPrixBas.Location = new System.Drawing.Point(13, 347);
            this.lblPrixBas.Name = "lblPrixBas";
            this.lblPrixBas.Size = new System.Drawing.Size(50, 13);
            this.lblPrixBas.TabIndex = 6;
            this.lblPrixBas.Text = "Prix bas :";
            // 
            // lblPrixMoyen
            // 
            this.lblPrixMoyen.AutoSize = true;
            this.lblPrixMoyen.Location = new System.Drawing.Point(13, 377);
            this.lblPrixMoyen.Name = "lblPrixMoyen";
            this.lblPrixMoyen.Size = new System.Drawing.Size(64, 13);
            this.lblPrixMoyen.TabIndex = 7;
            this.lblPrixMoyen.Text = "Prix moyen :";
            // 
            // txtNoType
            // 
            this.txtNoType.Location = new System.Drawing.Point(124, 253);
            this.txtNoType.Name = "txtNoType";
            this.txtNoType.ReadOnly = true;
            this.txtNoType.Size = new System.Drawing.Size(343, 20);
            this.txtNoType.TabIndex = 8;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(124, 283);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(343, 20);
            this.txtDescription.TabIndex = 9;
            // 
            // txtPrixHaut
            // 
            this.txtPrixHaut.Location = new System.Drawing.Point(124, 314);
            this.txtPrixHaut.Name = "txtPrixHaut";
            this.txtPrixHaut.Size = new System.Drawing.Size(343, 20);
            this.txtPrixHaut.TabIndex = 10;
            // 
            // txtPrixBas
            // 
            this.txtPrixBas.Location = new System.Drawing.Point(124, 344);
            this.txtPrixBas.Name = "txtPrixBas";
            this.txtPrixBas.Size = new System.Drawing.Size(343, 20);
            this.txtPrixBas.TabIndex = 11;
            // 
            // txtPrixMoyen
            // 
            this.txtPrixMoyen.Location = new System.Drawing.Point(124, 374);
            this.txtPrixMoyen.Name = "txtPrixMoyen";
            this.txtPrixMoyen.Size = new System.Drawing.Size(343, 20);
            this.txtPrixMoyen.TabIndex = 12;
            // 
            // btnAjouterType
            // 
            this.btnAjouterType.Location = new System.Drawing.Point(13, 420);
            this.btnAjouterType.Name = "btnAjouterType";
            this.btnAjouterType.Size = new System.Drawing.Size(86, 28);
            this.btnAjouterType.TabIndex = 13;
            this.btnAjouterType.Text = "Ajouter";
            this.btnAjouterType.UseVisualStyleBackColor = true;
            this.btnAjouterType.Click += new System.EventHandler(this.btnAjouterType_Click);
            // 
            // btnModifierType
            // 
            this.btnModifierType.Location = new System.Drawing.Point(107, 420);
            this.btnModifierType.Name = "btnModifierType";
            this.btnModifierType.Size = new System.Drawing.Size(86, 28);
            this.btnModifierType.TabIndex = 14;
            this.btnModifierType.Text = "Modifier";
            this.btnModifierType.UseVisualStyleBackColor = true;
            this.btnModifierType.Click += new System.EventHandler(this.btnModifierType_Click);
            // 
            // btnSupprimerType
            // 
            this.btnSupprimerType.Location = new System.Drawing.Point(201, 420);
            this.btnSupprimerType.Name = "btnSupprimerType";
            this.btnSupprimerType.Size = new System.Drawing.Size(86, 28);
            this.btnSupprimerType.TabIndex = 15;
            this.btnSupprimerType.Text = "Supprimer";
            this.btnSupprimerType.UseVisualStyleBackColor = true;
            this.btnSupprimerType.Click += new System.EventHandler(this.btnSupprimerType_Click);
            // 
            // btnEnregistrerType
            // 
            this.btnEnregistrerType.Location = new System.Drawing.Point(296, 420);
            this.btnEnregistrerType.Name = "btnEnregistrerType";
            this.btnEnregistrerType.Size = new System.Drawing.Size(86, 28);
            this.btnEnregistrerType.TabIndex = 16;
            this.btnEnregistrerType.Text = "Enregistrer";
            this.btnEnregistrerType.UseVisualStyleBackColor = true;
            this.btnEnregistrerType.Click += new System.EventHandler(this.btnEnregistrerType_Click);
            // 
            // btnAnnulerType
            // 
            this.btnAnnulerType.Location = new System.Drawing.Point(296, 455);
            this.btnAnnulerType.Name = "btnAnnulerType";
            this.btnAnnulerType.Size = new System.Drawing.Size(86, 28);
            this.btnAnnulerType.TabIndex = 17;
            this.btnAnnulerType.Text = "Annuler";
            this.btnAnnulerType.UseVisualStyleBackColor = true;
            this.btnAnnulerType.Click += new System.EventHandler(this.btnAnnulerType_Click);
            // 
            // dgvChambres
            // 
            this.dgvChambres.AllowUserToAddRows = false;
            this.dgvChambres.AllowUserToDeleteRows = false;
            this.dgvChambres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChambres.Location = new System.Drawing.Point(514, 74);
            this.dgvChambres.MultiSelect = false;
            this.dgvChambres.Name = "dgvChambres";
            this.dgvChambres.ReadOnly = true;
            this.dgvChambres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChambres.Size = new System.Drawing.Size(471, 165);
            this.dgvChambres.TabIndex = 19;
            // 
            // lblNoChambre
            // 
            this.lblNoChambre.AutoSize = true;
            this.lblNoChambre.Location = new System.Drawing.Point(514, 256);
            this.lblNoChambre.Name = "lblNoChambre";
            this.lblNoChambre.Size = new System.Drawing.Size(109, 13);
            this.lblNoChambre.TabIndex = 20;
            this.lblNoChambre.Text = "Numéro de chambre :";
            // 
            // lblEmplacement
            // 
            this.lblEmplacement.AutoSize = true;
            this.lblEmplacement.Location = new System.Drawing.Point(514, 290);
            this.lblEmplacement.Name = "lblEmplacement";
            this.lblEmplacement.Size = new System.Drawing.Size(77, 13);
            this.lblEmplacement.TabIndex = 21;
            this.lblEmplacement.Text = "Emplacement :";
            // 
            // lblDecorations
            // 
            this.lblDecorations.AutoSize = true;
            this.lblDecorations.Location = new System.Drawing.Point(514, 325);
            this.lblDecorations.Name = "lblDecorations";
            this.lblDecorations.Size = new System.Drawing.Size(70, 13);
            this.lblDecorations.TabIndex = 22;
            this.lblDecorations.Text = "Décorations :";
            // 
            // txtNoChambre
            // 
            this.txtNoChambre.Location = new System.Drawing.Point(643, 253);
            this.txtNoChambre.Name = "txtNoChambre";
            this.txtNoChambre.ReadOnly = true;
            this.txtNoChambre.Size = new System.Drawing.Size(343, 20);
            this.txtNoChambre.TabIndex = 23;
            // 
            // txtEmplacement
            // 
            this.txtEmplacement.Location = new System.Drawing.Point(643, 288);
            this.txtEmplacement.Name = "txtEmplacement";
            this.txtEmplacement.Size = new System.Drawing.Size(343, 20);
            this.txtEmplacement.TabIndex = 24;
            // 
            // txtDecorations
            // 
            this.txtDecorations.Location = new System.Drawing.Point(643, 322);
            this.txtDecorations.Name = "txtDecorations";
            this.txtDecorations.Size = new System.Drawing.Size(343, 20);
            this.txtDecorations.TabIndex = 25;
            // 
            // btnAjouterChambre
            // 
            this.btnAjouterChambre.Location = new System.Drawing.Point(514, 420);
            this.btnAjouterChambre.Name = "btnAjouterChambre";
            this.btnAjouterChambre.Size = new System.Drawing.Size(86, 28);
            this.btnAjouterChambre.TabIndex = 26;
            this.btnAjouterChambre.Text = "Ajouter";
            this.btnAjouterChambre.UseVisualStyleBackColor = true;
            this.btnAjouterChambre.Click += new System.EventHandler(this.btnAjouterChambre_Click);
            // 
            // btnModifierChambre
            // 
            this.btnModifierChambre.Location = new System.Drawing.Point(609, 420);
            this.btnModifierChambre.Name = "btnModifierChambre";
            this.btnModifierChambre.Size = new System.Drawing.Size(86, 28);
            this.btnModifierChambre.TabIndex = 27;
            this.btnModifierChambre.Text = "Modifier";
            this.btnModifierChambre.UseVisualStyleBackColor = true;
            this.btnModifierChambre.Click += new System.EventHandler(this.btnModifierChambre_Click);
            // 
            // btnSupprimerChambre
            // 
            this.btnSupprimerChambre.Location = new System.Drawing.Point(703, 420);
            this.btnSupprimerChambre.Name = "btnSupprimerChambre";
            this.btnSupprimerChambre.Size = new System.Drawing.Size(86, 28);
            this.btnSupprimerChambre.TabIndex = 28;
            this.btnSupprimerChambre.Text = "Supprimer";
            this.btnSupprimerChambre.UseVisualStyleBackColor = true;
            this.btnSupprimerChambre.Click += new System.EventHandler(this.btnSupprimerChambre_Click);
            // 
            // btnEnregistrerChambre
            // 
            this.btnEnregistrerChambre.Location = new System.Drawing.Point(797, 420);
            this.btnEnregistrerChambre.Name = "btnEnregistrerChambre";
            this.btnEnregistrerChambre.Size = new System.Drawing.Size(86, 28);
            this.btnEnregistrerChambre.TabIndex = 29;
            this.btnEnregistrerChambre.Text = "Enregistrer";
            this.btnEnregistrerChambre.UseVisualStyleBackColor = true;
            this.btnEnregistrerChambre.Click += new System.EventHandler(this.btnEnregistrerChambre_Click);
            // 
            // btnAnnulerChambre
            // 
            this.btnAnnulerChambre.Location = new System.Drawing.Point(797, 455);
            this.btnAnnulerChambre.Name = "btnAnnulerChambre";
            this.btnAnnulerChambre.Size = new System.Drawing.Size(86, 28);
            this.btnAnnulerChambre.TabIndex = 30;
            this.btnAnnulerChambre.Text = "Annuler";
            this.btnAnnulerChambre.UseVisualStyleBackColor = true;
            this.btnAnnulerChambre.Click += new System.EventHandler(this.btnAnnulerChambre_Click);
            // 
            // errMessage
            // 
            this.errMessage.ContainerControl = this;
            // 
            // FrmTypesChambres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 511);
            this.Controls.Add(this.dgvTypes);
            this.Controls.Add(this.lblNoType);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblPrixHaut);
            this.Controls.Add(this.lblPrixBas);
            this.Controls.Add(this.lblPrixMoyen);
            this.Controls.Add(this.txtNoType);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPrixHaut);
            this.Controls.Add(this.txtPrixBas);
            this.Controls.Add(this.txtPrixMoyen);
            this.Controls.Add(this.btnAjouterType);
            this.Controls.Add(this.btnModifierType);
            this.Controls.Add(this.btnSupprimerType);
            this.Controls.Add(this.btnEnregistrerType);
            this.Controls.Add(this.btnAnnulerType);
            this.Controls.Add(this.dgvChambres);
            this.Controls.Add(this.lblNoChambre);
            this.Controls.Add(this.lblEmplacement);
            this.Controls.Add(this.lblDecorations);
            this.Controls.Add(this.txtNoChambre);
            this.Controls.Add(this.txtEmplacement);
            this.Controls.Add(this.txtDecorations);
            this.Controls.Add(this.btnAjouterChambre);
            this.Controls.Add(this.btnModifierChambre);
            this.Controls.Add(this.btnSupprimerChambre);
            this.Controls.Add(this.btnEnregistrerChambre);
            this.Controls.Add(this.btnAnnulerChambre);
            this.MinimumSize = new System.Drawing.Size(1027, 550);
            this.Name = "FrmTypesChambres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestion des types et des chambres";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChambres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
