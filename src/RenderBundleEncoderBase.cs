using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class RenderBundleEncoderBase :
    WebGPUHandleWrapperBase<RenderBundleEncoderHandle>
{
    public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) =>
        Handle.Draw(vertexCount, instanceCount, firstVertex, firstInstance);

    public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance) =>
        Handle.DrawIndexed(indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

    public void DrawIndexedIndirect(Buffer indirectBuffer, ulong indirectOffset) =>
        Handle.DrawIndexedIndirect(indirectBuffer, indirectOffset);

    public void DrawIndirect(Buffer indirectBuffer, ulong indirectOffset) =>
        Handle.DrawIndirect(indirectBuffer, indirectOffset);

    public RenderBundle? Finish(in RenderBundleDescriptor descriptor) =>
        Handle.Finish(descriptor).ToSafeHandle(true);

    public void InsertDebugMarker(WGPURefText label) =>
        Handle.InsertDebugMarker(label);

    public void PopDebugGroup() =>
        Handle.PopDebugGroup();

    public void PushDebugGroup(WGPURefText groupLabel) =>
        Handle.PushDebugGroup(groupLabel);

    public void SetBindGroup(uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffset) =>
        Handle.SetBindGroup(groupIndex, group, dynamicOffset);

    public void SetIndexBuffer(Buffer buffer, IndexFormat format, ulong offset, ulong size) =>
        Handle.SetIndexBuffer(buffer, format, offset, size);

    public void SetLabel(WGPURefText label) =>
        Handle.SetLabel(label);

    public void SetPipeline(RenderPipeline pipeline) =>
        Handle.SetPipeline(pipeline);

    public void SetVertexBuffer(uint slot, Buffer buffer, ulong offset, ulong size) =>
        Handle.SetVertexBuffer(slot, buffer, offset, size);

}