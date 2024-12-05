using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct SharedFenceVkSemaphoreZirconHandleDescriptor
{
    public ChainedStruct Chain = new();
    public uint Handle;

    public SharedFenceVkSemaphoreZirconHandleDescriptor() { }

}
