using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace SDLV1.Localization
{
    public class JsonStringLocatizer : IStringLocalizer
    {

        private readonly JsonSerializer _jsonSerializer = new JsonSerializer();


        public LocalizedString this[string name] 
        {
            get
            {
                var value = GetString(name);
                return new LocalizedString(name, value);
            }
        } 

        public LocalizedString this[string name, params object[] arguments] 
        {
            get
            {
                var actualValue = this[name];
                return !actualValue.ResourceNotFound
                    ? new LocalizedString(name, string.Format(actualValue.Value, arguments))
                    : actualValue;
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        private string GetString(string key)
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            var fullFilePath = Path.GetFullPath(filePath);
            if (File.Exists(fullFilePath))
            {
                var result = GetValueFromJson(key, fullFilePath);
                return result;
            }

            return string.Empty;

        }

        private string GetValueFromJson(string propertyName, string filePath)
        {
            if (string.IsNullOrEmpty(propertyName) || string.IsNullOrEmpty(filePath))
            {
                return string.Empty;
            }
            using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new StreamReader(fileStream);
            using JsonTextReader jsonTextReader = new JsonTextReader(streamReader);

            while (jsonTextReader.Read())
            {
                if (jsonTextReader.TokenType == JsonToken.PropertyName && jsonTextReader.Value as string == propertyName)
                {
                    jsonTextReader.Read();
                    return _jsonSerializer.Deserialize<string>(jsonTextReader);
                }
            }
            return string.Empty;
        }
    }
}
