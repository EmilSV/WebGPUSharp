using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Struct holding a future to wait on, and a `completed` boolean flag.
/// </summary>
public partial struct FutureWaitInfo
{
    /// <summary>
    /// The future to wait on.
    /// </summary>
    public Future Future = new();
    /// <summary>
    /// Whether or not the future completed.
    /// </summary>
    public WebGPUBool Completed = new();

    public FutureWaitInfo() { }

}
