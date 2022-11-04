using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Koofr, Digi Storage and other Koofr-compatible storage providers
    /// </summary>
    [FlagPrefix("koofr")]
    public class Koofr_OptionsBuilder : Base_OptionsBuilder
    {
        public enum Providers
        {
            /// <summary>
            /// Koofr, https://app.koofr.net/
            /// </summary>
            [Description("koofr")]
            Koofr,

            /// <summary>
            /// Digi Storage, https://storage.rcs-rds.ro/
            /// </summary>
            [Description("digistorage")]
            Digistorage,

            /// <summary>
            /// Any other Koofr API compatible storage service
            /// </summary>
            [Description("other")]
            Other,

        }


        /// <summary>
        /// The encoding for the backend (default Slash,BackSlash,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.BackSlash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// The Koofr API endpoint to use
        /// </summary>
        [StringFlag("endpoint")]
        public string Endpoint { get; set; }


        /// <summary>
        /// Mount ID of the mount to use
        /// </summary>
        [StringFlag("mountid")]
        public string Mountid { get; set; }


        /// <summary>
        /// Your password for rclone (generate one at https://app.koofr.net/app/admin/preferences/password) (obscured)
        /// </summary>
        [StringFlag("password")]
        public string Password { get; set; }


        /// <summary>
        /// Choose your storage provider
        /// </summary>
        [SingleEnumFlag("provider", (int)Providers.Koofr)]
        public Providers? Provider { get; set; }


        /// <summary>
        /// Does the backend support setting modification time (default true)
        /// </summary>
        [BoolFlag("setmtime", true)]
        public bool Setmtime { get; set; } = true;


        /// <summary>
        /// Your user name
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
