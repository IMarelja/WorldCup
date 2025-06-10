using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Models;
using WorldCupWPF.Utilities;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void StartWindow_Load(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void gbResolution_Loaded(object sender, RoutedEventArgs e)
        {
            FormAutomization.CreateRadioButtonsFromSettingsOptionDescriptionEnum<Resolution>(gbResolution);
        }

        private void gbLanguage_Loaded(object sender, RoutedEventArgs e)
        {
            FormAutomization.CreateRadioButtonsFromSettingsOptionLanguageEnum(gbLanguage);
        }

        private void gbGender_Loaded(object sender, RoutedEventArgs e)
        {
            FormAutomization.CreateRadioButtonsFromSettingsOptionEnum<Gender>(gbGender);
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedGender = FormAutomization.GetSelectedRadioButton(gbGender).Name;
                string selectedLanguage = FormAutomization.GetSelectedRadioButton(gbLanguage).Tag.ToString();
                string selectedResolution = FormAutomization.GetSelectedRadioButton(gbResolution).Tag.ToString();

                Settings.SaveGenderSetting(selectedGender);
                Settings.SaveLanguageSettings(selectedLanguage);
                Settings.SaveResolutionSetting(selectedResolution);

                this.Hide();
                Window worldCup = new MainWindow();
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
