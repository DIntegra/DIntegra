using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DI.TyrantStation.Forms;

namespace DI.TyrantStation.IntegraLauncher
{
    public partial class IntegraLauncher : Form
    {
        public IntegraLauncher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Arena arena = new Arena();

            arena.Show();
        }
    }
}
