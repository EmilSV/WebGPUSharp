using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct BufferHandle : IEquatable<BufferHandle>
{
    private readonly nuint _ptr;
    public static BufferHandle Null
    {
        get => new(nuint.Zero);
    }

    public BufferHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(BufferHandle handle) => handle._ptr;

    public static bool operator ==(BufferHandle left, BufferHandle right) => left._ptr == right._ptr;

    public static bool operator !=(BufferHandle left, BufferHandle right) => left._ptr != right._ptr;

    public static bool operator ==(BufferHandle left, BufferHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(BufferHandle left, BufferHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(BufferHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(BufferHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(BufferHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is BufferHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Destroys the  <see cref="WebGpuSharp.Buffer"/>.
    /// Note: It is valid to destroy a buffer multiple times.
    /// Note: Since no further operations can be enqueued using this buffer, implementations can
    /// free resource allocations, including mapped memory that was just unmapped.
    /// </summary>
    public void Destroy() => WebGPU_FFI.BufferDestroy(this);

    public void* GetConstMappedRange(nuint offset, nuint size) => WebGPU_FFI.BufferGetConstMappedRange(this, offset, size);

    public BufferMapState GetMapState() => WebGPU_FFI.BufferGetMapState(this);

    /// <summary>
    /// Returns an ArrayBuffer with the contents of the  <see cref="WebGpuSharp.Buffer"/> in the given mapped range.
    /// </summary>
    /// <param name="offset">Offset in bytes into the buffer to return buffer contents from.</param>
    /// <param name="size">Size in bytes of the ArrayBuffer to return.</param>
    public void* GetMappedRange(nuint offset, nuint size) => WebGPU_FFI.BufferGetMappedRange(this, offset, size);

    public ulong GetSize() => WebGPU_FFI.BufferGetSize(this);

    public BufferUsage GetUsage() => WebGPU_FFI.BufferGetUsage(this);

    /// <summary>
    /// Maps the given range of the  <see cref="WebGpuSharp.Buffer"/> and resolves the returned Promise when the
    ///  <see cref="WebGpuSharp.Buffer"/>'s content is ready to be accessed with  <see cref="WebGpuSharp.Buffer.GetMappedRange"/>.
    /// The resolution of the returned Promise **only** indicates that the buffer has been mapped.
    /// It does not guarantee the completion of any other operations visible to the content timeline,
    /// and in particular does not imply that any other Promise returned from
    ///  <see cref="WebGpuSharp.Queue.OnSubmittedWorkDone"/> or  <see cref="WebGpuSharp.Buffer.MapAsync"/> on other  <see cref="WebGpuSharp.Buffer"/>s
    /// have resolved.
    /// The resolution of the Promise returned from  <see cref="WebGpuSharp.Queue.OnSubmittedWorkDone"/>
    /// **does** imply the completion of
    ///  <see cref="WebGpuSharp.Buffer.MapAsync"/> calls made prior to that call,
    /// on  <see cref="WebGpuSharp.Buffer"/>s last used exclusively on that queue.
    /// </summary>
    /// <param name="mode">Whether the buffer should be mapped for reading or writing.</param>
    /// <param name="offset">Offset in bytes into the buffer to the start of the range to map.</param>
    /// <param name="size">Size in bytes of the range to map.</param>
    public void MapAsync(MapMode mode, nuint offset, nuint size, delegate* unmanaged[Cdecl]<BufferMapAsyncStatus, void*, void> callback, void* userdata) => WebGPU_FFI.BufferMapAsync(this, mode, offset, size, callback, userdata);

    public Future MapAsync(MapMode mode, nuint offset, nuint size, BufferMapCallbackInfo2FFI callbackInfo) => WebGPU_FFI.BufferMapAsync2(this, mode, offset, size, callbackInfo);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.BufferSetLabel(this, label);

    /// <summary>
    /// Unmaps the mapped range of the  <see cref="WebGpuSharp.Buffer"/> and makes its contents available for use by the
    /// GPU again.
    /// </summary>
    public void Unmap() => WebGPU_FFI.BufferUnmap(this);

    public void AddRef() => WebGPU_FFI.BufferAddRef(this);

    public void Release() => WebGPU_FFI.BufferRelease(this);

}
