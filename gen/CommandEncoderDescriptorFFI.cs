using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct CommandEncoderDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public StringViewFFI Label;

    public CommandEncoderDescriptorFFI()
    {
    }

}
