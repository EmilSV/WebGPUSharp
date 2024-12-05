using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct CommandEncoderHandle : IEquatable<CommandEncoderHandle>
{
    private readonly nuint _ptr;
    public static CommandEncoderHandle Null
    {
        get => new(nuint.Zero);
    }

    public CommandEncoderHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(CommandEncoderHandle handle) => handle._ptr;

    public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr == right._ptr;

    public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle right) => left._ptr != right._ptr;

    public static bool operator ==(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(CommandEncoderHandle left, CommandEncoderHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(CommandEncoderHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(CommandEncoderHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(CommandEncoderHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is CommandEncoderHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public ComputePassEncoderHandle BeginComputePass(ComputePassDescriptorFFI* descriptor) => WebGPU_FFI.CommandEncoderBeginComputePass(this, descriptor);

    /// <summary>
    /// Begins encoding a render pass described by <paramref name="descriptor"/>.
    /// </summary>
    /// <param name="descriptor">Description of the  <see cref="WebGpuSharp.RenderPassEncoder"/> to create.</param>
    public RenderPassEncoderHandle BeginRenderPass(RenderPassDescriptorFFI* descriptor) => WebGPU_FFI.CommandEncoderBeginRenderPass(this, descriptor);

    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that fills a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> with zeros.
    /// </summary>
    /// <param name="buffer">The  <see cref="WebGpuSharp.Buffer"/> to clear.</param>
    /// <param name="offset">Offset in bytes into <paramref name="buffer"/> where the sub-region to clear begins.</param>
    /// <param name="size">Size in bytes of the sub-region to clear. Defaults to the size of the buffer minus <paramref name="offset"/>.</param>
    public void ClearBuffer(BufferHandle buffer, ulong offset, ulong size) => WebGPU_FFI.CommandEncoderClearBuffer(this, buffer, offset, size);

    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> to a sub-region of another  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="source">The  <see cref="WebGpuSharp.Buffer"/> to copy from.</param>
    /// <param name="sourceOffset">Offset in bytes into <paramref name="source"/> to begin copying from.</param>
    /// <param name="destination">The  <see cref="WebGpuSharp.Buffer"/> to copy to.</param>
    /// <param name="destinationOffset">Offset in bytes into <paramref name="destination"/> to place the copied data.</param>
    /// <param name="size">Bytes to copy.</param>
    public void CopyBufferToBuffer(BufferHandle source, ulong sourceOffset, BufferHandle destination, ulong destinationOffset, ulong size) => WebGPU_FFI.CommandEncoderCopyBufferToBuffer(this, source, sourceOffset, destination, destinationOffset, size);

    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of a
    ///  <see cref="WebGpuSharp.Buffer"/> to a sub-region of one or multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source buffer.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresource.
    /// <paramref name="copySize"/>:
    /// </param>
    public void CopyBufferToTexture(ImageCopyBufferFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize) => WebGPU_FFI.CommandEncoderCopyBufferToTexture(this, source, destination, copySize);

    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of one or
    /// multiple continuous texture subresources to a sub-region of a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination buffer.
    /// <paramref name="copySize"/>:
    /// </param>
    public void CopyTextureToBuffer(ImageCopyTextureFFI* source, ImageCopyBufferFFI* destination, Extent3D* copySize) => WebGPU_FFI.CommandEncoderCopyTextureToBuffer(this, source, destination, copySize);

    /// <summary>
    /// Encode a command into the  <see cref="WebGpuSharp.CommandEncoder"/> that copies data from a sub-region of one
    /// or multiple contiguous texture subresources to another sub-region of one or
    /// multiple continuous texture subresources.
    /// </summary>
    /// <param name="source">Combined with <paramref name="copySize"/>, defines the region of the source texture subresources.</param>
    /// <param name="destination">
    /// Combined with <paramref name="copySize"/>, defines the region of the destination texture subresources.
    /// <paramref name="copySize"/>:
    /// </param>
    public void CopyTextureToTexture(ImageCopyTextureFFI* source, ImageCopyTextureFFI* destination, Extent3D* copySize) => WebGPU_FFI.CommandEncoderCopyTextureToTexture(this, source, destination, copySize);

    /// <summary>
    /// Completes recording of the commands sequence and returns a corresponding  <see cref="WebGpuSharp.CommandBuffer"/>.
    /// </summary>
    public CommandBufferHandle Finish(CommandBufferDescriptorFFI* descriptor) => WebGPU_FFI.CommandEncoderFinish(this, descriptor);

    public void InjectValidationError(StringViewFFI message) => WebGPU_FFI.CommandEncoderInjectValidationError(this, message);

    public void InsertDebugMarker(StringViewFFI markerLabel) => WebGPU_FFI.CommandEncoderInsertDebugMarker(this, markerLabel);

    public void PopDebugGroup() => WebGPU_FFI.CommandEncoderPopDebugGroup(this);

    public void PushDebugGroup(StringViewFFI groupLabel) => WebGPU_FFI.CommandEncoderPushDebugGroup(this, groupLabel);

    /// <summary>
    /// Resolves query results from a  <see cref="WebGpuSharp.QuerySet"/> out into a range of a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    public void ResolveQuerySet(QuerySetHandle querySet, uint firstQuery, uint queryCount, BufferHandle destination, ulong destinationOffset) => WebGPU_FFI.CommandEncoderResolveQuerySet(this, querySet, firstQuery, queryCount, destination, destinationOffset);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.CommandEncoderSetLabel(this, label);

    public void WriteBuffer(BufferHandle buffer, ulong bufferOffset, byte* data, ulong size) => WebGPU_FFI.CommandEncoderWriteBuffer(this, buffer, bufferOffset, data, size);

    public void WriteTimestamp(QuerySetHandle querySet, uint queryIndex) => WebGPU_FFI.CommandEncoderWriteTimestamp(this, querySet, queryIndex);

    public void AddRef() => WebGPU_FFI.CommandEncoderAddRef(this);

    public void Release() => WebGPU_FFI.CommandEncoderRelease(this);

}
