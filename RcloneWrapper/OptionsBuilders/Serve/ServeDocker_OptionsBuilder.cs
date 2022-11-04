using RcloneWrapper.OptionsBuilders.Attributes;

namespace RcloneWrapper.OptionsBuilders.Serve
{
    /// <summary>
    /// Serve any remote on docker's volume plugin API.
    /// </summary>
    public class ServeDocker_OptionsBuilder : VFS_OptionsBuilder
    {
        /// <summary>
        /// Base directory for volumes (default "/var/lib/docker-volumes/rclone")
        /// </summary>
        [StringFlag("base-dir", "/var/lib/docker-volumes/rclone")]
        public string BaseDir { get; set; }

        /// <summary>
        /// Address <host:port> or absolute path (default: /run/docker/plugins/rclone.sock)
        /// </summary>
        [StringFlag("socket-addr", "/run/docker/plugins/rclone.sock")]
        public string SocketAddr { get; set; }

        /// <summary>
        /// Skip restoring previous state
        /// </summary>
        [BoolFlag("forget-state")]
        public bool ForgetState { get; set; }

        /// <summary>
        /// Do not write spec file
        /// </summary>
        [BoolFlag("no-spec")]
        public bool NoSpec { get; set; }

        /// <summary>
        /// >GID for unix socket (default: current process GID) (default 1000)
        /// </summary>
        [IntFlag("socket-gid", int.MinValue, int.MaxValue, 1000)]
        public int? SocketGid { get; set; }



        public override string BuildArgs() => this.GetOptionsString();

        public override string ToString() => BuildArgs();
    }
}
