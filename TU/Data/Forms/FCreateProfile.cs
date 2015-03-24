using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace DIntegra.TU.Forms
{
    public partial class FCreateProfile : Form
    {
        public FCreateProfile()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Engine engine = new Engine();

            engine.CredentialManager.AddCredentialRecord(
                this.textBoxName.Text,
                this.textBoxLogin.Text,
                this.textBoxPassword.Text
            );

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }
    }
}
