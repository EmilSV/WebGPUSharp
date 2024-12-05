using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceSyncFDExportInfo
{
    public ChainedStructOut Chain = new();
    public int Handle;

    public SharedFenceSyncFDExportInfo() { }

}
