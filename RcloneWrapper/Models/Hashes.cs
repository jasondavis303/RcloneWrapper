using System.Text.Json.Serialization;

namespace RcloneWrapper.Models
{
    public class Hashes
    {
        [JsonPropertyName("SHA-1")]
        public string Sha1 { get; set; }

        public string MD5 { get; set; }

        public string DropboxHash { get; set; }
    }
}
