using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct QuerySetHandle : IEquatable<QuerySetHandle>
{
    private readonly nuint _ptr;
    public static QuerySetHandle Null
    {
        get => new(nuint.Zero);
    }

    public QuerySetHandle(nuint ptr) => _ptr = ptr;
    public static explicit operator nuint(QuerySetHandle handle) => handle._ptr;
    public static bool operator ==(QuerySetHandle left, QuerySetHandle right) => left._ptr == right._ptr;
    public static bool operator !=(QuerySetHandle left, QuerySetHandle right) => left._ptr != right._ptr;
    public static bool operator ==(QuerySetHandle left, QuerySetHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
    public static bool operator !=(QuerySetHandle left, QuerySetHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
    public static bool operator ==(QuerySetHandle left, nuint right) => left._ptr == right;
    public static bool operator !=(QuerySetHandle left, nuint right) => left._ptr != right;
    public nuint GetAddress() => _ptr;
    public bool Equals(QuerySetHandle other) => _ptr == other._ptr;
    public override bool Equals(object? other) => other is QuerySetHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;
    public override int GetHashCode() => _ptr.GetHashCode();
}
