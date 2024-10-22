using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct SharedTextureMemoryHandle : IEquatable<SharedTextureMemoryHandle>
{
    private readonly nuint _ptr;
    public static SharedTextureMemoryHandle Null
    {
        get => new(nuint.Zero);
    }

    public SharedTextureMemoryHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(SharedTextureMemoryHandle handle) => handle._ptr;

    public static bool operator ==(SharedTextureMemoryHandle left, SharedTextureMemoryHandle right) => left._ptr == right._ptr;

    public static bool operator !=(SharedTextureMemoryHandle left, SharedTextureMemoryHandle right) => left._ptr != right._ptr;

    public static bool operator ==(SharedTextureMemoryHandle left, SharedTextureMemoryHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(SharedTextureMemoryHandle left, SharedTextureMemoryHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(SharedTextureMemoryHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(SharedTextureMemoryHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(SharedTextureMemoryHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is SharedTextureMemoryHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public Status BeginAccess(TextureHandle texture, SharedTextureMemoryBeginAccessDescriptorFFI* descriptor) => WebGPU_FFI.SharedTextureMemoryBeginAccess(this, texture, descriptor);

    public TextureHandle CreateTexture(TextureDescriptorFFI* descriptor) => WebGPU_FFI.SharedTextureMemoryCreateTexture(this, descriptor);

    public Status EndAccess(TextureHandle texture, SharedTextureMemoryEndAccessStateFFI* descriptor) => WebGPU_FFI.SharedTextureMemoryEndAccess(this, texture, descriptor);

    public Status GetProperties(SharedTextureMemoryProperties* properties) => WebGPU_FFI.SharedTextureMemoryGetProperties(this, properties);

    public WebGPUBool IsDeviceLost() => WebGPU_FFI.SharedTextureMemoryIsDeviceLost(this);

    public void SetLabel(byte* label) => WebGPU_FFI.SharedTextureMemorySetLabel(this, label);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.SharedTextureMemorySetLabel2(this, label);

    public void AddRef() => WebGPU_FFI.SharedTextureMemoryAddRef(this);

    public void Release() => WebGPU_FFI.SharedTextureMemoryRelease(this);

}
