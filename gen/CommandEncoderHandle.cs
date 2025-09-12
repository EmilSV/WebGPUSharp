using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Encodes a series of GPU operations. A command encoder can record RenderPasses,
/// ComputePasses, and transfer operations between driver-managed resources like Buffers and
/// Textures. When finished recording, call CommandEncoder.Finish() to obtain a
/// CommandBuffer which may be submitted for execution.
/// </summary>
public unsafe partial struct CommandEncoderHandle : IEquatable<CommandEncoderHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static CommandEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public CommandEncoderHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(CommandEncoderHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(CommandEncoderHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(CommandEncoderHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(CommandEncoderHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is CommandEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Begins encoding a compute pass described by descriptor.
    /// </summary>
    /// <param name="descriptor">The descriptor for the compute pass.</param>
    /// <returns>A ComputePassEncoder which encodes the compute pass.</returns>
    public ComputePassEncoderHandle BeginComputePass(ComputePassDescriptorFFI* descriptor) => WebGPU_FFI.CommandEncoderBeginComputePass(this, descriptor);

    /// <summary>
    /// Begins encoding a render pass described by <paramref name="descriptor"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="RenderPassEncoder"/> to create.</param>
    public RenderPassEncoderHandle BeginRenderPass(RenderPassDescriptorFFI* descriptor) => WebGPU_FFI.CommandEncoderBeginRenderPass(this, descriptor);

    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that fills a sub-region of a
    ///  <see cref="Buffer"/> with zeros.
    /// </summary>
    /// <param name="buffer">The  <see cref="Buffer"/> to clear.</param>
    /// <param name="offset">Offset in bytes into <paramref name="buffer"/> where the sub-region to clear begins.</param>
    /// <param name="size">Size in bytes of the sub-region to clear. Defaults to the size of the buffer minus <paramref name="offset"/>.</param>
    public void ClearBuffer(BufferHandle buffer, ulong offset, ulong size) => WebGPU_FFI.CommandEncoderClearBuffer(this, buffer, offset, size);

    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="Buffer"/> to a sub-region of another  <see cref="Buffer"/>.
    /// </summary>
    /// <param name="source">The  <see cref="Buffer"/> to copy from.</param>
    /// <param name="sourceOffset">Offset in bytes into <paramref name="source"/> to begin copying from.</param>
    /// <param name="destination">The  <see cref="Buffer"/> to copy to.</param>
    /// <param name="destinationOffset">Offset in bytes into <paramref name="destination"/> to place the copied data.</param>
    /// <param name="size">Bytes to copy.</param>
    public void CopyBufferToBuffer(BufferHandle source, ulong sourceOffset, BufferHandle destination, ulong destinationOffset, ulong size) => WebGPU_FFI.CommandEncoderCopyBufferToBuffer(this, source, sourceOffset, destination, destinationOffset, size);

    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="Buffer"/> to a sub-region of one or multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source buffer.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresource.
    /// <paramref name="copySize"/>:
    /// </param>
    /// <param name="copySize">specifies the width, height, and depth/array layer count of the copied data.</param>
    public void CopyBufferToTexture(TexelCopyBufferInfoFFI* source, TexelCopyTextureInfoFFI* destination, Extent3D* copySize) => WebGPU_FFI.CommandEncoderCopyBufferToTexture(this, source, destination, copySize);

    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of one or
    /// multiple continuous texture subresources to a sub-region of a  <see cref="Buffer"/>.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination buffer.
    /// <paramref name="copySize"/>:
    /// </param>
    /// <param name="copySize">specifies the width, height, and depth/array layer count of the copied data.</param>
    public void CopyTextureToBuffer(TexelCopyTextureInfoFFI* source, TexelCopyBufferInfoFFI* destination, Extent3D* copySize) => WebGPU_FFI.CommandEncoderCopyTextureToBuffer(this, source, destination, copySize);

    /// <summary>
    /// Encode a command into the  <see cref="CommandEncoder"/> that copies data from a sub-region of one
    /// or multiple contiguous texture subresources to another sub-region of one or
    /// multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresources.
    /// <paramref name="copySize"/>:
    /// </param>
    /// <param name="copySize">specifies the width, height, and depth/array layer count of the copied data.</param>
    public void CopyTextureToTexture(TexelCopyTextureInfoFFI* source, TexelCopyTextureInfoFFI* destination, Extent3D* copySize) => WebGPU_FFI.CommandEncoderCopyTextureToTexture(this, source, destination, copySize);

    /// <summary>
    /// Completes recording of the commands sequence and returns a corresponding  <see cref="CommandBuffer"/>.
    /// </summary>
    /// <param name="descriptor">The descriptor.</param>
    public CommandBufferHandle Finish(CommandBufferDescriptorFFI* descriptor) => WebGPU_FFI.CommandEncoderFinish(this, descriptor);

    /// <summary>
    /// Marks a point in a stream of commands with a label.
    /// </summary>
    /// <param name="markerLabel">The label to insert.</param>
    public void InsertDebugMarker(StringViewFFI markerLabel) => WebGPU_FFI.CommandEncoderInsertDebugMarker(this, markerLabel);

    /// <summary>
    /// Ends the labeled debug group most recently started by <see cref="CommandEncoderHandle.PushDebugGroup">pushDebugGroup()</see>.
    /// </summary>
    public void PopDebugGroup() => WebGPU_FFI.CommandEncoderPopDebugGroup(this);

    /// <summary>
    /// Begins a labeled debug group containing subsequent commands.
    /// </summary>
    /// <param name="groupLabel">The label for the command group.</param>
    public void PushDebugGroup(StringViewFFI groupLabel) => WebGPU_FFI.CommandEncoderPushDebugGroup(this, groupLabel);

    /// <summary>
    /// Resolves query results from a  <see cref="QuerySet"/> out into a range of a  <see cref="Buffer"/>.
    /// </summary>
    /// <param name="destinationOffset">The offset, in bytes, from the start of the buffer to start writing the query values at.</param>
    /// <param name="queryCount">The number of queries to be copied over to the buffer, starting from <paramref name="firstQuery" /></param>
    /// <param name="firstQuery">The index number of the first query value to be copied over to the buffer.</param>
    /// <param name="querySet">The query set.</param>
    /// <param name="destination">The buffer to copy the query values to.</param>
    public void ResolveQuerySet(QuerySetHandle querySet, uint firstQuery, uint queryCount, BufferHandle destination, ulong destinationOffset) => WebGPU_FFI.CommandEncoderResolveQuerySet(this, querySet, firstQuery, queryCount, destination, destinationOffset);

    /// <summary>
    /// Set debug label of this command encoder.
    /// </summary>
    /// <param name="label">The new label.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.CommandEncoderSetLabel(this, label);

    [Obsolete("", false)]
    public void WriteTimestamp(QuerySetHandle querySet, uint queryIndex) => WebGPU_FFI.CommandEncoderWriteTimestamp(this, querySet, queryIndex);

    /// <summary>
    /// Increments the reference count of the <see cref="CommandEncoderHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.CommandEncoderAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="CommandEncoderHandle"/>. When the reference count reaches zero, the <see cref="CommandEncoderHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="CommandEncoderHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.CommandEncoderRelease(this);

}
