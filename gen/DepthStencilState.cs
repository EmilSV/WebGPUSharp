using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public unsafe partial struct DepthStencilState
{
    public ChainedStruct* NextInChain;
    public TextureFormat Format;
    public OptionalBool DepthWriteEnabled;
    public CompareFunction DepthCompare;
    public StencilFaceState StencilFront;
    public StencilFaceState StencilBack;
    public uint StencilReadMask;
    public uint StencilWriteMask;
    public int DepthBias;
    public float DepthBiasSlopeScale;
    public float DepthBiasClamp;

    public DepthStencilState()
    {
    }


    public DepthStencilState(ChainedStruct* nextInChain = default, TextureFormat format = default, OptionalBool depthWriteEnabled = default, CompareFunction depthCompare = default, StencilFaceState stencilFront = default, StencilFaceState stencilBack = default, uint stencilReadMask = 4294967295, uint stencilWriteMask = 4294967295, int depthBias = 0, float depthBiasSlopeScale = 0, float depthBiasClamp = 0)
    {
        this.NextInChain = nextInChain;
        this.Format = format;
        this.DepthWriteEnabled = depthWriteEnabled;
        this.DepthCompare = depthCompare;
        this.StencilFront = stencilFront;
        this.StencilBack = stencilBack;
        this.StencilReadMask = stencilReadMask;
        this.StencilWriteMask = stencilWriteMask;
        this.DepthBias = depthBias;
        this.DepthBiasSlopeScale = depthBiasSlopeScale;
        this.DepthBiasClamp = depthBiasClamp;
    }


    public DepthStencilState(TextureFormat format = default, OptionalBool depthWriteEnabled = default, CompareFunction depthCompare = default, StencilFaceState stencilFront = default, StencilFaceState stencilBack = default, uint stencilReadMask = 4294967295, uint stencilWriteMask = 4294967295, int depthBias = 0, float depthBiasSlopeScale = 0, float depthBiasClamp = 0)
    {
        this.Format = format;
        this.DepthWriteEnabled = depthWriteEnabled;
        this.DepthCompare = depthCompare;
        this.StencilFront = stencilFront;
        this.StencilBack = stencilBack;
        this.StencilReadMask = stencilReadMask;
        this.StencilWriteMask = stencilWriteMask;
        this.DepthBias = depthBias;
        this.DepthBiasSlopeScale = depthBiasSlopeScale;
        this.DepthBiasClamp = depthBiasClamp;
    }

}
