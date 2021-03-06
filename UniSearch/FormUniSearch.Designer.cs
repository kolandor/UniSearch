﻿namespace UniSearch
{
    partial class FormUniSearch
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUniSearch));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelInpData = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxSearchString = new System.Windows.Forms.TextBox();
            this.textBoxThreadsCount = new System.Windows.Forms.TextBox();
            this.labelSearchString = new System.Windows.Forms.Label();
            this.labelThreadsCount = new System.Windows.Forms.Label();
            this.labelSearchCount = new System.Windows.Forms.Label();
            this.textBoxSearchCount = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelUrl = new System.Windows.Forms.TableLayoutPanel();
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelScanInfo = new System.Windows.Forms.TableLayoutPanel();
            this.labelSearchInfo = new System.Windows.Forms.Label();
            this.listViewSearchInfo = new System.Windows.Forms.ListView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanelControlButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.buttonPauseResume = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelInpData.SuspendLayout();
            this.tableLayoutPanelUrl.SuspendLayout();
            this.tableLayoutPanelScanInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelControlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(548, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 1;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelInpData, 0, 1);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelUrl, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelScanInfo, 0, 2);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelControlButtons, 0, 4);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 5;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.22222F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.77778F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(548, 302);
            this.tableLayoutPanelMain.TabIndex = 1;
            // 
            // tableLayoutPanelInpData
            // 
            this.tableLayoutPanelInpData.ColumnCount = 3;
            this.tableLayoutPanelInpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInpData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanelInpData.Controls.Add(this.textBoxSearchString, 2, 1);
            this.tableLayoutPanelInpData.Controls.Add(this.textBoxThreadsCount, 1, 1);
            this.tableLayoutPanelInpData.Controls.Add(this.labelSearchString, 2, 0);
            this.tableLayoutPanelInpData.Controls.Add(this.labelThreadsCount, 1, 0);
            this.tableLayoutPanelInpData.Controls.Add(this.labelSearchCount, 0, 0);
            this.tableLayoutPanelInpData.Controls.Add(this.textBoxSearchCount, 0, 1);
            this.tableLayoutPanelInpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelInpData.Location = new System.Drawing.Point(3, 49);
            this.tableLayoutPanelInpData.Name = "tableLayoutPanelInpData";
            this.tableLayoutPanelInpData.RowCount = 2;
            this.tableLayoutPanelInpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelInpData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanelInpData.Size = new System.Drawing.Size(542, 46);
            this.tableLayoutPanelInpData.TabIndex = 0;
            // 
            // textBoxSearchString
            // 
            this.textBoxSearchString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearchString.Location = new System.Drawing.Point(289, 22);
            this.textBoxSearchString.Name = "textBoxSearchString";
            this.textBoxSearchString.Size = new System.Drawing.Size(250, 20);
            this.textBoxSearchString.TabIndex = 5;
            // 
            // textBoxThreadsCount
            // 
            this.textBoxThreadsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxThreadsCount.Location = new System.Drawing.Point(146, 22);
            this.textBoxThreadsCount.Name = "textBoxThreadsCount";
            this.textBoxThreadsCount.Size = new System.Drawing.Size(137, 20);
            this.textBoxThreadsCount.TabIndex = 4;
            // 
            // labelSearchString
            // 
            this.labelSearchString.AutoSize = true;
            this.labelSearchString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSearchString.Location = new System.Drawing.Point(289, 0);
            this.labelSearchString.Name = "labelSearchString";
            this.labelSearchString.Size = new System.Drawing.Size(250, 19);
            this.labelSearchString.TabIndex = 3;
            this.labelSearchString.Text = "Search String";
            // 
            // labelThreadsCount
            // 
            this.labelThreadsCount.AutoSize = true;
            this.labelThreadsCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelThreadsCount.Location = new System.Drawing.Point(146, 0);
            this.labelThreadsCount.Name = "labelThreadsCount";
            this.labelThreadsCount.Size = new System.Drawing.Size(137, 19);
            this.labelThreadsCount.TabIndex = 2;
            this.labelThreadsCount.Text = "Threads Count";
            // 
            // labelSearchCount
            // 
            this.labelSearchCount.AutoSize = true;
            this.labelSearchCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSearchCount.Location = new System.Drawing.Point(3, 0);
            this.labelSearchCount.Name = "labelSearchCount";
            this.labelSearchCount.Size = new System.Drawing.Size(137, 19);
            this.labelSearchCount.TabIndex = 0;
            this.labelSearchCount.Text = "URL Search Count";
            // 
            // textBoxSearchCount
            // 
            this.textBoxSearchCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSearchCount.Location = new System.Drawing.Point(3, 22);
            this.textBoxSearchCount.Name = "textBoxSearchCount";
            this.textBoxSearchCount.Size = new System.Drawing.Size(137, 20);
            this.textBoxSearchCount.TabIndex = 1;
            // 
            // tableLayoutPanelUrl
            // 
            this.tableLayoutPanelUrl.ColumnCount = 1;
            this.tableLayoutPanelUrl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelUrl.Controls.Add(this.labelUrl, 0, 0);
            this.tableLayoutPanelUrl.Controls.Add(this.textBoxUrl, 0, 1);
            this.tableLayoutPanelUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelUrl.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelUrl.Name = "tableLayoutPanelUrl";
            this.tableLayoutPanelUrl.RowCount = 2;
            this.tableLayoutPanelUrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.63636F));
            this.tableLayoutPanelUrl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.36364F));
            this.tableLayoutPanelUrl.Size = new System.Drawing.Size(542, 40);
            this.tableLayoutPanelUrl.TabIndex = 1;
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUrl.Location = new System.Drawing.Point(3, 0);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(536, 15);
            this.labelUrl.TabIndex = 0;
            this.labelUrl.Text = "URL";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxUrl.Location = new System.Drawing.Point(3, 18);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(536, 20);
            this.textBoxUrl.TabIndex = 1;
            // 
            // tableLayoutPanelScanInfo
            // 
            this.tableLayoutPanelScanInfo.ColumnCount = 1;
            this.tableLayoutPanelScanInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelScanInfo.Controls.Add(this.labelSearchInfo, 0, 0);
            this.tableLayoutPanelScanInfo.Controls.Add(this.listViewSearchInfo, 0, 1);
            this.tableLayoutPanelScanInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelScanInfo.Location = new System.Drawing.Point(3, 101);
            this.tableLayoutPanelScanInfo.Name = "tableLayoutPanelScanInfo";
            this.tableLayoutPanelScanInfo.RowCount = 2;
            this.tableLayoutPanelScanInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanelScanInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.61539F));
            this.tableLayoutPanelScanInfo.Size = new System.Drawing.Size(542, 115);
            this.tableLayoutPanelScanInfo.TabIndex = 2;
            // 
            // labelSearchInfo
            // 
            this.labelSearchInfo.AutoSize = true;
            this.labelSearchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSearchInfo.Location = new System.Drawing.Point(3, 0);
            this.labelSearchInfo.Name = "labelSearchInfo";
            this.labelSearchInfo.Size = new System.Drawing.Size(536, 17);
            this.labelSearchInfo.TabIndex = 0;
            this.labelSearchInfo.Text = "Search Information";
            // 
            // listViewSearchInfo
            // 
            this.listViewSearchInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSearchInfo.Location = new System.Drawing.Point(3, 20);
            this.listViewSearchInfo.Name = "listViewSearchInfo";
            this.listViewSearchInfo.Size = new System.Drawing.Size(536, 92);
            this.listViewSearchInfo.TabIndex = 1;
            this.listViewSearchInfo.UseCompatibleStateImageBehavior = false;
            this.listViewSearchInfo.View = System.Windows.Forms.View.Tile;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelProgress, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 222);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.69388F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.30612F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(542, 43);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProgress.Location = new System.Drawing.Point(3, 0);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(536, 14);
            this.labelProgress.TabIndex = 0;
            this.labelProgress.Text = "Progress";
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 17);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(536, 23);
            this.progressBar.TabIndex = 1;
            // 
            // tableLayoutPanelControlButtons
            // 
            this.tableLayoutPanelControlButtons.ColumnCount = 2;
            this.tableLayoutPanelControlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelControlButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanelControlButtons.Controls.Add(this.buttonStartStop, 1, 0);
            this.tableLayoutPanelControlButtons.Controls.Add(this.buttonPauseResume, 0, 0);
            this.tableLayoutPanelControlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelControlButtons.Location = new System.Drawing.Point(3, 271);
            this.tableLayoutPanelControlButtons.Name = "tableLayoutPanelControlButtons";
            this.tableLayoutPanelControlButtons.RowCount = 1;
            this.tableLayoutPanelControlButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelControlButtons.Size = new System.Drawing.Size(542, 28);
            this.tableLayoutPanelControlButtons.TabIndex = 4;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonStartStop.Enabled = false;
            this.buttonStartStop.Location = new System.Drawing.Point(411, 3);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(128, 22);
            this.buttonStartStop.TabIndex = 0;
            this.buttonStartStop.Text = "START";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // buttonPauseResume
            // 
            this.buttonPauseResume.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonPauseResume.Enabled = false;
            this.buttonPauseResume.Location = new System.Drawing.Point(277, 3);
            this.buttonPauseResume.Name = "buttonPauseResume";
            this.buttonPauseResume.Size = new System.Drawing.Size(128, 22);
            this.buttonPauseResume.TabIndex = 1;
            this.buttonPauseResume.Text = "PAUSE";
            this.buttonPauseResume.UseVisualStyleBackColor = true;
            this.buttonPauseResume.Click += new System.EventHandler(this.buttonPauseResume_Click);
            // 
            // FormUniSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 326);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "FormUniSearch";
            this.Text = "UniSearch";
            this.Load += new System.EventHandler(this.FormUniSearch_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelInpData.ResumeLayout(false);
            this.tableLayoutPanelInpData.PerformLayout();
            this.tableLayoutPanelUrl.ResumeLayout(false);
            this.tableLayoutPanelUrl.PerformLayout();
            this.tableLayoutPanelScanInfo.ResumeLayout(false);
            this.tableLayoutPanelScanInfo.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelControlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelInpData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUrl;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.TextBox textBoxSearchString;
        private System.Windows.Forms.TextBox textBoxThreadsCount;
        private System.Windows.Forms.Label labelSearchString;
        private System.Windows.Forms.Label labelThreadsCount;
        private System.Windows.Forms.Label labelSearchCount;
        private System.Windows.Forms.TextBox textBoxSearchCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScanInfo;
        private System.Windows.Forms.Label labelSearchInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControlButtons;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Button buttonPauseResume;
        private System.Windows.Forms.ListView listViewSearchInfo;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

