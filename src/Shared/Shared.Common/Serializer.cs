using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Shared.Common
{
    public class Serializer
    {
        private readonly Formatting _formatting;

        private readonly JsonSerializerSettings _settings;

        static Serializer()
        {
            Default = new Serializer(Formatting.None, new JsonSerializerSettings());
            Minimal = new Serializer(Formatting.None,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            View = new Serializer(Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

        internal Serializer(Formatting formatting, JsonSerializerSettings settings)
        {
            _formatting = formatting;
            _settings = settings;
        }

        public static Serializer Default { get; }

        public static Serializer View { get; }

        public static Serializer Minimal { get; }

        public T DeSerialize<T>(string s) where T : class, new()
        {
            return JsonConvert.DeserializeObject<T>(s, _settings);
        }

        public object DeSerialize(string s, Type type)
        {
            return JsonConvert.DeserializeObject(s, type, _settings);
        }

        public string Serialize<T>(T p) where T : class
        {
            return JsonConvert.SerializeObject(p, _formatting, _settings);
        }
    }
}
