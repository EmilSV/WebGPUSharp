using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreSyncFDDescriptor
{
    public ChainedStruct Chain;
    public int Handle;

    public SharedFenceVkSemaphoreSyncFDDescriptor()
    {
    }


    public SharedFenceVkSemaphoreSyncFDDescriptor(ChainedStruct chain = default, int handle = default)
    {
        this.Chain = chain;
        this.Handle = handle;
    }

}
