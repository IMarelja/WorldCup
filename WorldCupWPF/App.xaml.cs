using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using WorldCupWPF.Utilities;

namespace WorldCupWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Your initialization logic here
            // For example: load language settings, configuration files, etc.

            if (SettingsValidation())
            {
                Window settingsWindow = new StartWindow();
                settingsWindow.Show();
            }
            else
            {
                Window mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
        private static bool SettingsValidation()
        {
            try
            {
                string settingsFile = Path.Combine(HomePath.Value(), @"Settings\settings.xml");
                if (!File.Exists(settingsFile))
                {
                    File.Delete(settingsFile);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
    

}
