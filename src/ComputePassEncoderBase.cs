using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


/// <inheritdoc cref="ComputePassEncoderHandle"/>
public abstract class ComputePassEncoderBase :
    WebGPUHandleWrapperBase<ComputePassEncoderHandle>
{
    /// <inheritdoc cref="ComputePassEncoderHandle.DispatchWorkgroups(uint, uint, uint)"/>
    public void DispatchWorkgroups(uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ) =>
        Handle.DispatchWorkgroups(workgroupCountX, workgroupCountY, workgroupCountZ);

    /// <inheritdoc cref="ComputePassEncoderHandle.DispatchWorkgroupsIndirect(Buffer, ulong)"/>
    public void DispatchWorkgroupsIndirect(Buffer indirectBuffer, ulong indirectOffset) =>
        Handle.DispatchWorkgroupsIndirect(indirectBuffer, indirectOffset);

    /// <inheritdoc cref="ComputePassEncoderHandle.End()"/>
    public void End() => Handle.End();

    /// <inheritdoc cref="ComputePassEncoderHandle.InsertDebugMarker(WGPURefText)"/>
    public void InsertDebugMarker(WGPURefText markerLabel) =>
        Handle.InsertDebugMarker(markerLabel);

    /// <inheritdoc cref="ComputePassEncoderHandle.PopDebugGroup()"/>
    public void PopDebugGroup() =>
        Handle.PopDebugGroup();

    /// <inheritdoc cref="ComputePassEncoderHandle.PushDebugGroup(WGPURefText)"/>
    public void PushDebugGroup(WGPURefText groupLabel) =>
        Handle.PushDebugGroup(groupLabel);

    /// <inheritdoc cref="ComputePassEncoderHandle.SetBindGroup(uint, BindGroup, ReadOnlySpan{uint})"/>
    public void SetBindGroup(
        uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets) =>
        Handle.SetBindGroup(groupIndex, group, dynamicOffsets);

    /// <inheritdoc cref="ComputePassEncoderHandle.SetLabel(WGPURefText)"/>
    public void SetLabel(WGPURefText label) =>
        Handle.SetLabel(label);

    /// <inheritdoc cref="ComputePassEncoderHandle.SetPipeline(ComputePipeline)"/>
    public void SetPipeline(ComputePipeline pipeline) =>
        Handle.SetPipeline(pipeline);
}