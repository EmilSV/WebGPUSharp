using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public sealed class QuerySet : BaseWebGpuSafeHandle<QuerySet, QuerySetHandle>
{
    private QuerySet(QuerySetHandle handle) : base(handle)
    {
    }

    internal static QuerySet? FromHandle(QuerySetHandle handle, bool isOwnedHandle)
    {
        var newQuerySet = WebGpuSafeHandleCache.GetOrCreate(handle, static (handle) => new QuerySet(handle));
        if (isOwnedHandle)
        {
            newQuerySet?.AddReference(false);
        }
        return newQuerySet;
    }

    public void Destroy()
    {
        _handle.Destroy();
    }
    public uint GetCount()
    {
        return _handle.GetCount();
    }
    public QueryType GetQueryType()
    {
        return _handle.GetQueryType();
    }
    public void SetLabel(WGPURefText label)
    {
        _handle.SetLabel(label);
    }
}