using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

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
    public void SetLabel(byte* label) => WebGPU_FFI.RenderBundleSetLabel(this, label);
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.RenderBundleSetLabel2(this, label);
    public void AddRef() => WebGPU_FFI.RenderBundleAddRef(this);
    public void Release() => WebGPU_FFI.RenderBundleRelease(this);
}
