using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using static WebGpuSharp.FFI.WebGPUMarshal;

namespace WebGpuSharp;

public sealed class RenderPassEncoder : BaseWebGpuSafeHandle<RenderPassEncoderHandle>
{
    private RenderPassEncoder(RenderPassEncoderHandle handle) : base(handle)
    {
    }

    internal static RenderPassEncoder? FromHandle(RenderPassEncoderHandle handle, bool isOwnedHandle)
    {
        var newRenderPassEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new RenderPassEncoder(handle));
        if (isOwnedHandle)
        {
            newRenderPassEncoder?.AddReference(false);
        }
        return newRenderPassEncoder;
    }

    public void Draw(
        uint vertexCount, uint instanceCount,
        uint firstVertex, uint firstInstance)
    {
        _handle.Draw(vertexCount, instanceCount, firstVertex, firstInstance);
    }

    public void End()
    {
        _handle.End();
    }

    public void SetBindGroup(uint groupIndex, BindGroup group)
    {
        _handle.SetBindGroup(groupIndex, group);
    }

    public void SetBindGroup(uint groupIndex, BindGroup group, uint dynamicOffset)
    {
        _handle.SetBindGroup(groupIndex, group, dynamicOffset);
    }

    public void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets)
    {
        _handle.SetBindGroup(groupIndex, group, dynamicOffsets);
    }

    public void SetPipeline(RenderPipeline pipeline)
    {
        _handle.SetPipeline(pipeline);
    }

    public void SetVertexBuffer(
        uint slot, Buffer buffer, ulong offset, ulong size)
    {
        _handle.SetVertexBuffer(slot, buffer, offset, size);
    }
}