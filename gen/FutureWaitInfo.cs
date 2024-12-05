using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct FutureWaitInfo
{
    public Future Future = new();
    public WebGPUBool Completed = new();

    public FutureWaitInfo() { }

}
