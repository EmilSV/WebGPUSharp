using WebGpuSharp.FFI;
using WebGpuSharp.Internal;

namespace WebGpuSharp;

public abstract class QuerySetBase : 
    WebGPUHandleWrapperBase<QuerySetHandle>
{
    public void Destroy()
    {
        Handle.Destroy();
    }
    public uint GetCount()
    {
        return Handle.GetCount();
    }
    public QueryType GetQueryType()
    {
        return Handle.GetQueryType();
    }
    public void SetLabel(WGPURefText label)
    {
        Handle.SetLabel(label);
    }
}