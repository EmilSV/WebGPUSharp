using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly unsafe partial struct SurfaceHandle : IEquatable<SurfaceHandle>
{
    private readonly nuint _ptr;
    public static SurfaceHandle Null
    {
        get => new(nuint.Zero);
    }

    public SurfaceHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(SurfaceHandle handle) => handle._ptr;

    public static bool operator ==(SurfaceHandle left, SurfaceHandle right) => left._ptr == right._ptr;

    public static bool operator !=(SurfaceHandle left, SurfaceHandle right) => left._ptr != right._ptr;

    public static bool operator ==(SurfaceHandle left, SurfaceHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(SurfaceHandle left, SurfaceHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(SurfaceHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(SurfaceHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(SurfaceHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is SurfaceHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    public void Configure(SurfaceConfigurationFFI* config) => WebGPU_FFI.SurfaceConfigure(this, config);

    public Status GetCapabilities(AdapterHandle adapter, SurfaceCapabilitiesFFI* capabilities) => WebGPU_FFI.SurfaceGetCapabilities(this, adapter, capabilities);

    public void GetCurrentTexture(SurfaceTextureFFI* surfaceTexture) => WebGPU_FFI.SurfaceGetCurrentTexture(this, surfaceTexture);

    public void Present() => WebGPU_FFI.SurfacePresent(this);

    public void SetLabel(StringViewFFI label) => WebGPU_FFI.SurfaceSetLabel(this, label);

    public void Unconfigure() => WebGPU_FFI.SurfaceUnconfigure(this);

    public void AddRef() => WebGPU_FFI.SurfaceAddRef(this);

    public void Release() => WebGPU_FFI.SurfaceRelease(this);

}
