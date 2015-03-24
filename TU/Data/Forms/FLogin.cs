using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DIntegra.TU.Forms
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private Boolean ValidateCredentials()
        {
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.ValidateCredentials())
            {                
                FMainForm mainForm = new FMainForm();
                mainForm.FormClosed += new FormClosedEventHandler(mainForm_FormClosed);
                this.Hide();

                mainForm.Show();
            }
            else
            {
                this.textBoxPassword.Text = "";
            }
        }

        void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
