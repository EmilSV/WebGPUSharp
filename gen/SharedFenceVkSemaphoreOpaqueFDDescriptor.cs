using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreOpaqueFDDescriptor
{
    public ChainedStruct Chain = new();
    public int Handle;

    public SharedFenceVkSemaphoreOpaqueFDDescriptor() { }

}
