using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct DepthStencilState
{
    public ChainedStruct* NextInChain;
    public required TextureFormat Format;
    public OptionalBool DepthWriteEnabled;
    public CompareFunction DepthCompare;
    public StencilFaceState StencilFront;
    public StencilFaceState StencilBack;
    public uint StencilReadMask = 4294967295;
    public uint StencilWriteMask = 4294967295;
    public int DepthBias = 0;
    public float DepthBiasSlopeScale = 0;
    public float DepthBiasClamp = 0;

    public DepthStencilState()
    {
    }

}
