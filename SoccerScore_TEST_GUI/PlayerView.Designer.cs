namespace SoccerScore_TEST_GUI
{
    partial class PlayerView
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.pbCaptain = new System.Windows.Forms.PictureBox();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.pbPLayer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(44, 231);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(140, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "PLAYER NAME";
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.AutoSize = true;
            this.lblShirtNumber.BackColor = System.Drawing.Color.Black;
            this.lblShirtNumber.Font = new System.Drawing.Font("Microsoft Tai Le", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShirtNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblShirtNumber.Location = new System.Drawing.Point(73, 105);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(83, 61);
            this.lblShirtNumber.TabIndex = 5;
            this.lblShirtNumber.Text = "12";
            // 
            // pbCaptain
            // 
            this.pbCaptain.Image = global::SoccerScore_TEST_GUI.Images.captain;
            this.pbCaptain.Location = new System.Drawing.Point(98, 6);
            this.pbCaptain.Name = "pbCaptain";
            this.pbCaptain.Size = new System.Drawing.Size(30, 30);
            this.pbCaptain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCaptain.TabIndex = 4;
            this.pbCaptain.TabStop = false;
            // 
            // pbFavourite
            // 
            this.pbFavourite.Image = global::SoccerScore_TEST_GUI.Images.favourite;
            this.pbFavourite.Location = new System.Drawing.Point(194, 6);
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.Size = new System.Drawing.Size(30, 30);
            this.pbFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFavourite.TabIndex = 3;
            this.pbFavourite.TabStop = false;
            // 
            // pbPLayer
            // 
            this.pbPLayer.Image = global::SoccerScore_TEST_GUI.Images.default_player_image;
            this.pbPLayer.Location = new System.Drawing.Point(3, 42);
            this.pbPLayer.Name = "pbPLayer";
            this.pbPLayer.Size = new System.Drawing.Size(221, 182);
            this.pbPLayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPLayer.TabIndex = 2;
            this.pbPLayer.TabStop = false;
            // 
            // PlayerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblShirtNumber);
            this.Controls.Add(this.pbCaptain);
            this.Controls.Add(this.pbFavourite);
            this.Controls.Add(this.pbPLayer);
            this.Controls.Add(this.lblName);
            this.Name = "PlayerView";
            this.Size = new System.Drawing.Size(228, 270);
            this.Load += new System.EventHandler(this.PlayerView_Load);
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
    }
}
