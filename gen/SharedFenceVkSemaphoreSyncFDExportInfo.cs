using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreSyncFDExportInfo
{
    public ChainedStructOut Chain;
    public int Handle;

    public SharedFenceVkSemaphoreSyncFDExportInfo() { }

}
