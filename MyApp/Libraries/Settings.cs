namespace XML130.Libraries
{
    public sealed class Settings
    {
        private static Settings defaultInstance = new Settings();

        public static Settings Default => Settings.defaultInstance;

        public string ConnectionString
        {
            get => EasyProperties.Settings.Default.BaseConnString;
            set => EasyProperties.Settings.Default["BaseConnString"] = (object)value;
        }
    }
}
