﻿namespace SoccerScore_TEST_GUI
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
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.lblShirtNumber = new System.Windows.Forms.Label();
            this.cmsOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToggleFavouriteOption = new System.Windows.Forms.ToolStripMenuItem();
            this.viewPlayerOption = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseImageOption = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPositon = new System.Windows.Forms.Label();
            this.pbCaptain = new System.Windows.Forms.PictureBox();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            this.pbPLayer = new System.Windows.Forms.PictureBox();
            this.cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCaptain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPLayer)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(39, 168);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(113, 19);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "PLAYER NAME";
            // 
            // lblShirtNumber
            // 
            this.lblShirtNumber.AutoSize = true;
            this.lblShirtNumber.BackColor = System.Drawing.Color.White;
            this.lblShirtNumber.Font = new System.Drawing.Font("Yu Gothic", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShirtNumber.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblShirtNumber.Location = new System.Drawing.Point(54, 71);
            this.lblShirtNumber.Name = "lblShirtNumber";
            this.lblShirtNumber.Size = new System.Drawing.Size(68, 52);
            this.lblShirtNumber.TabIndex = 5;
            this.lblShirtNumber.Text = "12";
            // 
            // cmsOptions
            // 
            this.cmsOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToggleFavouriteOption,
            this.viewPlayerOption,
            this.chooseImageOption});
            this.cmsOptions.Name = "cmsOptions";
            this.cmsOptions.Size = new System.Drawing.Size(160, 70);
            // 
            // ToggleFavouriteOption
            // 
            this.ToggleFavouriteOption.Name = "ToggleFavouriteOption";
            this.ToggleFavouriteOption.Size = new System.Drawing.Size(180, 22);
            this.ToggleFavouriteOption.Text = "Toggle favourite";
            this.ToggleFavouriteOption.Click += new System.EventHandler(this.ToggleFavoruiteOption_Click);
            // 
            // viewPlayerOption
            // 
            this.viewPlayerOption.Name = "viewPlayerOption";
            this.viewPlayerOption.Size = new System.Drawing.Size(180, 22);
            this.viewPlayerOption.Text = "View player";
            this.viewPlayerOption.Click += new System.EventHandler(this.ViewDetailsOption_Click);
            // 
            // chooseImageOption
            // 
            this.chooseImageOption.Name = "chooseImageOption";
            this.chooseImageOption.Size = new System.Drawing.Size(180, 22);
            this.chooseImageOption.Text = "Choose image";
            this.chooseImageOption.Click += new System.EventHandler(this.ChangeImageOption_Click);
            // 
            // lblPositon
            // 
            this.lblPositon.AutoSize = true;
            this.lblPositon.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPositon.Location = new System.Drawing.Point(58, 187);
            this.lblPositon.Name = "lblPositon";
            this.lblPositon.Size = new System.Drawing.Size(74, 19);
            this.lblPositon.TabIndex = 7;
            this.lblPositon.Text = "POSITION";
            // 
            // pbCaptain
            // 
            this.pbCaptain.Image = global::SoccerScore_TEST_GUI.Images.captain;
            this.pbCaptain.Location = new System.Drawing.Point(78, 0);
            this.pbCaptain.Name = "pbCaptain";
            this.pbCaptain.Size = new System.Drawing.Size(35, 29);
            this.pbCaptain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCaptain.TabIndex = 4;
            this.pbCaptain.TabStop = false;
            // 
            // pbFavourite
            // 
            this.pbFavourite.Image = global::SoccerScore_TEST_GUI.Images.favourite;
            this.pbFavourite.Location = new System.Drawing.Point(4, 3);
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.Size = new System.Drawing.Size(27, 26);
            this.pbFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFavourite.TabIndex = 3;
            this.pbFavourite.TabStop = false;
            // 
            // pbPLayer
            // 
            this.pbPLayer.Image = global::SoccerScore_TEST_GUI.Images.default_player_image;
            this.pbPLayer.Location = new System.Drawing.Point(4, 38);
            this.pbPLayer.Name = "pbPLayer";
            this.pbPLayer.Size = new System.Drawing.Size(181, 127);
            this.pbPLayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPLayer.TabIndex = 2;
            this.pbPLayer.TabStop = false;
            // 
            // PlayerView
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsOptions;
            this.Controls.Add(this.lblPositon);
            this.Controls.Add(this.lblShirtNumber);
            this.Controls.Add(this.pbCaptain);
            this.Controls.Add(this.pbFavourite);
            this.Controls.Add(this.pbPLayer);
            this.Controls.Add(this.lblName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "PlayerView";
            this.Size = new System.Drawing.Size(190, 207);
            this.Load += new System.EventHandler(this.PlayerView_Load);
            this.Click += new System.EventHandler(this.PlayerView_Click);
            this.cmsOptions.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsOptions;
        private System.Windows.Forms.ToolStripMenuItem ToggleFavouriteOption;
        private System.Windows.Forms.Label lblPositon;
        private System.Windows.Forms.ToolStripMenuItem viewPlayerOption;
        private System.Windows.Forms.ToolStripMenuItem chooseImageOption;
    }
}
