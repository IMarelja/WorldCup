namespace WorldCup
{
    partial class PlayerInfo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbPlayerPicture = new PictureBox();
            btnSelectImage = new Button();
            lbName = new Label();
            lbShirtNumber = new Label();
            lbCaptain = new Label();
            pbStar = new PictureBox();
            lbPosition = new Label();
            cmsPlayerInfo = new ContextMenuStrip(components);
            tsmiFavoriteIt = new ToolStripMenuItem();
            tsmiRemoveFromFavorite = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pbPlayerPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbStar).BeginInit();
            cmsPlayerInfo.SuspendLayout();
            SuspendLayout();
            // 
            // pbPlayerPicture
            // 
            pbPlayerPicture.Location = new Point(3, 3);
            pbPlayerPicture.Name = "pbPlayerPicture";
            pbPlayerPicture.Size = new Size(100, 108);
            pbPlayerPicture.TabIndex = 0;
            pbPlayerPicture.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(3, 120);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(123, 43);
            btnSelectImage.TabIndex = 1;
            btnSelectImage.Text = "Select image";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(167, 14);
            lbName.Name = "lbName";
            lbName.Size = new Size(74, 25);
            lbName.TabIndex = 2;
            lbName.Text = "lbName";
            // 
            // lbShirtNumber
            // 
            lbShirtNumber.AutoSize = true;
            lbShirtNumber.Location = new Point(167, 49);
            lbShirtNumber.Name = "lbShirtNumber";
            lbShirtNumber.Size = new Size(128, 25);
            lbShirtNumber.TabIndex = 3;
            lbShirtNumber.Text = "lbShirtNumber";
            // 
            // lbCaptain
            // 
            lbCaptain.AutoSize = true;
            lbCaptain.ForeColor = Color.FromArgb(192, 192, 0);
            lbCaptain.Location = new Point(167, 134);
            lbCaptain.Name = "lbCaptain";
            lbCaptain.Size = new Size(72, 25);
            lbCaptain.TabIndex = 4;
            lbCaptain.Text = "Captain";
            // 
            // pbStar
            // 
            pbStar.Location = new Point(109, 3);
            pbStar.Name = "pbStar";
            pbStar.Size = new Size(52, 51);
            pbStar.TabIndex = 5;
            pbStar.TabStop = false;
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Location = new Point(167, 91);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(90, 25);
            lbPosition.TabIndex = 6;
            lbPosition.Text = "lbPosition";
            // 
            // cmsPlayerInfo
            // 
            cmsPlayerInfo.ImageScalingSize = new Size(24, 24);
            cmsPlayerInfo.Items.AddRange(new ToolStripItem[] { tsmiFavoriteIt, tsmiRemoveFromFavorite });
            cmsPlayerInfo.Name = "cmsPlayerInfo";
            cmsPlayerInfo.Size = new Size(260, 101);
            cmsPlayerInfo.Opening += cmsPlayerInfo_Opening;
            // 
            // tsmiFavoriteIt
            // 
            tsmiFavoriteIt.Name = "tsmiFavoriteIt";
            tsmiFavoriteIt.Size = new Size(259, 32);
            tsmiFavoriteIt.Text = "Favorite it";
            tsmiFavoriteIt.Click += tsmiFavoriteIt_Click;
            // 
            // tsmiRemoveFromFavorite
            // 
            tsmiRemoveFromFavorite.Name = "tsmiRemoveFromFavorite";
            tsmiRemoveFromFavorite.Size = new Size(259, 32);
            tsmiRemoveFromFavorite.Text = "Remove from Favorite";
            tsmiRemoveFromFavorite.Click += tsmiRemoveFromFavorite_Click;
            // 
            // PlayerInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            Controls.Add(lbPosition);
            Controls.Add(pbStar);
            Controls.Add(lbCaptain);
            Controls.Add(lbShirtNumber);
            Controls.Add(lbName);
            Controls.Add(btnSelectImage);
            Controls.Add(pbPlayerPicture);
            Name = "PlayerInfo";
            Size = new Size(407, 167);
            Load += PlayerInfo_Load;
            MouseDown += PlayerInfo_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pbPlayerPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbStar).EndInit();
            cmsPlayerInfo.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbPlayerPicture;
        private Button btnSelectImage;
        private Label lbName;
        private Label lbShirtNumber;
        private Label lbCaptain;
        private PictureBox pbStar;
        private Label lbPosition;
        private ContextMenuStrip cmsPlayerInfo;
        private ToolStripMenuItem tsmiFavoriteIt;
        private ToolStripMenuItem tsmiRemoveFromFavorite;
    }
}
