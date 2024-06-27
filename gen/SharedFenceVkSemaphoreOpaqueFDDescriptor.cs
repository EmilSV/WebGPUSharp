using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreOpaqueFDDescriptor
{
    public ChainedStruct Chain;
    public int Handle;

    public SharedFenceVkSemaphoreOpaqueFDDescriptor()
    {
    }


    public SharedFenceVkSemaphoreOpaqueFDDescriptor(ChainedStruct chain = default, int handle = default)
    {
        this.Chain = chain;
        this.Handle = handle;
    }

}
