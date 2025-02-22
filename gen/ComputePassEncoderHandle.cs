using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// The compute pass encoder encodes commands related to controlling the compute
/// shader stage, as issued by a ComputePipeline.
/// </summary>
public readonly unsafe partial struct ComputePassEncoderHandle : IEquatable<ComputePassEncoderHandle>
{
    private readonly nuint _ptr;
    public static ComputePassEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public ComputePassEncoderHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(ComputePassEncoderHandle handle) => handle._ptr;

    public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr == right._ptr;

    public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr != right._ptr;

    public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(ComputePassEncoderHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(ComputePassEncoderHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(ComputePassEncoderHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is ComputePassEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="WebGpuSharp.ComputePipeline"/>.
    /// See #computing-operations for the detailed specification.
    /// </summary>
    /// <param name="workgroupCountX">X dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountY">Y dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountZ">Z dimension of the grid of workgroups to dispatch.</param>
    public void DispatchWorkgroups(uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ) => WebGPU_FFI.ComputePassEncoderDispatchWorkgroups(this, workgroupCountX, workgroupCountY, workgroupCountZ);

    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="WebGpuSharp.ComputePipeline"/> using parameters read
    /// from a  <see cref="WebGpuSharp.Buffer"/>.
    /// See #computing-operations for the detailed specification.
    /// packed block of **three 32-bit unsigned integer values (12 bytes total)**,
    /// given in the same order as the arguments for  <see cref="WebGpuSharp.ComputePassEncoder.DispatchWorkgroups"/>.
    /// For example:
    /// </summary>
    /// <param name="indirectBuffer">Buffer containing the indirect dispatch parameters.</param>
    /// <param name="indirectOffset">Offset in bytes into <paramref name="indirectBuffer"/> where the dispatch data begins.</param>
    public void DispatchWorkgroupsIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.ComputePassEncoderDispatchWorkgroupsIndirect(this, indirectBuffer, indirectOffset);

    /// <summary>
    /// Completes recording of the compute pass commands sequence.
    /// </summary>
    public void End() => WebGPU_FFI.ComputePassEncoderEnd(this);

    /// <summary>
    /// Marks a point in a stream of commands with a label.
    /// </summary>
    public void InsertDebugMarker(StringViewFFI markerLabel) => WebGPU_FFI.ComputePassEncoderInsertDebugMarker(this, markerLabel);

    /// <summary>
    /// Ends the labeled debug group most recently started by <see cref="PushDebugGroup" />.
    /// </summary>
    public void PopDebugGroup() => WebGPU_FFI.ComputePassEncoderPopDebugGroup(this);

    /// <summary>
    /// Begins a labeled debug group containing subsequent commands.
    /// </summary>
    /// <param name="groupLabel">The label to use for the debug group.</param>
    public void PushDebugGroup(StringViewFFI groupLabel) => WebGPU_FFI.ComputePassEncoderPushDebugGroup(this, groupLabel);

    /// <summary>
    /// Sets the current GPUBindGroup for the given index.
    /// </summary>
    /// <param name="dynamicOffsets">
    /// a sequence containing buffer offsets in bytes for each
    /// entry in bindGroup marked as Buffer.HasDynamicOffset, ordered by
    /// BindGroupLayoutEntry.Binding.
    /// </param>
    /// <param name="dynamicOffsetCount">The number of dynamic offsets in the dynamicOffsets sequence.</param>
    /// <param name="bindGroup">Bind group to use for subsequent render or compute commands.</param>
    /// <param name="index">The index to set the bind group at.</param>
    public void SetBindGroup(uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets) => WebGPU_FFI.ComputePassEncoderSetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);

    /// <summary>
    /// Set debug label of this command encoder.
    /// </summary>
    /// <param name="label">The new label.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.ComputePassEncoderSetLabel(this, label);

    /// <summary>
    /// Sets the current  <see cref="WebGpuSharp.ComputePipeline"/>.
    /// </summary>
    /// <param name="pipeline">The compute pipeline to use for subsequent dispatch commands.</param>
    public void SetPipeline(ComputePipelineHandle pipeline) => WebGPU_FFI.ComputePassEncoderSetPipeline(this, pipeline);

    public void AddRef() => WebGPU_FFI.ComputePassEncoderAddRef(this);

    public void Release() => WebGPU_FFI.ComputePassEncoderRelease(this);

}
