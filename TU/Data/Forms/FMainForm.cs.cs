using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DIntegra.TU.Forms
{
    public partial class FMainForm : Form
    {
        private Engine _engine = null;
        private Credentials _currentcred = null;

        internal Credentials CurrentProfile
        {
            get
            {
                return this._currentcred;
            }
        }

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
            this.ddlCredentials.Items.Clear();

            var creds = this.Engine.CredentialManager.GetAllCredentials();

            this.ddlCredentials.Items.Add("");

            foreach (Credentials cred in creds)
            {
                this.ddlCredentials.Items.Add(cred);
            }
        }


        public FMainForm()
        {
            InitializeComponent();            
        }

        private void декиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDeckUpdater deckUpdater = new FDeckUpdater(this.CurrentProfile);
            deckUpdater.MdiParent = this;

            deckUpdater.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FCreateProfile profileForm = new FCreateProfile();

            DialogResult dlg = profileForm.ShowDialog();

            if (dlg == System.Windows.Forms.DialogResult.OK)
            {
                this.UpdateProfileList();
            }
        }

        private void FMainForm_Load(object sender, EventArgs e)
        {
            UpdateProfileList();
        }

        private void ddlCredentials_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = this.ddlCredentials.SelectedItem;

            this._currentcred = selected as Credentials;

            if (this._currentcred != null)
            {
                this.mainMenu.Enabled = true;
            }
            else
            {
                this.mainMenu.Enabled = false;
            }
        }

        internal void ShowNotification(String text, ToolTipIcon type)
        {
            notifyIcon.BalloonTipIcon = type;
            notifyIcon.BalloonTipTitle = "DIntegra (c) Tyrant Station";
            notifyIcon.BalloonTipText = text;
            if (type == ToolTipIcon.Info)
            {
                notifyIcon.ShowBalloonTip(5000);
            }
            else if (type == ToolTipIcon.Warning)
            {
                notifyIcon.ShowBalloonTip(10000);
            }
            else if (type == ToolTipIcon.Error)
            {
                notifyIcon.ShowBalloonTip(30000);
            }
            else
            {
                notifyIcon.ShowBalloonTip(2000);
            }
        }

        private void запасыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FChestsDownloader chestUpdater = new FChestsDownloader(this.CurrentProfile);
            chestUpdater.MdiParent = this;

            chestUpdater.Show();            
        }

        private void обновитьSimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Engine.UpdateSimFiles(this.CurrentProfile, Environment.CurrentDirectory);

                MessageBox.Show("Товарищ, проверь все ли прошло успешно. Есть данные, что файлы были обновлены.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
        }
    }
}
