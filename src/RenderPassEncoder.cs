using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="RenderPassEncoderHandle"/>
public readonly struct RenderPassEncoder : IEquatable<RenderPassEncoder>,
     IBindingCommands, IDebugCommands, IRenderCommands
{
    private readonly ulong _localToken;
    private readonly RenderPassEncoderHandle _originalHandle;
    private readonly ThreadLockedPooledHandle<RenderPassEncoderHandle> _pooledHandle;

    private RenderPassEncoder(ThreadLockedPooledHandle<RenderPassEncoderHandle> pooledHandle)
    {
        _originalHandle = pooledHandle.Handle;
        _localToken = pooledHandle.Token;
        _pooledHandle = pooledHandle;
    }

    internal static RenderPassEncoder FromHandle(RenderPassEncoderHandle handle)
    {
        var newRenderPassEncoderPooledHandle = ThreadLockedPooledHandle<RenderPassEncoderHandle>.Get(handle);
        return new RenderPassEncoder(newRenderPassEncoderPooledHandle);
    }

    internal RenderPassEncoderHandle GetHandle()
    {
        return _pooledHandle.GetHandle(_localToken);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.BeginOcclusionQuery(uint)"/>
    public void BeginOcclusionQuery(uint queryIndex)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.BeginOcclusionQuery(queryIndex);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.Draw(uint, uint, uint, uint)"/>
    public void Draw(
        uint vertexCount, uint instanceCount = 1,
        uint firstVertex = 0, uint firstInstance = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.Draw(vertexCount, instanceCount, firstVertex, firstInstance);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.DrawIndexed(uint, uint, uint, int, uint)"/>
    public void DrawIndexed(
        uint indexCount, uint instanceCount = 1,
        uint firstIndex = 0, int baseVertex = 0, uint firstInstance = 0)

    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.DrawIndexed(
            indexCount: indexCount,
            instanceCount: instanceCount,
            firstIndex: firstIndex,
            baseVertex: baseVertex,
            firstInstance: firstInstance
        );
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.DrawIndexedIndirect(Buffer, ulong)"/>
    public void DrawIndexedIndirect(
        Buffer indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.DrawIndexedIndirect(indirectBuffer, indirectOffset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.DrawIndirect(Buffer, ulong)"/>
    public void DrawIndirect(
        Buffer indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.DrawIndirect(indirectBuffer, indirectOffset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.End()"/>
    public void End()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.End();
        ThreadLockedPooledHandle<RenderPassEncoderHandle>.Return(_pooledHandle);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.EndOcclusionQuery()"/>
    public void EndOcclusionQuery()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.EndOcclusionQuery();
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.ExecuteBundle(RenderBundle)"/>
    public void ExecuteBundle(RenderBundle bundle)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.ExecuteBundle(bundle);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.ExecuteBundles(ReadOnlySpan{RenderBundle})"/>
    public void ExecuteBundles(ReadOnlySpan<RenderBundle> bundles)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.ExecuteBundles(bundles);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.InsertDebugMarker(WGPURefText)"/>
    public void InsertDebugMarker(WGPURefText markerLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.InsertDebugMarker(markerLabel);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.PopDebugGroup()"/>
    public void PopDebugGroup()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.PopDebugGroup();
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.PushDebugGroup(WGPURefText)"/>
    public void PushDebugGroup(WGPURefText groupLabel)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.PushDebugGroup(groupLabel);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBindGroup(uint, BindGroup)"/>
    public void SetBindGroup(uint groupIndex, BindGroup group)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetBindGroup(groupIndex, group);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBindGroup(uint, BindGroup, uint)"/>
    public void SetBindGroup(uint groupIndex, BindGroup group, uint dynamicOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetBindGroup(groupIndex, group, dynamicOffset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBindGroup(uint, BindGroup, ReadOnlySpan{uint})"/>
    public void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetBindGroup(groupIndex, group, dynamicOffsets);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetBlendConstant(in Color)"/>
    public void SetBlendConstant(in Color color)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetBlendConstant(color);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetIndexBuffer(Buffer, IndexFormat, ulong, ulong)"/>
    public void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetIndexBuffer(buffer, format, offset, size);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetIndexBuffer(Buffer, IndexFormat, ulong)"/>
    public void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetIndexBuffer(buffer, format, offset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetLabel(label);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetPipeline(RenderPipeline)"/>
    public void SetPipeline(RenderPipeline pipeline)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetPipeline(pipeline);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetScissorRect(uint, uint, uint, uint)"/>
    public void SetScissorRect(uint x, uint y, uint width, uint height)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetScissorRect(x, y, width, height);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetStencilReference(uint)"/>
    public void SetStencilReference(uint reference)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetStencilReference(reference);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetVertexBuffer(uint, Buffer, ulong, ulong)"/>
    public void SetVertexBuffer(
        uint slot, Buffer buffer, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetVertexBuffer(slot, buffer, offset, size);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetVertexBuffer(uint, Buffer, ulong)"/>
    public void SetVertexBuffer(
     uint slot, Buffer buffer, ulong offset = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetVertexBuffer(slot, buffer, offset);
    }

    /// <inheritdoc cref="RenderPassEncoderHandle.SetViewport(uint, uint, uint, uint, float, float)"/>
    public void SetViewport(
        uint x, uint y, uint width, uint height,
        float minDepth, float maxDepth)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.Handle.SetViewport(
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
        return _pooledHandle.Handle == other._pooledHandle.Handle;
    }

    public override bool Equals(object? obj)
    {
        return false;
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