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

    public void BeginOcclusionQuery(uint queryIndex)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.BeginOcclusionQuery(queryIndex);
    }

    public void Draw(
        uint vertexCount, uint instanceCount = 1,
        uint firstVertex = 0, uint firstInstance = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.Draw(vertexCount, instanceCount, firstVertex, firstInstance);
    }



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

    public void DrawIndexedIndirect(
        Buffer indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.DrawIndexedIndirect(indirectBuffer, indirectOffset);
    }

    public void DrawIndirect(
        Buffer indirectBuffer, ulong indirectOffset)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.DrawIndirect(indirectBuffer, indirectOffset);
    }


    public void End()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.End();
        PooledHandle<RenderPassEncoderHandle>.Return(_pooledHandle);
    }

    public void EndOcclusionQuery()
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.EndOcclusionQuery();
    }

    public void ExecuteBundle(RenderBundle bundle)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ExecuteBundle(bundle);
    }

    public void ExecuteBundles(ReadOnlySpan<RenderBundle> bundles)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.ExecuteBundles(bundles);
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

    public void SetBlendConstant(in Color color)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetBlendConstant(color);
    }

    public void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetIndexBuffer(buffer, format, offset, size);
    }


    public void SetLabel(WGPURefText label)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetLabel(label);
    }

    public void SetPipeline(RenderPipeline pipeline)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetPipeline(pipeline);
    }

    public void SetScissorRect(uint x, uint y, uint width, uint height)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetScissorRect(x, y, width, height);
    }

    public void SetStencilReference(uint reference)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetStencilReference(reference);
    }


    public void SetVertexBuffer(
        uint slot, Buffer buffer, ulong offset, ulong size)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetVertexBuffer(slot, buffer, offset, size);
    }

    public void SetVertexBuffer(
     uint slot, Buffer buffer, ulong offset = 0)
    {
        _pooledHandle.VerifyToken(_localToken);
        _pooledHandle.handle.SetVertexBuffer(slot, buffer, offset, buffer.GetSize() - offset);
    }

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