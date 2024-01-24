using AsyncKeyedLock;
using EFCoreCache.Interfaces;
using System.Runtime.CompilerServices;

namespace EFCoreCache.Providers;

public sealed class LockProvider : ILockProvider
{
    private readonly AsyncNonKeyedLocker _lock = new();

    /// <summary>
    ///     Tries to enter the sync lock
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public AsyncNonKeyedLockReleaser Lock(CancellationToken cancellationToken = default) => _lock.Lock(cancellationToken);

    /// <summary>
    ///     Tries to enter the async lock
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueTask<AsyncNonKeyedLockReleaser> LockAsync(CancellationToken cancellationToken = default) =>
        _lock.LockAsync(cancellationToken);

    /// <summary>
    ///     Disposes the lock
    /// </summary>    
    public void Dispose()
    {
        _lock.Dispose();
    }
}