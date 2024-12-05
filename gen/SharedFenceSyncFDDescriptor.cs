using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceSyncFDDescriptor
{
    public ChainedStruct Chain = new();
    public int Handle;

    public SharedFenceSyncFDDescriptor() { }

}
