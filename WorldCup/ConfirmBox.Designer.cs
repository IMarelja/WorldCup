namespace WorldCup
{
    partial class ConfirmBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmBox));
            btnConfirm = new Button();
            btnCancel = new Button();
            lbAreYouSureYouWantApply = new Label();
            pbWarning = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbWarning).BeginInit();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(108, 53);
            btnConfirm.Margin = new Padding(2, 2, 2, 2);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(78, 20);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(191, 53);
            btnCancel.Margin = new Padding(2, 2, 2, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(78, 20);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lbAreYouSureYouWantApply
            // 
            lbAreYouSureYouWantApply.AutoSize = true;
            lbAreYouSureYouWantApply.Location = new Point(49, 20);
            lbAreYouSureYouWantApply.Margin = new Padding(2, 0, 2, 0);
            lbAreYouSureYouWantApply.Name = "lbAreYouSureYouWantApply";
            lbAreYouSureYouWantApply.Size = new Size(176, 15);
            lbAreYouSureYouWantApply.TabIndex = 2;
            lbAreYouSureYouWantApply.Text = "Are you sure you want to apply?";
            // 
            // pbWarning
            // 
            pbWarning.Image = (Image)resources.GetObject("pbWarning.Image");
            pbWarning.Location = new Point(8, 7);
            pbWarning.Margin = new Padding(2, 2, 2, 2);
            pbWarning.Name = "pbWarning";
            pbWarning.Size = new Size(36, 33);
            pbWarning.TabIndex = 3;
            pbWarning.TabStop = false;
            // 
            // ConfirmBox
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(278, 81);
            Controls.Add(pbWarning);
            Controls.Add(lbAreYouSureYouWantApply);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Margin = new Padding(2, 2, 2, 2);
            Name = "ConfirmBox";
            Text = "Warning";
            Load += ConfirmBox_Load;
            ((System.ComponentModel.ISupportInitialize)pbWarning).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private Button btnCancel;
        private Label lbAreYouSureYouWantApply;
        private PictureBox pbWarning;
    }
}