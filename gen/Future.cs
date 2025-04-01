using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Opaque handle to an asynchronous operation
/// </summary>
public partial struct Future
{
    /// <summary>
    /// The unique identifier of the future.
    /// </summary>
    public ulong Id;

    public Future() { }

}
