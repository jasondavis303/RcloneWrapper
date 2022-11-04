using RcloneWrapper.JsonConverters;
using System;
using System.Text.Json.Serialization;

namespace RcloneWrapper.Models
{
    public class RemoteObject
    {
        public Hashes Hashes { get; set; }

        public string ID { get; set; }

        public string OrigID { get; set; }

        public bool IsBucket { get; set; }

        public bool IsDir { get; set; }

        public string MimeType { get; set; }

        [JsonConverter(typeof(DefaultValueConverter<DateTime>))]
        public DateTime ModTime { get; set; }

        public string Name { get; set; }

        public string Encrypted { get; set; }

        public string EncryptedPath { get; set; }

        public string Path { get; set; }

        public long Size { get; set; }

        public string Tier { get; set; }
    }
}
