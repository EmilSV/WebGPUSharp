using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="CommandBufferHandle"/>
public readonly struct CommandBuffer : IEquatable<CommandBuffer>
{
    internal readonly ulong _localToken;
    internal readonly CommandBufferHandle _originalHandle;
    internal readonly PooledHandle<CommandBufferHandle> _pooledHandle;

    private CommandBuffer(PooledHandle<CommandBufferHandle> pooledHandle)
    {
        _originalHandle = pooledHandle.Handle;
        _localToken = pooledHandle.Token;
        _pooledHandle = pooledHandle;
    }

    internal static CommandBuffer FromHandle(CommandBufferHandle handle)
    {
        var newCommandBufferPooledHandle = PooledHandle<CommandBufferHandle>.Get(handle);
        return new CommandBuffer(newCommandBufferPooledHandle);
    }

    public bool Equals(CommandBuffer other)
    {
        _pooledHandle.VerifyToken(_localToken);
        other._pooledHandle.VerifyToken(other._localToken);
        return _pooledHandle.Handle == other._pooledHandle.Handle;
    }

    public override bool Equals(object? obj)
    {
        return obj is CommandBuffer encoder && Equals(encoder);
    }

    public static bool operator ==(CommandBuffer left, CommandBuffer right)
    {
        return left._originalHandle == right._originalHandle;
    }

    public static bool operator !=(CommandBuffer left, CommandBuffer right)
    {
        return left._originalHandle != right._originalHandle;
    }

    public override int GetHashCode()
    {
        return _originalHandle.GetHashCode();
    }
}