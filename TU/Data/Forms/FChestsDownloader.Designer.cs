namespace DIntegra.TU.Forms
{
    partial class FChestsDownloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbAllMaxed = new System.Windows.Forms.CheckBox();
            this.cbAllFuses = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCurrCards = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbLevel6 = new System.Windows.Forms.CheckBox();
            this.cbLevel5 = new System.Windows.Forms.CheckBox();
            this.cbLevel4 = new System.Windows.Forms.CheckBox();
            this.cbLevel3 = new System.Windows.Forms.CheckBox();
            this.cbLevel2 = new System.Windows.Forms.CheckBox();
            this.cbLevel1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbLookUpForGuild = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(154, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(649, 23);
            this.progressBar.TabIndex = 0;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(12, 12);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(136, 23);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.Text = "Начать скачивание";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(344, 40);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(459, 329);
            this.listBoxLog.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // cbAllMaxed
            // 
            this.cbAllMaxed.AutoSize = true;
            this.cbAllMaxed.Checked = true;
            this.cbAllMaxed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllMaxed.Location = new System.Drawing.Point(6, 42);
            this.cbAllMaxed.Name = "cbAllMaxed";
            this.cbAllMaxed.Size = new System.Drawing.Size(292, 17);
            this.cbAllMaxed.TabIndex = 12;
            this.cbAllMaxed.Text = "Скачивать список карт как полностью прокаченных";
            this.cbAllMaxed.UseVisualStyleBackColor = true;
            // 
            // cbAllFuses
            // 
            this.cbAllFuses.AutoSize = true;
            this.cbAllFuses.Checked = true;
            this.cbAllFuses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAllFuses.Location = new System.Drawing.Point(6, 19);
            this.cbAllFuses.Name = "cbAllFuses";
            this.cbAllFuses.Size = new System.Drawing.Size(166, 17);
            this.cbAllFuses.TabIndex = 11;
            this.cbAllFuses.Text = "Скачивать список всех фуз";
            this.cbAllFuses.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCurrCards);
            this.groupBox1.Controls.Add(this.cbAllMaxed);
            this.groupBox1.Controls.Add(this.cbAllFuses);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 97);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дополнительные сеты";
            // 
            // cbCurrCards
            // 
            this.cbCurrCards.AutoSize = true;
            this.cbCurrCards.Checked = true;
            this.cbCurrCards.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCurrCards.Location = new System.Drawing.Point(6, 65);
            this.cbCurrCards.Name = "cbCurrCards";
            this.cbCurrCards.Size = new System.Drawing.Size(190, 17);
            this.cbCurrCards.TabIndex = 13;
            this.cbCurrCards.Text = "Скачивать текущий список карт";
            this.cbCurrCards.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbLevel6);
            this.groupBox2.Controls.Add(this.cbLevel5);
            this.groupBox2.Controls.Add(this.cbLevel4);
            this.groupBox2.Controls.Add(this.cbLevel3);
            this.groupBox2.Controls.Add(this.cbLevel2);
            this.groupBox2.Controls.Add(this.cbLevel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 165);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Фильтры для текущих запасов";
            // 
            // cbLevel6
            // 
            this.cbLevel6.AutoSize = true;
            this.cbLevel6.Location = new System.Drawing.Point(7, 135);
            this.cbLevel6.Name = "cbLevel6";
            this.cbLevel6.Size = new System.Drawing.Size(224, 17);
            this.cbLevel6.TabIndex = 5;
            this.cbLevel6.Text = "Не скачивать карты с прокачкой на +6";
            this.cbLevel6.UseVisualStyleBackColor = true;
            // 
            // cbLevel5
            // 
            this.cbLevel5.AutoSize = true;
            this.cbLevel5.Location = new System.Drawing.Point(7, 112);
            this.cbLevel5.Name = "cbLevel5";
            this.cbLevel5.Size = new System.Drawing.Size(224, 17);
            this.cbLevel5.TabIndex = 4;
            this.cbLevel5.Text = "Не скачивать карты с прокачкой на +5";
            this.cbLevel5.UseVisualStyleBackColor = true;
            // 
            // cbLevel4
            // 
            this.cbLevel4.AutoSize = true;
            this.cbLevel4.Location = new System.Drawing.Point(7, 89);
            this.cbLevel4.Name = "cbLevel4";
            this.cbLevel4.Size = new System.Drawing.Size(224, 17);
            this.cbLevel4.TabIndex = 3;
            this.cbLevel4.Text = "Не скачивать карты с прокачкой на +4";
            this.cbLevel4.UseVisualStyleBackColor = true;
            // 
            // cbLevel3
            // 
            this.cbLevel3.AutoSize = true;
            this.cbLevel3.Location = new System.Drawing.Point(7, 66);
            this.cbLevel3.Name = "cbLevel3";
            this.cbLevel3.Size = new System.Drawing.Size(224, 17);
            this.cbLevel3.TabIndex = 2;
            this.cbLevel3.Text = "Не скачивать карты с прокачкой на +3";
            this.cbLevel3.UseVisualStyleBackColor = true;
            // 
            // cbLevel2
            // 
            this.cbLevel2.AutoSize = true;
            this.cbLevel2.Location = new System.Drawing.Point(6, 43);
            this.cbLevel2.Name = "cbLevel2";
            this.cbLevel2.Size = new System.Drawing.Size(224, 17);
            this.cbLevel2.TabIndex = 1;
            this.cbLevel2.Text = "Не скачивать карты с прокачкой на +2";
            this.cbLevel2.UseVisualStyleBackColor = true;
            // 
            // cbLevel1
            // 
            this.cbLevel1.AutoSize = true;
            this.cbLevel1.Location = new System.Drawing.Point(7, 20);
            this.cbLevel1.Name = "cbLevel1";
            this.cbLevel1.Size = new System.Drawing.Size(224, 17);
            this.cbLevel1.TabIndex = 0;
            this.cbLevel1.Text = "Не скачивать карты с прокачкой на +1";
            this.cbLevel1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbLookUpForGuild);
            this.groupBox3.Location = new System.Drawing.Point(13, 324);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 45);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Обработка ников";
            // 
            // cbLookUpForGuild
            // 
            this.cbLookUpForGuild.AutoSize = true;
            this.cbLookUpForGuild.Location = new System.Drawing.Point(7, 20);
            this.cbLookUpForGuild.Name = "cbLookUpForGuild";
            this.cbLookUpForGuild.Size = new System.Drawing.Size(213, 17);
            this.cbLookUpForGuild.TabIndex = 0;
            this.cbLookUpForGuild.Text = "Пытаться найти гильдию для игрока";
            this.cbLookUpForGuild.UseVisualStyleBackColor = true;
            // 
            // FChestsDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 381);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FChestsDownloader";
            this.Text = "Старший брат следит за тобой";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FChestsDownloader_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox cbAllMaxed;
        private System.Windows.Forms.CheckBox cbAllFuses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbLevel6;
        private System.Windows.Forms.CheckBox cbLevel5;
        private System.Windows.Forms.CheckBox cbLevel4;
        private System.Windows.Forms.CheckBox cbLevel3;
        private System.Windows.Forms.CheckBox cbLevel2;
        private System.Windows.Forms.CheckBox cbLevel1;
        private System.Windows.Forms.CheckBox cbCurrCards;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbLookUpForGuild;
    }
}