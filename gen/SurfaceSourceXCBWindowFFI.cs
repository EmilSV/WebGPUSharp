using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp.FFI;

/// <summary>
/// A surface source for an XCB window.
/// </summary>
public unsafe partial struct SurfaceSourceXCBWindowFFI
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// The XCB connection.
    /// </summary>
    public void* Connection;
    /// <summary>
    /// The XCB window.
    /// </summary>
    public uint Window;

    public SurfaceSourceXCBWindowFFI() { }

}
