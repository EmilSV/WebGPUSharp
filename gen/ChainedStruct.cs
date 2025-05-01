using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Structures used to extend descriptors.
/// </summary>
public unsafe partial struct ChainedStruct
{
    /// <summary>
    /// The next chained struct in the chain.
    /// </summary>
    public ChainedStruct* Next;
    /// <summary>
    /// The type of the chained struct.
    /// </summary>
    public SType SType;

    public ChainedStruct() { }

}
