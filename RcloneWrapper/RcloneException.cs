using System;

namespace RcloneWrapper
{
    public class RcloneException : Exception
    {
        public RcloneException(int exitCode, string message, string providedArgs) : base(message)
        {
            ExitCode = exitCode;
            ProvidedArgs = providedArgs;
        }

        public int ExitCode { get; }
        public string ProvidedArgs { get; }
    }
}