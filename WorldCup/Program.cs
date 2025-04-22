using WorldCup.Utilities;

namespace WorldCup
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Settings.Correction();

            
            if (!SettingsValidation())
            {
                Application.Run(new StartForm());
            }
            else
            {
                Application.Run(new WorldCup());
                
                
                
            }
        }

        private static bool SettingsValidation()
        {
            try
            {
                string settingsFile = Path.Combine(HomePath.Value(), @"Settings\settings.xml");

                return File.Exists(Settings.settingsFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}