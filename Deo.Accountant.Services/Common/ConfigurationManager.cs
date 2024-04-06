namespace Deo.Accountant.Services.Common
{
    static class DeoConfigurationManager
    {
        public static IConfiguration? AppSetting
        {
            get;
        }
        static DeoConfigurationManager()
        {
            AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }
}
