using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Pcloud
    /// </summary>
    [FlagPrefix("pcloud")]
    public class Pcloud_OptionsBuilder : OAuth_OptionsBuilder
    {
        public static class Hostnames
        {
            public const string Original_US_Region = "api.pcloud.com";

            public const string EU_Region = "eapi.pcloud.com";

        }


        /// <summary>
        /// The encoding for the backend (default Slash,BackSlash,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Hostname to connect to (default &quot;api.pcloud.com&quot;)
        /// </summary>
        [StringFlag("hostname", "api.pcloud.com")]
        public string Hostname { get; set; }


        /// <summary>
        /// Your pcloud password (obscured)
        /// </summary>
        [StringFlag("password")]
        public string Password { get; set; }


        /// <summary>
        /// Fill in for rclone to use a non root folder as its starting point (default &quot;d0&quot;)
        /// </summary>
        [StringFlag("root-folder-id", "d0")]
        public string RootFolderId { get; set; }


        /// <summary>
        /// Your pcloud username
        /// </summary>
        [StringFlag("username")]
        public string Username { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
