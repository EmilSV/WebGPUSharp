using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Encodes a series of GPU operations into a reusable “render bundle”
/// 
/// It only supports a handful of render commands, but it makes them reusable.
/// It can be created with
/// <see cref="DeviceHandle.CreateRenderBundleEncoder"></see> It can be executed onto a CommandEncoder using <see cref="FFI.RenderPassHandle.ExecuteBundles"></see>
/// .
/// 
/// Executing a RenderBundle is often more efficient than issuing the underlying commands manually.
/// </summary>
public unsafe partial struct RenderBundleEncoderHandle : IEquatable<RenderBundleEncoderHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static RenderBundleEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderBundleEncoderHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(RenderBundleEncoderHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(RenderBundleEncoderHandle left, RenderBundleEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(RenderBundleEncoderHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(RenderBundleEncoderHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(RenderBundleEncoderHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is RenderBundleEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Draws primitives from the active vertex buffer(s).
    /// 
    /// The active vertex buffers can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer"></see>.
    /// Does not use an Index Buffer.
    /// If you need this see <see cref="DrawIndexed"></see>.
    /// 
    /// Errors if vertices Range is outside of the range of the vertices range of any set vertex buffer.
    /// </summary>
    /// <param name="firstVertex">The index of the first vertex to draw.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="vertexCount">The number of vertices to draw.</param>
    /// <param name="firstInstance">The index of the first instance to draw.</param>
    public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) => WebGPU_FFI.RenderBundleEncoderDraw(this, vertexCount, instanceCount, firstVertex, firstInstance);

    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffer(s).
    /// 
    /// The active index buffer can be set with <see cref="RenderBundleEncoderHandle.SetIndexBuffer" />.
    /// The active vertex buffer(s) can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer" />.
    /// 
    /// Errors if indices Range is outside of the range of the indices range of any set index buffer.
    /// </summary>
    /// <param name="firstInstance">The index of the first instance to draw.</param>
    /// <param name="baseVertex">The value added to the vertex index before indexing into the vertex buffer.</param>
    /// <param name="firstIndex">The index of the first index to draw.</param>
    /// <param name="instanceCount">The number of instances to draw.</param>
    /// <param name="indexCount">The number of indices to draw.</param>
    public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, int baseVertex, uint firstInstance) => WebGPU_FFI.RenderBundleEncoderDrawIndexed(this, indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

    /// <summary>
    /// Draws indexed primitives using the active index buffer and the active vertex buffers, based on the contents of the indirectBuffer.
    /// 
    /// The active index buffer can be set with RenderBundleEncoder.SetIndexBuffer, while the active vertex buffers can be set with RenderBundleEncoder.SetVertexBuffer.
    /// </summary>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters.</param>
    public void DrawIndexedIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderBundleEncoderDrawIndexedIndirect(this, indirectBuffer, indirectOffset);

    /// <summary>
    /// Draws primitives from the active vertex buffer(s) based on the contents of the indirectBuffer.
    /// 
    /// The active vertex buffers can be set with <see cref="RenderBundleEncoderHandle.SetVertexBuffer" />.
    /// </summary>
    /// <param name="indirectOffset">Offset in bytes into indirectBuffer where the drawing data begins.</param>
    /// <param name="indirectBuffer">Buffer containing the indirect drawIndexed parameters.</param>
    public void DrawIndirect(BufferHandle indirectBuffer, ulong indirectOffset) => WebGPU_FFI.RenderBundleEncoderDrawIndirect(this, indirectBuffer, indirectOffset);

    /// <summary>
    /// Completes recording of the render bundle commands sequence.
    /// </summary>
    /// <param name="descriptor">The descriptor to use for the RenderBundle.</param>
    /// <returns>A new RenderBundleHandle.</returns>
    public RenderBundleHandle Finish(RenderBundleDescriptorFFI* descriptor) => WebGPU_FFI.RenderBundleEncoderFinish(this, descriptor);

    /// <summary>
    /// Inserts a debug marker into the command stream.
    /// </summary>
    /// <param name="markerLabel">The label of the debug marker.</param>
    public void InsertDebugMarker(StringViewFFI markerLabel) => WebGPU_FFI.RenderBundleEncoderInsertDebugMarker(this, markerLabel);

    /// <summary>
    /// Stops command recording and creates debug group.
    /// </summary>
    public void PopDebugGroup() => WebGPU_FFI.RenderBundleEncoderPopDebugGroup(this);

    /// <summary>
    /// Start record commands and group it into debug marker group.
    /// </summary>
    /// <param name="groupLabel">The label of the debug marker group.</param>
    public void PushDebugGroup(StringViewFFI groupLabel) => WebGPU_FFI.RenderBundleEncoderPushDebugGroup(this, groupLabel);

    /// <summary>
    /// Sets the active bind group for a given bind group index.
    /// The bind group layout in the active pipeline when any Draw() function is called must match the layout of this bind group.
    /// 
    /// If the bind group have dynamic offsets, provide them in the binding order.
    /// </summary>
    /// <param name="dynamicOffsets">A square containing buffer offsets in bytes for each entry in bindGroup marked as buffer.HasDynamicOffset, ordered by BindGroupLayoutEntry.Binding.</param>
    /// <param name="dynamicOffsetCount">The number of offsets in dynamicOffsets.</param>
    /// <param name="group">Bind group to use for subsequent render or compute commands.</param>
    /// <param name="groupIndex">The index to set the bind group at.</param>
    public void SetBindGroup(uint groupIndex, BindGroupHandle group, nuint dynamicOffsetCount, uint* dynamicOffsets) => WebGPU_FFI.RenderBundleEncoderSetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);

    /// <summary>
    /// Sets the active index buffer.
    /// 
    /// Subsequent calls to DrawIndexed on this RenderBundleEncoderHandle will use buffer as the source index buffer.
    /// </summary>
    /// <param name="size">The size in bytes of the index buffer.</param>
    /// <param name="offset">The offset in bytes from the start of the buffer to the first index.</param>
    /// <param name="format">The format of the index buffer.</param>
    /// <param name="buffer">The index buffer to use.</param>
    public void SetIndexBuffer(BufferHandle buffer, IndexFormat format, ulong offset, ulong size) => WebGPU_FFI.RenderBundleEncoderSetIndexBuffer(this, buffer, format, offset, size);

    /// <summary>
    /// Sets the debug label of the RenderBundleEncoderHandle.
    /// </summary>
    /// <param name="label">The new debug label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderBundleEncoderSetLabel(this, label);

    /// <summary>
    /// Sets the current RenderPipeline.
    /// </summary>
    /// <param name="pipeline">The render pipeline to use for subsequent drawing commands.</param>
    public void SetPipeline(RenderPipelineHandle pipeline) => WebGPU_FFI.RenderBundleEncoderSetPipeline(this, pipeline);

    /// <summary>
    /// Assign a vertex buffer to a slot.
    /// 
    /// Subsequent calls to draw and draw_indexed on this RenderBundleEncoderHandle will use buffer as one of the source vertex buffers.
    /// 
    /// The slot refers to the index of the matching descriptor in VertexState.Buffers.
    /// </summary>
    /// <param name="offset">Offset in bytes into buffer where the vertex data begins.</param>
    /// <param name="buffer">Buffer containing vertex data to use for subsequent drawing commands.</param>
    /// <param name="slot">The vertex buffer slot to set the vertex buffer for.</param>
    /// <param name="size">Size in bytes of the vertex data in buffer. Defaults to the size of the buffer minus the offset.</param>
    public void SetVertexBuffer(uint slot, BufferHandle buffer, ulong offset, ulong size) => WebGPU_FFI.RenderBundleEncoderSetVertexBuffer(this, slot, buffer, offset, size);

    /// <summary>
    /// Increments the reference count of the <see cref="RenderBundleEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.RenderBundleEncoderAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="RenderBundleEncoderHandle"/>. When the reference count reaches zero, the <see cref="RenderBundleEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="RenderBundleEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.RenderBundleEncoderRelease(this);

}
