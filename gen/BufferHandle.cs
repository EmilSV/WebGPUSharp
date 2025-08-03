using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// The Buffer represents a block of memory that can be used to store raw data to use
/// in GPU operations.
/// </summary>
public unsafe partial struct BufferHandle : IEquatable<BufferHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static BufferHandle Null
    {
        get => new(nuint.Zero);
    }

    public BufferHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(BufferHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(BufferHandle left, BufferHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(BufferHandle left, BufferHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(BufferHandle left, BufferHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(BufferHandle left, BufferHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(BufferHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(BufferHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(BufferHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is BufferHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Destroys the  <see cref="Buffer"/>.
    /// Note: It is valid to destroy a buffer multiple times.
    /// Note: Since no further operations can be enqueued using this buffer, implementations can
    /// free resource allocations, including mapped memory that was just unmapped.
    /// </summary>
    public void Destroy() => WebGPU_FFI.BufferDestroy(this);

    /// <summary>
    /// Returns a const pointer to beginning of the mapped range.
    /// It must not be written; writing to this range causes undefined behavior.
    /// See MappedRangeBehavior for error conditions and guarantees.
    /// This function is safe to call inside spontaneous callbacks (see CallbackReentrancy).
    /// </summary>
    /// <param name="size">
    /// Byte size of the range to get.
    /// If this is
    /// <see cref="WebGPU_FFI.WHOLE_MAP_SIZE" />
    /// , it defaults to `buffer.size - offset`.
    /// The returned pointer is valid for exactly this many bytes.
    /// </param>
    /// <param name="offset">Byte offset relative to the beginning of the buffer.</param>
    public void* GetConstMappedRange(nuint offset, nuint size) => WebGPU_FFI.BufferGetConstMappedRange(this, offset, size);

    /// <summary>
    /// Returns an ArrayBuffer with the contents of the  <see cref="Buffer"/> in the given mapped range.
    /// </summary>
    /// <param name="offset">Offset in bytes into the buffer to return buffer contents from.</param>
    /// <param name="size">Size in bytes of the ArrayBuffer to return.</param>
    public void* GetMappedRange(nuint offset, nuint size) => WebGPU_FFI.BufferGetMappedRange(this, offset, size);

    /// <summary>
    /// An enumerated value representing the mapped state of the Buffer.
    /// </summary>
    public BufferMapState GetMapState() => WebGPU_FFI.BufferGetMapState(this);

    /// <summary>
    /// Returns the size of the buffer in bytes.
    /// </summary>
    public ulong GetSize() => WebGPU_FFI.BufferGetSize(this);

    /// <summary>
    /// Returns the allowed usages of the Buffer
    /// </summary>
    public BufferUsage GetUsage() => WebGPU_FFI.BufferGetUsage(this);

    /// <summary>
    /// Maps the given range of the  <see cref="Buffer"/> and resolves the returned Promise when the
    ///  <see cref="Buffer"/>'s content is ready to be accessed with  <see cref="Buffer.GetMappedRange"/>.
    /// The resolution of the returned Promise **only** indicates that the buffer has been mapped.
    /// It does not guarantee the completion of any other operations visible to the content timeline,
    /// and in particular does not imply that any other Promise returned from
    ///  <see cref="Queue.OnSubmittedWorkDone"/> or  <see cref="Buffer.MapAsync"/> on other  <see cref="Buffer"/>s
    /// have resolved.
    /// The resolution of the Promise returned from  <see cref="Queue.OnSubmittedWorkDone"/>
    /// **does** imply the completion of
    ///  <see cref="Buffer.MapAsync"/> calls made prior to that call,
    /// on  <see cref="Buffer"/>s last used exclusively on that queue.
    /// </summary>
    /// <param name="mode">Whether the buffer should be mapped for reading or writing.</param>
    /// <param name="offset">Offset in bytes into the buffer to the start of the range to map.</param>
    /// <param name="size">Size in bytes of the range to map.</param>
    /// <param name="callbackInfo">Callback to be called when the buffer is mapped.</param>
    /// <returns>The future for the callback.</returns>
    public Future MapAsync(MapMode mode, nuint offset, nuint size, BufferMapCallbackInfoFFI callbackInfo) => WebGPU_FFI.BufferMapAsync(this, mode, offset, size, callbackInfo);

    /// <summary>
    /// Copies a range of data from the buffer mapping into the provided destination pointer.
    /// See MappedRangeBehavior for error conditions and guarantees.
    /// This function is safe to call inside spontaneous callbacks (see CallbackReentrancy).
    /// 
    /// In Wasm, this is more efficient than copying from a mapped range into a `malloc`'d range.
    /// </summary>
    /// <param name="size">Number of bytes of data to read from the buffer. (Note <see cref="WebGPU_FFI.WHOLE_MAP_SIZE" /> is *not* accepted here.)</param>
    /// <param name="data">Destination, to read buffer data into.</param>
    /// <param name="offset">Byte offset relative to the beginning of the buffer.</param>
    /// <returns><see cref="Status.Error" /> if the copy did not occur.</returns>
    public Status ReadMappedRange(nuint offset, void* data, nuint size) => WebGPU_FFI.BufferReadMappedRange(this, offset, data, size);

    /// <summary>
    /// Sets a label on the Buffer.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.BufferSetLabel(this, label);

    /// <summary>
    /// Unmaps the mapped range of the  <see cref="Buffer"/> and makes its contents available for use by the
    /// GPU again.
    /// </summary>
    public void Unmap() => WebGPU_FFI.BufferUnmap(this);

    /// <summary>
    /// Copies a range of data from the provided source pointer into the buffer mapping.
    /// See MappedRangeBehavior for error conditions and guarantees.
    /// This function is safe to call inside spontaneous callbacks (see CallbackReentrancy).
    /// In Wasm, this is more efficient than copying from a `malloc`'d range into a mapped range.
    /// </summary>
    /// <param name="size">Number of bytes of data to write to the buffer. (Note <see cref="WebGPU_FFI.WHOLE_MAP_SIZE" /> is *not* accepted here.)</param>
    /// <param name="data">Source, to write buffer data from.</param>
    /// <param name="offset">Byte offset relative to the beginning of the buffer.</param>
    /// <returns><see cref="Status.Error" /> if the copy did not occur.</returns>
    public Status WriteMappedRange(nuint offset, void* data, nuint size) => WebGPU_FFI.BufferWriteMappedRange(this, offset, data, size);

    /// <summary>
    /// Increments the reference count of the <see cref="BufferHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    public void AddRef() => WebGPU_FFI.BufferAddRef(this);

    /// <summary>
    /// Decrements the reference count of the <see cref="BufferHandle"/>. When the reference count reaches zero, the <see cref="BufferHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="BufferHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.BufferRelease(this);

}
