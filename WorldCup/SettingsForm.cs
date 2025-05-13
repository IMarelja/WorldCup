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
using WCRepo.Model;
using WorldCup.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace WorldCup
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {
            FormAutomization.ApplyLanguage(this, Settings.LoadLanguageTagSetting());

            FormAutomization.CreateRadioButtonsFromSettingsOptionEnum<Gender>(gbGender);
            FormAutomization.CreateRadioButtonsFromSettingsOptionLanguageEnum(gbLanguage);

            FormAutomization.SetDefaultRadioButtonForGroupBox(gbGender, Settings.LoadGenderTagSetting().ToString());
            FormAutomization.SetDefaultRadioButtonForLanguageGroupBox(gbLanguage, Settings.LoadLanguageDescriptionSetting());

            
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Do you want to save current choice? If yes the application will restart", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Gender selectedGender = (Gender)FormAutomization.GetSelectedRadioButton(gbGender).Tag;
                String selectedLanguage = FormAutomization.GetSelectedRadioButton(gbLanguage).Text;

                Settings.SaveGenderSetting(selectedGender);
                Settings.SaveLanguageSettings(selectedLanguage);

                Application.Restart();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
