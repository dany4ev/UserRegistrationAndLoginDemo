using System.Configuration;

namespace UserRegistrationAndLoginDemo.Common.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetValue(string key) => ConfigurationManager.AppSettings[key];

        //public static string GetConnectionString(string key) => ConfigurationManager.ConnectionStrings[key].ConnectionString;
    }
}
