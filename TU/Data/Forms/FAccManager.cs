using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DIntegra.TU.Forms
{
    public partial class FAccManager : Form
    {
        private FMainForm _mainForm = null;
        private Engine _engine = null;


        internal Engine Engine
        {
            get
            {
                if (this._engine == null)
                {
                    this._engine = new Engine();
                }
                return this._engine;
            }
        }

        private void UpdateProfileList()
        {
            this.listBoxAccaunts.Items.Clear();

            var creds = this.Engine.CredentialManager.GetAllCredentials();

            foreach (Credentials cred in creds)
            {
                this.listBoxAccaunts.Items.Add(cred);
            }

            this._mainForm.UpdateProfileList();
        }



        public FAccManager(FMainForm mainform)
        {
            InitializeComponent();

            this._mainForm = mainform;
        }

        

        private void FAccManager_Load(object sender, EventArgs e)
        {
            this.UpdateProfileList();
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FCreateProfile profileForm = new FCreateProfile();

            DialogResult dlg = profileForm.ShowDialog();

            if (dlg == System.Windows.Forms.DialogResult.OK)
            {
                this.UpdateProfileList();                
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Credentials selected = this.listBoxAccaunts.SelectedItem as Credentials;

            if (selected == null)
                return;

            if (MessageBox.Show("Реально удалить учетку для " + selected.NickName + "?!", "Ээээ...", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Engine.CredentialManager.RemoveCredentialsRecord(selected);
                this.UpdateProfileList();
            }
        }

        private void listBoxAccaunts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Credentials selected = this.listBoxAccaunts.SelectedItem as Credentials;

            this.buttonRemove.Enabled = (selected != null);
        }
    }
}
