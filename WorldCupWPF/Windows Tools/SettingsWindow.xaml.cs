using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using WorldCupWPF.Windows_Tools;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void gbResolution_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void gbLanguage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void gbGender_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool? result = ConfirmBox.ShowDialogBox();

                if (result == true)
                {
                    string selectedGender = FormAutomization.GetSelectedRadioButton(gbGender).Name;
                    string selectedLanguage = FormAutomization.GetSelectedRadioButton(gbLanguage).Tag.ToString();
                    string selectedResolution = FormAutomization.GetSelectedRadioButton(gbResolution).Tag.ToString();

                    Settings.SaveGenderSetting(selectedGender);
                    Settings.SaveLanguageSettings(selectedLanguage);
                    Settings.SaveResolutionSetting(selectedResolution);

                    // Restart the application
                    string appPath = Process.GetCurrentProcess().MainModule.FileName;
                    Process.Start(appPath);
                    Application.Current.Shutdown();
                }
            
            }
            catch (Exception ex)
            {
                File.Delete(Settings.settingsFilePath);
                MessageBox.Show($"{ex}");
            }
        }

        private void windowSettings_Loaded(object sender, RoutedEventArgs e)
        {
            FormAutomization.ApplyLanguage(this, Settings.LoadLanguageTagSetting());

            FormAutomization.CreateRadioButtonsFromSettingsOptionDescriptionEnum<Resolution>(gbResolution);
            FormAutomization.SetDefaultRadioButtonForDescriptionEnumGroupBox(gbResolution, Settings.LoadResolutionDescriptionSetting());

            FormAutomization.CreateRadioButtonsFromSettingsOptionLanguageEnum(gbLanguage);
            FormAutomization.SetDefaultRadioButtonForLanguageGroupBox(gbLanguage, Settings.LoadLanguageDescriptionSetting());

            FormAutomization.CreateRadioButtonsFromSettingsOptionEnum<Gender>(gbGender);
            FormAutomization.SetDefaultRadioButtonForGroupBox(gbGender, Settings.LoadGenderTagSetting().ToString());
        }
    }
}
