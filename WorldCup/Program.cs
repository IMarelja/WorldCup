using Utilities;

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

            if (!Settings.FileValidation())
            {
                Application.Run(new StartForm());
            }
            else
            {
                Application.Run(new WorldCup());
                
            }
        }
    }
}