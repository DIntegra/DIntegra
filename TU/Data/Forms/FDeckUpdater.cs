using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DIntegra.TU.Data;
using System.IO;

namespace DIntegra.TU.Forms
{
    public partial class FDeckUpdater : Form
    {
        private Credentials _currentCred = null;

        private Credentials CurrentCredential
        {
            get
            {
                return this._currentCred;
            }
        }

        private FMainForm ParentForm
        {
            get
            {
                return this.MdiParent as FMainForm;
            }
        }


        public FDeckUpdater(Credentials current)
        {
            InitializeComponent();

            this._currentCred = current;
        }

        private void labelLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void FDeckUpdater_Load(object sender, EventArgs e)
        {
            
        }

        private void FDeckUpdater_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.bgDeckLoader.IsBusy)
            {
                DialogResult res = MessageBox.Show("Выполняется скачивание. Если закрыть - скачивание будет остановлено. закрыть форму?", "Че творишь, а?", MessageBoxButtons.YesNo);

                if (res != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.bgDeckLoader.CancelAsync();
                }
            }
        }

        static void CreateFSystemobjects()
        {
            string folderDataName = "chests";

            if (!Directory.Exists(folderDataName))
            {
                Directory.CreateDirectory(folderDataName);
            }  
        }

        private void bgDeckLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int progress = 0;
                this.bgDeckLoader.ReportProgress(progress, "Приступаем к обработке Дек");
                
                
                this.bgDeckLoader.ReportProgress(progress, "Созданы объекты файловой системы");

                SiteDataManager manager = new SiteDataManager("russia", "mother", this._currentCred.Password);

                int size = 23;

                Boolean downloadAll = Convert.ToBoolean( e.Argument );

                if (downloadAll)
                {
                    size = int.MaxValue;
                }

                this.bgDeckLoader.ReportProgress(progress, "Подключаемся к сайту");
                var pagesenumerator = manager.SiteDeckManager.getDeckPages(size);

                List<String> pages = new List<String>();
                foreach (String page in pagesenumerator)
                {
                    pages.Add(page);
                }

                int pagesCount = pages.Count;

                using (var file = CurrentCredential.Engine.DeckManager.OpenForWrite())
                {
                    using (StreamWriter f = new StreamWriter(file))
                    {
                        for(int pageIngex = 0; pageIngex < pagesCount; pageIngex++)
                        {
                            String page = pages[pageIngex];

                            this.bgDeckLoader.ReportProgress(progress, "Обрабатываем " + page);

                            try
                            {
                                var decks = manager.SiteDeckManager.GetDecksListFromPage(page);
                                foreach (String deck in decks)
                                {
                                    f.WriteLine(deck);
                                }
                                f.Flush(); 
                            }
                            catch (Exception ex)
                            {
                                this.bgDeckLoader.ReportProgress(progress, ex.Message);
                            }

                            progress = ((100000 * pageIngex) / pagesCount) /1000;
                            this.bgDeckLoader.ReportProgress(progress/100);
                        }
                    }

                    this.bgDeckLoader.ReportProgress(progress, "Все страницы закачаны ");
                }
            }
            catch (Exception ex)
            {
                this.bgDeckLoader.ReportProgress(-1, ex.Message);
            }
        }

        private void bgDeckLoader_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int v = e.ProgressPercentage;

            if (v > 0)
            {
                if (v > 100)
                {
                    v = 100;
                }
                this.progressBar1.Value = v;
                this.progressBar1.Update();
            }

            if (e.UserState != null)
            {
                this.ParentForm.ShowNotification(e.UserState + "("+ v +"%)", ToolTipIcon.Info);
                this.listBoxLog.Items.Add(e.UserState);
                this.listBoxLog.Update();
            }
        }

        private void bgDeckLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar1.Value = 0;
            this.progressBar1.Update();

            this.button1.Enabled = true;
            this.ParentForm.ShowNotification("Обновление данных о деках игроков завершено", ToolTipIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.listBoxLog.Items.Clear();
            this.listBoxLog.Update();

            this.button1.Enabled = false;

            this.bgDeckLoader = new BackgroundWorker();
            this.bgDeckLoader.WorkerReportsProgress = true;
            this.bgDeckLoader.WorkerSupportsCancellation = true;
            
            this.bgDeckLoader.DoWork += bgDeckLoader_DoWork;
            this.bgDeckLoader.ProgressChanged += bgDeckLoader_ProgressChanged;
            this.bgDeckLoader.RunWorkerCompleted += bgDeckLoader_RunWorkerCompleted;            
            this.bgDeckLoader.RunWorkerAsync(this.checkBoxAlldecks.Checked);
        }
    }
}
