namespace SoccerScore_TEST_GUI
{
    partial class ExitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExitForm));
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblExit = new System.Windows.Forms.Label();
            this.pbExitIcon = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExitIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYes
            // 
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(62, 127);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(69, 23);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // btnNo
            // 
            this.btnNo.BackColor = System.Drawing.SystemColors.Window;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(137, 127);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(69, 23);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbExitIcon);
            this.groupBox1.Controls.Add(this.lblExit);
            this.groupBox1.Controls.Add(this.btnNo);
            this.groupBox1.Controls.Add(this.btnYes);
            this.groupBox1.Location = new System.Drawing.Point(12, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 168);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.Font = new System.Drawing.Font("Microsoft Tai Le", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.Location = new System.Drawing.Point(30, 25);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(208, 19);
            this.lblExit.TabIndex = 2;
            this.lblExit.Text = "Are you sure you want to exit?";
            // 
            // pbExitIcon
            // 
            this.pbExitIcon.Image = global::SoccerScore_TEST_GUI.Images.ball;
            this.pbExitIcon.Location = new System.Drawing.Point(62, 47);
            this.pbExitIcon.Name = "pbExitIcon";
            this.pbExitIcon.Size = new System.Drawing.Size(144, 74);
            this.pbExitIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbExitIcon.TabIndex = 3;
            this.pbExitIcon.TabStop = false;
            // 
            // ExitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(292, 177);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Soccer Score";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbExitIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbExitIcon;
        private System.Windows.Forms.Label lblExit;
    }
}