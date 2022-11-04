using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Yandex Disk
    /// </summary>
    [FlagPrefix("yandex")]
    public class Yandex_OptionsBuilder : OAuth_OptionsBuilder
    {
        /// <summary>
        /// The encoding for the backend (default Slash,Del,Ctl,InvalidUtf8,Dot)
        /// </summary>
        [MultiEnumFlag("encoding", (int)(EncodingFlags.Slash | EncodingFlags.Del | EncodingFlags.Ctl | EncodingFlags.InvalidUtf8 | EncodingFlags.Dot))]
        public EncodingFlags? Encoding { get; set; }


        /// <summary>
        /// Delete files permanently rather than putting them into the trash
        /// </summary>
        [BoolFlag("hard-delete")]
        public bool HardDelete { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
