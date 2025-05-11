using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Describes how a buffer is expected to be used.
/// </summary>
[Flags]
public enum BufferUsage : ulong
{
    /// <summary>
    /// No flags set. This is the default value.
    /// </summary>
    None = 0,
    /// <summary>
    /// The buffer can be mapped for reading, for example when calling MapAsync() with
    /// a mode of GPUMapMode.READ. This flag may only be combined with
    /// GPUBufferUsage.COPY_DST.
    /// </summary>
    MapRead = 1,
    /// <summary>
    /// Allow a buffer to be mapped for writing using <see cref="Buffer.MapAsync" /> +<see cref="Buffer.GetMappedRange" />. This does not include creating a buffer with MappedAtCreation set.
    /// </summary>
    MapWrite = 2,
    /// <summary>
    /// Allow a buffer to be the source buffer for a <see cref="CommandEncoder.CopyBufferToBuffer" /> or <see cref="CommandEncoder.CopyBufferToTexture" /> operation.
    /// </summary>
    CopySrc = 4,
    /// <summary>
    /// Allow a buffer to be the destination buffer for a <see cref="CommandEncoder.CopyBufferToBuffer" />, <see cref="CommandEncoder.CopyTextureToBuffer" />, <see cref="CommandEncoder.ClearBuffer" /> or <see cref="Queue.WriteBuffer" /> operation.
    /// </summary>
    CopyDst = 8,
    /// <summary>
    /// Allow a buffer to be the index buffer in a draw operation.
    /// </summary>
    Index = 16,
    /// <summary>
    /// Allow a buffer to be the vertex buffer in a draw operation.
    /// </summary>
    Vertex = 32,
    /// <summary>
    /// Allow a buffer to be a <see cref="BufferBindingType.Uniform" /> inside a bind group.
    /// </summary>
    Uniform = 64,
    /// <summary>
    /// Allow a buffer to be a <see cref="BufferBindingType.Storage" /> inside a bind group.
    /// </summary>
    Storage = 128,
    /// <summary>
    /// Allow a buffer to be the indirect buffer in an indirect draw call.
    /// </summary>
    Indirect = 256,
    /// <summary>
    /// Allow a buffer to be the destination buffer for a <see cref="CommandEncoder.ResolveQuerySet" /> operation
    /// </summary>
    QueryResolve = 512,
}
