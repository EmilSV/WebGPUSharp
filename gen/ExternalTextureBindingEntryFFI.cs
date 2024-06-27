using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ExternalTextureBindingEntryFFI
{
    public ChainedStruct Chain;
    public ExternalTextureHandle ExternalTexture;

    public ExternalTextureBindingEntryFFI()
    {
    }


    public ExternalTextureBindingEntryFFI(ChainedStruct chain = default, ExternalTextureHandle externalTexture = default)
    {
        this.Chain = chain;
        this.ExternalTexture = externalTexture;
    }

}
