using System.Configuration;

namespace XML130.Libraries
{
    public class AppConfig
    {
        public static string GetValue(string key) => ConfigurationManager.AppSettings.Get(key);

        public static void SetValue(string key, string value)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetConnectionString(string name) => ConfigurationManager.ConnectionStrings[name].ConnectionString;

        public static void SetConnectionString(string conn, string name)
        {
            System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ((ConnectionStringsSection)configuration.GetSection("connectionStrings")).ConnectionStrings[name].ConnectionString = conn;
            configuration.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
