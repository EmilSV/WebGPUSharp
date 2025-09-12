using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// The maximum number of draw calls that can be submitted to a render pass.
/// </summary>
public partial struct RenderPassMaxDrawCount
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The maximum number of draw calls that can be submitted to a render pass.
    /// </summary>
    public ulong MaxDrawCount = 50000000;

    public RenderPassMaxDrawCount() { }

}
