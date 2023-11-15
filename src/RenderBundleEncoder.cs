using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public class RenderBundleEncoder : BaseWebGpuSafeHandle<RenderBundleEncoder, RenderBundleEncoderHandle>
{
    private RenderBundleEncoder(RenderBundleEncoderHandle handle) : base(handle)
    {
    }

    internal static RenderBundleEncoder? FromHandle(RenderBundleEncoderHandle handle, bool isOwnedHandle)
    {
        var newRenderBundleEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new RenderBundleEncoder(handle));
        if (isOwnedHandle)
        {
            newRenderBundleEncoder?.AddReference(false);
        }
        return newRenderBundleEncoder;
    }

    public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) =>
        _handle.Draw(vertexCount, instanceCount, firstVertex, firstInstance);

    public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance) =>
        _handle.DrawIndexed(indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

    public void DrawIndexedIndirect(Buffer indirectBuffer, ulong indirectOffset) =>
        _handle.DrawIndexedIndirect(indirectBuffer, indirectOffset);

    public void DrawIndirect(Buffer indirectBuffer, ulong indirectOffset) =>
        _handle.DrawIndirect(indirectBuffer, indirectOffset);

    public RenderBundleHandle Finish(in RenderBundleDescriptor descriptor) =>
        _handle.Finish(descriptor);

    public void InsertDebugMarker(WGPURefText label) =>
        _handle.InsertDebugMarker(label);

    public void PopDebugGroup() =>
        _handle.PopDebugGroup();

    public void PushDebugGroup(WGPURefText groupLabel) =>
        _handle.PushDebugGroup(groupLabel);

    public void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffset) =>
        _handle.SetBindGroup(groupIndex, group, dynamicOffset);

    public void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset, ulong size) =>
        _handle.SetIndexBuffer(buffer, format, offset, size);

    public void SetLabel(WGPURefText label) =>
        _handle.SetLabel(label);

    public void SetPipeline(RenderPipeline pipeline) =>
        _handle.SetPipeline(pipeline);

    public void SetVertexBuffer(uint slot, Buffer buffer, ulong offset, ulong size) =>
        _handle.SetVertexBuffer(slot, buffer, offset, size);

}