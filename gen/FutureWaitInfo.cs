using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public partial struct FutureWaitInfo
{
    public Future Future;
    public WebGPUBool Completed;

    public FutureWaitInfo()
    {
    }

}
