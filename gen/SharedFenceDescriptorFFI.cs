using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedFenceDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label = StringViewFFI.NullValue;

    public SharedFenceDescriptorFFI() { }

}
