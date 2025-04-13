using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace WorldCup
{
    public partial class WorldCup : Form
    {
        public WorldCup()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Form settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void WorldCup_Load(object sender, EventArgs e)
        {
            //ApplyLanguage(Settings.LoadSetting(SettingsOptions.Language));

            try
            {
                // Read the JSON file
                string jsonString = null;

                // Deserialize the JSON string to a list of Team objects
                List<Country> teams = JsonSerializer.Deserialize<List<Country>>(jsonString);

                // Add all teams to the ComboBox
                foreach (Country team in teams)
                {
                    cbFavoriteTeam.Items.Add(team);
                }

                MessageBox.Show($"{cbFavoriteTeam.Items.Count}");

                // Optionally select the first item
                if (cbFavoriteTeam.Items.Count > 0)
                    cbFavoriteTeam.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading countries: " + ex.Message);
            }
        }

        private void ApplyLanguage(string language)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);


        }
    }
}
