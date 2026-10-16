namespace ProjetBaseDeDonneeIII
{
    partial class FrmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuPlanifSoins = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUtilisateurs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClients = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAssistants = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSoins = new System.Windows.Forms.ToolStripMenuItem();
            this.planifierDesSoinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChambres = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReserverChambres = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRapports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeconnexion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlanifSoins,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuPlanifSoins
            // 
            this.mnuPlanifSoins.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUtilisateurs,
            this.mnuClients,
            this.mnuAssistants,
            this.mnuSoins,
            this.planifierDesSoinsToolStripMenuItem,
            this.mnuChambres,
            this.mnuReserverChambres,
            this.mnuRapports,
            this.mnuDeconnexion,
            this.mnuQuitter});
            this.mnuPlanifSoins.Name = "mnuPlanifSoins";
            this.mnuPlanifSoins.Size = new System.Drawing.Size(50, 20);
            this.mnuPlanifSoins.Text = "Menu";
            // 
            // mnuUtilisateurs
            // 
            this.mnuUtilisateurs.Name = "mnuUtilisateurs";
            this.mnuUtilisateurs.Size = new System.Drawing.Size(197, 22);
            this.mnuUtilisateurs.Text = "Utilisateurs";
            this.mnuUtilisateurs.Click += new System.EventHandler(this.mnuUtilisateurs_Click);
            // 
            // mnuClients
            // 
            this.mnuClients.Name = "mnuClients";
            this.mnuClients.Size = new System.Drawing.Size(197, 22);
            this.mnuClients.Text = "Clients et invités";
            this.mnuClients.Click += new System.EventHandler(this.mnuClients_Click);
            // 
            // mnuAssistants
            // 
            this.mnuAssistants.Name = "mnuAssistants";
            this.mnuAssistants.Size = new System.Drawing.Size(197, 22);
            this.mnuAssistants.Text = "Assistants et leurs soins";
            this.mnuAssistants.Click += new System.EventHandler(this.mnuAssistants_Click);
            // 
            // mnuSoins
            // 
            this.mnuSoins.Name = "mnuSoins";
            this.mnuSoins.Size = new System.Drawing.Size(197, 22);
            this.mnuSoins.Text = "Soins";
            this.mnuSoins.Click += new System.EventHandler(this.mnuSoins_Click);
            // 
            // planifierDesSoinsToolStripMenuItem
            // 
            this.planifierDesSoinsToolStripMenuItem.Name = "planifierDesSoinsToolStripMenuItem";
            this.planifierDesSoinsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.planifierDesSoinsToolStripMenuItem.Text = "Planifier des soins";
            this.planifierDesSoinsToolStripMenuItem.Click += new System.EventHandler(this.planifierDesSoinsToolStripMenuItem_Click);
            // 
            // mnuChambres
            // 
            this.mnuChambres.Name = "mnuChambres";
            this.mnuChambres.Size = new System.Drawing.Size(197, 22);
            this.mnuChambres.Text = "Chambres";
            this.mnuChambres.Click += new System.EventHandler(this.mnuChambres_Click);
            // 
            // mnuReserverChambres
            // 
            this.mnuReserverChambres.Name = "mnuReserverChambres";
            this.mnuReserverChambres.Size = new System.Drawing.Size(197, 22);
            this.mnuReserverChambres.Text = "Réserver des chambres";
            this.mnuReserverChambres.Click += new System.EventHandler(this.mnuReserverChambres_Click);
            // 
            // mnuRapports
            // 
            this.mnuRapports.Name = "mnuRapports";
            this.mnuRapports.Size = new System.Drawing.Size(197, 22);
            this.mnuRapports.Text = "Rapports";
            this.mnuRapports.Click += new System.EventHandler(this.mnuRapports_Click);
            // 
            // mnuDeconnexion
            // 
            this.mnuDeconnexion.Name = "mnuDeconnexion";
            this.mnuDeconnexion.Size = new System.Drawing.Size(197, 22);
            this.mnuDeconnexion.Text = "Se déconnecter";
            this.mnuDeconnexion.Click += new System.EventHandler(this.mnuDeconnexion_Click);
            // 
            // mnuQuitter
            // 
            this.mnuQuitter.Name = "mnuQuitter";
            this.mnuQuitter.Size = new System.Drawing.Size(197, 22);
            this.mnuQuitter.Text = "Quitter";
            this.mnuQuitter.Click += new System.EventHandler(this.mnuQuitter_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem,
            this.déconnecterToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quitter";
            // 
            // déconnecterToolStripMenuItem
            // 
            this.déconnecterToolStripMenuItem.Name = "déconnecterToolStripMenuItem";
            this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.déconnecterToolStripMenuItem.Text = "Déconnecter";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "FrmMenu";
            this.Load += new System.EventHandler(this.FrmMenu_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuPlanifSoins;
        private System.Windows.Forms.ToolStripMenuItem mnuUtilisateurs;
        private System.Windows.Forms.ToolStripMenuItem mnuClients;
        private System.Windows.Forms.ToolStripMenuItem mnuAssistants;
        private System.Windows.Forms.ToolStripMenuItem mnuSoins;
        private System.Windows.Forms.ToolStripMenuItem planifierDesSoinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuChambres;
        private System.Windows.Forms.ToolStripMenuItem mnuReserverChambres;
        private System.Windows.Forms.ToolStripMenuItem mnuRapports;
        private System.Windows.Forms.ToolStripMenuItem mnuDeconnexion;
        private System.Windows.Forms.ToolStripMenuItem mnuQuitter;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem déconnecterToolStripMenuItem;
    }
}