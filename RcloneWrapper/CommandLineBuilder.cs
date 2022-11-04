using RcloneWrapper.Enums;
using RcloneWrapper.OptionsBuilders;
using RcloneWrapper.OptionsBuilders.Serve;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RcloneWrapper
{
    public class CommandLineBuilder
    {
        private readonly string _command;

        private readonly List<string> _options = new();

        private CommandLineBuilder() { }


        internal CommandLineBuilder(params string[] commands)
        {
            _command = string.Join(' ', commands).Trim();
            if (string.IsNullOrWhiteSpace(_command))
                throw new ArgumentNullException(nameof(commands));
        }

        internal CommandLineBuilder(IEnumerable<string> commands) : this(commands.ToArray()) { }

        internal CommandLineBuilder(IOptionsBuilder options, params string[] commands) : this(commands)
        {
            if (options != null)
                AddOptions(options);
        }


        /// <summary>
        /// Build the full command line
        /// </summary>
        public string Build() => (_command + ' ' + string.Join(' ', _options)).Trim();

        public void ResetOptions() => _options.Clear();

        public void AddOptions(IOptionsBuilder options) => AddOption(options.GetOptionsString());

        public void AddOptions(params IOptionsBuilder[] options)
        {
            if (options != null)
                foreach (var option in options)
                    if (option != null)
                        AddOption(option.GetOptionsString());
        }

        public void AddOption(string option)
        {
            if (!string.IsNullOrWhiteSpace(option))
                _options.Add(option);
        }

        public void AddOptions(params string[] options)
        {
            foreach (var option in options)
                if (!string.IsNullOrWhiteSpace(option))
                    _options.Add(option);
        }

        public override string ToString() => Build();





        private static void AddOptionalArg(List<string> args, string flag, bool val, bool defaultVal = false)
        {
            if (val == defaultVal)
                return;

            if (val)
                args.Add($"--{flag}");
            else
                args.Add($"--{flag}=false");
        }

        private static void AddOptionalArg(List<string> args, string flag, string val)
        {
            if (!string.IsNullOrEmpty(val))
                args.Add($"--{flag} {val}");
        }

        private static void AddOptionalArg(List<string> args, string flag, int val, int exclude = 0)
        {
            if (val != exclude)
                args.Add($"--{flag} {val}");
        }

        private static void AddOptionalArg(List<string> args, string flag, uint? val, uint? exclude = 0)
        {
            if (val != null)
                if (val.Value != exclude)
                    args.Add($"--{flag} {val.Value}");
        }





        public static CommandLineBuilder Command(string command) => new(command);

        /// <summary>
        /// Prints quota information about a remote
        /// </summary>
        public static CommandLineBuilder About(string remote, bool full = false, bool json = false) => new("about", remote, full ? "--full" : null, json ? "--json" : null);

        /// <summary>
        /// Used to authorize a remote or headless rclone from a machine with a browser - use as instructed by rclone config.
        /// </summary>
        /// <param name="authNoOpenBrowser">Do not automatically open auth link in default browser</param>
        public static CommandLineBuilder Authorize(string remote, bool authNoOpenBrowser = false) => new("authorize", remote, authNoOpenBrowser ? "--auth-no-open-browser" : null);

        /// <summary>
        /// Run a backend-specific command.
        /// </summary>
        /// <param name="json">Always output in JSON format</param>
        public static CommandLineBuilder Backend(string remote, bool json = false) => new("backend", remote, json ? "--json" : null);

        /// <summary>
        /// Perform bidirectional synchronization between two paths.
        /// </summary>
        /// <param name="checkAccess">Ensure expected RCLONE_TEST files are found on both Path1 and Path2 filesystems, else abort.</param>
        /// <param name="checkFilename">Filename for --check-access (default: RCLONE_TEST)</param>
        /// <param name="checkSync">Controls comparison of final listings: true|false|only (default: true)</param>
        /// <param name="filtersFile">Read filtering patterns from a file</param>
        /// <param name="force">Bypass --max-delete safety check and run the sync. Consider using with --verbose</param>
        /// <param name="localTime">Use local time in listings (default: UTC)</param>
        /// <param name="noCleanup">Retain working files (useful for troubleshooting and testing).</param>
        /// <param name="removeEmptyDirs">Remove empty directories at the final cleanup step.</param>
        /// <param name="resync">Performs the resync run. Path1 files may overwrite Path2 versions. Consider using --verbose or --dry-run first.</param>
        /// <param name="workdir">Use custom working dir - useful for testing. (default: $HOME/.cache/rclone/bisync)</param>
        /// <returns></returns>
        public static CommandLineBuilder BiSync(string remotePath1, string remotePath2, bool checkAccess = false, string checkFilename = null,
                                                string checkSync = null, string filtersFile = null, bool force = false, bool localTime = false,
                                                bool noCleanup = false, bool removeEmptyDirs = false, bool resync = false, string workdir = null)
        {
            var lst = new List<string> { "bisync", remotePath1, remotePath2 };

            AddOptionalArg(lst, "check-access", checkAccess);
            AddOptionalArg(lst, "check-filename", checkFilename);
            AddOptionalArg(lst, "check-sync", checkSync);
            AddOptionalArg(lst, "filters-file", filtersFile);
            AddOptionalArg(lst, "force", force);
            AddOptionalArg(lst, "localtime", localTime);
            AddOptionalArg(lst, "no-cleanup", noCleanup);
            AddOptionalArg(lst, "remove-empty-dirs", removeEmptyDirs);
            AddOptionalArg(lst, "resync", resync);
            AddOptionalArg(lst, "workdir", workdir);

            return new CommandLineBuilder(lst);
        }

        /// <summary>
        /// Concatenates any files and sends them to stdout.
        /// </summary>
        /// <param name="count">Only print N characters (default -1)</param>
        /// <param name="discard">Discard the output instead of printing</param>
        /// <param name="head">Only print the first N characters</param>
        /// <param name="offset">Start printing at offset N (or from end if -ve)</param>
        /// <param name="tail">Only print the last N characters</param>
        /// <returns></returns>
        public static CommandLineBuilder Cat(string remotePath, int count, bool discard, int head, int offset, int tail)
        {
            var lst = new List<string> { "cat", remotePath };

            AddOptionalArg(lst, "count", count, -1);
            AddOptionalArg(lst, "discard", discard);
            AddOptionalArg(lst, "head", head);
            AddOptionalArg(lst, "offset", offset);
            AddOptionalArg(lst, "tail", tail);

            return new(lst);
        }

        /// <summary>
        /// Checks the files in the source and destination match.
        /// </summary>
        /// <param name="checkFile">Treat source:path as a SUM file with hashes of given type</param>
        /// <param name="combined">ake a combined report of changes to this file</param>
        /// <param name="differ">Report all non-matching files to this file</param>
        /// <param name="download">Check by downloading rather than with hash</param>
        /// <param name="error">Report all files with errors (hashing or reading) to this file</param>
        /// <param name="match">Report all matching files to this file</param>
        /// <param name="missingOnSrc">Report all files missing from the source to this file</param>
        /// <param name="missingOnDst">Report all files missing from the destination to this file</param>
        /// <param name="oneWay">Check one way only, source files must exist on remote</param>
        public static CommandLineBuilder Check(string remotePathSrc, string remotePathDst, string checkFile = null, string combined = null, string differ = null,
                                               bool download = false, string error = null, string match = null, string missingOnSrc = null, string missingOnDst = null,
                                               bool oneWay = false)
        {
            var lst = new List<string> { "check", remotePathSrc, remotePathDst };

            AddOptionalArg(lst, "check-file", checkFile);
            AddOptionalArg(lst, "combined", combined);
            AddOptionalArg(lst, "differ", differ);
            AddOptionalArg(lst, "download", download);
            AddOptionalArg(lst, "error", error);
            AddOptionalArg(lst, "match", match);
            AddOptionalArg(lst, "missing-on-src", missingOnSrc);
            AddOptionalArg(lst, "missing-on-dst", missingOnDst);
            AddOptionalArg(lst, "one-way", oneWay);

            return new(lst);
        }


        /// <summary>
        /// Checks the files in the source against a SUM file.
        /// </summary>
        /// <param name="hash">MD5, SHA1, etc</param>
        /// <param name="combined">ake a combined report of changes to this file</param>
        /// <param name="differ">Report all non-matching files to this file</param>
        /// <param name="download">Check by downloading rather than with hash</param>
        /// <param name="error">Report all files with errors (hashing or reading) to this file</param>
        /// <param name="match">Report all matching files to this file</param>
        /// <param name="missingOnSrc">Report all files missing from the source to this file</param>
        /// <param name="missingOnDst">Report all files missing from the destination to this file</param>
        /// <param name="oneWay">Check one way only, source files must exist on remote</param>
        public static CommandLineBuilder CheckSum(string remotePath, string sumFile, string hash = null, string combined = null, string differ = null, bool download = false,
                                                  string error = null, string match = null, string missingOnSrc = null, string missingOnDst = null, bool oneWay = false)
        {
            var lst = new List<string> { "checksum" };
            if (!string.IsNullOrWhiteSpace(hash))
                lst.Add(hash);
            lst.AddRange(new string[] { sumFile, remotePath });

            AddOptionalArg(lst, "combined", combined);
            AddOptionalArg(lst, "differ", differ);
            AddOptionalArg(lst, "download", download);
            AddOptionalArg(lst, "error", error);
            AddOptionalArg(lst, "match", match);
            AddOptionalArg(lst, "missing-on-src", missingOnSrc);
            AddOptionalArg(lst, "missing-on-dst", missingOnDst);
            AddOptionalArg(lst, "one-way", oneWay);

            return new(lst);
        }

        /// <summary>
        /// Clean up the remote if possible.Empty the trash or delete old file versions. Not supported by all remotes.
        /// </summary>
        public static CommandLineBuilder Cleanup(string remotePath) => new("cleanup", remotePath);

        /// <summary>
        /// Dump the config file as JSON.
        /// </summary>
        public static CommandLineBuilder ConfigDump() => new("config", "dump");

        /// <summary>
        /// Copy files from source to dest, skipping identical files.
        /// </summary>
        /// <param name="createEmptySrcDirs">Create empty source dirs on destination after copy</param>
        public static CommandLineBuilder Copy(string remotePathSrc, string remotePathDst, bool createEmptySrcDirs = false) =>
            new("copy", remotePathSrc, remotePathDst, createEmptySrcDirs ? "--create-empty-src-dirs" : null);

        /// <summary>
        /// Copy files from source to dest, skipping identical files.
        /// </summary>
        public static CommandLineBuilder CopyTo(string remotePathSrc, string remotePathDst) => new("copyto", remotePathSrc, remotePathDst);


        /// <summary>
        /// Copy url content to dest.
        /// </summary>
        /// <param name="autoFilename">Get the file name from the URL and use it for destination file path</param>
        /// <param name="headerFilename">Get the file name from the Content-Disposition header</param>
        /// <param name="noClobber">Prevent overwriting file with same name</param>
        /// <param name="printFilename">Print the resulting name from --auto-filename</param>
        /// <param name="stdout">Write the output to stdout rather than a file</param>
        /// <returns></returns>
        public static CommandLineBuilder CopyUrl(string url,
                                                 string remotePathDst,
                                                 bool autoFilename = false,
                                                 bool headerFilename = false,
                                                 bool noClobber = false,
                                                 bool printFilename = false,
                                                 bool stdout = false)
        {
            var lst = new List<string> { "copyurl", url, remotePathDst };

            AddOptionalArg(lst, "auto-filename", autoFilename);
            AddOptionalArg(lst, "header-filename", headerFilename);
            AddOptionalArg(lst, "no-clobber", noClobber);
            AddOptionalArg(lst, "print-filename", printFilename);
            AddOptionalArg(lst, "stdout", stdout);

            return new(lst);
        }

        /// <summary>
        /// Cryptcheck checks the integrity of a crypted remote.
        /// </summary>
        /// <param name="combined">Make a combined report of changes to this file</param>
        /// <param name="differ">Report all non-matching files to this file</param>
        /// <param name="error">Report all files with errors (hashing or reading) to this file</param>
        /// <param name="match">Report all matching files to this file</param>
        /// <param name="missingOnDst">Report all files missing from the destination to this file</param>
        /// <param name="missingOnSrc">Report all files missing from the source to this file</param>
        /// <param name="oneWay">Check one way only, source files must exist on remote</param>
        public static CommandLineBuilder CryptCheck(string remotePathSrc,
                                                    string remotePathDst,
                                                    string combined = null,
                                                    string differ = null,
                                                    string error = null,
                                                    string match = null,
                                                    string missingOnDst = null,
                                                    string missingOnSrc = null,
                                                    bool oneWay = false)
        {
            var lst = new List<string> { "cryptcheck", remotePathSrc, remotePathDst };

            AddOptionalArg(lst, "combined", combined);
            AddOptionalArg(lst, "differ", differ);
            AddOptionalArg(lst, "error", error);
            AddOptionalArg(lst, "match", match);
            AddOptionalArg(lst, "missing-on-dst", missingOnDst);
            AddOptionalArg(lst, "missing-on-src", missingOnSrc);
            AddOptionalArg(lst, "one-way", oneWay);

            return new(lst);
        }

        /// <summary>
        /// Check one way only, source files must exist on remote
        /// </summary>
        public static CommandLineBuilder CryptDecode(string remote, params string[] filenames) => CryptDecode(false, remote, filenames);

        /// <summary>
        /// Check one way only, source files must exist on remote
        /// </summary>
        /// <param name="reverse">Reverse cryptdecode, encrypts filenames</param>
        public static CommandLineBuilder CryptDecode(bool reverse, string remote, params string[] filenames)
        {
            var lst = new List<string> { "cryptdecode" };
            AddOptionalArg(lst, "reverse", reverse);
            lst.Add(remote);
            lst.AddRange(filenames);
            return new(lst);
        }

        /// <summary>
        /// Remove the files in path.
        /// </summary>
        /// <param name="rmDirs">Removes empty directories but leaves root intact</param>
        public static CommandLineBuilder Delete(string remotePath, bool rmDirs = false) => new("delete", remotePath, rmDirs ? "--rmdirs" : null);

        /// <summary>
        /// Remove a single file from remote.
        /// </summary>
        public static CommandLineBuilder DeleteFile(string remotePath) => new("deletefile", remotePath);


        /// <summary>
        /// Produces a hashsum file for all the objects in the path.
        /// </summary>
        /// <param name="base64">Output base64 encoded hashsum</param>
        /// <param name="checkFile">Validate hashes against a given SUM file instead of printing them</param>
        /// <param name="download">Download the file and hash it locally; if this flag is not specified, the hash is requested from the remote</param>
        /// <param name="outputFile"Output hashsums to a file rather than the terminal></param>
        public static CommandLineBuilder HashSum(string remotePath, bool base64 = false, string checkFile = null, bool download = false, string outputFile = null)
        {
            var lst = new List<string> { "hashsum", remotePath };

            AddOptionalArg(lst, "base64", base64);
            AddOptionalArg(lst, "checkfile", checkFile);
            AddOptionalArg(lst, "download", download);
            AddOptionalArg(lst, "output-file", outputFile);

            return new(lst);
        }

        /// <summary>
        /// Generate public link to file/folder.
        /// </summary>
        /// <param name="duration">The amount of time that the link will be valid (default off)</param>
        /// <param name="unlink">Remove existing public link to file/folder</param>
        public static CommandLineBuilder Link(string remotePath, TimeSpan? duration = null, bool unlink = false)
        {
            var lst = new List<string> { "link", remotePath };

            AddOptionalArg(lst, "expire", duration.ToRclone());
            AddOptionalArg(lst, "unlink", unlink);

            return new(lst);
        }

        /// <summary>
        /// List all the remotes in the config file
        /// </summary>
        /// <param name="lng">Show the type as well as names</param>
        public static CommandLineBuilder ListRemotes(bool lng = false) => new("listremotes", lng ? "--long" : null);

        /// <summary>
        /// List the objects in the path with size and path.
        /// </summary>
        public static CommandLineBuilder LS(string remotePath) => new("ls", remotePath);


        /// <summary>
        /// List directories and objects in remote:path formatted for parsing.
        /// </summary>
        /// <param name="absolute">Put a leading / in front of path names</param>
        /// <param name="csv">Output in CSV format</param>
        /// <param name="dirSlash">Append a slash to directory names (default true)</param>
        /// <param name="dirsOnly">Only list directories</param>
        /// <param name="filesOnly">Only list files</param>
        /// <param name="format">
        /// Output format
        /// <br>p - path</br>
        /// <br>s - size</br>
        /// <br>t - modification time</br>
        /// <br>i - ID of object</br>
        /// <br>o - Original ID of underlying object</br>
        /// <br>m - MimeType of object if known</br>
        /// <br>e - encrypted name</br>
        /// <br>T - tier of storage if known, e.g. "Hot" or "Cool"</br>
        /// <br>M - Metadata of object in JSON blob format, eg {"key":"value"}</br>
        /// </param>
        /// <param name="hash">Use this hash when h is used in the format MD5|SHA-1|DropboxHash (default "md5")</param>
        /// <param name="recursive">Recurse into the listing</param>
        /// <param name="separator">Separator for the items in the format (default ";")</param>
        public static CommandLineBuilder LSF(string remotePath,
                                             bool absolute = false,
                                             bool csv = false,
                                             bool dirSlash = true,
                                             bool dirsOnly = false,
                                             bool filesOnly = false,
                                             string format = "p",
                                             string hash = null,
                                             bool recursive = false,
                                             string separator = ";")
        {
            var lst = new List<string> { "lsf", remotePath };

            AddOptionalArg(lst, "absolute", absolute);
            AddOptionalArg(lst, "csv", csv);
            AddOptionalArg(lst, "dir-slash", dirSlash, true);
            AddOptionalArg(lst, "dirs-only", dirsOnly);
            AddOptionalArg(lst, "files-only", filesOnly);
            AddOptionalArg(lst, "format", format);
            AddOptionalArg(lst, "hash", hash);
            AddOptionalArg(lst, "recursive", recursive);
            AddOptionalArg(lst, "separator", separator);

            return new(lst);
        }


        /// <summary>
        /// List directories and objects in the path in JSON format.
        /// </summary>
        /// <param name="dirsOnly">Show only directories in the listing</param>
        /// <param name="encrypted">Show the encrypted names</param>
        /// <param name="filesOnly">Show only files in the listing</param>
        /// <param name="hash">Include hashes in the output (may take longer)</param>
        /// <param name="hashTypes">Show only these hash types</param>
        /// <param name="noMimeType">Don't read the mime type (can speed things up)</param>
        /// <param name="noModTime">Don't read the modification time (can speed things up)</param>
        /// <param name="original">Show the ID of the underlying Object</param>
        /// <param name="recursive">Recurse into the listing</param>
        /// <param name="stat">Just return the info for the pointed to file</param>
        public static CommandLineBuilder LsJSon(string remotePath,
                                                bool dirsOnly = false,
                                                bool encrypted = false,
                                                bool filesOnly = false,
                                                bool hash = false,
                                                HashTypes? hashTypes = null,
                                                bool noMimeType = false,
                                                bool noModTime = false,
                                                bool original = false,
                                                bool recursive = false,
                                                bool stat = false
                                                )
        {

            var lst = new List<string> { "lsjson", remotePath };

            AddOptionalArg(lst, "dirs-only", dirsOnly);
            AddOptionalArg(lst, "encrypted", encrypted);
            AddOptionalArg(lst, "files-only", filesOnly);
            AddOptionalArg(lst, "hash", hash);

            if (hashTypes != null)
            {
                if (hashTypes.Value.HasFlag(HashTypes.MD5))
                    AddOptionalArg(lst, "hash-type", "md5");
                if (hashTypes.Value.HasFlag(HashTypes.SHA1))
                    AddOptionalArg(lst, "hash-type", "sha1");
                if (hashTypes.Value.HasFlag(HashTypes.DropBox))
                    AddOptionalArg(lst, "hash-type", "dropbox");
            }

            AddOptionalArg(lst, "no-mimetype", noMimeType);
            AddOptionalArg(lst, "no-modtime", noModTime);
            AddOptionalArg(lst, "original", original);
            AddOptionalArg(lst, "recursive", recursive);
            AddOptionalArg(lst, "stat", stat);

            return new(lst);
        }

        /// <summary>
        /// List the objects in path with modification time, size and path.
        /// </summary>
        public static CommandLineBuilder LSL(string remotePath) => new("lsl", remotePath);


        /// <summary>
        /// Mount the remote as file system on a mountpoint.
        /// </summary>
        /// <param name="remotePath">The remote path to mount</param>
        /// <param name="mountPath">The location that will contain the mount</param>
        /// <param name="options">Option for libfuse/WinFsp</param>
        public static CommandLineBuilder Mount(string remotePath, string mountPath, VFS_OptionsBuilder options = null)
        {
            var ret = new CommandLineBuilder("mount", remotePath, mountPath);

            if (options != null)
                ret.AddOptions(options);

            return ret;
        }


        /// <summary>
        /// Move files from source to dest.
        /// </summary>
        /// <param name="createEmptySrcDirs"></param>
        /// <param name="deleteEmptySrcDirs"></param>
        public static CommandLineBuilder Move(string remotePathSrc, string remotePathDst, bool createEmptySrcDirs = false, bool deleteEmptySrcDirs = false) =>
            new("move", remotePathSrc, remotePathDst, createEmptySrcDirs ? "--create-empty-src-dirs" : null, deleteEmptySrcDirs ? "--delete-empty-src-dirs" : null);


        /// <summary>
        /// Move file or directory from source to dest.
        /// </summary>
        public static CommandLineBuilder MoveTo(string remotePathSrc, string remotePathDst) => new("moveto", remotePathSrc, remotePathDst);


        /// <summary>
        /// Obscure password
        /// </summary>
        public static CommandLineBuilder Obscure(string password) => new("obscure", password);


        /// <summary>
        /// Remove the path and all of its contents.
        /// </summary>
        public static CommandLineBuilder Purge(string remotePath) => new("purge", remotePath);


        /// <summary>
        /// Run a command against a running rclone.
        /// </summary>
        /// <param name="args">Arguments placed in the "arg" array</param>
        /// <param name="json">Input JSON - use instead of key=value args</param>
        /// <param name="opts">Option in the form name=value or name placed in the "opt" array</param>
        /// <param name="url">URL to connect to rclone remote control (default "http://localhost:5572/")</param>
        /// <param name="loopback">If set connect to this rclone instance not via HTTP</param>
        /// <param name="user">Username to use to rclone remote control</param>
        /// <param name="pass">Password to use to connect to rclone remote control</param>
        /// <param name="noOutput">If set, don't output the JSON result</param>
        /// <returns></returns>
        public static CommandLineBuilder RC(IEnumerable<string> args = null,
                                            string json = null,
                                            IEnumerable<string> opts = null,
                                            string url = null,
                                            bool loopback = false,
                                            string user = null,
                                            string pass = null,
                                            bool noOutput = false
                                            )
        {
            var lst = new List<string> { "rc" };

            AddOptionalArg(lst, "json", json);

            if (args != null)
                foreach (var arg in args)
                    AddOptionalArg(lst, "arg", arg);
            if (opts != null)
                foreach (var opt in opts)
                    AddOptionalArg(lst, "opt", opt);

            AddOptionalArg(lst, "url", url);
            AddOptionalArg(lst, "loopback", loopback);
            AddOptionalArg(lst, "user", user);
            AddOptionalArg(lst, "pass", pass);
            AddOptionalArg(lst, "no-output", noOutput);

            return new(lst);
        }

        /// <summary>
        /// Copies standard input to file on remote.
        /// </summary>
        /// <param name="size">File size hint to preallocate (default -1)</param>
        public static CommandLineBuilder Rcat(string remotePath, int size = -1) => new("rcat", remotePath, size > -1 ? $"--size {size}" : null);


        /// <summary>
        /// Run rclone listening to remote control commands only.
        /// </summary>
        /// <returns></returns>
        public static CommandLineBuilder RCD(VFS_OptionsBuilder options = null)
        {
            var ret = new CommandLineBuilder("rcd");

            if (options != null)
                ret.AddOptions(options);

            return ret;
        }


        /// <summary>
        /// Remove the empty directory at path.
        /// </summary>
        public static CommandLineBuilder RmDir(string remotePath) => new("rmdir", remotePath);


        /// <summary>
        /// Remove empty directories under the path.
        /// </summary>
        /// <param name="leaveRoot">Do not remove root directory if empty</param>
        public static CommandLineBuilder RmDirs(string remotePath, bool leaveRoot = false) =>
            new("rmdirs", remotePath, leaveRoot ? "--leave-root" : null);


        /// <summary>
        /// Update the rclone binary.
        /// </summary>
        /// <param name="beta">Install beta release</param>
        /// <param name="check">Check for latest release, do not download</param>
        /// <param name="output">Save the downloaded binary at a given path (default: replace running binary)</param>
        /// <param name="package">Package format: zip|deb|rpm (default: zip)</param>
        /// <param name="stable">Install stable release (this is the default)</param>
        /// <param name="version">Install the given rclone version (default: latest)</param>
        /// <returns></returns>
        public static CommandLineBuilder SelfUpdate(bool beta = false,
                                                    bool check = false,
                                                    string output = null,
                                                    string package = null,
                                                    bool stable = true,
                                                    string version = null)
        {
            var lst = new List<string> { "selfupdate" };

            AddOptionalArg(lst, "beta", beta);
            AddOptionalArg(lst, "check", check);
            AddOptionalArg(lst, "output", output);
            AddOptionalArg(lst, "package", package);
            AddOptionalArg(lst, "stable", stable, true);
            AddOptionalArg(lst, "version", version);

            return new(lst);
        }


        public static class Serve
        {
            /// <summary>
            /// Serve remote:path over DLNA
            /// </summary>
            public static CommandLineBuilder DLNA(string remotePath, ServeDLNA_OptionsBuilder options = null) => new(options, "serve", "dlna", remotePath);

            /// <summary>
            /// Serve any remote on docker's volume plugin API.
            /// </summary>
            public static CommandLineBuilder Docker(string remotePath, ServeDocker_OptionsBuilder options = null) => new(options, "serve", "docker", remotePath);


            /// <summary>
            /// Serve remote:path over FTP.
            /// </summary>
            public static CommandLineBuilder FTP(string remotePath, ServeFTP_OptionsBuilder options = null) => new(options, "serve", "ftp", remotePath);



            /// <summary>
            /// Serve the remote over HTTP.
            /// </summary>
            public static CommandLineBuilder HTTP(string remotePath, ServeHTTP_OptionsBuilder options = null) => new(options, "serve", "http", remotePath);



            /// <summary>
            /// Serve the remote for restic's REST API.
            /// </summary>
            public static CommandLineBuilder Restic(string remotePath, ServeRestic_OptionsBuilder options = null) => new(options, "serve", "restic", remotePath);


            /// <summary>
            /// Serve the remote over SFTP.
            /// </summary>
            public static CommandLineBuilder SFTP(string remotePath, ServeSFTP_OptionsBuilder options = null) => new(options, "serve", "sftp", remotePath);

            /// <summary>
            /// Serve the remote over WebDav.
            /// </summary>
            public static CommandLineBuilder WebDav(string remotePath, ServeWebDav_OptionsBuilder options = null) => new(options, "serve", "webdav", remotePath);

        }


        /// <summary>
        /// Changes storage class/tier of objects in remote.
        /// </summary>
        public static CommandLineBuilder SetTier(string remotePath, string tier) => new("settier", tier, remotePath);

        /// <summary>
        /// Prints the total size and number of objects in remote:path.
        /// </summary>
        /// <param name="json">Format output as JSON</param>
        public static CommandLineBuilder Size(string remotePath, bool json = false) => new("size", remotePath, json ? "--json" : null);

        /// <summary>
        /// Make source and dest identical, modifying destination only.
        /// </summary>
        /// <param name="createEmptySrcDirs">Create empty source dirs on destination after sync</param>
        public static CommandLineBuilder Sync(string remotePathSrc, string remotePathDst, bool createEmptySrcDirs = false)
            => new("sync", remotePathSrc, remotePathDst, createEmptySrcDirs ? "--create-empty-src-dirs" : null);


        /// <summary>
        /// Create new file or change file modification time.
        /// </summary>
        /// <param name="useLocalTime">Use localtime for timestamp, not UTC</param>
        /// <param name="noCreate">Do not create the file if it does not exist (implied with --recursive)</param>
        /// <param name="recursive">Recursively touch all files</param>
        /// <param name="timestamp">Use specified time instead of the current time of day</param>
        public static CommandLineBuilder Touch(string remotePath,
                                               bool localTime = false,
                                               bool noCreate = false,
                                               bool recursive = false,
                                               DateTime? timestamp = null)
        {
            var lst = new List<string> { "touch", remotePath };

            AddOptionalArg(lst, "localtime", localTime);
            AddOptionalArg(lst, "no-create", noCreate);
            AddOptionalArg(lst, "recursive", recursive);
            AddOptionalArg(lst, "timestamp", timestamp.ToRclone());

            return new(lst);
        }



        /// <summary>
        /// List the contents of the remote in a tree like fashion.
        /// </summary>
        /// <param name="all">All files are listed (list . files too)</param>
        /// <param name="color">Turn colorization on always</param>
        /// <param name="dirsOnly">List directories only</param>
        /// <param name="dirsFirst">List directories before files (-U disables)</param>
        /// <param name="fullPath">Print the full path prefix for each file</param>
        /// <param name="level">Descend only level directories deep</param>
        /// <param name="modTime">Print the date of last modification.</param>
        /// <param name="noIndent">Don't print indentation lines</param>
        /// <param name="noReport">Turn off file/directory count at end of tree listing</param>
        /// <param name="output">Output to file instead of stdout</param>
        /// <param name="protections">Print the protections for each file.</param>
        /// <param name="quote">Quote filenames with double quotes.</param>
        /// <param name="size">Print the size in bytes of each file.</param>
        /// <param name="sort">Select sort: name,version,size,mtime,ctime</param>
        /// <param name="sortCTime">Sort files by last status change time</param>
        /// <param name="sortModTime">Sort files by last modification time</param>
        /// <param name="sortReverse">Reverse the order of the sort</param>
        /// <param name="unsorted">Leave files unsorted</param>
        /// <param name="version">Sort files alphanumerically by version</param>
        public static CommandLineBuilder Tree(string remotePath,
                                              bool all = false,
                                              bool color = false,
                                              bool dirsOnly = false,
                                              bool dirsFirst = false,
                                              bool fullPath = false,
                                              uint? level = null,
                                              bool modTime = false,
                                              bool noIndent = false,
                                              bool noReport = false,
                                              string output = null,
                                              bool protections = false,
                                              bool quote = false,
                                              bool size = false,
                                              string sort = null,
                                              bool sortCTime = false,
                                              bool sortModTime = false,
                                              bool sortReverse = false,
                                              bool unsorted = false,
                                              bool version = false)
        {
            var lst = new List<string> { "tree", remotePath };

            AddOptionalArg(lst, "all", all);
            AddOptionalArg(lst, "color", color);
            AddOptionalArg(lst, "dirs-only", dirsOnly);
            AddOptionalArg(lst, "dirsfirst", dirsFirst);
            AddOptionalArg(lst, "full-path", fullPath);
            AddOptionalArg(lst, "level", level);
            AddOptionalArg(lst, "modtime", modTime);
            AddOptionalArg(lst, "noindent", noIndent);
            AddOptionalArg(lst, "noreport", noReport);
            AddOptionalArg(lst, "output", output);
            AddOptionalArg(lst, "protections", protections);
            AddOptionalArg(lst, "quote", quote);
            AddOptionalArg(lst, "size", size);
            AddOptionalArg(lst, "sort", sort);
            AddOptionalArg(lst, "sort-ctime", sortCTime);
            AddOptionalArg(lst, "sort-modtime", sortModTime);
            AddOptionalArg(lst, "sort-reverse", sortReverse);
            AddOptionalArg(lst, "unsorted", unsorted);
            AddOptionalArg(lst, "version", version);

            return new(lst);
        }



        /// <summary>
        /// Show the version number.
        /// </summary>
        /// <param name="check">Check for new version</param>
        public static CommandLineBuilder Version(bool check = false) => new("version", check ? "--check" : null);
    }
}
