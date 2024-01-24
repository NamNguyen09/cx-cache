using AsyncKeyedLock;

namespace EFCoreCache.Interfaces;
public interface ILockProvider : IDisposable
{
    /// <summary>
    ///     Tries to enter the sync lock
    /// </summary>
    AsyncNonKeyedLockReleaser Lock(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Tries to enter the async lock
    /// </summary>
    ValueTask<AsyncNonKeyedLockReleaser> LockAsync(CancellationToken cancellationToken = default);
}