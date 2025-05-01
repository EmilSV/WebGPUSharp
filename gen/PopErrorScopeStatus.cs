using System;
using System.Runtime.InteropServices;

namespace WebGpuSharp;

public enum PopErrorScopeStatus
{
    Success = 1,
    CallbackCancelled = 2,
    Error = 3,
}
