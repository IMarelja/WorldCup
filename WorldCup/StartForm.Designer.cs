namespace WorldCup
{
    partial class StartForm
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
        /// 

        private void InitializeComponent()
        {
            btnApply = new Button();
            gbLanguage = new GroupBox();
            gbGender = new GroupBox();
            SuspendLayout();
            // 
            // btnApply
            // 
            btnApply.Font = new Font("Segoe UI", 10F);
            btnApply.Location = new Point(214, 395);
            btnApply.Margin = new Padding(4, 5, 4, 5);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(140, 44);
            btnApply.TabIndex = 4;
            btnApply.Text = "Apply";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // gbLanguage
            // 
            gbLanguage.Location = new Point(37, 207);
            gbLanguage.Margin = new Padding(4, 5, 4, 5);
            gbLanguage.Name = "gbLanguage";
            gbLanguage.Padding = new Padding(4, 5, 4, 5);
            gbLanguage.Size = new Size(317, 178);
            gbLanguage.TabIndex = 12;
            gbLanguage.TabStop = false;
            gbLanguage.Text = "Language";
            // 
            // gbGender
            // 
            gbGender.Location = new Point(37, 32);
            gbGender.Margin = new Padding(4, 5, 4, 5);
            gbGender.Name = "gbGender";
            gbGender.Padding = new Padding(4, 5, 4, 5);
            gbGender.Size = new Size(317, 165);
            gbGender.TabIndex = 12;
            gbGender.TabStop = false;
            gbGender.Text = "Gender";
            // 
            // StartForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 453);
            Controls.Add(gbGender);
            Controls.Add(gbLanguage);
            Controls.Add(btnApply);
            Margin = new Padding(4, 5, 4, 5);
            Name = "StartForm";
            Text = "Start settings";
            Load += StartForm_Load;
            ResumeLayout(false);
        }

        #endregion
        private Button btnApply;
        private GroupBox gbLanguage;
        private GroupBox gbGender;

        /*
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "StartForm";
        }
        */
    }
}