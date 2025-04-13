using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WorldCup
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save current choice? If yes the application will restart", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                string selectedGender = FormAutomization.GetSelectedRadioButton(gbGender).Text;
                string selectedLanguage = FormAutomization.GetSelectedRadioButton(gbLanguage).Text;


                Settings.SaveSettings(new Dictionary<SettingsOptions, string> {
                                                                                { SettingsOptions.Gender, selectedGender },
                                                                                { SettingsOptions.Language, selectedLanguage }
                });

                Application.Restart();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

            FormAutomization.CreateRadioButtonsFromSettingsOptionEnum<Gender>(gbGender);
            FormAutomization.CreateRadioButtonsFromSettingsOptionEnum<Language>(gbLanguage);

            FormAutomization.SetDefaultRadioButtonForGroupBox(gbGender, SettingsOptions.Gender);
            FormAutomization.SetDefaultRadioButtonForGroupBox(gbLanguage, SettingsOptions.Language);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
