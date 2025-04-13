using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace WorldCup
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

            FormAutomization.CreateRadioButtonsFromSettingsOptionEnum<Gender>(gbGender);
            FormAutomization.CreateRadioButtonsFromSettingsOptionEnum<Language>(gbLanguage);

            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedGender = FormAutomization.GetSelectedRadioButton(gbGender).Text;
                string selectedLanguage = FormAutomization.GetSelectedRadioButton(gbLanguage).Text;


                Settings.SaveSettings(new Dictionary<SettingsOptions, string> {
                                                                                { SettingsOptions.Gender, selectedGender },
                                                                                { SettingsOptions.Language, selectedLanguage }
                });

                this.Hide();
                var worldCup = new WorldCup();
                worldCup.Closed += (object_sender, EventArgs_e) => this.Close();
                worldCup.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
