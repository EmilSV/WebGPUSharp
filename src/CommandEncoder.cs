using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;
using static WebGpuSharp.Marshalling.WebGPUMarshal;

namespace WebGpuSharp;

/// <inheritdoc cref="CommandEncoderHandle"/>
public readonly struct CommandEncoder : IEquatable<CommandEncoder>
{
    private readonly ulong _localToken;
    private readonly CommandEncoderHandle _originalHandle;
    private readonly PooledHandle<CommandEncoderHandle> _pooledHandle;

    private CommandEncoder(PooledHandle<CommandEncoderHandle> pooledHandle)
    {
        _originalHandle = pooledHandle.handle;
        _localToken = pooledHandle.token;
        _pooledHandle = pooledHandle;
    }

    internal static CommandEncoder FromHandle(CommandEncoderHandle handle)
    {
        var newCommandEncoderPooledHandle = PooledHandle<CommandEncoderHandle>.Get(handle);
        return new CommandEncoder(newCommandEncoderPooledHandle);
    }

    public RenderPassEncoder BeginRenderPass(in RenderPassDescriptor descriptor)
    {
        _pooledHandle.VerifyToken(_localToken);
        return _pooledHandle.handle.BeginRenderPass(descriptor).ToSafeHandle();
    }


    /// <inheritdoc cref="CommandEncoderHandle.CopyBufferToBuffer(Buffer, ulong, Buffer, ulong, ulong)"/>
    public void CopyBufferToBuffer(
        Buffer source,
        Buffer destination,
        ulong? size = null
    )
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyBufferToBuffer(
            GetBorrowHandle(source),
            0,
            GetBorrowHandle(destination),
            0,
            size ?? source.GetSize()
        );
    }

    /// <inheritdoc cref="CommandEncoderHandle.CopyBufferToBuffer(Buffer, ulong, Buffer, ulong, ulong)"/>
    public void CopyBufferToBuffer(
        Buffer source,
        ulong sourceOffset,
        Buffer destination,
        ulong destinationOffset,
        ulong? size = null
    )
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyBufferToBuffer(
            GetBorrowHandle(source),
            sourceOffset,
            GetBorrowHandle(destination),
            destinationOffset,
            size ?? (source.GetSize() - sourceOffset)
        );
    }

    /// <inheritdoc cref="CommandEncoderHandle.ClearBuffer(Buffer, ulong, ulong)"/>
    public void ClearBuffer(Buffer buffer, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ClearBuffer(buffer, offset, size);
    }

    /// <inheritdoc cref="CommandEncoderHandle.CopyBufferToTexture(in TexelCopyBufferInfo, in TexelCopyTextureInfo, in Extent3D)"/>
    public void CopyBufferToTexture(in TexelCopyBufferInfo source, in TexelCopyTextureInfo destination, in Extent3D copySize)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyBufferToTexture(source, destination, copySize);
    }

    /// <inheritdoc cref="CommandEncoderHandle.CopyTextureToBuffer(in TexelCopyTextureInfo, in TexelCopyBufferInfo, in Extent3D)"/>
    public void CopyTextureToBuffer(in TexelCopyTextureInfo source, in TexelCopyBufferInfo destination, in Extent3D copySize)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyTextureToBuffer(source, destination, copySize);
    }

    /// <inheritdoc cref="CommandEncoderHandle.CopyTextureToTexture(in TexelCopyTextureInfo, in TexelCopyTextureInfo, in Extent3D)"/>
    public void CopyTextureToTexture(in TexelCopyTextureInfo source, in TexelCopyTextureInfo destination, in Extent3D copySize)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyTextureToTexture(source, destination, copySize);
    }

    /// <inheritdoc cref="CommandEncoderHandle.InsertDebugMarker(WGPURefText)"/>
    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.InsertDebugMarker(markerLabel);
    }

    /// <inheritdoc cref="CommandEncoderHandle.PopDebugGroup"/>
    public void PopDebugGroup()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.PopDebugGroup();
    }

    /// <inheritdoc cref="CommandEncoderHandle.PushDebugGroup(WGPURefText)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.PushDebugGroup(groupLabel);
    }

    /// <inheritdoc cref="CommandEncoderHandle.ResolveQuerySet(QuerySet, uint, uint, Buffer, ulong)"/>
    public void ResolveQuerySet(
        QuerySet querySet, uint firstQuery, uint queryCount,
        Buffer destination, ulong destinationOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ResolveQuerySet(querySet, firstQuery, queryCount, destination, destinationOffset);
    }

    /// <inheritdoc cref="CommandEncoderHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetLabel(label);
    }

    /// <inheritdoc cref="CommandEncoderHandle.Finish(in CommandBufferDescriptor)"/>
    public CommandBuffer Finish(in CommandBufferDescriptor descriptor)
    {
        _pooledHandle.VerifyToken(_localToken);
        var commandBufferHandle = _pooledHandle.handle.Finish(descriptor);
        PooledHandle<CommandEncoderHandle>.Return(_pooledHandle);
        return commandBufferHandle.ToSafeHandle();
    }

    /// <inheritdoc cref="CommandEncoderHandle.Finish()"/>
    public CommandBuffer Finish()
    {
        _pooledHandle.VerifyToken(_localToken);
        var commandBufferHandle = _pooledHandle.handle.Finish();
        PooledHandle<CommandEncoderHandle>.Return(_pooledHandle);
        return commandBufferHandle.ToSafeHandle();
    }

    public bool Equals(CommandEncoder other)
    {
        _pooledHandle.VerifyToken(_localToken);
        other._pooledHandle.VerifyToken(other._localToken);
        return _pooledHandle.handle == other._pooledHandle.handle;
    }

    public override bool Equals(object? obj)
    {
        return obj is CommandEncoder encoder && Equals(encoder);
    }

    public static bool operator ==(CommandEncoder left, CommandEncoder right)
    {
        return left._originalHandle == right._originalHandle;
    }

    public static bool operator !=(CommandEncoder left, CommandEncoder right)
    {
        return left._originalHandle != right._originalHandle;
    }

    public override int GetHashCode()
    {
        return _originalHandle.GetHashCode();
    }
}