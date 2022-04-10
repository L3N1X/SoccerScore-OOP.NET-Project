
namespace RESTfulAPI
{
    partial class MainFormAsync
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
            this.ddlUsers = new System.Windows.Forms.ComboBox();
            this.btnShowProgress = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ddlUsers
            // 
            this.ddlUsers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ddlUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlUsers.FormattingEnabled = true;
            this.ddlUsers.Location = new System.Drawing.Point(12, 12);
            this.ddlUsers.Name = "ddlUsers";
            this.ddlUsers.Size = new System.Drawing.Size(460, 21);
            this.ddlUsers.TabIndex = 0;
            // 
            // btnShowProgress
            // 
            this.btnShowProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowProgress.Location = new System.Drawing.Point(191, 48);
            this.btnShowProgress.Name = "btnShowProgress";
            this.btnShowProgress.Size = new System.Drawing.Size(100, 50);
            this.btnShowProgress.TabIndex = 1;
            this.btnShowProgress.Text = "Show progress";
            this.btnShowProgress.UseVisualStyleBackColor = true;
            this.btnShowProgress.Click += new System.EventHandler(this.btnShowProgress_Click);
            // 
            // MainFormAsync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 110);
            this.Controls.Add(this.btnShowProgress);
            this.Controls.Add(this.ddlUsers);
            this.Name = "MainFormAsync";
            this.Text = "Main Form Async";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlUsers;
        private System.Windows.Forms.Button btnShowProgress;
    }
}

