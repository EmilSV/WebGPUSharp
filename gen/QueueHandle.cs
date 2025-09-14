using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a command queue on a device.
/// A Queue executes recorded CommandBuffer objects and provides convenience methods for writing to buffers and textures.
/// </summary>
public unsafe partial struct QueueHandle : IEquatable<QueueHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static QueueHandle Null
    {
        get => new(nuint.Zero);
    }

    public QueueHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(QueueHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(QueueHandle left, QueueHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(QueueHandle left, QueueHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(QueueHandle left, QueueHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(QueueHandle left, QueueHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(QueueHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(QueueHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(QueueHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is QueueHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Registers a callback when the previous call to submit finishes running on the gpu. This callback being called implies that all mapped buffer callbacks which were registered before this call will have been called.
    /// For the callback to complete, either queue.submit(..), instance.poll_all(..), or device.poll(..) must be called elsewhere in the runtime, possibly integrated into an event loop or run on a separate thread.
    /// The callback will be called on the thread that first calls the above functions after the gpu work has completed. There are no restrictions on the code you can run in the callback,
    /// however on native the call to the function will not complete until the callback returns, so prefer keeping callbacks short and used to set flags, send messages, etc.
    /// </summary>
    /// <param name="callbackInfo">callback to be called with some user data to be passed to the callback.</param>
    public Future OnSubmittedWorkDone(QueueWorkDoneCallbackInfoFFI callbackInfo) => WebGPU_FFI.QueueOnSubmittedWorkDone(this, callbackInfo);

    /// <summary>
    /// Sets a label on the queue.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.QueueSetLabel(this, label);

    /// <summary>
    /// Schedules the execution of the command buffers by the GPU on this queue.
    /// Submitted command buffers cannot be used again.
    /// </summary>
    /// <param name="commandCount">The number of command buffers to submit.</param>
    /// <param name="commands">The command buffers to submit.</param>
    public void Submit(nuint commandCount, CommandBufferHandle* commands) => WebGPU_FFI.QueueSubmit(this, commandCount, commands);

    /// <summary>
    /// Issues a write operation of the provided data into a  <see cref="Buffer"/>.
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
    /// Issues a write operation of the provided data into a  <see cref="Texture"/>.
    /// </summary>
    /// <param name="destination">The texture subresource and origin to write to.</param>
    /// <param name="data">Data to write into <paramref name="destination"/>.</param>
    /// <param name="dataLayout">Layout of the content in <paramref name="data"/>.</param>
    /// <param name="writeSize">Extents of the content to write from <paramref name="data" /> to <paramref name="destination" />.</param>
    /// <param name="dataSize">The size of the data to write.</param>
    public void WriteTexture(TexelCopyTextureInfoFFI* destination, void* data, nuint dataSize, TexelCopyBufferLayout* dataLayout, Extent3D* writeSize) => WebGPU_FFI.QueueWriteTexture(this, destination, data, dataSize, dataLayout, writeSize);

    /// <summary>
    /// Increments the reference count of the <see cref="QueueHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.QueueAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="QueueHandle"/>. When the reference count reaches zero, the <see cref="QueueHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="QueueHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.QueueRelease(this);

}
