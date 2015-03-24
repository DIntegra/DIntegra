namespace DIntegra.TU.Forms
{
    partial class FMainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.скачатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запасыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.декиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.системныеФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ddlCredentials = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.обновитьSimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Enabled = false;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.скачатьToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1014, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // скачатьToolStripMenuItem
            // 
            this.скачатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запасыToolStripMenuItem,
            this.декиToolStripMenuItem,
            this.системныеФайлыToolStripMenuItem,
            this.toolStripSeparator2,
            this.обновитьSimToolStripMenuItem});
            this.скачатьToolStripMenuItem.Name = "скачатьToolStripMenuItem";
            this.скачатьToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.скачатьToolStripMenuItem.Text = "Скачать";
            // 
            // запасыToolStripMenuItem
            // 
            this.запасыToolStripMenuItem.Name = "запасыToolStripMenuItem";
            this.запасыToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.запасыToolStripMenuItem.Text = "Запасы";
            this.запасыToolStripMenuItem.Click += new System.EventHandler(this.запасыToolStripMenuItem_Click);
            // 
            // декиToolStripMenuItem
            // 
            this.декиToolStripMenuItem.Name = "декиToolStripMenuItem";
            this.декиToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.декиToolStripMenuItem.Text = "Деки";
            this.декиToolStripMenuItem.Click += new System.EventHandler(this.декиToolStripMenuItem_Click);
            // 
            // системныеФайлыToolStripMenuItem
            // 
            this.системныеФайлыToolStripMenuItem.Name = "системныеФайлыToolStripMenuItem";
            this.системныеФайлыToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.системныеФайлыToolStripMenuItem.Text = "Системные файлы";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ddlCredentials,
            this.toolStripButton1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1014, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(141, 22);
            this.toolStripLabel1.Text = "Текущий профиль игрока:";
            // 
            // ddlCredentials
            // 
            this.ddlCredentials.Name = "ddlCredentials";
            this.ddlCredentials.Size = new System.Drawing.Size(121, 25);
            this.ddlCredentials.SelectedIndexChanged += new System.EventHandler(this.ddlCredentials_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(89, 22);
            this.toolStripButton1.Text = "Создать новый";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "TU Integra Station";
            this.notifyIcon.Visible = true;
            // 
            // обновитьSimToolStripMenuItem
            // 
            this.обновитьSimToolStripMenuItem.Name = "обновитьSimToolStripMenuItem";
            this.обновитьSimToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.обновитьSimToolStripMenuItem.Text = "Обновить Sim";
            this.обновитьSimToolStripMenuItem.Click += new System.EventHandler(this.обновитьSimToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // FMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 505);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FMainForm";
            this.Text = "TU Integra Station 0.0.0.2";
            this.Load += new System.EventHandler(this.FMainForm_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem скачатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запасыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem декиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem системныеФайлыToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ddlCredentials;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem обновитьSimToolStripMenuItem;
    }
}