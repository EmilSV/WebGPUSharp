using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreOpaqueFDDescriptor
{
    public ChainedStruct Chain;
    public int Handle;

    public SharedFenceVkSemaphoreOpaqueFDDescriptor() { }

}
