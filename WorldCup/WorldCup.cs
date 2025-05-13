using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCRepo.Model;
using WCRepo.Models;
using WCRepo.Repository;
using WorldCup.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WorldCup
{
    public partial class WorldCup : Form
    {
        private static readonly IRepository repository = RepositoryFactory.GetRepository();


        public WorldCup()
        {
            InitializeComponent();
        }

        private void WorldCup_Load(object sender, EventArgs e)
        {
            WallOfShame();
            FormAutomization.ApplyLanguage(this,Settings.LoadLanguageTagSetting());
            LoadCountriesIntoComboBox();
            LoadPlayersIntoFlowLayoutPanels();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void cbFavoriteTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
                if (cbFavoriteTeam.SelectedItem is Team selectedTeam)
                {
                    Settings.SaveFavoriteTeamSetting(selectedTeam);
                    this.Text = $"WorldCup - {selectedTeam.country} ({selectedTeam.fifa_code})";
                    LoadPlayersIntoFlowLayoutPanels();
                }
            }
            catch(Exception ex)
            {
                cbFavoriteTeam.SelectedIndex = -1;
            }
            
        }

        private void LoadCountriesIntoComboBox()
        {
            //suppressLoadEvents = true;
            try
            {
                cbFavoriteTeam.Items.Clear();

                foreach (Team team in repository.GetTeams(Settings.LoadGenderTagSetting()))
                {
                    cbFavoriteTeam.Items.Add(team);
                }

                if (Settings.LoadFavoriteTeamSetting() != null)
                {
                    foreach (Team item in cbFavoriteTeam.Items)
                    {
                        if (item.id == Settings.LoadFavoriteTeamSetting().id) { 
                            cbFavoriteTeam.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
            

        }
        private void LoadPlayersIntoFlowLayoutPanels()
        {
            flpFavoritePlayers.Controls.Clear();
            flpPlayers.Controls.Clear();

            if (Settings.LoadFavoriteTeamSetting() != null)
            {
                string MessagePlayer = "";

                foreach (Player player in repository.GetPlayers(Settings.LoadFavoriteTeamSetting().id, Settings.LoadGenderTagSetting()))
                {
                    PlayerInfo playerInfo = new PlayerInfo();

                    if (Settings.IsFavoritePlayerSetting(player))
                    {
                        player.favorite = true;
                    }
                    else
                    {
                        player.favorite = false;
                    }

                    playerInfo.SetPlayerInfo(player);
                    

                    if (player.favorite == false) {
                        
                        flpPlayers.Controls.Add(playerInfo);

                    }
                    if (player.favorite == true)
                    {

                        flpFavoritePlayers.Controls.Add(playerInfo);

                    }



                    MessagePlayer += $"ID: {player.id}, Name: {player.name}, Position: {player.position}, Shirt number: {player.shirt_number}, Captain: {player.captain}\n";
                }


                //MessageBox.Show(MessagePlayer);
            }
        }

        private void ApplyLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


        }

        private void FlpFavoritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerInfo)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FlpFavoritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            try {
                var playerControl = e.Data.GetData(typeof(PlayerInfo)) as PlayerInfo;
                if (playerControl != null)
                {
                    FlowLayoutPanel parentPanel = (FlowLayoutPanel)playerControl.Parent;
                    FlowLayoutPanel currentPanel = (FlowLayoutPanel)sender;

                    if (parentPanel == currentPanel) // self-drop check
                        return;

                    playerControl.BackColor = SystemColors.ButtonFace;
                    playerControl.SetPlayerInfoFavoriteStatus(true);

                    if (parentPanel != null)
                    {
                        // Add to new panel
                        currentPanel.Controls.Add(playerControl);
                        parentPanel.Controls.Remove(playerControl);
                        Settings.SaveFavoritePlayerSetting(playerControl.Tag as Player);
                    }

                    List<PlayerInfo> selectedControls = parentPanel.Controls
                    .OfType<PlayerInfo>()
                    .Where(p => p.selectStatusPlayerInfo && p != playerControl)
                    .ToList();

                    foreach (var selected in selectedControls)
                    {
                        selected.BackColor = SystemColors.ButtonFace;
                        selected.SetPlayerInfoFavoriteStatus(true);
                        currentPanel.Controls.Add(selected);
                        parentPanel.Controls.Remove(selected);
                        Settings.SaveFavoritePlayerSetting(selected.Tag as Player);
                    }

                }
            } catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FlpPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(PlayerInfo)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void FlpPlayers_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var playerControl = e.Data.GetData(typeof(PlayerInfo)) as PlayerInfo;
                if (playerControl != null)
                {
                    FlowLayoutPanel parentPanel = (FlowLayoutPanel)playerControl.Parent;
                    FlowLayoutPanel currentPanel = (FlowLayoutPanel)sender;

                    if (parentPanel == currentPanel) // self-drop check
                        return;

                    playerControl.BackColor = SystemColors.ButtonFace;
                    playerControl.SetPlayerInfoFavoriteStatus(false);

                    if (parentPanel != null)
                    {
                        // Add to new panel
                        currentPanel.Controls.Add(playerControl);
                        parentPanel.Controls.Remove(playerControl);
                        Settings.RemoveFavoritePlayerSettingByPlayer(playerControl.Tag as Player);
                    }

                    List<PlayerInfo> selectedControls = parentPanel.Controls
                    .OfType<PlayerInfo>()
                    .Where(p => p.selectStatusPlayerInfo && p != playerControl)
                    .ToList();

                    foreach (var selected in selectedControls)
                    {
                        selected.BackColor = SystemColors.ButtonFace;
                        selected.SetPlayerInfoFavoriteStatus(false);
                        currentPanel.Controls.Add(selected);
                        parentPanel.Controls.Remove(selected);
                        Settings.RemoveFavoritePlayerSettingByPlayer(selected.Tag as Player);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void WallOfShame()
        {
            lbPlayerRanking.Enabled = false;
            lbPlayerRanking.Visible = false;
            tcbPlayerRanking.Enabled = false;
            tcbPlayerRanking.Visible = false ;
        }
    }
}
