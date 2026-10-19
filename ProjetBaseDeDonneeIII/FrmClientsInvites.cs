
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjetBaseDeDonneeIII
{
    public partial class FrmClientsInvites : Form
    {
        private const int MAX_INVITES = 9;

        private bool modeAjoutClient = false;
        private bool modeModificationClient = false;
        private bool modeAjoutInvite = false;
        private bool modeModificationInvite = false;

        public FrmClientsInvites()
        {
            InitializeComponent();
            this.Load -= FrmClientsInvites_Load;
            this.Load += FrmClientsInvites_Load;
        }

        private void FrmClientsInvites_Load(object sender, EventArgs e)
        {
            ChargerDonnees();

            dgvClients.DataSource = clientBindingSource;
            dgvInvites.DataSource = inviteBindingSource;

            LierTexte(txtNoClient, clientBindingSource, "NoClient");
            LierTexte(txtNom, clientBindingSource, "Nom");
            LierTexte(txtPrenom, clientBindingSource, "Prenom");
            LierTexte(txtVille, clientBindingSource, "Ville");
            LierTexte(txtPays, clientBindingSource, "Pays");
            LierTexte(txtAdresse, clientBindingSource, "Adresse");
            LierTexte(txtCodePostal, clientBindingSource, "CodePostal");

            txtDateInscription.DataBindings.Clear();
            txtDateInscription.DataBindings.Add("Text", clientBindingSource, "DateInscription", true, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy-MM-dd");

            LierTexte(txtNoInvite, inviteBindingSource, "NoInvite");
            LierTexte(txtNomPrenomInvite, inviteBindingSource, "NomPrenom");

            TextBox[] champsClient = { txtNom, txtPrenom, txtVille, txtPays, txtAdresse, txtCodePostal };

            foreach (TextBox champ in champsClient)
                champ.TextChanged += champClient_TextChanged;

            txtNomPrenomInvite.TextChanged += champInvite_TextChanged;
            clientBindingSource.CurrentChanged += clientBindingSource_CurrentChanged;

            FiltrerInvites();
            MettreAJourEtat();
        }

        private void LierTexte(TextBox champ, BindingSource source, string colonne)
        {
            champ.DataBindings.Clear();
            champ.DataBindings.Add("Text", source, colonne, true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void ChargerDonnees()
        {
            this.clientTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Client);
            this.inviteTableAdapter.Fill(this.bDB56Projet1CKWDataSet.Invite);

            clientBindingSource.ResetBindings(false);
            inviteBindingSource.ResetBindings(false);

            modeAjoutClient = false;
            modeModificationClient = false;
            modeAjoutInvite = false;
            modeModificationInvite = false;

            FiltrerInvites();
            MettreAJourEtat();
        }

        private void clientBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (!modeAjoutClient)
                FiltrerInvites();

            MettreAJourEtat();
        }

        private void FiltrerInvites()
        {
            DataRowView client = clientBindingSource.Current as DataRowView;

            if (client == null || client["NoClient"] == DBNull.Value)
            {
                inviteBindingSource.Filter = "NoClient = -1";
                return;
            }

            inviteBindingSource.Filter = "NoClient = " + Convert.ToInt32(client["NoClient"]);
        }

        private void champClient_TextChanged(object sender, EventArgs e)
        {
            if (!modeAjoutClient && ((Control)sender).Focused)
            {
                modeModificationClient = true;
                MettreAJourEtat();
            }
        }

        private void champInvite_TextChanged(object sender, EventArgs e)
        {
            if (!modeAjoutInvite && ((Control)sender).Focused)
            {
                modeModificationInvite = true;
                MettreAJourEtat();
            }
        }

        private void MettreAJourEtat()
        {
            bool modeClient = modeAjoutClient || modeModificationClient;
            bool modeInvite = modeAjoutInvite || modeModificationInvite;

            bool aClient = clientBindingSource.Current != null;
            bool aInvite = inviteBindingSource.Current != null;

            txtNoClient.ReadOnly = true;
            txtDateInscription.ReadOnly = true;
            txtNoInvite.ReadOnly = true;

            txtNomPrenomInvite.ReadOnly = modeClient || !(aInvite || modeAjoutInvite);

            btnAjouterClient.Enabled = !modeClient && !modeInvite;
            btnSupprimerClient.Enabled = !modeClient && !modeInvite && aClient;
            btnEnregistrerClient.Enabled = modeClient;
            btnAnnulerClient.Enabled = modeClient;

            btnAjouterInvite.Enabled = !modeClient && !modeInvite && aClient;
            btnSupprimerInvite.Enabled = !modeClient && !modeInvite && aInvite;
            btnEnregistrerInvite.Enabled = modeInvite;
            btnAnnulerInvite.Enabled = modeInvite;

            dgvClients.Enabled = !modeClient && !modeInvite;
            dgvInvites.Enabled = !modeClient && !modeInvite;
        }

        private int Compter(string requete, params SqlParameter[] parametres)
        {
            using (SqlConnection connexion = new SqlConnection(ConnexionBD.Chaine))
            using (SqlCommand commande = new SqlCommand(requete, connexion))
            {
                commande.Parameters.AddRange(parametres);
                connexion.Open();
                return Convert.ToInt32(commande.ExecuteScalar());
            }
        }

        private int ObtenirProchainNumeroClient()
        {
            int numeroMax = 0;

            foreach (DataRow ligne in bDB56Projet1CKWDataSet.Client.Rows)
            {
                if (ligne.RowState != DataRowState.Deleted)
                {
                    int numero = Convert.ToInt32(ligne["NoClient"]);

                    if (numero > numeroMax)
                        numeroMax = numero;
                }
            }

            return numeroMax + 10;
        }

        private int ObtenirProchainNumeroInvite(int noClient)
        {
            for (int i = 1; i <= MAX_INVITES; i++)
            {
                int candidat = noClient + i;
                bool utilise = false;

                foreach (DataRow ligne in bDB56Projet1CKWDataSet.Invite.Rows)
                {
                    if (ligne.RowState != DataRowState.Deleted && Convert.ToInt32(ligne["NoInvite"]) == candidat)
                    {
                        utilise = true;
                        break;
                    }
                }

                if (!utilise)
                    return candidat;
            }

            return -1;
        }

        private void btnAjouterClient_Click(object sender, EventArgs e)
        {
            if (modeAjoutClient || modeModificationClient || modeAjoutInvite || modeModificationInvite)
                return;

            modeAjoutClient = true;

            int numero = ObtenirProchainNumeroClient();
            DataRowView nouvelleLigne = (DataRowView)clientBindingSource.AddNew();

            nouvelleLigne["NoClient"] = numero;
            nouvelleLigne["Nom"] = "";
            nouvelleLigne["Prenom"] = "";
            nouvelleLigne["Ville"] = "";
            nouvelleLigne["Pays"] = "";
            nouvelleLigne["Adresse"] = "";
            nouvelleLigne["CodePostal"] = "";
            nouvelleLigne["DateInscription"] = DateTime.Today;

            FiltrerInvites();
            MettreAJourEtat();
            txtNom.Focus();
        }

        private void btnSupprimerClient_Click(object sender, EventArgs e)
        {
            if (modeAjoutClient || modeModificationClient || modeAjoutInvite || modeModificationInvite)
            {
                MessageBox.Show("Enregistrez ou annulez l'opération en cours.");
                return;
            }

            if (clientBindingSource.Current == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }

            DataRowView ligne = (DataRowView)clientBindingSource.Current;
            int numero = Convert.ToInt32(ligne["NoClient"]);
            string nomComplet = ligne["Prenom"] + " " + ligne["Nom"];

            try
            {
                if (Compter("SELECT COUNT(*) FROM Invite WHERE NoClient = @no", new SqlParameter("@no", numero)) > 0)
                {
                    MessageBox.Show("Ce client a des invités : suppression impossible.", "Suppression refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Compter("SELECT COUNT(*) FROM ReservationChambre WHERE NoClient = @no", new SqlParameter("@no", numero)) > 0)
                {
                    MessageBox.Show("Ce client a réservé une chambre : suppression impossible.", "Suppression refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Compter("SELECT COUNT(*) FROM PlanifSoin WHERE NoPersonne = @no", new SqlParameter("@no", numero)) > 0)
                {
                    MessageBox.Show("Des soins sont planifiés pour ce client : suppression impossible.", "Suppression refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer le client « " + nomComplet + " » ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (reponse != DialogResult.Yes)
                    return;

                clientBindingSource.RemoveCurrent();

                this.Validate();
                clientBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDB56Projet1CKWDataSet);

                MessageBox.Show("Le client a été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChargerDonnees();
            }
        }

        private void btnEnregistrerClient_Click(object sender, EventArgs e)
        {
            if (!modeAjoutClient && !modeModificationClient)
            {
                MessageBox.Show("Aucune opération n'est en cours.");
                return;
            }

            if (!ValiderClient())
                return;

            try
            {
                DataRowView courant = clientBindingSource.Current as DataRowView;

                if (courant == null)
                {
                    MessageBox.Show("Aucune ligne à enregistrer.");
                    return;
                }

                int numero = Convert.ToInt32(courant["NoClient"]);

                this.Validate();
                clientBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDB56Projet1CKWDataSet);

                ChargerDonnees();
                SelectionnerClient(numero);

                MessageBox.Show("Les modifications ont été enregistrées dans la base de données.", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement :\n" + ex.ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValiderClient()
        {
            errMessage.Clear();

            TextBox[] champs = { txtNom, txtPrenom, txtVille, txtPays, txtAdresse, txtCodePostal };
            string[] noms = { "Le nom", "Le prénom", "La ville", "Le pays", "L'adresse", "Le code postal" };

            for (int i = 0; i < champs.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(champs[i].Text))
                {
                    errMessage.SetError(champs[i], noms[i] + " est obligatoire.");
                    champs[i].Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnAnnulerClient_Click(object sender, EventArgs e)
        {
            bDB56Projet1CKWDataSet.Client.RejectChanges();
            clientBindingSource.CancelEdit();
            clientBindingSource.ResetBindings(false);
            errMessage.Clear();
            ChargerDonnees();

            MessageBox.Show("Les modifications non enregistrées ont été annulées.", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAjouterInvite_Click(object sender, EventArgs e)
        {
            if (modeAjoutClient || modeModificationClient || modeAjoutInvite || modeModificationInvite)
                return;

            DataRowView client = clientBindingSource.Current as DataRowView;

            if (client == null)
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }

            int noClient = Convert.ToInt32(client["NoClient"]);
            int numero = ObtenirProchainNumeroInvite(noClient);

            if (numero == -1)
            {
                MessageBox.Show("Ce client a déjà le nombre maximum d'invités (" + MAX_INVITES + ").");
                return;
            }

            modeAjoutInvite = true;
            DataRowView nouvelleLigne = (DataRowView)inviteBindingSource.AddNew();

            nouvelleLigne["NoInvite"] = numero;
            nouvelleLigne["NoClient"] = noClient;
            nouvelleLigne["NomPrenom"] = "";

            MettreAJourEtat();
            txtNomPrenomInvite.Focus();
        }

        private void btnSupprimerInvite_Click(object sender, EventArgs e)
        {
            if (modeAjoutClient || modeModificationClient || modeAjoutInvite || modeModificationInvite)
            {
                MessageBox.Show("Enregistrez ou annulez l'opération en cours.");
                return;
            }

            if (inviteBindingSource.Current == null)
            {
                MessageBox.Show("Veuillez sélectionner un invité.");
                return;
            }

            DataRowView ligne = (DataRowView)inviteBindingSource.Current;
            int numero = Convert.ToInt32(ligne["NoInvite"]);
            string nom = ligne["NomPrenom"].ToString();

            try
            {
                if (Compter("SELECT COUNT(*) FROM PlanifSoin WHERE NoPersonne = @no", new SqlParameter("@no", numero)) > 0)
                {
                    MessageBox.Show("Des soins sont planifiés pour cet invité : suppression impossible.", "Suppression refusée", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult reponse = MessageBox.Show("Voulez-vous vraiment supprimer l'invité « " + nom + " » ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (reponse != DialogResult.Yes)
                    return;

                inviteBindingSource.RemoveCurrent();

                this.Validate();
                inviteBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDB56Projet1CKWDataSet);

                MessageBox.Show("L'invité a été supprimé.", "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ChargerDonnees();
            }
        }

        private void btnEnregistrerInvite_Click(object sender, EventArgs e)
        {
            if (!modeAjoutInvite && !modeModificationInvite)
            {
                MessageBox.Show("Aucune opération n'est en cours.");
                return;
            }

            errMessage.Clear();

            if (string.IsNullOrWhiteSpace(txtNomPrenomInvite.Text))
            {
                errMessage.SetError(txtNomPrenomInvite, "Le nom de l'invité est obligatoire.");
                txtNomPrenomInvite.Focus();
                return;
            }

            try
            {
                DataRowView client = clientBindingSource.Current as DataRowView;
                DataRowView invite = inviteBindingSource.Current as DataRowView;

                if (client == null || invite == null)
                {
                    MessageBox.Show("Aucune ligne à enregistrer.");
                    return;
                }

                int noClient = Convert.ToInt32(client["NoClient"]);
                int noInvite = Convert.ToInt32(invite["NoInvite"]);

                this.Validate();
                inviteBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.bDB56Projet1CKWDataSet);

                ChargerDonnees();
                SelectionnerClient(noClient);
                SelectionnerInvite(noInvite);

                MessageBox.Show("Les modifications ont été enregistrées dans la base de données.", "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement :\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnnulerInvite_Click(object sender, EventArgs e)
        {
            bDB56Projet1CKWDataSet.Invite.RejectChanges();
            inviteBindingSource.CancelEdit();
            inviteBindingSource.ResetBindings(false);
            errMessage.Clear();
            ChargerDonnees();

            MessageBox.Show("Les modifications non enregistrées ont été annulées.", "Annulation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SelectionnerClient(int numero)
        {
            for (int i = 0; i < clientBindingSource.Count; i++)
            {
                DataRowView vue = clientBindingSource[i] as DataRowView;

                if (vue != null && Convert.ToInt32(vue["NoClient"]) == numero)
                {
                    clientBindingSource.Position = i;
                    break;
                }
            }

            FiltrerInvites();
        }

        private void SelectionnerInvite(int numero)
        {
            for (int i = 0; i < inviteBindingSource.Count; i++)
            {
                DataRowView vue = inviteBindingSource[i] as DataRowView;

                if (vue != null && Convert.ToInt32(vue["NoInvite"]) == numero)
                {
                    inviteBindingSource.Position = i;
                    break;
                }
            }
        }
    }
}
