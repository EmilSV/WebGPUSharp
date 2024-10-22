using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreSyncFDDescriptor
{
    public ChainedStruct Chain;
    public int Handle;

    public SharedFenceVkSemaphoreSyncFDDescriptor() { }

}
