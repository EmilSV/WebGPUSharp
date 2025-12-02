using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct ExternalTextureBindingEntryFFI
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    public ExternalTextureHandle ExternalTexture;

    public ExternalTextureBindingEntryFFI() { }

}
