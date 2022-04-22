namespace SoccerScore_TEST_GUI
{
    partial class DefaultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultForm));
            this.playersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.favoruitePLayersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearAllAndExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.programTab = new System.Windows.Forms.TabControl();
            this.playersTab = new System.Windows.Forms.TabPage();
            this.statisticsTab = new System.Windows.Forms.TabPage();
            this.matchesTab = new System.Windows.Forms.TabPage();
            this.optionsStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printOption = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnEnglish = new System.Windows.Forms.ToolStripButton();
            this.btnCroatian = new System.Windows.Forms.ToolStripButton();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.programTab.SuspendLayout();
            this.playersTab.SuspendLayout();
            this.optionsStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // playersContainer
            // 
            this.playersContainer.AutoScroll = true;
            this.playersContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playersContainer.Location = new System.Drawing.Point(7, 81);
            this.playersContainer.Name = "playersContainer";
            this.playersContainer.Size = new System.Drawing.Size(1162, 240);
            this.playersContainer.TabIndex = 0;
            this.playersContainer.Visible = false;
            this.playersContainer.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(544, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "All players";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(524, 336);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Favourite players";
            this.label2.Visible = false;
            // 
            // favoruitePLayersContainer
            // 
            this.favoruitePLayersContainer.AutoScroll = true;
            this.favoruitePLayersContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.favoruitePLayersContainer.Location = new System.Drawing.Point(290, 360);
            this.favoruitePLayersContainer.Name = "favoruitePLayersContainer";
            this.favoruitePLayersContainer.Size = new System.Drawing.Size(596, 240);
            this.favoruitePLayersContainer.TabIndex = 1;
            this.favoruitePLayersContainer.Visible = false;
            this.favoruitePLayersContainer.WrapContents = false;
            // 
            // btnClearAllAndExit
            // 
            this.btnClearAllAndExit.Location = new System.Drawing.Point(497, 641);
            this.btnClearAllAndExit.Name = "btnClearAllAndExit";
            this.btnClearAllAndExit.Size = new System.Drawing.Size(182, 23);
            this.btnClearAllAndExit.TabIndex = 4;
            this.btnClearAllAndExit.Text = "Clear all and exit";
            this.btnClearAllAndExit.UseVisualStyleBackColor = true;
            this.btnClearAllAndExit.Click += new System.EventHandler(this.btnClearAllAndExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(534, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 34);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Country";
            this.lblTitle.Visible = false;
            // 
            // programTab
            // 
            this.programTab.Controls.Add(this.playersTab);
            this.programTab.Controls.Add(this.statisticsTab);
            this.programTab.Controls.Add(this.matchesTab);
            this.programTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.programTab.Location = new System.Drawing.Point(0, 23);
            this.programTab.Name = "programTab";
            this.programTab.SelectedIndex = 0;
            this.programTab.Size = new System.Drawing.Size(1184, 738);
            this.programTab.TabIndex = 6;
            // 
            // playersTab
            // 
            this.playersTab.BackColor = System.Drawing.SystemColors.Control;
            this.playersTab.Controls.Add(this.pbLoading);
            this.playersTab.Controls.Add(this.label1);
            this.playersTab.Controls.Add(this.playersContainer);
            this.playersTab.Controls.Add(this.btnClearAllAndExit);
            this.playersTab.Controls.Add(this.lblTitle);
            this.playersTab.Controls.Add(this.favoruitePLayersContainer);
            this.playersTab.Controls.Add(this.label2);
            this.playersTab.Location = new System.Drawing.Point(4, 22);
            this.playersTab.Name = "playersTab";
            this.playersTab.Padding = new System.Windows.Forms.Padding(3);
            this.playersTab.Size = new System.Drawing.Size(1176, 712);
            this.playersTab.TabIndex = 0;
            this.playersTab.Text = "Players";
            // 
            // statisticsTab
            // 
            this.statisticsTab.Location = new System.Drawing.Point(4, 22);
            this.statisticsTab.Name = "statisticsTab";
            this.statisticsTab.Padding = new System.Windows.Forms.Padding(3);
            this.statisticsTab.Size = new System.Drawing.Size(1176, 712);
            this.statisticsTab.TabIndex = 1;
            this.statisticsTab.Text = "Team statistics";
            this.statisticsTab.UseVisualStyleBackColor = true;
            // 
            // matchesTab
            // 
            this.matchesTab.Location = new System.Drawing.Point(4, 22);
            this.matchesTab.Name = "matchesTab";
            this.matchesTab.Size = new System.Drawing.Size(1176, 712);
            this.matchesTab.TabIndex = 2;
            this.matchesTab.Text = "Matches";
            this.matchesTab.UseVisualStyleBackColor = true;
            // 
            // optionsStrip
            // 
            this.optionsStrip.Enabled = false;
            this.optionsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.optionsStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.optionsStrip.Location = new System.Drawing.Point(0, 0);
            this.optionsStrip.Name = "optionsStrip";
            this.optionsStrip.Size = new System.Drawing.Size(1184, 23);
            this.optionsStrip.TabIndex = 7;
            this.optionsStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printOption,
            this.settingsOption});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // printOption
            // 
            this.printOption.Name = "printOption";
            this.printOption.Size = new System.Drawing.Size(180, 22);
            this.printOption.Text = "Print";
            // 
            // settingsOption
            // 
            this.settingsOption.Name = "settingsOption";
            this.settingsOption.Size = new System.Drawing.Size(180, 22);
            this.settingsOption.Text = "Settings";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "National team [FFC]";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(113, 17);
            this.lblStatus.Text = "National team [FFC]";
            // 
            // toolStrip
            // 
            this.toolStrip.Enabled = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnglish,
            this.btnCroatian});
            this.toolStrip.Location = new System.Drawing.Point(0, 23);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip.TabIndex = 9;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnEnglish
            // 
            this.btnEnglish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEnglish.Image = global::SoccerScore_TEST_GUI.Images.uk;
            this.btnEnglish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Size = new System.Drawing.Size(23, 22);
            this.btnEnglish.Text = "Switch to English";
            // 
            // btnCroatian
            // 
            this.btnCroatian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCroatian.Image = global::SoccerScore_TEST_GUI.Images.cro;
            this.btnCroatian.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCroatian.Name = "btnCroatian";
            this.btnCroatian.Size = new System.Drawing.Size(23, 22);
            this.btnCroatian.Text = "Switch to Croatian";
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::SoccerScore_TEST_GUI.Images.loading;
            this.pbLoading.Location = new System.Drawing.Point(1068, 608);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(100, 100);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 1;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // DefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.programTab);
            this.Controls.Add(this.optionsStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.optionsStrip;
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "DefaultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soccer Score BETA";
            this.Load += new System.EventHandler(this.DefaultForm_Load);
            this.programTab.ResumeLayout(false);
            this.playersTab.ResumeLayout(false);
            this.playersTab.PerformLayout();
            this.optionsStrip.ResumeLayout(false);
            this.optionsStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel playersContainer;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel favoruitePLayersContainer;
        private System.Windows.Forms.Button btnClearAllAndExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl programTab;
        private System.Windows.Forms.TabPage playersTab;
        private System.Windows.Forms.TabPage statisticsTab;
        private System.Windows.Forms.TabPage matchesTab;
        private System.Windows.Forms.MenuStrip optionsStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printOption;
        private System.Windows.Forms.ToolStripMenuItem settingsOption;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnEnglish;
        private System.Windows.Forms.ToolStripButton btnCroatian;
    }
}

