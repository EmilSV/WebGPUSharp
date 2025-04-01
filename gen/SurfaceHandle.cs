using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A handle to a surface.
/// </summary>
public readonly unsafe partial struct SurfaceHandle : IEquatable<SurfaceHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// A null handle.
    /// </summary>
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

    /// <summary>
    /// Configures the surface.
    /// </summary>
    /// <param name="config">The configuration to use.</param>
    public void Configure(SurfaceConfigurationFFI* config) => WebGPU_FFI.SurfaceConfigure(this, config);

    /// <summary>
    /// Returns the capabilities of the surface when used with the given adapter.
    /// 
    /// Returns specified values (see SurfaceCapabilities) if surface is incompatible with the adapter.
    /// </summary>
    /// <param name="adapter">The adapter to use.</param>
    /// <param name="capabilities">The capabilities of the surface.</param>
    public Status GetCapabilities(AdapterHandle adapter, SurfaceCapabilitiesFFI* capabilities) => WebGPU_FFI.SurfaceGetCapabilities(this, adapter, capabilities);

    /// <summary>
    /// Gets the current texture of the surface.
    /// </summary>
    /// <param name="surfaceTexture">The current texture of the surface.</param>
    public void GetCurrentTexture(SurfaceTextureFFI* surfaceTexture) => WebGPU_FFI.SurfaceGetCurrentTexture(this, surfaceTexture);

    /// <summary>
    /// Presents the surface.
    /// </summary>
    public void Present() => WebGPU_FFI.SurfacePresent(this);

    /// <summary>
    /// Sets the label of the surface.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.SurfaceSetLabel(this, label);

    /// <summary>
    /// Unconfigures the surface.
    /// </summary>
    public void Unconfigure() => WebGPU_FFI.SurfaceUnconfigure(this);

    public void AddRef() => WebGPU_FFI.SurfaceAddRef(this);

    public void Release() => WebGPU_FFI.SurfaceRelease(this);

}
