using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceSyncFDDescriptor
{
    public ChainedStruct Chain;
    public int Handle;

    public SharedFenceSyncFDDescriptor() { }

}
