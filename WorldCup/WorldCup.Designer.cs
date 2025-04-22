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
            tbWorldCup = new TabControl();
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
            lbFavoriteTeam = new Label();
            tbWorldCup.SuspendLayout();
            tabPlayers.SuspendLayout();
            tabRanking.SuspendLayout();
            tabControl2.SuspendLayout();
            SuspendLayout();
            // 
            // cbFavoriteTeam
            // 
            cbFavoriteTeam.FormattingEnabled = true;
            cbFavoriteTeam.Location = new Point(156, 20);
            cbFavoriteTeam.Margin = new Padding(4, 5, 4, 5);
            cbFavoriteTeam.Name = "cbFavoriteTeam";
            cbFavoriteTeam.Size = new Size(263, 33);
            cbFavoriteTeam.TabIndex = 0;
            //cbFavoriteTeam.SelectedIndexChanged += cbFavoriteTeam_SelectedIndexChanged;
            cbFavoriteTeam.SelectionChangeCommitted += cbFavoriteTeam_SelectedIndexChanged;
            // 
            // tbWorldCup
            // 
            tbWorldCup.Controls.Add(tabPlayers);
            tbWorldCup.Controls.Add(tabRanking);
            tbWorldCup.Location = new Point(17, 68);
            tbWorldCup.Margin = new Padding(4, 5, 4, 5);
            tbWorldCup.Name = "tbWorldCup";
            tbWorldCup.SelectedIndex = 0;
            tbWorldCup.Size = new Size(1109, 662);
            tbWorldCup.TabIndex = 1;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(lbPlayers);
            tabPlayers.Controls.Add(lbFavoritePlayers);
            tabPlayers.Controls.Add(pnlPlayers);
            tabPlayers.Controls.Add(pnlFavoritePlayer);
            tabPlayers.Location = new Point(4, 34);
            tabPlayers.Margin = new Padding(4, 5, 4, 5);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Padding = new Padding(4, 5, 4, 5);
            tabPlayers.Size = new Size(1101, 624);
            tabPlayers.TabIndex = 0;
            tabPlayers.Text = "Players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // lbPlayers
            // 
            lbPlayers.AutoSize = true;
            lbPlayers.Location = new Point(576, 27);
            lbPlayers.Margin = new Padding(4, 0, 4, 0);
            lbPlayers.Name = "lbPlayers";
            lbPlayers.Size = new Size(67, 25);
            lbPlayers.TabIndex = 3;
            lbPlayers.Text = "Players";
            // 
            // lbFavoritePlayers
            // 
            lbFavoritePlayers.AutoSize = true;
            lbFavoritePlayers.Location = new Point(9, 27);
            lbFavoritePlayers.Margin = new Padding(4, 0, 4, 0);
            lbFavoritePlayers.Name = "lbFavoritePlayers";
            lbFavoritePlayers.Size = new Size(135, 25);
            lbFavoritePlayers.TabIndex = 2;
            lbFavoritePlayers.Text = "Favorite players";
            // 
            // pnlPlayers
            // 
            pnlPlayers.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayers.Location = new Point(576, 57);
            pnlPlayers.Margin = new Padding(4, 5, 4, 5);
            pnlPlayers.Name = "pnlPlayers";
            pnlPlayers.Size = new Size(512, 547);
            pnlPlayers.TabIndex = 1;
            // 
            // pnlFavoritePlayer
            // 
            pnlFavoritePlayer.BorderStyle = BorderStyle.FixedSingle;
            pnlFavoritePlayer.Location = new Point(9, 57);
            pnlFavoritePlayer.Margin = new Padding(4, 5, 4, 5);
            pnlFavoritePlayer.Name = "pnlFavoritePlayer";
            pnlFavoritePlayer.Size = new Size(525, 547);
            pnlFavoritePlayer.TabIndex = 0;
            // 
            // tabRanking
            // 
            tabRanking.Controls.Add(panel1);
            tabRanking.Controls.Add(tabControl2);
            tabRanking.Controls.Add(label2);
            tabRanking.Controls.Add(lbMatchRanking);
            tabRanking.Location = new Point(4, 34);
            tabRanking.Margin = new Padding(4, 5, 4, 5);
            tabRanking.Name = "tabRanking";
            tabRanking.Padding = new Padding(4, 5, 4, 5);
            tabRanking.Size = new Size(1101, 624);
            tabRanking.TabIndex = 1;
            tabRanking.Text = "Ranking";
            tabRanking.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Location = new Point(9, 62);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(499, 537);
            panel1.TabIndex = 3;
            // 
            // tabControl2
            // 
            tabControl2.Controls.Add(tabPage1);
            tabControl2.Controls.Add(tabPage2);
            tabControl2.Location = new Point(546, 62);
            tabControl2.Margin = new Padding(4, 5, 4, 5);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(543, 543);
            tabControl2.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(535, 505);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(535, 505);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(546, 32);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(128, 25);
            label2.TabIndex = 1;
            label2.Text = "Player Ranking";
            // 
            // lbMatchRanking
            // 
            lbMatchRanking.AutoSize = true;
            lbMatchRanking.Location = new Point(9, 32);
            lbMatchRanking.Margin = new Padding(4, 0, 4, 0);
            lbMatchRanking.Name = "lbMatchRanking";
            lbMatchRanking.Size = new Size(201, 25);
            lbMatchRanking.TabIndex = 0;
            lbMatchRanking.Text = "Match Ranking (visitors)";
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(1013, 20);
            btnSettings.Margin = new Padding(4, 5, 4, 5);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(107, 38);
            btnSettings.TabIndex = 2;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // lbFavoriteTeam
            // 
            lbFavoriteTeam.AutoSize = true;
            lbFavoriteTeam.Location = new Point(23, 27);
            lbFavoriteTeam.Margin = new Padding(4, 0, 4, 0);
            lbFavoriteTeam.Name = "lbFavoriteTeam";
            lbFavoriteTeam.Size = new Size(124, 25);
            lbFavoriteTeam.TabIndex = 3;
            lbFavoriteTeam.Text = "Favorite Team:";
            // 
            // WorldCup
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(lbFavoriteTeam);
            Controls.Add(btnSettings);
            Controls.Add(tbWorldCup);
            Controls.Add(cbFavoriteTeam);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            Name = "WorldCup";
            Text = "WorldCup";
            Load += WorldCup_Load;
            tbWorldCup.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabPlayers.PerformLayout();
            tabRanking.ResumeLayout(false);
            tabRanking.PerformLayout();
            tabControl2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbFavoriteTeam;
        private TabControl tbWorldCup;
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
        private Label lbFavoriteTeam;
    }
}