using RcloneWrapper.OptionsBuilders.Attributes;
using RcloneWrapper.OptionsBuilders.BaseClasses;
using System;
using System.Collections.Generic;

namespace RcloneWrapper.OptionsBuilders
{
    /// <summary>
    /// Better checksums for other remotes
    /// </summary>
    [FlagPrefix("hasher")]
    public class Hasher_OptionsBuilder : Base_OptionsBuilder
    {
        /// <summary>
        /// Auto-update checksum for files smaller than this size (disabled by default)
        /// </summary>
        [SizeSuffixFlag("auto-size", "0")]
        public SizeSuffix AutoSize { get; set; }


        /// <summary>
        /// Comma separated list of supported checksum types (default md5,sha1)
        /// </summary>
        [CommaSeparatedListFlag("hashes")]
        public List<string> Hashes { get; set; } = new();


        /// <summary>
        /// Maximum time to keep checksums in cache (0 = no cache, off = cache forever) (default off)
        /// </summary>
        [TimeSpanFlag("max-age")]
        public TimeSpan? MaxAge { get; set; }


        /// <summary>
        /// Remote to cache checksums for (e.g. myRemote:path)
        /// </summary>
        [StringFlag("remote")]
        public string Remote { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
