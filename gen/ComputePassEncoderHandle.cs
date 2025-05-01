using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// The compute pass encoder encodes commands related to controlling the compute
/// shader stage, as issued by a ComputePipeline.
/// </summary>
public unsafe partial struct ComputePassEncoderHandle : IEquatable<ComputePassEncoderHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static ComputePassEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public ComputePassEncoderHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(ComputePassEncoderHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(ComputePassEncoderHandle left, ComputePassEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(ComputePassEncoderHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(ComputePassEncoderHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(ComputePassEncoderHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is ComputePassEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="ComputePipeline"/>.
    /// See #computing-operations for the detailed specification.
    /// </summary>
    /// <param name="workgroupCountX">X dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountY">Y dimension of the grid of workgroups to dispatch.</param>
    /// <param name="workgroupCountZ">Z dimension of the grid of workgroups to dispatch.</param>
    public void DispatchWorkgroups(uint workgroupCountX, uint workgroupCountY, uint workgroupCountZ) => WebGPU_FFI.ComputePassEncoderDispatchWorkgroups(this, workgroupCountX, workgroupCountY, workgroupCountZ);

    /// <summary>
    /// Dispatch work to be performed with the current  <see cref="ComputePipeline"/> using parameters read
    /// from a  <see cref="Buffer"/>.
    /// See #computing-operations for the detailed specification.
    /// packed block of **three 32-bit unsigned integer values (12 bytes total)**,
    /// given in the same order as the arguments for  <see cref="ComputePassEncoder.DispatchWorkgroups"/>.
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
    /// <param name="markerLabel">The label to insert.</param>
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
    /// <param name="group">Bind group to use for subsequent render or compute commands.</param>
    /// <param name="groupIndex">The index to set the bind group at.</param>
    /// <param name="dynamicOffsetCount">The number of dynamic offsets in the dynamicOffsets sequence.</param>
    public void SetBindGroup(uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets) => WebGPU_FFI.ComputePassEncoderSetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);

    /// <summary>
    /// Set debug label of this command encoder.
    /// </summary>
    /// <param name="label">The new label.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.ComputePassEncoderSetLabel(this, label);

    /// <summary>
    /// Sets the current  <see cref="ComputePipeline"/>.
    /// </summary>
    /// <param name="pipeline">The compute pipeline to use for subsequent dispatch commands.</param>
    public void SetPipeline(ComputePipelineHandle pipeline) => WebGPU_FFI.ComputePassEncoderSetPipeline(this, pipeline);

    /// <summary>
    /// Increments the reference count of the <see cref="ComputePassEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.ComputePassEncoderAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="ComputePassEncoderHandle"/>. When the reference count reaches zero, the <see cref="ComputePassEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="ComputePassEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.ComputePassEncoderRelease(this);

}
