using System.Windows.Forms;

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
            tbcWorldCup = new TabControl();
            tabPlayers = new TabPage();
            flpPlayers = new FlowLayoutPanel();
            flpFavoritePlayers = new FlowLayoutPanel();
            lbPlayers = new Label();
            lbFavoritePlayers = new Label();
            tabRanking = new TabPage();
            flpVisitorsMatchRanking = new FlowLayoutPanel();
            tcbPlayerRanking = new TabControl();
            tabGoalScore = new TabPage();
            flpGoalScored = new FlowLayoutPanel();
            tabYellowCards = new TabPage();
            flpYellowCards = new FlowLayoutPanel();
            lbPlayerRanking = new Label();
            lbMatchRanking = new Label();
            btnSettings = new Button();
            lbFavoriteTeam = new Label();
            tbcWorldCup.SuspendLayout();
            tabPlayers.SuspendLayout();
            tabRanking.SuspendLayout();
            tcbPlayerRanking.SuspendLayout();
            tabGoalScore.SuspendLayout();
            tabYellowCards.SuspendLayout();
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
            cbFavoriteTeam.SelectionChangeCommitted += cbFavoriteTeam_SelectedIndexChanged;
            // 
            // tbcWorldCup
            // 
            tbcWorldCup.Controls.Add(tabPlayers);
            tbcWorldCup.Controls.Add(tabRanking);
            tbcWorldCup.Location = new Point(17, 68);
            tbcWorldCup.Margin = new Padding(4, 5, 4, 5);
            tbcWorldCup.Name = "tbcWorldCup";
            tbcWorldCup.SelectedIndex = 0;
            tbcWorldCup.Size = new Size(1109, 662);
            tbcWorldCup.TabIndex = 1;
            // 
            // tabPlayers
            // 
            tabPlayers.Controls.Add(flpPlayers);
            tabPlayers.Controls.Add(flpFavoritePlayers);
            tabPlayers.Controls.Add(lbPlayers);
            tabPlayers.Controls.Add(lbFavoritePlayers);
            tabPlayers.Location = new Point(4, 34);
            tabPlayers.Margin = new Padding(4, 5, 4, 5);
            tabPlayers.Name = "tabPlayers";
            tabPlayers.Padding = new Padding(4, 5, 4, 5);
            tabPlayers.Size = new Size(1101, 624);
            tabPlayers.TabIndex = 0;
            tabPlayers.Text = "Players";
            tabPlayers.UseVisualStyleBackColor = true;
            // 
            // flpPlayers
            // 
            flpPlayers.AllowDrop = true;
            flpPlayers.AutoScroll = true;
            flpPlayers.BackColor = Color.Silver;
            flpPlayers.Location = new Point(576, 62);
            flpPlayers.Name = "flpPlayers";
            flpPlayers.Size = new Size(500, 558);
            flpPlayers.TabIndex = 5;
            flpPlayers.DragDrop += FlpPlayers_DragDrop;
            flpPlayers.DragEnter += FlpPlayers_DragEnter;
            // 
            // flpFavoritePlayers
            // 
            flpFavoritePlayers.AllowDrop = true;
            flpFavoritePlayers.AutoScroll = true;
            flpFavoritePlayers.BackColor = Color.Silver;
            flpFavoritePlayers.Location = new Point(14, 62);
            flpFavoritePlayers.Name = "flpFavoritePlayers";
            flpFavoritePlayers.Size = new Size(517, 553);
            flpFavoritePlayers.TabIndex = 4;
            flpFavoritePlayers.DragDrop += FlpFavoritePlayers_DragDrop;
            flpFavoritePlayers.DragEnter += FlpFavoritePlayers_DragEnter;
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
            // tabRanking
            // 
            tabRanking.Controls.Add(flpVisitorsMatchRanking);
            tabRanking.Controls.Add(tcbPlayerRanking);
            tabRanking.Controls.Add(lbPlayerRanking);
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
            // flpVisitorsMatchRanking
            // 
            flpVisitorsMatchRanking.BackColor = Color.Silver;
            flpVisitorsMatchRanking.Location = new Point(11, 65);
            flpVisitorsMatchRanking.Name = "flpVisitorsMatchRanking";
            flpVisitorsMatchRanking.Size = new Size(513, 537);
            flpVisitorsMatchRanking.TabIndex = 3;
            // 
            // tcbPlayerRanking
            // 
            tcbPlayerRanking.Controls.Add(tabGoalScore);
            tcbPlayerRanking.Controls.Add(tabYellowCards);
            tcbPlayerRanking.Location = new Point(546, 62);
            tcbPlayerRanking.Margin = new Padding(4, 5, 4, 5);
            tcbPlayerRanking.Name = "tcbPlayerRanking";
            tcbPlayerRanking.SelectedIndex = 0;
            tcbPlayerRanking.Size = new Size(543, 543);
            tcbPlayerRanking.TabIndex = 2;
            // 
            // tabGoalScore
            // 
            tabGoalScore.Controls.Add(flpGoalScored);
            tabGoalScore.Location = new Point(4, 34);
            tabGoalScore.Margin = new Padding(4, 5, 4, 5);
            tabGoalScore.Name = "tabGoalScore";
            tabGoalScore.Padding = new Padding(4, 5, 4, 5);
            tabGoalScore.Size = new Size(535, 505);
            tabGoalScore.TabIndex = 0;
            tabGoalScore.Text = "Goal scored";
            tabGoalScore.UseVisualStyleBackColor = true;
            // 
            // flpGoalScored
            // 
            flpGoalScored.BackColor = Color.Silver;
            flpGoalScored.Location = new Point(4, 3);
            flpGoalScored.Name = "flpGoalScored";
            flpGoalScored.Size = new Size(530, 500);
            flpGoalScored.TabIndex = 0;
            // 
            // tabYellowCards
            // 
            tabYellowCards.Controls.Add(flpYellowCards);
            tabYellowCards.Location = new Point(4, 34);
            tabYellowCards.Margin = new Padding(4, 5, 4, 5);
            tabYellowCards.Name = "tabYellowCards";
            tabYellowCards.Padding = new Padding(4, 5, 4, 5);
            tabYellowCards.Size = new Size(535, 505);
            tabYellowCards.TabIndex = 1;
            tabYellowCards.Text = "Yellow cards";
            tabYellowCards.UseVisualStyleBackColor = true;
            // 
            // flpYellowCards
            // 
            flpYellowCards.BackColor = Color.Silver;
            flpYellowCards.Location = new Point(4, 3);
            flpYellowCards.Name = "flpYellowCards";
            flpYellowCards.Size = new Size(529, 498);
            flpYellowCards.TabIndex = 0;
            // 
            // lbPlayerRanking
            // 
            lbPlayerRanking.AutoSize = true;
            lbPlayerRanking.Location = new Point(546, 32);
            lbPlayerRanking.Margin = new Padding(4, 0, 4, 0);
            lbPlayerRanking.Name = "lbPlayerRanking";
            lbPlayerRanking.Size = new Size(128, 25);
            lbPlayerRanking.TabIndex = 1;
            lbPlayerRanking.Text = "Player Ranking";
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
            Controls.Add(tbcWorldCup);
            Controls.Add(cbFavoriteTeam);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            Name = "WorldCup";
            Text = "WorldCup";
            Load += WorldCup_Load;
            tbcWorldCup.ResumeLayout(false);
            tabPlayers.ResumeLayout(false);
            tabPlayers.PerformLayout();
            tabRanking.ResumeLayout(false);
            tabRanking.PerformLayout();
            tcbPlayerRanking.ResumeLayout(false);
            tabGoalScore.ResumeLayout(false);
            tabYellowCards.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbFavoriteTeam;
        private TabControl tbcWorldCup;
        private TabPage tabPlayers;
        private Button btnSettings;
        private Label lbFavoritePlayers;
        private Label lbPlayers;
        private TabPage tabRanking;
        private Label lbPlayerRanking;
        private Label lbMatchRanking;
        private TabControl tcbPlayerRanking;
        private TabPage tabGoalScore;
        private TabPage tabYellowCards;
        private Label lbFavoriteTeam;
        private FlowLayoutPanel flpPlayers;
        private FlowLayoutPanel flpFavoritePlayers;
        private FlowLayoutPanel flpVisitorsMatchRanking;
        private FlowLayoutPanel flpGoalScored;
        private FlowLayoutPanel flpYellowCards;
    }
}