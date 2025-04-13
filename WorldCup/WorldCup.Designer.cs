namespace WorldCup
{
    partial class WorldCup
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
            cbFavoriteTeam = new ComboBox();
            tabControl1 = new TabControl();
            tabPlayers = new TabPage();
            lbPlayers = new Label();
            lbFavoritePlayers = new Label();
            pnlPlayers = new Panel();
            pnlFavoritePlayer = new Panel();
            tabRanking = new TabPage();
            panel1 = new Panel();
            tabControl2 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            label2 = new Label();
            lbMatchRanking = new Label();
            btnSettings = new Button();
            tabControl1.SuspendLayout();
            tabPlayers.SuspendLayout();
            tabRanking.SuspendLayout();
            tabControl2.SuspendLayout();
            SuspendLayout();
            // 
            // cbFavoriteTeam
            // 
            cbFavoriteTeam.FormattingEnabled = true;
            cbFavoriteTeam.Items.AddRange(new object[] { "Choose Team" });
            cbFavoriteTeam.Location = new Point(12, 12);
            cbFavoriteTeam.Name = "cbFavoriteTeam";
            cbFavoriteTeam.Size = new Size(185, 23);
            cbFavoriteTeam.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPlayers);
            tabControl1.Controls.Add(tabRanking);
            tabControl1.Location = new Point(12, 41);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 397);
            tabControl1.TabIndex = 1;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(lbPlayers);
            tabPlayers.Controls.Add(lbFavoritePlayers);
            tabPlayers.Controls.Add(pnlPlayers);
            tabPlayers.Controls.Add(pnlFavoritePlayer);
            tabPlayers.Location = new Point(4, 24);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Padding = new Padding(3);
            tabPlayers.Size = new Size(768, 369);
            tabPlayers.TabIndex = 0;
            tabPlayers.Text = "Players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // lbPlayers
            // 
            lbPlayers.AutoSize = true;
            lbPlayers.Location = new Point(403, 16);
            lbPlayers.Name = "lbPlayers";
            lbPlayers.Size = new Size(44, 15);
            lbPlayers.TabIndex = 3;
            lbPlayers.Text = "Players";
            // 
            // lbFavoritePlayers
            // 
            lbFavoritePlayers.AutoSize = true;
            lbFavoritePlayers.Location = new Point(6, 16);
            lbFavoritePlayers.Name = "lbFavoritePlayers";
            lbFavoritePlayers.Size = new Size(89, 15);
            lbFavoritePlayers.TabIndex = 2;
            lbFavoritePlayers.Text = "Favorite players";
            // 
            // pnlPlayers
            // 
            pnlPlayers.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayers.Location = new Point(403, 34);
            pnlPlayers.Name = "pnlPlayers";
            pnlPlayers.Size = new Size(359, 329);
            pnlPlayers.TabIndex = 1;
            // 
            // pnlFavoritePlayer
            // 
            pnlFavoritePlayer.BorderStyle = BorderStyle.FixedSingle;
            pnlFavoritePlayer.Location = new Point(6, 34);
            pnlFavoritePlayer.Name = "pnlFavoritePlayer";
            pnlFavoritePlayer.Size = new Size(368, 329);
            pnlFavoritePlayer.TabIndex = 0;
            // 
            // tabRanking
            // 
            tabRanking.Controls.Add(panel1);
            tabRanking.Controls.Add(tabControl2);
            tabRanking.Controls.Add(label2);
            tabRanking.Controls.Add(lbMatchRanking);
            tabRanking.Location = new Point(4, 24);
            tabRanking.Name = "tabRanking";
            tabRanking.Padding = new Padding(3);
            tabRanking.Size = new Size(768, 369);
            tabRanking.TabIndex = 1;
            tabRanking.Text = "Ranking";
            tabRanking.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Location = new Point(6, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(349, 322);
            panel1.TabIndex = 3;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage1);
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Location = new Point(382, 37);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(380, 326);
            tabControl2.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(372, 298);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(372, 298);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(382, 19);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 1;
            label2.Text = "Player Ranking";
            // 
            // lbMatchRanking
            // 
            lbMatchRanking.AutoSize = true;
            lbMatchRanking.Location = new Point(6, 19);
            lbMatchRanking.Name = "lbMatchRanking";
            lbMatchRanking.Size = new Size(135, 15);
            lbMatchRanking.TabIndex = 0;
            lbMatchRanking.Text = "Match Ranking (visitors)";
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(709, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(75, 23);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // WorldCup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSettings);
            Controls.Add(tabControl1);
            Controls.Add(cbFavoriteTeam);
            Name = "WorldCup";
            Text = "WorldCup";
            Load += WorldCup_Load;
            tabControl1.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabPlayers.PerformLayout();
            tabRanking.ResumeLayout(false);
            tabRanking.PerformLayout();
            tabControl2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbFavoriteTeam;
        private TabControl tabControl1;
        private TabPage tabPlayers;
        private Button btnSettings;
        private Label lbFavoritePlayers;
        private Panel pnlPlayers;
        private Panel pnlFavoritePlayer;
        private Label lbPlayers;
        private TabPage tabRanking;
        private Label label2;
        private Label lbMatchRanking;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
    }
}