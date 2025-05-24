using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

/// <inheritdoc cref="QuerySetHandle" />
public abstract class QuerySetBase :
    WebGPUHandleWrapperBase<QuerySetHandle>
{
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
}