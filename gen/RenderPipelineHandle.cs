using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct RenderPipelineHandle : IEquatable<RenderPipelineHandle>
{
    private readonly nuint _ptr;
    public static RenderPipelineHandle Null
    {
        get => new(nuint.Zero);
    }

    public RenderPipelineHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(RenderPipelineHandle handle) => handle._ptr;
    public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr == right._ptr;
    public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle right) => left._ptr != right._ptr;
    public static bool operator ==(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(RenderPipelineHandle left, RenderPipelineHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(RenderPipelineHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(RenderPipelineHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(RenderPipelineHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is RenderPipelineHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
