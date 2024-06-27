using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct StorageTextureBindingLayout
{
    public ChainedStruct* NextInChain;
    public StorageTextureAccess Access;
    public TextureFormat Format;
    public TextureViewDimension ViewDimension;

    public StorageTextureBindingLayout()
    {
    }


    public StorageTextureBindingLayout(ChainedStruct* nextInChain = default, StorageTextureAccess access = default, TextureFormat format = default, TextureViewDimension viewDimension = default)
    {
        this.NextInChain = nextInChain;
        this.Access = access;
        this.Format = format;
        this.ViewDimension = viewDimension;
    }


    public StorageTextureBindingLayout(StorageTextureAccess access = default, TextureFormat format = default, TextureViewDimension viewDimension = default)
    {
        this.Access = access;
        this.Format = format;
        this.ViewDimension = viewDimension;
    }

}
