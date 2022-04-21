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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitializeForm));
            this.btnConfirm = new System.Windows.Forms.Button();
            this.cbNationalTeams = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbInitialize = new System.Windows.Forms.GroupBox();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.gbInitialize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(52, 393);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(198, 43);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "Select";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbNationalTeams
            // 
            this.cbNationalTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNationalTeams.Enabled = false;
            this.cbNationalTeams.FormattingEnabled = true;
            this.cbNationalTeams.Location = new System.Drawing.Point(108, 202);
            this.cbNationalTeams.Name = "cbNationalTeams";
            this.cbNationalTeams.Size = new System.Drawing.Size(73, 21);
            this.cbNationalTeams.TabIndex = 1;
            this.cbNationalTeams.SelectedIndexChanged += new System.EventHandler(this.cbNationalTeams_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "National Team";
            // 
            // gbInitialize
            // 
            this.gbInitialize.Controls.Add(this.pbLoading);
            this.gbInitialize.Controls.Add(this.lblName);
            this.gbInitialize.Controls.Add(this.lblTitle);
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
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::SoccerScore_TEST_GUI.Images.loading;
            this.pbLoading.Location = new System.Drawing.Point(96, 249);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(111, 101);
            this.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLoading.TabIndex = 8;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(106, 459);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(102, 9);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "OOP.NET Leon Kruslin 2022";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(72, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(159, 29);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Soccer Score";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 337);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 5;
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
            // InitializeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 495);
            this.Controls.Add(this.gbInitialize);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(343, 534);
            this.MinimumSize = new System.Drawing.Size(343, 534);
            this.Name = "InitializeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Soccer Score Setup";
            this.Load += new System.EventHandler(this.InitializeForm_Load);
            this.gbInitialize.ResumeLayout(false);
            this.gbInitialize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
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
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbLoading;
    }
}