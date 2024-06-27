using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreZirconHandleExportInfo
{
    public ChainedStructOut Chain;
    public uint Handle;

    public SharedFenceVkSemaphoreZirconHandleExportInfo()
    {
    }


    public SharedFenceVkSemaphoreZirconHandleExportInfo(ChainedStructOut chain = default, uint handle = default)
    {
        this.Chain = chain;
        this.Handle = handle;
    }

}
