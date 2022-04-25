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
            this.lblTitle = new System.Windows.Forms.Label();
            this.programTab = new System.Windows.Forms.TabControl();
            this.playersTab = new System.Windows.Forms.TabPage();
            this.lblCredits = new System.Windows.Forms.Label();
            this.statisticsTab = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPoints = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblGoalDifferential = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblGoalsAgainst = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGoalsFor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGamesPlayed = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblDraws = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblLosses = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblWins = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalPoints = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblFifaCode = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPlayers = new System.Windows.Forms.ListBox();
            this.matchesTab = new System.Windows.Forms.TabPage();
            this.btnSettings = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.flpMatches = new System.Windows.Forms.FlowLayoutPanel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.btnEnglish = new System.Windows.Forms.ToolStripButton();
            this.btnCroatian = new System.Windows.Forms.ToolStripButton();
            this.pbBorderLeft = new System.Windows.Forms.PictureBox();
            this.pbBorderRight = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.programTab.SuspendLayout();
            this.playersTab.SuspendLayout();
            this.statisticsTab.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.matchesTab.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorderLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorderRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playersContainer
            // 
            resources.ApplyResources(this.playersContainer, "playersContainer");
            this.playersContainer.Name = "playersContainer";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // favoruitePLayersContainer
            // 
            resources.ApplyResources(this.favoruitePLayersContainer, "favoruitePLayersContainer");
            this.favoruitePLayersContainer.Name = "favoruitePLayersContainer";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // programTab
            // 
            this.programTab.Controls.Add(this.playersTab);
            this.programTab.Controls.Add(this.matchesTab);
            this.programTab.Controls.Add(this.statisticsTab);
            resources.ApplyResources(this.programTab, "programTab");
            this.programTab.Name = "programTab";
            this.programTab.SelectedIndex = 0;
            // 
            // playersTab
            // 
            this.playersTab.BackColor = System.Drawing.SystemColors.Control;
            this.playersTab.Controls.Add(this.lblCredits);
            this.playersTab.Controls.Add(this.pbBorderLeft);
            this.playersTab.Controls.Add(this.pbBorderRight);
            this.playersTab.Controls.Add(this.label1);
            this.playersTab.Controls.Add(this.playersContainer);
            this.playersTab.Controls.Add(this.lblTitle);
            this.playersTab.Controls.Add(this.favoruitePLayersContainer);
            this.playersTab.Controls.Add(this.label2);
            resources.ApplyResources(this.playersTab, "playersTab");
            this.playersTab.Name = "playersTab";
            this.playersTab.Click += new System.EventHandler(this.playersTab_Click);
            // 
            // lblCredits
            // 
            resources.ApplyResources(this.lblCredits, "lblCredits");
            this.lblCredits.Name = "lblCredits";
            // 
            // statisticsTab
            // 
            this.statisticsTab.BackColor = System.Drawing.SystemColors.Control;
            this.statisticsTab.Controls.Add(this.label8);
            this.statisticsTab.Controls.Add(this.groupBox2);
            this.statisticsTab.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.statisticsTab, "statisticsTab");
            this.statisticsTab.Name = "statisticsTab";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPoints);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblGoalDifferential);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblGoalsAgainst);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblGoalsFor);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblGamesPlayed);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblDraws);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lblLosses);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lblWins);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.lblTotalPoints);
            this.groupBox2.Controls.Add(this.lblCountry);
            this.groupBox2.Controls.Add(this.lblFifaCode);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // lblPoints
            // 
            resources.ApplyResources(this.lblPoints, "lblPoints");
            this.lblPoints.Name = "lblPoints";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblGoalDifferential
            // 
            resources.ApplyResources(this.lblGoalDifferential, "lblGoalDifferential");
            this.lblGoalDifferential.Name = "lblGoalDifferential";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // lblGoalsAgainst
            // 
            resources.ApplyResources(this.lblGoalsAgainst, "lblGoalsAgainst");
            this.lblGoalsAgainst.Name = "lblGoalsAgainst";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // lblGoalsFor
            // 
            resources.ApplyResources(this.lblGoalsFor, "lblGoalsFor");
            this.lblGoalsFor.Name = "lblGoalsFor";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // lblGamesPlayed
            // 
            resources.ApplyResources(this.lblGamesPlayed, "lblGamesPlayed");
            this.lblGamesPlayed.Name = "lblGamesPlayed";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // lblDraws
            // 
            resources.ApplyResources(this.lblDraws, "lblDraws");
            this.lblDraws.Name = "lblDraws";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // lblLosses
            // 
            resources.ApplyResources(this.lblLosses, "lblLosses");
            this.lblLosses.Name = "lblLosses";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // lblWins
            // 
            resources.ApplyResources(this.lblWins, "lblWins");
            this.lblWins.Name = "lblWins";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // lblTotalPoints
            // 
            resources.ApplyResources(this.lblTotalPoints, "lblTotalPoints");
            this.lblTotalPoints.Name = "lblTotalPoints";
            // 
            // lblCountry
            // 
            resources.ApplyResources(this.lblCountry, "lblCountry");
            this.lblCountry.Name = "lblCountry";
            // 
            // lblFifaCode
            // 
            resources.ApplyResources(this.lblFifaCode, "lblFifaCode");
            this.lblFifaCode.Name = "lblFifaCode";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbPlayers);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lbPlayers
            // 
            this.lbPlayers.BackColor = System.Drawing.SystemColors.Control;
            this.lbPlayers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbPlayers.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.lbPlayers, "lbPlayers");
            this.lbPlayers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPlayers.Name = "lbPlayers";
            // 
            // matchesTab
            // 
            this.matchesTab.BackColor = System.Drawing.SystemColors.Control;
            this.matchesTab.Controls.Add(this.flpMatches);
            this.matchesTab.Controls.Add(this.btnSettings);
            resources.ApplyResources(this.matchesTab, "matchesTab");
            this.matchesTab.Name = "matchesTab";
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            resources.ApplyResources(this.lblStatus, "lblStatus");
            // 
            // toolStrip
            // 
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnglish,
            this.btnCroatian});
            this.toolStrip.Name = "toolStrip";
            // 
            // flpMatches
            // 
            resources.ApplyResources(this.flpMatches, "flpMatches");
            this.flpMatches.Name = "flpMatches";
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::SoccerScore_TEST_GUI.Images.ball_loading;
            resources.ApplyResources(this.pbLoading, "pbLoading");
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.TabStop = false;
            // 
            // btnEnglish
            // 
            this.btnEnglish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEnglish.Image = global::SoccerScore_TEST_GUI.Images.uk;
            resources.ApplyResources(this.btnEnglish, "btnEnglish");
            this.btnEnglish.Name = "btnEnglish";
            this.btnEnglish.Click += new System.EventHandler(this.btnEnglish_Click);
            // 
            // btnCroatian
            // 
            this.btnCroatian.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCroatian.Image = global::SoccerScore_TEST_GUI.Images.cro;
            resources.ApplyResources(this.btnCroatian, "btnCroatian");
            this.btnCroatian.Name = "btnCroatian";
            this.btnCroatian.Click += new System.EventHandler(this.btnCroatian_Click);
            // 
            // pbBorderLeft
            // 
            this.pbBorderLeft.Image = global::SoccerScore_TEST_GUI.Images.border_left;
            resources.ApplyResources(this.pbBorderLeft, "pbBorderLeft");
            this.pbBorderLeft.Name = "pbBorderLeft";
            this.pbBorderLeft.TabStop = false;
            // 
            // pbBorderRight
            // 
            this.pbBorderRight.Image = global::SoccerScore_TEST_GUI.Images.border_right;
            resources.ApplyResources(this.pbBorderRight, "pbBorderRight");
            this.pbBorderRight.Name = "pbBorderRight";
            this.pbBorderRight.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::SoccerScore_TEST_GUI.Images.tactics;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // DefaultForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.programTab);
            this.Name = "DefaultForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DefaultForm_FormClosing);
            this.Load += new System.EventHandler(this.DefaultForm_Load);
            this.programTab.ResumeLayout(false);
            this.playersTab.ResumeLayout(false);
            this.playersTab.PerformLayout();
            this.statisticsTab.ResumeLayout(false);
            this.statisticsTab.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.matchesTab.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorderLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBorderRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel playersContainer;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel favoruitePLayersContainer;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl programTab;
        private System.Windows.Forms.TabPage playersTab;
        private System.Windows.Forms.TabPage statisticsTab;
        private System.Windows.Forms.TabPage matchesTab;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnEnglish;
        private System.Windows.Forms.ToolStripButton btnCroatian;
        private System.Windows.Forms.PictureBox pbBorderLeft;
        private System.Windows.Forms.PictureBox pbBorderRight;
        private System.Windows.Forms.Label lblCredits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.Label lblGoalDifferential;
        private System.Windows.Forms.Label lblGoalsAgainst;
        private System.Windows.Forms.Label lblGoalsFor;
        private System.Windows.Forms.Label lblGamesPlayed;
        private System.Windows.Forms.Label lblDraws;
        private System.Windows.Forms.Label lblLosses;
        private System.Windows.Forms.Label lblWins;
        private System.Windows.Forms.Label lblTotalPoints;
        private System.Windows.Forms.Label lblFifaCode;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox lbPlayers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.FlowLayoutPanel flpMatches;
    }
}

