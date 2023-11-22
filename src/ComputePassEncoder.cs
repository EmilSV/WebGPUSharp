using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;


public sealed class ComputePassEncoder :
    BaseWebGpuSafeHandle<ComputePassEncoder, ComputePassEncoderHandle>
{
    private ComputePassEncoder(ComputePassEncoderHandle handle) : base(handle)
    {
    }

    internal static ComputePassEncoder? FromHandle(ComputePassEncoderHandle handle, bool isOwnedHandle)
    {
        var newComputePassEncoder = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new ComputePassEncoder(handle));
        if (isOwnedHandle)
        {
            newComputePassEncoder?.AddReference(false);
        }
        return newComputePassEncoder;
    }

    public void DispatchWorkgroups(uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ) =>
        _handle.DispatchWorkgroups(workgroupCountX, workgroupCountY, workgroupCountZ);

    public void DispatchWorkgroupsIndirect(Buffer indirectBuffer, ulong indirectOffset) =>
        _handle.DispatchWorkgroupsIndirect(indirectBuffer, indirectOffset);

    public void End() => _handle.End();

    public void InsertDebugMarker(WGPURefText markerLabel) =>
        _handle.InsertDebugMarker(markerLabel);

    public void PopDebugGroup() =>
        _handle.PopDebugGroup();

    public void PushDebugGroup(WGPURefText groupLabel) =>
        _handle.PushDebugGroup(groupLabel);


    public void SetBindGroup(
        uint groupIndex, BindGroup group, ReadOnlySpan<uint> dynamicOffsets) =>
        _handle.SetBindGroup(groupIndex, group, dynamicOffsets);

    public void SetLabel(WGPURefText label) =>
        _handle.SetLabel(label);

    public void SetPipeline(ComputePipeline pipeline) =>
        _handle.SetPipeline(pipeline);
}