namespace RcloneWrapper;

public record RcloneLogStatus(
    long Bytes,
    int Checks,
    float ElapsedTime,
    int Errors,
    bool FatalError,
    string LastError,
    int Renames,
    bool RetryError,
    float Speed,
    long TotalBytes,
    int TotalChecks,
    int TotalTransfers,
    float TransferTime,
    int Transfers)
{
}