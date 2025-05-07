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
            FormAutomization.ApplyLanguage(this,Settings.LoadLanguageTagSetting());
            LoadCountriesIntoComboBox();
            LoadPlayersIntoPanel();
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
                    LoadPlayersIntoPanel();
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
        private void LoadPlayersIntoPanel()
        {

            if (Settings.LoadFavoriteTeamSetting() != null)
            {
                string MessagePlayer = "";
                foreach (Player player in repository.GetPlayers(Settings.LoadFavoriteTeamSetting().id, Settings.LoadGenderTagSetting()))
                {
                    MessagePlayer += $"ID: {player.id}, Name: {player.name}, Position: {player.position}, Shirt number: {player.shirt_number}\n";
                }
                MessageBox.Show(MessagePlayer);
            }
        }

        private void ApplyLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


        }
    }
}
