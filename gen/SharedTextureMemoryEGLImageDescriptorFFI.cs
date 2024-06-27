using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct SharedTextureMemoryEGLImageDescriptorFFI
{
    public ChainedStruct Chain;
    public void* Image;

    public SharedTextureMemoryEGLImageDescriptorFFI()
    {
    }


    public SharedTextureMemoryEGLImageDescriptorFFI(ChainedStruct chain = default, void* image = default)
    {
        this.Chain = chain;
        this.Image = image;
    }

}
