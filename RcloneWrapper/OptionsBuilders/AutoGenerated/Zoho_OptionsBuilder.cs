using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System.ComponentModel;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Zoho
    /// </summary>
    [FlagPrefix("zoho")]
    public class Zoho_OptionsBuilder : OAuth_OptionsBuilder
    {
        public enum Regions
        {
            /// <summary>
            /// United states / Global
            /// </summary>
            [Description("com")]
            Com,

            /// <summary>
            /// Europe
            /// </summary>
            [Description("eu")]
            Eu,

            /// <summary>
            /// India
            /// </summary>
            [Description("in")]
            In,

            /// <summary>
            /// Japan
            /// </summary>
            [Description("jp")]
            Jp,

            /// <summary>
            /// China
            /// </summary>
            [Description("com.cn")]
            Com_Cn,

            /// <summary>
            /// Australia
            /// </summary>
            [Description("com.au")]
            Com_Au,

        }


        /// <summary>
        /// The encoding for the backend (default Del,Ctl,InvalidUtf8)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Zoho region to connect to
        /// </summary>
        [SingleEnumFlag("region", (int)Regions.Com)]
        public Regions? Region { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
