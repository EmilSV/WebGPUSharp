using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// Handle to a query set. It can be created with <see cref="DeviceHandle.CreateQuerySet" />.
/// </summary>
public unsafe partial struct QuerySetHandle : IEquatable<QuerySetHandle>
{
    private readonly nuint _ptr;
    /// <summary>
    /// Get a null handle.
    /// </summary>
    public static QuerySetHandle Null
    {
        get => new(nuint.Zero);
    }

    public QuerySetHandle(nuint ptr) => _ptr = ptr;

    /// <summary>
    /// Convert a handle to a pointer.
    /// </summary>
    /// <param name="handle">The handle to convert.</param>
    public static explicit operator nuint(QuerySetHandle handle) => handle._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(QuerySetHandle left, QuerySetHandle right) => left._ptr == right._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(QuerySetHandle left, QuerySetHandle right) => left._ptr != right._ptr;

    /// <summary>
    /// Check if two handles are equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator ==(QuerySetHandle left, QuerySetHandle? right) => left._ptr == right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if two handles are not equal.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right handle.</param>
    public static bool operator !=(QuerySetHandle left, QuerySetHandle? right) => left._ptr != right.GetValueOrDefault()._ptr;

    /// <summary>
    /// Check if a handle is equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator ==(QuerySetHandle left, nuint right) => left._ptr == right;

    /// <summary>
    /// Check if a handle is not equal to a pointer.
    /// </summary>
    /// <param name="left">The left handle.</param>
    /// <param name="right">The right pointer.</param>
    public static bool operator !=(QuerySetHandle left, nuint right) => left._ptr != right;

    /// <summary>
    /// Get the address of the handle.
    /// </summary>
    public nuint GetAddress() => _ptr;

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">The other handle to compare with</param>
    public bool Equals(QuerySetHandle other) => _ptr == other._ptr;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="other">The other object to compare with</param>
    public override bool Equals(object? other) => other is QuerySetHandle h && Equals(h) || other is null && _ptr == UIntPtr.Zero;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    public override int GetHashCode() => _ptr.GetHashCode();

    /// <summary>
    /// Destroys the  <see cref="QuerySet"/>.
    /// </summary>
    public void Destroy() => WebGPU_FFI.QuerySetDestroy(this);

    /// <summary>
    /// Gets the number of queries managed by this QuerySet.
    /// </summary>
    /// <returns>number of queries managed by this QuerySet.</returns>
    public uint GetCount() => WebGPU_FFI.QuerySetGetCount(this);

    /// <summary>
    /// Specifying the type of queries managed by the <see cref="QuerySetHandle" />.
    /// </summary>
    /// <returns>
    /// Two possible values:
    /// <list type="bullet"><item><description><see cref="QueryType.Occlusion">Occlusion</see> The <see cref="QuerySetHandle" /> manages occlusion queries.</description></item><item><description><see cref="QueryType.Timestamp">Timestamp</see> The <see cref="QuerySetHandle" /> manages timestamp queries.</description></item></list>
    /// </returns>
    public QueryType WebGpuGetType() => WebGPU_FFI.QuerySetGetType(this);

    /// <summary>
    /// Sets a label on the QuerySet.
    /// </summary>
    /// <param name="label">The label to set.</param>
    public void SetLabel(StringViewFFI label) => WebGPU_FFI.QuerySetSetLabel(this, label);

    /// <summary>
    /// Increments the reference count of the <see cref="QuerySetHandle"/>.
    /// </summary>
    /// <remarks>
    /// WebGPU objects are refcounted. Each call to <see cref="AddRef"/> must be balanced with a corresponding
    /// call to <see cref="Release"/> when the reference is no longer needed. Objects returned directly from
    /// the API start with a reference count of 1.
    /// 
    /// Applications don't need to maintain refs to WebGPU objects that are internally used by other 
    /// WebGPU objects, as the implementation maintains internal references as needed.
    /// </remarks>
    /// <returns>The same <see cref="QuerySetHandle"/> instance with an incremented reference count.</returns>
    public QuerySetHandle AddRef()
    {
        WebGPU_FFI.QuerySetAddRef(this);
        return this;
    }

    /// <summary>
    /// Decrements the reference count of the <see cref="QuerySetHandle"/>. When the reference count reaches zero, the <see cref="QuerySetHandle"/> and associated resources may be freed.
    /// </summary>
    /// <remarks>
    /// It's unsafe to use an object after its reference count has reached zero, even if other
    /// WebGPU objects internally reference it.
    /// 
    /// Applications must call <see cref="Release"/> on all <see cref="QuerySetHandle"/> references they own before losing the pointer.
    /// Failing to balance <see cref="AddRef"/> and <see cref="Release"/> calls will result in memory leaks or use-after-free errors.
    /// </remarks>
    public void Release() => WebGPU_FFI.QuerySetRelease(this);

}
