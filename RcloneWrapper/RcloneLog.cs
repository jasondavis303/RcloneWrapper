using System;

namespace RcloneWrapper;

public record RcloneLog(string Level, string Msg, DateTime Time, RcloneLogStatus Stats)
{
}