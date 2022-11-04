using System;

namespace RcloneWrapper.Enums
{
    [Flags]
    public enum HashTypes
    {
        MD5 = 1,
        SHA1 = 2,
        DropBox = 4
    }
}
