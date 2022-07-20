namespace SoccerScore_TEST_GUI
{
    partial class PlayerViewRankView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerViewRankView));
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.lblPositon = new System.Windows.Forms.Label();
            this.pbCaptain = new System.Windows.Forms.PictureBox();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.pbPLayer = new System.Windows.Forms.PictureBox();
            this.lblRankValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblShirtNumber
            // 
            resources.ApplyResources(this.lblShirtNumber, "lblShirtNumber");
            this.lblShirtNumber.BackColor = System.Drawing.Color.White;
            this.lblShirtNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblShirtNumber.Name = "lblShirtNumber";
            // 
            // lblPositon
            // 
            resources.ApplyResources(this.lblPositon, "lblPositon");
            this.lblPositon.Name = "lblPositon";
            // 
            // pbCaptain
            // 
            this.pbCaptain.Image = global::SoccerScore_TEST_GUI.Images.captain;
            resources.ApplyResources(this.pbCaptain, "pbCaptain");
            this.pbCaptain.Name = "pbCaptain";
            this.pbCaptain.TabStop = false;
            // 
            // pbFavourite
            // 
            this.pbFavourite.Image = global::SoccerScore_TEST_GUI.Images.favourite;
            resources.ApplyResources(this.pbFavourite, "pbFavourite");
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.TabStop = false;
            // 
            // pbPLayer
            // 
            this.pbPLayer.Image = global::SoccerScore_TEST_GUI.Images.default_player_image;
            resources.ApplyResources(this.pbPLayer, "pbPLayer");
            this.pbPLayer.Name = "pbPLayer";
            this.pbPLayer.TabStop = false;
            // 
            // lblRankValue
            // 
            resources.ApplyResources(this.lblRankValue, "lblRankValue");
            this.lblRankValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblRankValue.Name = "lblRankValue";
            // 
            // PlayerViewRankView
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRankValue);
            this.Controls.Add(this.lblPositon);
            this.Controls.Add(this.lblShirtNumber);
            this.Controls.Add(this.pbCaptain);
            this.Controls.Add(this.pbFavourite);
            this.Controls.Add(this.pbPLayer);
            this.Controls.Add(this.lblName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PlayerViewRankView";
            this.Load += new System.EventHandler(this.PlayerView_Load);
            this.Click += new System.EventHandler(this.PlayerView_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPLayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pbPLayer;
        private System.Windows.Forms.PictureBox pbFavourite;
        private System.Windows.Forms.PictureBox pbCaptain;
        private System.Windows.Forms.Label lblShirtNumber;
        private System.Windows.Forms.Label lblPositon;
        private System.Windows.Forms.Label lblRankValue;
    }
}
