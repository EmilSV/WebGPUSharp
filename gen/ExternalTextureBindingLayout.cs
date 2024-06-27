using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct ExternalTextureBindingLayout
{
    public ChainedStruct Chain;

    public ExternalTextureBindingLayout()
    {
    }


    public ExternalTextureBindingLayout(ChainedStruct chain = default)
    {
        this.Chain = chain;
    }

}
