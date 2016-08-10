using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Model.Converts
{
   public class DecimalJsonConverter:JsonConverter
    {
       public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
       {
            var ts = (decimal)value;
            var tsString = XmlConvert.ToString(ts);
            serializer.Serialize(writer, tsString);
        }

       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
       {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var value = serializer.Deserialize<String>(reader);
            return XmlConvert.ToDecimal(value);
        }

       public override bool CanConvert(Type objectType)
       {
            return objectType == typeof(decimal) || objectType == typeof(decimal?);
        }
    }
}
