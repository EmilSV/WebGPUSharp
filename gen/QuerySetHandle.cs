using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public readonly partial struct QuerySetHandle : IEquatable<QuerySetHandle>
{
	private readonly UIntPtr _ptr;
	public QuerySetHandle(UIntPtr ptr) { _ptr = ptr; }
	public static QuerySetHandle Null => new QuerySetHandle(UIntPtr.Zero);
	public static explicit operator QuerySetHandle(UIntPtr ptr) => new QuerySetHandle(ptr);
	public static explicit operator UIntPtr(QuerySetHandle handle) => handle._ptr;
	public static bool operator ==(QuerySetHandle left, QuerySetHandle right) => left._ptr == right._ptr;
	public static bool operator !=(QuerySetHandle left, QuerySetHandle right) => left._ptr != right._ptr;
	public static bool operator ==(QuerySetHandle left, QuerySetHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;
	public static bool operator !=(QuerySetHandle left, QuerySetHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;
	public static bool operator ==(QuerySetHandle left, UIntPtr right) => left._ptr == right;
	public static bool operator !=(QuerySetHandle left, UIntPtr right) => left._ptr != right;
	public UIntPtr GetAddress() => _ptr;
	public bool Equals(QuerySetHandle h) => _ptr == h._ptr;
	public override bool Equals(object? o) => (o is QuerySetHandle h && Equals(h)) || (o is null && _ptr == UIntPtr.Zero);
	public override int GetHashCode() => _ptr.GetHashCode();
}

