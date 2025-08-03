using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderBundleEncoderHandle"/>
public readonly struct RenderBundleEncoder : IEquatable<RenderBundleEncoder>,
    IBindingCommands, IDebugCommands, IRenderCommands
{
    private readonly ulong _localToken;
    private readonly RenderBundleEncoderHandle _originalHandle;
    private readonly PooledHandle<RenderBundleEncoderHandle> _pooledHandle;

    private RenderBundleEncoder(PooledHandle<RenderBundleEncoderHandle> pooledHandle)
    {
        _originalHandle = pooledHandle.handle;
        _localToken = pooledHandle.token;
        _pooledHandle = pooledHandle;
    }

    internal static RenderBundleEncoder FromHandle(RenderBundleEncoderHandle handle)
    {
        var newRenderBundleEncoderPooledHandle = PooledHandle<RenderBundleEncoderHandle>.Get(handle);
        return new RenderBundleEncoder(newRenderBundleEncoderPooledHandle);
    }

    internal RenderBundleEncoderHandle GetOwnedHandle()
    {
        return _pooledHandle.GetOwnedHandle(_localToken);
    }


    /// <inheritdoc cref="RenderBundleEncoderHandle.Draw(uint, uint, uint, uint)"/>
    public void Draw(
        uint vertexCount, uint instanceCount = 1,
        uint firstVertex = 0, uint firstInstance = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.Draw(
            vertexCount: vertexCount,
            instanceCount: instanceCount,
            firstVertex: firstVertex,
            firstInstance: firstInstance
        );
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.DrawIndexed(uint, uint, uint, int, uint)"/>
    public void DrawIndexed(
        uint indexCount, uint instanceCount = 1,
        uint firstIndex = 0, int baseVertex = 0, uint firstInstance = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.DrawIndexed(
            indexCount: indexCount,
            instanceCount: instanceCount,
            firstIndex: firstIndex,
            baseVertex: baseVertex,
            firstInstance: firstInstance
        );
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.DrawIndexedIndirect(BufferBase, ulong)"/>
    public void DrawIndexedIndirect(
        BufferBase indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.DrawIndexedIndirect(indirectBuffer, indirectOffset);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.DrawIndirect(BufferBase, ulong)"/>
    public void DrawIndirect(
        BufferBase indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.DrawIndirect(indirectBuffer, indirectOffset);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.Finish(in RenderBundleDescriptor)"/>
    public RenderBundle Finish(in RenderBundleDescriptor descriptor)
    {
        _pooledHandle.VerifyToken(_localToken);
        var result = _originalHandle.Finish(descriptor).ToSafeHandle(false)!;
        PooledHandle<RenderBundleEncoderHandle>.Return(_pooledHandle);
        return result;
    }
    /// <inheritdoc cref="RenderBundleEncoderHandle.Finish()"/>
    public RenderBundle Finish()
    {
        _pooledHandle.VerifyToken(_localToken);
        var result = _originalHandle.Finish().ToSafeHandle(false)!;
        PooledHandle<RenderBundleEncoderHandle>.Return(_pooledHandle);
        return result;
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.InsertDebugMarker(WGPURefText)"/>
    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.InsertDebugMarker(markerLabel);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.PopDebugGroup()"/>
    public void PopDebugGroup()
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.PopDebugGroup();
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.PushDebugGroup(WGPURefText)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.PushDebugGroup(groupLabel);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetBindGroup(uint, BindGroupBase)"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetBindGroup(groupIndex, group);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetBindGroup(uint, BindGroupBase, uint)"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group, uint dynamicOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetBindGroup(groupIndex, group, dynamicOffset);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetBindGroup(uint, BindGroupBase, ReadOnlySpan{uint})"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group, ReadOnlySpan<uint> dynamicOffsets)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetBindGroup(groupIndex, group, dynamicOffsets);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetIndexBuffer(BufferBase, IndexFormat, ulong, ulong)"/>
    public void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetIndexBuffer(buffer, format, offset, size);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetIndexBuffer(BufferBase, IndexFormat, ulong)"/>
    public void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetIndexBuffer(buffer, format, offset);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetLabel(label);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetPipeline(RenderPipelineBase)"/>
    public void SetPipeline(RenderPipelineBase pipeline)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetPipeline(pipeline);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetVertexBuffer(uint, BufferBase, ulong, ulong)"/>
    public void SetVertexBuffer(uint slot, BufferBase buffer, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetVertexBuffer(slot, buffer, offset, size);
    }

    /// <inheritdoc cref="RenderBundleEncoderHandle.SetVertexBuffer(uint, BufferBase, ulong)"/>
    public void SetVertexBuffer(uint slot, BufferBase buffer, ulong offset = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _originalHandle.SetVertexBuffer(slot, buffer, offset);
    }

    public bool Equals(RenderBundleEncoder other)
    {
        _pooledHandle.VerifyToken(_localToken);
        return _pooledHandle.handle == other._pooledHandle.handle;
    }

    public override bool Equals(object? obj)
    {
        return obj is RenderBundleEncoder encoder && Equals(encoder);
    }

    public static bool operator ==(RenderBundleEncoder left, RenderBundleEncoder right)
    {
        return left._originalHandle == right._originalHandle;
    }

    public static bool operator !=(RenderBundleEncoder left, RenderBundleEncoder right)
    {
        return left._originalHandle != right._originalHandle;
    }

    public override int GetHashCode()
    {
        return _originalHandle.GetHashCode();
    }
}