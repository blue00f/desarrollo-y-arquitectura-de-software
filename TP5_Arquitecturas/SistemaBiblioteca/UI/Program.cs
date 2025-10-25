using dotenv.net;
namespace UI
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
            DotEnv.Load();
            string licencia = Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(licencia);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}