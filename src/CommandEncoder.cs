using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

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



    public void CopyBufferToBuffer(
        Buffer source,
        ulong sourceOffset,
        Buffer destination,
        ulong destinationOffset,
        ulong size
    )
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyBufferToBuffer(
            WebGPUMarshal.GetBorrowHandle(source),
            sourceOffset,
            WebGPUMarshal.GetBorrowHandle(destination),
            destinationOffset,
            size
        );
    }

    public void ClearBuffer(Buffer buffer, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ClearBuffer(buffer, offset, size);
    }

    public void CopyBufferToTexture(in TexelCopyBufferInfo source, in TexelCopyTextureInfo destination, in Extent3D copySize)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyBufferToTexture(source, destination, copySize);
    }

    public void CopyTextureToBuffer(in TexelCopyTextureInfo source, in TexelCopyBufferInfo destination, in Extent3D copySize)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyTextureToBuffer(source, destination, copySize);
    }

    public void CopyTextureToTexture(in TexelCopyTextureInfo source, in TexelCopyTextureInfo destination, in Extent3D copySize)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.CopyTextureToTexture(source, destination, copySize);
    }

    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.InsertDebugMarker(markerLabel);
    }

    public void PopDebugGroup()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.PopDebugGroup();
    }

    public void PushDebugGroup(WGPURefText groupLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.PushDebugGroup(groupLabel);
    }

    public void ResolveQuerySet(
        QuerySet querySet, uint firstQuery, uint queryCount,
        Buffer destination, ulong destinationOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ResolveQuerySet(querySet, firstQuery, queryCount, destination, destinationOffset);
    }

    public void SetLabel(WGPURefText label)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetLabel(label);
    }

    public void WriteTimestamp(QuerySet querySet, uint queryIndex)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.WriteTimestamp(querySet, queryIndex);
    }

    public CommandBuffer Finish(in CommandBufferDescriptor descriptor)
    {
        _pooledHandle.VerifyToken(_localToken);
        var commandBufferHandle = _pooledHandle.handle.Finish(descriptor);
        PooledHandle<CommandEncoderHandle>.Return(_pooledHandle);
        return commandBufferHandle.ToSafeHandle();
    }

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