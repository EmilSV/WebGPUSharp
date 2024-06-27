using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreSyncFDExportInfo
{
    public ChainedStructOut Chain;
    public int Handle;

    public SharedFenceVkSemaphoreSyncFDExportInfo()
    {
    }


    public SharedFenceVkSemaphoreSyncFDExportInfo(ChainedStructOut chain = default, int handle = default)
    {
        this.Chain = chain;
        this.Handle = handle;
    }

}
