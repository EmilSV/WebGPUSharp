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


    public StorageTextureBindingLayout(ChainedStruct* nextInChain = default, StorageTextureAccess access = StorageTextureAccess.WriteOnly, TextureFormat format = default, TextureViewDimension viewDimension = TextureViewDimension.D2)
    {
        this.NextInChain = nextInChain;
        this.Access = access;
        this.Format = format;
        this.ViewDimension = viewDimension;
    }


    public StorageTextureBindingLayout(StorageTextureAccess access = StorageTextureAccess.WriteOnly, TextureFormat format = default, TextureViewDimension viewDimension = TextureViewDimension.D2)
    {
        this.Access = access;
        this.Format = format;
        this.ViewDimension = viewDimension;
    }

}
