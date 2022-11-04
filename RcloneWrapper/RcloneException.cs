using System;

namespace RcloneWrapper
{
    public class RcloneException : Exception
    {
        public RcloneException(int exitCode, string message, Exception innerException) : base(message, innerException) => ExitCode = exitCode;

        public int ExitCode { get; set; }
    }
}
