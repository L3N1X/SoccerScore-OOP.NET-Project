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
            this.playersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // playersContainer
            // 
            this.playersContainer.AutoScroll = true;
            this.playersContainer.Location = new System.Drawing.Point(12, 122);
            this.playersContainer.Name = "playersContainer";
            this.playersContainer.Size = new System.Drawing.Size(1160, 305);
            this.playersContainer.TabIndex = 0;
            this.playersContainer.WrapContents = false;
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::SoccerScore_TEST_GUI.Images.loading;
            this.pbLoading.Location = new System.Drawing.Point(1072, 661);
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
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.playersContainer);
            this.Name = "DefaultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soccer Score - Leon Krušlin";
            this.Load += new System.EventHandler(this.DefaultForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel playersContainer;
        private System.Windows.Forms.PictureBox pbLoading;
    }
}

