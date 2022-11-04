using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RcloneWrapper.JsonConverters
{
    /*
        rclone lsjson --no-modtime will return empty strings for the modtime field,
        and the System.Text.JsonSerializer will throw an Exception. So this checks a
        value-type field, and for null or empty strings it will just set the default value

        Usage:

        class RemoteObject
        {
            [JsonConverter(typeof(DefaultValueConverter<DateTime>))]
            public DateTime ModTime { get; set; }
        }
    */
    internal class DefaultValueConverter<T> : JsonConverter<T> where T : struct
    {
        static readonly byte[] _emptyByteArray = Array.Empty<byte>();

        static readonly JsonSerializerOptions _numberHandlingOptions = new()
        {
            NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals
                             | JsonNumberHandling.AllowReadingFromString
        };

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default;

            if (reader.TokenType == JsonTokenType.String)
                if (reader.ValueTextEquals(_emptyByteArray))
                    return default;

            return JsonSerializer.Deserialize<T>(ref reader, _numberHandlingOptions);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) => JsonSerializer.Serialize(writer, value, options);
    }
}
