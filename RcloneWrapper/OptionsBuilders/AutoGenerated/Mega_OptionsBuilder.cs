using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Mega
    /// </summary>
    [FlagPrefix("mega")]
    public class Mega_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Output more debug from Mega
        /// </summary>
        [BoolFlag("debug")]
        public bool Debug { get; set; }


        /// <summary>
        /// The encoding for the backend (default Slash,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Delete files permanently rather than putting them into the trash
        /// </summary>
        [BoolFlag("hard-delete")]
        public bool HardDelete { get; set; }


        /// <summary>
        /// Password (obscured)
        /// </summary>
        [StringFlag("pass")]
        public string Pass { get; set; }


        /// <summary>
        /// User name
        /// </summary>
        [StringFlag("user")]
        public string User { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
