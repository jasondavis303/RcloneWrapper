using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Hadoop distributed file system
    /// </summary>
    [FlagPrefix("hdfs")]
    public class HDFS_OptionsBuilder : Base_OptionsBuilder
    {
        public enum DataTransferProtections
        {
            /// <summary>
            /// Ensure authentication, integrity and encryption enabled.
            /// </summary>
            [Description("privacy")]
            Privacy,

            [Description("authentication")]
            Authentication,

            [Description("integrity")]
            Integrity,

        }


        /// <summary>
        /// Kerberos data transfer protection: authentication|integrity|privacy
        /// </summary>
        [SingleEnumFlag("data-transfer-protection", (int)DataTransferProtections.Privacy)]
        public DataTransferProtections? DataTransferProtection { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,Colon,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Colon | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Hadoop name node and port
        /// </summary>
        [StringFlag("namenode")]
        public string Namenode { get; set; }


        /// <summary>
        /// Kerberos service principal name for the namenode
        /// </summary>
        [StringFlag("service-principal-name")]
        public string ServicePrincipalName { get; set; }


        /// <summary>
        /// Hadoop user name
        /// </summary>
        [StringFlag("username")]
        public string Username { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
