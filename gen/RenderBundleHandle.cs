using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Pre-prepared reusable bundle of GPU operations.
/// 
/// It only supports a handful of render commands, but it makes them reusable. Executing a RenderBundle is often more efficient than issuing the underlying commands manually.
/// 
/// It can be created by use of a RenderBundleEncoderHandle, and executed onto a CommandEncoder using <see cref="FFI.RenderPassHandle.ExecuteBundles" />.
/// </summary>
public readonly unsafe partial struct RenderBundleHandle : IEquatable<RenderBundleHandle>
{
    private readonly nuint _ptr;
    public static RenderBundleHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderBundleHandle(nuint ptr) => _ptr = ptr;

    public static explicit operator nuint(RenderBundleHandle handle) => handle._ptr;

    public static bool operator ==(RenderBundleHandle left, RenderBundleHandle right) => left._ptr == right._ptr;

    public static bool operator !=(RenderBundleHandle left, RenderBundleHandle right) => left._ptr != right._ptr;

    public static bool operator ==(RenderBundleHandle left, RenderBundleHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    public static bool operator !=(RenderBundleHandle left, RenderBundleHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    public static bool operator ==(RenderBundleHandle left, nuint right) => left._ptr == right;

    public static bool operator !=(RenderBundleHandle left, nuint right) => left._ptr != right;

    public nuint GetAddress() => _ptr;

    public bool Equals(RenderBundleHandle other) => _ptr == other._ptr;

    public override bool Equals(object? other) => other is RenderBundleHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Sets the debug label of the RenderBundleHandle.
    /// </summary>
    /// <param name="label">The new debug label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderBundleSetLabel(this, label);

    public void AddRef() => WebGPU_FFI.RenderBundleAddRef(this);

    public void Release() => WebGPU_FFI.RenderBundleRelease(this);

}
