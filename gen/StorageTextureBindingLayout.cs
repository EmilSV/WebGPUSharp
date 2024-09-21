using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct StorageTextureBindingLayout
{
    public ChainedStruct* NextInChain;
    public StorageTextureAccess Access = StorageTextureAccess.WriteOnly;
    public required TextureFormat Format;
    public TextureViewDimension ViewDimension = TextureViewDimension.D2;

    public StorageTextureBindingLayout()
    {
    }

}
