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
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.favoruitePLayersContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearAllAndExit = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // playersContainer
            // 
            this.playersContainer.AutoScroll = true;
            this.playersContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playersContainer.Location = new System.Drawing.Point(12, 122);
            this.playersContainer.Name = "playersContainer";
            this.playersContainer.Size = new System.Drawing.Size(1160, 240);
            this.playersContainer.TabIndex = 0;
            this.playersContainer.Visible = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 98);
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
            this.label2.Location = new System.Drawing.Point(528, 401);
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
            this.favoruitePLayersContainer.Location = new System.Drawing.Point(293, 425);
            this.favoruitePLayersContainer.Name = "favoruitePLayersContainer";
            this.favoruitePLayersContainer.Size = new System.Drawing.Size(599, 240);
            this.favoruitePLayersContainer.TabIndex = 1;
            this.favoruitePLayersContainer.Visible = false;
            this.favoruitePLayersContainer.WrapContents = false;
            // 
            // btnClearAllAndExit
            // 
            this.btnClearAllAndExit.Location = new System.Drawing.Point(501, 690);
            this.btnClearAllAndExit.Name = "btnClearAllAndExit";
            this.btnClearAllAndExit.Size = new System.Drawing.Size(182, 50);
            this.btnClearAllAndExit.TabIndex = 4;
            this.btnClearAllAndExit.Text = "Clear all and exit";
            this.btnClearAllAndExit.UseVisualStyleBackColor = true;
            this.btnClearAllAndExit.Click += new System.EventHandler(this.btnClearAllAndExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(538, 60);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(109, 34);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Country";
            this.lblTitle.Visible = false;
            // 
            // DefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnClearAllAndExit);
            this.Controls.Add(this.favoruitePLayersContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playersContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "DefaultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soccer Score BETA";
            this.Load += new System.EventHandler(this.DefaultForm_Load);
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
    }
}

