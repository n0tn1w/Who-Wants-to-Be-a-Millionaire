using GameApp.Services;

namespace GameApp
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

            var gameHelperService = new GameHelperService();

            // Instantiate your MainForm with the required service
            var mainForm = new MainForm(gameHelperService);

            Application.Run(mainForm);
        }
    }
}