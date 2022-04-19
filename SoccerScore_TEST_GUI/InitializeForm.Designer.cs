namespace SoccerScore_TEST_GUI
{
    partial class InitializeForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cbNationalTeams = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInitialize = new System.Windows.Forms.GroupBox();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.gbInitialize.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(86, 365);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(133, 43);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            // 
            // cbNationalTeams
            // 
            this.cbNationalTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNationalTeams.Enabled = false;
            this.cbNationalTeams.FormattingEnabled = true;
            this.cbNationalTeams.Location = new System.Drawing.Point(165, 193);
            this.cbNationalTeams.Name = "cbNationalTeams";
            this.cbNationalTeams.Size = new System.Drawing.Size(54, 21);
            this.cbNationalTeams.TabIndex = 1;
            this.cbNationalTeams.SelectedIndexChanged += new System.EventHandler(this.cbNationalTeams_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "National Team";
            // 
            // gbInitialize
            // 
            this.gbInitialize.Controls.Add(this.label2);
            this.gbInitialize.Controls.Add(this.rbFemale);
            this.gbInitialize.Controls.Add(this.rbMale);
            this.gbInitialize.Controls.Add(this.cbNationalTeams);
            this.gbInitialize.Controls.Add(this.btnConfirm);
            this.gbInitialize.Controls.Add(this.label1);
            this.gbInitialize.Location = new System.Drawing.Point(12, 12);
            this.gbInitialize.Name = "gbInitialize";
            this.gbInitialize.Size = new System.Drawing.Size(303, 471);
            this.gbInitialize.TabIndex = 3;
            this.gbInitialize.TabStop = false;
            this.gbInitialize.Enter += new System.EventHandler(this.gbInitialize_Enter);
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(86, 128);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(106, 17);
            this.rbMale.TabIndex = 3;
            this.rbMale.TabStop = true;
            this.rbMale.Tag = "Male";
            this.rbMale.Text = "Men\'s World-Cup";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.Click += new System.EventHandler(this.GenderButton_Click);
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(86, 95);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(122, 17);
            this.rbFemale.TabIndex = 4;
            this.rbFemale.TabStop = true;
            this.rbFemale.Tag = "Female";
            this.rbFemale.Text = "Women\'s World-Cup";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.Click += new System.EventHandler(this.GenderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
            // 
            // InitializeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 495);
            this.Controls.Add(this.gbInitialize);
            this.Name = "InitializeForm";
            this.Text = "InitializeForm";
            this.Load += new System.EventHandler(this.InitializeForm_Load);
            this.gbInitialize.ResumeLayout(false);
            this.gbInitialize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ComboBox cbNationalTeams;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbInitialize;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Label label2;
    }
}