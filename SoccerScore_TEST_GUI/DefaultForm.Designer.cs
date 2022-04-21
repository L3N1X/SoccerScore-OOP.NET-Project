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
            this.button1 = new System.Windows.Forms.Button();
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 401);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Favourite players";
            // 
            // favoruitePLayersContainer
            // 
            this.favoruitePLayersContainer.AutoScroll = true;
            this.favoruitePLayersContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.favoruitePLayersContainer.Location = new System.Drawing.Point(16, 425);
            this.favoruitePLayersContainer.Name = "favoruitePLayersContainer";
            this.favoruitePLayersContainer.Size = new System.Drawing.Size(599, 240);
            this.favoruitePLayersContainer.TabIndex = 1;
            this.favoruitePLayersContainer.Visible = false;
            this.favoruitePLayersContainer.WrapContents = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 724);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // DefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.favoruitePLayersContainer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playersContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DefaultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Soccer Score - Leon Krušlin";
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
        private System.Windows.Forms.Button button1;
    }
}

