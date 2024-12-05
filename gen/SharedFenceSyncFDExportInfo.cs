using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceSyncFDExportInfo
{
    public ChainedStructOut Chain;
    public int Handle;

    public SharedFenceSyncFDExportInfo() { }

}
