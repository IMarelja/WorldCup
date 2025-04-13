namespace WorldCup
{
    partial class SettingsForm
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
            gbGender = new GroupBox();
            gbLanguage = new GroupBox();
            btnApply = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // gbGender
            // 
            gbGender.Location = new Point(17, 20);
            gbGender.Margin = new Padding(4, 5, 4, 5);
            gbGender.Name = "gbGender";
            gbGender.Padding = new Padding(4, 5, 4, 5);
            gbGender.Size = new Size(317, 161);
            gbGender.TabIndex = 15;
            gbGender.TabStop = false;
            gbGender.Text = "Gender";
            // 
            // gbLanguage
            // 
            gbLanguage.Location = new Point(13, 191);
            gbLanguage.Margin = new Padding(4, 5, 4, 5);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Padding = new Padding(4, 5, 4, 5);
            gbLanguage.Size = new Size(317, 171);
            gbLanguage.TabIndex = 14;
            gbLanguage.TabStop = false;
            gbLanguage.Text = "Language";
            // 
            // btnApply
            // 
            btnApply.Location = new Point(117, 372);
            btnApply.Margin = new Padding(4, 5, 4, 5);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(107, 38);
            btnApply.TabIndex = 16;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(241, 372);
            btnExit.Margin = new Padding(4, 5, 4, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(107, 38);
            btnExit.TabIndex = 17;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(361, 424);
            Controls.Add(btnExit);
            Controls.Add(btnApply);
            Controls.Add(gbGender);
            Controls.Add(gbLanguage);
            Margin = new Padding(4, 5, 4, 5);
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbGender;
        private GroupBox gbLanguage;
        private Button btnApply;
        private Button btnExit;
    }
}