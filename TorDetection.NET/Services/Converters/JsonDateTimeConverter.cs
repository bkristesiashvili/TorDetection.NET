using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TorDetection.Services.Converters
{
    public sealed class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        #region PUBLIC OVERRIDE METHODS

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateString = reader.GetString();

            DateTime.TryParse(dateString, out var date);

            return date;
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }

        #endregion
    }
}
