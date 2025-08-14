using WebGpuSharp.FFI;
using WebGpuSharp.Internal;
using WebGpuSharp.Marshalling;

namespace WebGpuSharp;

/// <inheritdoc cref />
public sealed class QuerySet :
    WebGPUManagedHandleBase<QuerySetHandle>,
    IFromHandle<QuerySet, QuerySetHandle>
{
    private QuerySet(QuerySetHandle handle) : base(handle)
    {
    }

    /// <inheritdoc cref="QuerySetHandle.Destroy()" />
    public void Destroy()
    {
        Handle.Destroy();
    }
    /// <inheritdoc cref="QuerySetHandle.GetCount" />
    public uint GetCount()
    {
        return Handle.GetCount();
    }

    /// <inheritdoc cref="QuerySetHandle.GetQueryType" />
    public QueryType GetQueryType()
    {
        return Handle.GetQueryType();
    }

    /// <inheritdoc cref="QuerySetHandle.SetLabel(WGPURefText)" />
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
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