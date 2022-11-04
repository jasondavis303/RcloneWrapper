using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// seafile
    /// </summary>
    [FlagPrefix("seafile")]
    public class Seafile_OptionsBuilder : Base_OptionsBuilder
    {
        public static class Urls
        {
            public const string Default = "https://cloud.seafile.com/";

        }


        /// <summary>
        /// Two-factor authentication (&#39;true&#39; if the account has 2FA enabled)
        /// </summary>
        [BoolFlag("2fa")]
        public bool TwoFA { get; set; }


        /// <summary>
        /// Should rclone create a library if it doesn&#39;t exist
        /// </summary>
        [BoolFlag("create-library")]
        public bool CreateLibrary { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,DoubleQuote,BackSlash,Ctl,InvalidUtf8)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.DoubleQuote | EncodingFlags.BackSlash | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Name of the library
        /// </summary>
        [StringFlag("library")]
        public string Library { get; set; }


        /// <summary>
        /// Library password (for encrypted libraries only) (obscured)
        /// </summary>
        [StringFlag("library-key")]
        public string LibraryKey { get; set; }


        /// <summary>
        /// Password (obscured)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }


        /// <summary>
        /// URL of seafile host to connect to
        /// </summary>
        [StringFlag("url", "https://cloud.seafile.com/")]
        public string Url { get; set; }


        /// <summary>
        /// User name (usually email address)
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
