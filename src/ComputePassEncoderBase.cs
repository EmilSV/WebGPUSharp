using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public abstract class ComputePassEncoderBase :
    WebGPUHandleWrapperBase<ComputePassEncoderHandle>
{
    public void DispatchWorkgroups(uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ) =>
        Handle.DispatchWorkgroups(workgroupCountX, workgroupCountY, workgroupCountZ);

    public void DispatchWorkgroupsIndirect(Buffer indirectBuffer, ulong indirectOffset) =>
        Handle.DispatchWorkgroupsIndirect(indirectBuffer, indirectOffset);

    public void End() => Handle.End();

    public void InsertDebugMarker(WGPURefText markerLabel) =>
        Handle.InsertDebugMarker(markerLabel);

    public void PopDebugGroup() =>
        Handle.PopDebugGroup();

    public void PushDebugGroup(WGPURefText groupLabel) =>
        Handle.PushDebugGroup(groupLabel);


    public void SetBindGroup(
        uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets) =>
        Handle.SetBindGroup(groupIndex, group, dynamicOffsets);

    public void SetLabel(WGPURefText label) =>
        Handle.SetLabel(label);

    public void SetPipeline(ComputePipeline pipeline) =>
        Handle.SetPipeline(pipeline);
}