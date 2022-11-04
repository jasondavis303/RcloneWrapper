using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Compress a remote
    /// </summary>
    [FlagPrefix("compress")]
    public class Compress_OptionsBuilder : Base_OptionsBuilder
    {
        public static class Modes
        {
            public const string Gzip = "gzip";

        }


        /// <summary>
        /// GZIP compression level (-2 to 9) (default -1)
        /// </summary>
        [IntFlag("level", -1, -2, 9)]
        public int? Level { get; set; }


        /// <summary>
        /// Compression mode (default &quot;gzip&quot;)
        /// </summary>
        [StringFlag("mode", "gzip")]
        public string Mode { get; set; }


        /// <summary>
        /// Some remotes don&#39;t allow the upload of files with unknown size (default 20Mi)
        /// </summary>
        [SizeSuffixFlag("ram-cache-limit", "20M")]
        public SizeSuffix RamCacheLimit { get; set; }


        /// <summary>
        /// Remote to compress
        /// </summary>
        [StringFlag("remote")]
        public string Remote { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
