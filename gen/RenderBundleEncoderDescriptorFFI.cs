using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

public unsafe partial struct RenderBundleEncoderDescriptorFFI
{
    public ChainedStruct* NextInChain;
    public byte* Label;
    public nuint ColorFormatCount;
    public TextureFormat* ColorFormats;
    public TextureFormat DepthStencilFormat;
    public uint SampleCount;
    public WebGPUBool DepthReadOnly = false;
    public WebGPUBool StencilReadOnly = false;

    public RenderBundleEncoderDescriptorFFI()
    {
    }

}
