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
    public partial class FrmMenu : Form
    {
        private const int TYPE_ADMIN = 1;
        private const int TYPE_PREPOSE = 2;
        public bool Deconnexion { get; private set; } = false;


        FrmUtilisateurs fU = new FrmUtilisateurs();
        FrmClientsInvites fCI = new FrmClientsInvites();
        public FrmMenu()
        {
            InitializeComponent();
        }


        private void FrmMenu_Load_1(object sender, EventArgs e)
        {
            Text = "Connecté : " + Session.NomUtilisateur;
            ConfigurerMenu();
        }
        private void ConfigurerMenu()
        {
            bool admin = Session.NoType == TYPE_ADMIN;
            bool prepose = Session.NoType == TYPE_PREPOSE;

            // Options admin
            mnuUtilisateurs.Visible = admin;
            mnuAssistants.Visible = admin;
            mnuSoins.Visible = admin;
            mnuChambres.Visible = admin;
            mnuRapports.Visible = admin;

            // Options des deux
            mnuClients.Visible = admin || prepose;
            planifierDesSoinsToolStripMenuItem.Visible = admin || prepose;
            mnuReserverChambres.Visible = admin || prepose;

    
            mnuDeconnexion.Visible = true;
            mnuQuitter.Visible = true;
        }

        private void mnuUtilisateurs_Click(object sender, EventArgs e)
        {
            this.Hide();
            fU.ShowDialog();
            this.Show();
        }

        private void mnuClients_Click(object sender, EventArgs e)
        {
            this.Hide();
            fCI.ShowDialog();
            this.Show();
        }

        private void mnuAssistants_Click(object sender, EventArgs e)
        {

        }

        private void mnuSoins_Click(object sender, EventArgs e)
        {

        }

        private void planifierDesSoinsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuChambres_Click(object sender, EventArgs e)
        {

        }

        private void mnuReserverChambres_Click(object sender, EventArgs e)
        {

        }

        private void mnuRapports_Click(object sender, EventArgs e)
        {

        }

        private void mnuDeconnexion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous vous déconnecter ?", "Déconnexion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Deconnexion = true;
                Close();
            }
        }

        private void mnuQuitter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous quitter l'application ?", "Quitter",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Deconnexion = false;
                Close();
            }
        }
    }
}
