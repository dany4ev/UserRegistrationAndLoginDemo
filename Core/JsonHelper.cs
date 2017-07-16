using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace UserRegistrationAndLoginDemo.Common.Helpers
{
    public static class JsonHelper
    {
        static readonly JsonSerializerSettings _jsonSettings;

        static JsonHelper()
        {
            _jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented, // for readability, change to None for compactness
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat
            };

            _jsonSettings.Converters.Add(new StringEnumConverter());
        }

        public static string Serialize(object value) => JsonConvert.SerializeObject(value, _jsonSettings);

        public static T Deserialize<T>(string value) => JsonConvert.DeserializeObject<T>(value, _jsonSettings);
    }
}
