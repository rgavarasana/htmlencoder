using Newtonsoft.Json;
using System;
using System.Web;

namespace ravi.learn.web.htmlencoder.Infrastructure
{
    public class HtmlEncodeConvertor : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("Cannot read");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var valueAsString = value as string;
            writer.WriteValue(HttpUtility.HtmlEncode(valueAsString));
        }

        public override bool CanRead => false;
    }
}