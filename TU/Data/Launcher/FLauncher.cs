using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Reflection;

namespace Launcher
{
    public partial class FLauncher : Form
    {
        public FLauncher()
        {
            InitializeComponent();
        }

        private void FLauncher_Load(object sender, EventArgs e)
        {
            this.backgroundWorkerLoader.RunWorkerAsync();
        }

        private void backgroundWorkerLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.progressBar1.Update();
        }

        private void backgroundWorkerLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Value = 100;
            this.Hide();


            try
            {
                Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\DIntegra.TU.Forms.dll");

                Type type = assembly.GetType("DIntegra.TU.Forms.FLogin");
                object classInstance = Activator.CreateInstance(type, null);

                Form loginForm = (Form)classInstance;
                loginForm.FormClosed += loginForm_FormClosed;
                loginForm.Update();
                loginForm.Show();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(@"Не удалось прочитать DLL [DIntegra.TU.Forms.dll]: " + ex.Message);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }

        void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void backgroundWorkerLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            //Environment.SpecialFolder.ApplicationData
            String dllFolder = Environment.CurrentDirectory;
            if (!Directory.Exists(dllFolder))
            {
                Directory.CreateDirectory(dllFolder);
            }

            String downloadDllLink = "https://drive.google.com/uc?export=download&id=0B-umPckBC-iMaURHTG5Bb25rRmM";

            using (WebClient Client = new WebClient())
            {
                Client.DownloadFile(downloadDllLink, dllFolder + "\\DIntegra.TU.Download.dll");
            }

            Assembly assembly = Assembly.LoadFile(Environment.CurrentDirectory + @"\DIntegra.TU.Download.dll");
            Type mainType = assembly.GetType("DIntegra.TU.Download.DllsInfo");            

            var method = mainType.GetMethod("GetDonwloadDlls");
            Type interfType = method.ReturnType;

            var dlls = method.Invoke(null, null) as Dictionary<String, String>;

            int step = 100 / dlls.Count;
            int progress = 0;

            foreach (String dllName in dlls.Keys)
            {
                try
                {
                    String googleDrivepath = dlls[dllName];

                    using (WebClient Client = new WebClient())
                    {
                        Client.DownloadFile(googleDrivepath, dllFolder + "\\" + dllName);
                    }                    

                    progress += step;
                    this.backgroundWorkerLoader.ReportProgress(progress);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
