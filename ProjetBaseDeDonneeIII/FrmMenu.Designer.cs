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
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnecterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlanifSoins});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 33);
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
            this.mnuRapports});
            this.mnuPlanifSoins.Name = "mnuPlanifSoins";
            this.mnuPlanifSoins.Size = new System.Drawing.Size(73, 29);
            this.mnuPlanifSoins.Text = "Menu";
            // 
            // mnuUtilisateurs
            // 
            this.mnuUtilisateurs.Name = "mnuUtilisateurs";
            this.mnuUtilisateurs.Size = new System.Drawing.Size(301, 34);
            this.mnuUtilisateurs.Text = "Utilisateurs";
            this.mnuUtilisateurs.Click += new System.EventHandler(this.mnuUtilisateurs_Click);
            // 
            // mnuClients
            // 
            this.mnuClients.Name = "mnuClients";
            this.mnuClients.Size = new System.Drawing.Size(301, 34);
            this.mnuClients.Text = "Clients et invités";
            this.mnuClients.Click += new System.EventHandler(this.mnuClients_Click);
            // 
            // mnuAssistants
            // 
            this.mnuAssistants.Name = "mnuAssistants";
            this.mnuAssistants.Size = new System.Drawing.Size(301, 34);
            this.mnuAssistants.Text = "Assistants et leurs soins";
            this.mnuAssistants.Click += new System.EventHandler(this.mnuAssistants_Click);
            // 
            // mnuSoins
            // 
            this.mnuSoins.Name = "mnuSoins";
            this.mnuSoins.Size = new System.Drawing.Size(301, 34);
            this.mnuSoins.Text = "Soins";
            this.mnuSoins.Click += new System.EventHandler(this.mnuSoins_Click);
            // 
            // planifierDesSoinsToolStripMenuItem
            // 
            this.planifierDesSoinsToolStripMenuItem.Name = "planifierDesSoinsToolStripMenuItem";
            this.planifierDesSoinsToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.planifierDesSoinsToolStripMenuItem.Text = "Planifier des soins";
            this.planifierDesSoinsToolStripMenuItem.Click += new System.EventHandler(this.planifierDesSoinsToolStripMenuItem_Click);
            // 
            // mnuChambres
            // 
            this.mnuChambres.Name = "mnuChambres";
            this.mnuChambres.Size = new System.Drawing.Size(301, 34);
            this.mnuChambres.Text = "Chambres";
            this.mnuChambres.Click += new System.EventHandler(this.mnuChambres_Click);
            // 
            // mnuReserverChambres
            // 
            this.mnuReserverChambres.Name = "mnuReserverChambres";
            this.mnuReserverChambres.Size = new System.Drawing.Size(301, 34);
            this.mnuReserverChambres.Text = "Réserver des chambres";
            this.mnuReserverChambres.Click += new System.EventHandler(this.mnuReserverChambres_Click);
            // 
            // mnuRapports
            // 
            this.mnuRapports.Name = "mnuRapports";
            this.mnuRapports.Size = new System.Drawing.Size(301, 34);
            this.mnuRapports.Text = "Rapports";
            this.mnuRapports.Click += new System.EventHandler(this.mnuRapports_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quitter";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // déconnecterToolStripMenuItem
            // 
            this.déconnecterToolStripMenuItem.Name = "déconnecterToolStripMenuItem";
            this.déconnecterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.déconnecterToolStripMenuItem.Text = "Déconnecter";
            this.déconnecterToolStripMenuItem.Click += new System.EventHandler(this.déconnecterToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem déconnecterToolStripMenuItem;
    }
}