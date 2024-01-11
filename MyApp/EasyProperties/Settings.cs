using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace XML130.EasyProperties
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = (Settings)SettingsBase.Synchronized((SettingsBase)new Settings());

        public static Settings Default
        {
            get
            {
                Settings defaultInstance = Settings.defaultInstance;
                return defaultInstance;
            }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("Data Source=.\\sqlexpress;Initial Catalog=Dev;User ID=sa;Password=1234$")]
        [DebuggerNonUserCode]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        public string BaseConnString => (string)this[nameof(BaseConnString)];
    }
}
