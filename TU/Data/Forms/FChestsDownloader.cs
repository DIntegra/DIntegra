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
    public partial class FChestsDownloader : Form
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

        public FChestsDownloader(Credentials credential)
        {
            InitializeComponent();

            this._currentCred = credential;
        }

        private static String MakeSafeName(String name)
        {
            name = name.Replace("/", "_").Replace("\\", "_").Replace("<", "_").Replace(">", "_").Replace("?", "_").Replace("!", "_");

            return name;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ChestsDownloaderSettings settings = e.Argument as ChestsDownloaderSettings;

                if (settings == null)
                {
                    settings = new ChestsDownloaderSettings();
                }


                int progress = 0;
                this.backgroundWorker1.ReportProgress(progress, "Приступаем к обработке Дек");


                SiteDataManager manager = new SiteDataManager("russia", "mother", this.CurrentCredential.Password);
                this.backgroundWorker1.ReportProgress(progress, "Подключаемся к сайту");

                var chests = manager.SiteChestsManager.UserChestsDescriptions;
                this.backgroundWorker1.ReportProgress(progress, "Получена коллекция сундуков");

                String currentCardsFolder = this.CurrentCredential.Engine.ChestsManager.GetCurrentCardsFolderpath();
                String maxedCardsCardsFolder = this.CurrentCredential.Engine.ChestsManager.GetMaxedCardsFolderpath();
                String allFusesCardsFolder = this.CurrentCredential.Engine.ChestsManager.GetAllFusesCardsFolderpath();

                int step = 100 / chests.Count;

                foreach (UserChestDescription chestDescription in chests)
                {
                    this.backgroundWorker1.ReportProgress(progress, "Обрабатываем: " + chestDescription.Name);

                    int tries = 10;
                    while (tries-- > 0)
                    {
                        try
                        {
                            Console.WriteLine("Обрабатываем: " + chestDescription.Name);
                            var chest = manager.SiteChestsManager.FillChest(chestDescription);

                            var guild = manager.SiteDeckManager.GetGuildByPlayer(chestDescription.Name);

                            var fname = MakeSafeName(guild + "." + chestDescription.Name);

                            using (var f = System.IO.File.CreateText(currentCardsFolder + "\\" + fname + ".txt"))
                            {
                                foreach (String card in chest.IOwnerCards)
                                {
                                    if (settings.CheckFilterCard(card))
                                    {
                                        f.WriteLine(card);
                                    }
                                }
                            }

                            if (settings.GetAllMaxedCollection)
                            {
                                using (var f = File.CreateText(maxedCardsCardsFolder + "\\" + fname + ".txt"))
                                {
                                    foreach (String card in chest.IOwnerCardsMaxed)
                                    {
                                        f.WriteLine(card);
                                    }
                                }
                            }


                            if (settings.GetAllFusesCollection)
                            {
                                using (var f = File.CreateText(allFusesCardsFolder + "\\" + fname + ".txt"))
                                {
                                    foreach (String card in chest.IPossibleCard)
                                    {
                                        f.WriteLine(card);
                                    }
                                }
                            }
                            tries = 0;

                            progress = progress + step;
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            this.backgroundWorker1.ReportProgress(progress, "Произошла ошибка: " + ex.ToString());
                            this.backgroundWorker1.ReportProgress(progress, "Осталось попыток: " + tries);
                        }
                        catch (Exception ex)
                        {
                            this.backgroundWorker1.ReportProgress(progress, "Произошла ошибка: " + ex.ToString());
                            this.backgroundWorker1.ReportProgress(progress, "Осталось попыток: " + tries);
                        }
                    }

                }
               
            }
            catch (Exception ex)
            {
                this.backgroundWorker1.ReportProgress(-1, ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int v = e.ProgressPercentage;

            if (v > 0)
            {
                if (v > 100)
                {
                    v = 100;
                }
                this.progressBar.Value = v;
                this.progressBar.Update();
            }

            if (e.UserState != null)
            {
                this.ParentForm.ShowNotification(e.UserState + " (" + v + "%)", ToolTipIcon.Info);
                this.listBoxLog.Items.Add(e.UserState);
                this.listBoxLog.Update();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.progressBar.Value = 0;
            this.progressBar.Update();

            this.buttonDownload.Enabled = true;
            this.ParentForm.ShowNotification("Обновление данных о запасах игроков завершено", ToolTipIcon.Warning);
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            this.listBoxLog.Items.Clear();

            this.buttonDownload.Enabled = false;
            this.progressBar.Value = 0;

            ChestsDownloaderSettings settings = new ChestsDownloaderSettings();

            settings.GetAllFusesCollection = this.cbAllFuses.Checked;
            settings.GetAllMaxedCollection = this.cbAllMaxed.Checked;
            settings.GetCurrentCollection = this.cbCurrCards.Checked;

            if (this.cbLevel1.Checked)
            {
                settings.AddBlocklevel(1);
            }

            if (this.cbLevel2.Checked)
            {
                settings.AddBlocklevel(2);
            }

            if (this.cbLevel3.Checked)
            {
                settings.AddBlocklevel(3);
            }

            if (this.cbLevel4.Checked)
            {
                settings.AddBlocklevel(4);
            }

            if (this.cbLevel5.Checked)
            {
                settings.AddBlocklevel(5);
            }

            if (this.cbLevel6.Checked)
            {
                settings.AddBlocklevel(6);
            }

            this.backgroundWorker1.RunWorkerAsync(settings);
        }

        private void FChestsDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.backgroundWorker1.IsBusy)
            {
                DialogResult res = MessageBox.Show("Выполняется скачивание. Если закрыть - скачивание будет остановлено. закрыть форму?", "Че творишь, а?", MessageBoxButtons.YesNo);

                if (res != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    this.backgroundWorker1.CancelAsync();
                }
            }
        }
    }
}
