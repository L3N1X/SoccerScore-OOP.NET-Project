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
            this.lblLanguage = new System.Windows.Forms.Label();
            this.pbCroatian = new System.Windows.Forms.PictureBox();
            this.pbEnglish = new System.Windows.Forms.PictureBox();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.lblDataType = new System.Windows.Forms.Label();
            this.gbInitialize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCroatian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnglish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnConfirm, "btnConfirm");
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // cbNationalTeams
            // 
            this.cbNationalTeams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.cbNationalTeams, "cbNationalTeams");
            this.cbNationalTeams.FormattingEnabled = true;
            this.cbNationalTeams.Name = "cbNationalTeams";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // gbInitialize
            // 
            this.gbInitialize.Controls.Add(this.lblDataType);
            this.gbInitialize.Controls.Add(this.lblLanguage);
            this.gbInitialize.Controls.Add(this.pbCroatian);
            this.gbInitialize.Controls.Add(this.pbEnglish);
            this.gbInitialize.Controls.Add(this.pbLoading);
            this.gbInitialize.Controls.Add(this.lblName);
            this.gbInitialize.Controls.Add(this.lblTitle);
            this.gbInitialize.Controls.Add(this.label2);
            this.gbInitialize.Controls.Add(this.rbFemale);
            this.gbInitialize.Controls.Add(this.rbMale);
            this.gbInitialize.Controls.Add(this.cbNationalTeams);
            this.gbInitialize.Controls.Add(this.btnConfirm);
            this.gbInitialize.Controls.Add(this.label1);
            resources.ApplyResources(this.gbInitialize, "gbInitialize");
            this.gbInitialize.Name = "gbInitialize";
            this.gbInitialize.TabStop = false;
            // 
            // lblLanguage
            // 
            resources.ApplyResources(this.lblLanguage, "lblLanguage");
            this.lblLanguage.Name = "lblLanguage";
            // 
            // pbCroatian
            // 
            this.pbCroatian.Image = global::SoccerScore_TEST_GUI.Images.cro;
            resources.ApplyResources(this.pbCroatian, "pbCroatian");
            this.pbCroatian.Name = "pbCroatian";
            this.pbCroatian.TabStop = false;
            this.pbCroatian.Click += new System.EventHandler(this.pbCroatian_Click);
            // 
            // pbEnglish
            // 
            this.pbEnglish.Image = global::SoccerScore_TEST_GUI.Images.uk;
            resources.ApplyResources(this.pbEnglish, "pbEnglish");
            this.pbEnglish.Name = "pbEnglish";
            this.pbEnglish.TabStop = false;
            this.pbEnglish.Click += new System.EventHandler(this.pbEnglish_Click);
            // 
            // pbLoading
            // 
            this.pbLoading.Image = global::SoccerScore_TEST_GUI.Images.ball_loading;
            resources.ApplyResources(this.pbLoading, "pbLoading");
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.TabStop = false;
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Name = "lblName";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // rbFemale
            // 
            resources.ApplyResources(this.rbFemale, "rbFemale");
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.TabStop = true;
            this.rbFemale.Tag = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            this.rbFemale.Click += new System.EventHandler(this.GenderButton_Click);
            // 
            // rbMale
            // 
            resources.ApplyResources(this.rbMale, "rbMale");
            this.rbMale.Name = "rbMale";
            this.rbMale.TabStop = true;
            this.rbMale.Tag = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            this.rbMale.Click += new System.EventHandler(this.GenderButton_Click);
            // 
            // lblDataType
            // 
            resources.ApplyResources(this.lblDataType, "lblDataType");
            this.lblDataType.Name = "lblDataType";
            // 
            // InitializeForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbInitialize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InitializeForm";
            this.Load += new System.EventHandler(this.InitializeForm_Load);
            this.gbInitialize.ResumeLayout(false);
            this.gbInitialize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCroatian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnglish)).EndInit();
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
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.PictureBox pbCroatian;
        private System.Windows.Forms.PictureBox pbEnglish;
        private System.Windows.Forms.Label lblDataType;
    }
}