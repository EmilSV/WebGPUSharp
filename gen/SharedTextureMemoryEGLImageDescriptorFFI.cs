using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryEGLImageDescriptorFFI
{
    public ChainedStruct Chain = new();
    public void* Image;

    public SharedTextureMemoryEGLImageDescriptorFFI() { }

}
