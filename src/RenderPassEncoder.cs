using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public readonly struct RenderPassEncoder : IEquatable<RenderPassEncoder>
{
    private readonly ulong _localToken;
    private readonly RenderPassEncoderHandle _originalHandle;
    private readonly PooledHandle<RenderPassEncoderHandle> _pooledHandle;

    private RenderPassEncoder(PooledHandle<RenderPassEncoderHandle> pooledHandle)
    {
        _originalHandle = pooledHandle.handle;
        _localToken = pooledHandle.token;
        _pooledHandle = pooledHandle;
    }

    internal static RenderPassEncoder FromHandle(RenderPassEncoderHandle handle)
    {
        var newRenderPassEncoderPooledHandle = PooledHandle<RenderPassEncoderHandle>.Get(handle);
        return new RenderPassEncoder(newRenderPassEncoderPooledHandle);
    }

    internal RenderPassEncoderHandle GetOwnedHandle()
    {
        return _pooledHandle.GetOwnedHandle(_localToken);
    }

    public void Draw(
        uint vertexCount, uint instanceCount,
        uint firstVertex, uint firstInstance)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.Draw(vertexCount, instanceCount, firstVertex, firstInstance);
    }

    public void End()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.End();
        PooledHandle<RenderPassEncoderHandle>.Return(_pooledHandle);
    }

    public void SetBindGroup(uint groupIndex, BindGroup group)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBindGroup(groupIndex, group);
    }

    public void SetBindGroup(uint groupIndex, BindGroup group, uint dynamicOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBindGroup(groupIndex, group, dynamicOffset);
    }

    public void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBindGroup(groupIndex, group, dynamicOffsets);
    }

    public void SetPipeline(RenderPipeline pipeline)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetPipeline(pipeline);
    }

    public void SetVertexBuffer(
        uint slot, Buffer buffer, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetVertexBuffer(slot, buffer, offset, size);
    }

    public bool Equals(RenderPassEncoder other)
    {
        _pooledHandle.VerifyToken(_localToken);
        other._pooledHandle.VerifyToken(other._localToken);
        return _pooledHandle.handle == other._pooledHandle.handle;
    }

    public override bool Equals(object? obj)
    {
        return obj is RenderPassEncoder encoder && Equals(encoder);
    }

    public static bool operator ==(RenderPassEncoder left, RenderPassEncoder right)
    {
        return left._originalHandle == right._originalHandle;
    }

    public static bool operator !=(RenderPassEncoder left, RenderPassEncoder right)
    {
        return left._originalHandle != right._originalHandle;
    }

    public override int GetHashCode()
    {
        return _originalHandle.GetHashCode();
    }
}