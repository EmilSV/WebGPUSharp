using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref />
public sealed class QuerySet :
    QuerySetBase,
    IFromHandle<QuerySet, QuerySetHandle>
{
    private readonly WebGpuSafeHandle<QuerySetHandle> _safeHandle;

    protected override QuerySetHandle Handle => _safeHandle.Handle;
    protected override bool HandleWrapperSameLifetime => true;

    private QuerySet(QuerySetHandle handle)
    {
        _safeHandle = new WebGpuSafeHandle<QuerySetHandle>(handle);
    }

    static QuerySet? IFromHandle<QuerySet, QuerySetHandle>.FromHandle(
        QuerySetHandle handle)
    {
        if (QuerySetHandle.IsNull(handle))
        {
            return null;
        }

        QuerySetHandle.Reference(handle);
        return new(handle);
    }

    static QuerySet? IFromHandle<QuerySet, QuerySetHandle>.FromHandleNoRefIncrement(
        QuerySetHandle handle)
    {
        if (QuerySetHandle.IsNull(handle))
        {
            return null;
        }

        return new(handle);
    }
}