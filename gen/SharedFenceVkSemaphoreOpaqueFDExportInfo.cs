using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreOpaqueFDExportInfo
{
    public ChainedStructOut Chain;
    public int Handle;

    public SharedFenceVkSemaphoreOpaqueFDExportInfo()
    {
    }


    public SharedFenceVkSemaphoreOpaqueFDExportInfo(ChainedStructOut chain = default, int handle = default)
    {
        this.Chain = chain;
        this.Handle = handle;
    }

}
