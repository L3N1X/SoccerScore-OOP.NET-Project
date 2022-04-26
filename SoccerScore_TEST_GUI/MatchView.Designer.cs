namespace SoccerScore_TEST_GUI
{
    partial class MatchView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchView));
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblHomeAwayScore = new System.Windows.Forms.Label();
            this.lblAwayFifaCode = new System.Windows.Forms.Label();
            this.lblHomeFifaCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVisitorsLabel = new System.Windows.Forms.Label();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbHomeWinner = new System.Windows.Forms.PictureBox();
            this.pbAwayWinner = new System.Windows.Forms.PictureBox();
            this.pnlContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHomeWinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAwayWinner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            resources.ApplyResources(this.pnlContainer, "pnlContainer");
            this.pnlContainer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlContainer.Controls.Add(this.lblDate);
            this.pnlContainer.Controls.Add(this.lblLocation);
            this.pnlContainer.Controls.Add(this.pbHomeWinner);
            this.pnlContainer.Controls.Add(this.pbAwayWinner);
            this.pnlContainer.Controls.Add(this.lblHomeAwayScore);
            this.pnlContainer.Controls.Add(this.lblAwayFifaCode);
            this.pnlContainer.Controls.Add(this.lblHomeFifaCode);
            this.pnlContainer.Controls.Add(this.label2);
            this.pnlContainer.Controls.Add(this.label1);
            this.pnlContainer.Name = "pnlContainer";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Name = "lblDate";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // lblHomeAwayScore
            // 
            resources.ApplyResources(this.lblHomeAwayScore, "lblHomeAwayScore");
            this.lblHomeAwayScore.Name = "lblHomeAwayScore";
            // 
            // lblAwayFifaCode
            // 
            resources.ApplyResources(this.lblAwayFifaCode, "lblAwayFifaCode");
            this.lblAwayFifaCode.Name = "lblAwayFifaCode";
            // 
            // lblHomeFifaCode
            // 
            resources.ApplyResources(this.lblHomeFifaCode, "lblHomeFifaCode");
            this.lblHomeFifaCode.Name = "lblHomeFifaCode";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblVisitorsLabel
            // 
            resources.ApplyResources(this.lblVisitorsLabel, "lblVisitorsLabel");
            this.lblVisitorsLabel.Name = "lblVisitorsLabel";
            // 
            // lblAttendance
            // 
            resources.ApplyResources(this.lblAttendance, "lblAttendance");
            this.lblAttendance.Name = "lblAttendance";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.lblAttendance);
            this.panel1.Controls.Add(this.lblVisitorsLabel);
            this.panel1.Name = "panel1";
            // 
            // pbHomeWinner
            // 
            resources.ApplyResources(this.pbHomeWinner, "pbHomeWinner");
            this.pbHomeWinner.Name = "pbHomeWinner";
            this.pbHomeWinner.TabStop = false;
            // 
            // pbAwayWinner
            // 
            resources.ApplyResources(this.pbAwayWinner, "pbAwayWinner");
            this.pbAwayWinner.Name = "pbAwayWinner";
            this.pbAwayWinner.TabStop = false;
            // 
            // MatchView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlContainer);
            this.Name = "MatchView";
            this.pnlContainer.ResumeLayout(false);
            this.pnlContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHomeWinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAwayWinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label lblHomeAwayScore;
        private System.Windows.Forms.Label lblAwayFifaCode;
        private System.Windows.Forms.Label lblHomeFifaCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVisitorsLabel;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.PictureBox pbHomeWinner;
        private System.Windows.Forms.PictureBox pbAwayWinner;
        private System.Windows.Forms.Label lblDate;
    }
}
