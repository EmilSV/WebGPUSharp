using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreZirconHandleDescriptor
{
    public ChainedStruct Chain;
    public uint Handle;

    public SharedFenceVkSemaphoreZirconHandleDescriptor() { }

}