using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct SharedBufferMemoryHandle : IEquatable<SharedBufferMemoryHandle>
{
    private readonly nuint _ptr;
    public static SharedBufferMemoryHandle Null
    {
        get => new(nuint.Zero);
    }

    public SharedBufferMemoryHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(SharedBufferMemoryHandle handle) => handle._ptr;

    public static bool operator ==(SharedBufferMemoryHandle left, SharedBufferMemoryHandle right) => left._ptr == right._ptr;

    public static bool operator !=(SharedBufferMemoryHandle left, SharedBufferMemoryHandle right) => left._ptr != right._ptr;

    public static bool operator ==(SharedBufferMemoryHandle left, SharedBufferMemoryHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(SharedBufferMemoryHandle left, SharedBufferMemoryHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(SharedBufferMemoryHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(SharedBufferMemoryHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(SharedBufferMemoryHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is SharedBufferMemoryHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public Status BeginAccess(BufferHandle buffer, SharedBufferMemoryBeginAccessDescriptorFFI* descriptor) => WebGPU_FFI.SharedBufferMemoryBeginAccess(this, buffer, descriptor);

    public BufferHandle CreateBuffer(BufferDescriptorFFI* descriptor) => WebGPU_FFI.SharedBufferMemoryCreateBuffer(this, descriptor);

    public Status EndAccess(BufferHandle buffer, SharedBufferMemoryEndAccessStateFFI* descriptor) => WebGPU_FFI.SharedBufferMemoryEndAccess(this, buffer, descriptor);

    public Status GetProperties(SharedBufferMemoryProperties* properties) => WebGPU_FFI.SharedBufferMemoryGetProperties(this, properties);

    public WebGPUBool IsDeviceLost() => WebGPU_FFI.SharedBufferMemoryIsDeviceLost(this);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.SharedBufferMemorySetLabel(this, label);

    public void AddRef() => WebGPU_FFI.SharedBufferMemoryAddRef(this);

    public void Release() => WebGPU_FFI.SharedBufferMemoryRelease(this);

}
