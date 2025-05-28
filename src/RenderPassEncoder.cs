using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderPassEncoderHandle"/>
public readonly struct RenderPassEncoder : IEquatable<RenderPassEncoder>,
     IBindingCommands, IDebugCommands, IRenderCommands
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

    /// <inheritdoc cref="RenderPassEncoderHandle.BeginOcclusionQuery(uint)"/>
    public void BeginOcclusionQuery(uint queryIndex)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.BeginOcclusionQuery(queryIndex);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.Draw(uint, uint, uint, uint)"/>
    public void Draw(
        uint vertexCount, uint instanceCount = 1,
        uint firstVertex = 0, uint firstInstance = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.Draw(vertexCount, instanceCount, firstVertex, firstInstance);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.DrawIndexed(uint, uint, uint, int, uint)"/>
    public void DrawIndexed(
        uint indexCount, uint instanceCount = 1,
        uint firstIndex = 0, int baseVertex = 0, uint firstInstance = 0)

    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.DrawIndexed(
            indexCount: indexCount,
            instanceCount: instanceCount,
            firstIndex: firstIndex,
            baseVertex: baseVertex,
            firstInstance: firstInstance
        );
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.DrawIndexedIndirect(BufferBase, ulong)"/>
    public void DrawIndexedIndirect(
        BufferBase indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.DrawIndexedIndirect(indirectBuffer, indirectOffset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.DrawIndirect(BufferBase, ulong)"/>
    public void DrawIndirect(
        BufferBase indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.DrawIndirect(indirectBuffer, indirectOffset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.End()"/>
    public void End()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.End();
        PooledHandle<RenderPassEncoderHandle>.Return(_pooledHandle);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.EndOcclusionQuery()"/>
    public void EndOcclusionQuery()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.EndOcclusionQuery();
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.ExecuteBundle(RenderBundleBase)"/>
    public void ExecuteBundle(RenderBundleBase bundle)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ExecuteBundle(bundle);
    }
    
    /// <inheritdoc cref="RenderPassEncoderHandle.ExecuteBundles(ReadOnlySpan{RenderBundle})"/>
    public void ExecuteBundles(ReadOnlySpan<RenderBundle> bundles)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ExecuteBundles(bundles);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.InsertDebugMarker(WGPURefText)"/>
    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.InsertDebugMarker(markerLabel);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.PopDebugGroup()"/>
    public void PopDebugGroup()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.PopDebugGroup();
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.PushDebugGroup(WGPURefText)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.PushDebugGroup(groupLabel);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBindGroup(uint, BindGroupBase)"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBindGroup(groupIndex, group);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBindGroup(uint, BindGroupBase, uint)"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group, uint dynamicOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBindGroup(groupIndex, group, dynamicOffset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBindGroup(uint, BindGroupBase, ReadOnlySpan{uint})"/>
    public void SetBindGroup(uint groupIndex, BindGroupBase group, ReadOnlySpan<uint> dynamicOffsets)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBindGroup(groupIndex, group, dynamicOffsets);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBlendConstant(in Color)"/>
    public void SetBlendConstant(in Color color)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBlendConstant(color);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetIndexBuffer(BufferBase, IndexFormat, ulong, ulong)"/>
    public void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetIndexBuffer(buffer, format, offset, size);
    }

     /// <inheritdoc cref="RenderPassEncoderHandle.SetIndexBuffer(BufferBase, IndexFormat, ulong)"/>
    public void SetIndexBuffer(BufferBase buffer, IndexFormat format, ulong offset = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetIndexBuffer(buffer, format, offset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetLabel(label);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetPipeline(RenderPipelineBase)"/>
    public void SetPipeline(RenderPipelineBase pipeline)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetPipeline(pipeline);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetScissorRect(uint, uint, uint, uint)"/>
    public void SetScissorRect(uint x, uint y, uint width, uint height)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetScissorRect(x, y, width, height);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetStencilReference(uint)"/>
    public void SetStencilReference(uint reference)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetStencilReference(reference);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetVertexBuffer(uint, BufferBase, ulong, ulong)"/>
    public void SetVertexBuffer(
        uint slot, BufferBase buffer, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetVertexBuffer(slot, buffer, offset, size);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetVertexBuffer(uint, BufferBase, ulong)"/>
    public void SetVertexBuffer(
     uint slot, BufferBase buffer, ulong offset = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetVertexBuffer(slot, buffer, offset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetViewport(uint, uint, uint, uint, float, float)"/>
    public void SetViewport(
        uint x, uint y, uint width, uint height,
        float minDepth, float maxDepth)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetViewport(
            x: x,
            y: y,
            width: width,
            height: height,
            minDepth: minDepth,
            maxDepth: maxDepth
        );
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