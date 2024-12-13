using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct QueueHandle : IEquatable<QueueHandle>
{
    private readonly nuint _ptr;
    public static QueueHandle Null
    {
        get => new(nuint.Zero);
    }

    public QueueHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(QueueHandle handle) => handle._ptr;

    public static bool operator ==(QueueHandle left, QueueHandle right) => left._ptr == right._ptr;

    public static bool operator !=(QueueHandle left, QueueHandle right) => left._ptr != right._ptr;

    public static bool operator ==(QueueHandle left, QueueHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(QueueHandle left, QueueHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(QueueHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(QueueHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(QueueHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is QueueHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public void OnSubmittedWorkDone(delegate* unmanaged[Cdecl]<QueueWorkDoneStatus, void*, void> callback, void* userdata) => WebGPU_FFI.QueueOnSubmittedWorkDone(this, callback, userdata);

    public Future OnSubmittedWorkDone(QueueWorkDoneCallbackInfo2FFI callbackInfo) => WebGPU_FFI.QueueOnSubmittedWorkDone2(this, callbackInfo);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.QueueSetLabel(this, label);

    /// <summary>
    /// Schedules the execution of the command buffers by the GPU on this queue.
    /// Submitted command buffers cannot be used again.
    /// </summary>
    public void Submit(nuint commandCount, CommandBufferHandle* commands) => WebGPU_FFI.QueueSubmit(this, commandCount, commands);

    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="WebGpuSharp.Buffer"/>.
    /// </summary>
    /// <param name="buffer">The buffer to write to.</param>
    /// <param name="bufferOffset">Offset in bytes into <paramref name="buffer"/> to begin writing at.</param>
    /// <param name="data">Data to write into <paramref name="buffer"/>.</param>
    /// <param name="dataOffset">
    /// Offset in into <paramref name="data"/> to begin writing from. Given in elements if
    /// <paramref name="data"/> is a `TypedArray` and bytes otherwise.
    /// </param>
    /// <param name="size">
    /// Size of content to write from <paramref name="data"/> to <paramref name="buffer"/>. Given in elements if
    /// <paramref name="data"/> is a `TypedArray` and bytes otherwise.
    /// </param>
    public void WriteBuffer(BufferHandle buffer, ulong bufferOffset, void* data, nuint size) => WebGPU_FFI.QueueWriteBuffer(this, buffer, bufferOffset, data, size);

    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="WebGpuSharp.Texture"/>.
    /// </summary>
    /// <param name="destination">The texture subresource and origin to write to.</param>
    /// <param name="data">Data to write into <paramref name="destination"/>.</param>
    /// <param name="dataLayout">Layout of the content in <paramref name="data"/>.</param>
    /// <param name="size">Extents of the content to write from <paramref name="data"/> to <paramref name="destination"/>.</param>
    public void WriteTexture(ImageCopyTextureFFI* destination, void* data, nuint dataSize, TextureDataLayout* dataLayout, Extent3D* writeSize) => WebGPU_FFI.QueueWriteTexture(this, destination, data, dataSize, dataLayout, writeSize);

    public void AddRef() => WebGPU_FFI.QueueAddRef(this);

    public void Release() => WebGPU_FFI.QueueRelease(this);

}
