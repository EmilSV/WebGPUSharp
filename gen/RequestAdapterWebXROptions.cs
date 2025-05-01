using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

/// <summary>
/// Extension providing requestAdapter options for implementations with WebXR interop (i.e. Wasm).
/// </summary>
public partial struct RequestAdapterWebXROptions
{
    /// <summary>
    /// The chain link for struct chaining.
    /// </summary>
    public ChainedStruct Chain;
    /// <summary>
    /// Sets the `xrCompatible` option in the JS API.
    /// </summary>
    public WebGPUBool XrCompatible = new();

    public RequestAdapterWebXROptions() { }

}
